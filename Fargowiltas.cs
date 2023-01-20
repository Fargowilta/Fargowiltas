using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Fargowiltas.Projectiles;
using Fargowilta;
using Fargowiltas.Items.CaughtNPCs;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.RuntimeDetour.HookGen;
using Terraria.DataStructures;
using Terraria.UI;
using Terraria.Chat;
using Fargowiltas.Items.Vanity;

namespace Fargowiltas
{
    public class Fargowiltas : Mod
    {
        internal static MutantSummonTracker summonTracker;
        internal static DevianttDialogueTracker dialogueTracker;

        // Hotkeys
        internal static ModKeybind CustomKey;
        internal static ModKeybind HomeKey;
        internal static ModKeybind RodKey;

        internal static ModKeybind StatKey;

        public static UIManager UserInterfaceManager => Instance._userInterfaceManager;
        private UIManager _userInterfaceManager;

        // Swarms
        internal static bool SwarmActive;
        internal static int SwarmKills;
        internal static int SwarmTotal;
        internal static int SwarmSpawned;

        // Mod loaded bools
        internal static Dictionary<string, bool> ModLoaded;
        internal static Dictionary<int, string> ModRareEnemies = new Dictionary<int, string>();
        private string[] mods;

        internal static Fargowiltas Instance;

        public override uint ExtraPlayerBuffSlots => ModContent.GetInstance<FargoConfig>().ExtraBuffSlots;

        public Fargowiltas()
        {
//            Properties = new ModProperties()
//            {
//                Autoload = true,
//                AutoloadGores = true,
//                AutoloadSounds = true,
//            }; 
//            HookIntoLoad();
        }

        public void AddToggle(String toggle, String name, int item, String color)
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(toggle);
            text.SetDefault("[i:" + item + "] [c/" + color + ":" + name + "]");

            LocalizationLoader.AddTranslation(text);
        }

        public override void Load()
        {
            Instance = this;

            summonTracker = new MutantSummonTracker();
            dialogueTracker = new DevianttDialogueTracker();
            dialogueTracker.AddVanillaDialogue();

            HomeKey = KeybindLoader.RegisterKeybind(this, "Quick Recall/Mirror", "Home");
            RodKey = KeybindLoader.RegisterKeybind(this, "Quick Rod of Discord", "E");
            CustomKey = KeybindLoader.RegisterKeybind(this, "Quick Use Custom (Bottom Left Inventory Slot)", "K");

            StatKey = KeybindLoader.RegisterKeybind(this, "Open Stat Sheet", "M");

            _userInterfaceManager = new UIManager();
            _userInterfaceManager.LoadUI();

            mods = new string[]
            {
                "FargowiltasSouls", // Fargo's Souls
                "FargowiltasSoulsDLC",
                "ThoriumMod",
                "CalamityMod",
                "MagicStorage"
            };

            ModLoaded = new Dictionary<string, bool>();
            foreach (string mod in mods)
            {
                ModLoaded.Add(mod, false);
            }

            AddToggle("Mods.Fargowiltas.Config.Mutant", "{$Mods.Fargowiltas.NPCName.Mutant} {$Mods.Fargowiltas.Config.CanSpawn}", ModContent.ItemType<MutantMask>(), "ffffff");
            AddToggle("Mods.Fargowiltas.Config.Abom", "{$Mods.Fargowiltas.NPCName.Abominationn} {$Mods.Fargowiltas.Config.CanSpawn}", ModContent.ItemType<AbominationnMask>(), "ffffff");
            AddToggle("Mods.Fargowiltas.Config.Devi", "{$Mods.Fargowiltas.NPCName.Deviantt} {$Mods.Fargowiltas.Config.CanSpawn}", ModContent.ItemType<DevianttMask>(), "ffffff");
            AddToggle("Mods.Fargowiltas.Config.Lumber", "{$Mods.Fargowiltas.NPCName.LumberJack} {$Mods.Fargowiltas.Config.CanSpawn}", ModContent.ItemType<LumberjackMask>(), "ffffff");
            AddToggle("Mods.Fargowiltas.Config.Squirrel", "{$Mods.Fargowiltas.NPCName.Squirrel} {$Mods.Fargowiltas.Config.CanSpawn}", ItemID.TopHat, "ffffff");

            CaughtNPCItem.RegisterItems(this);

            // DD2 Banner Effect hack
            ItemID.Sets.BannerStrength = ItemID.Sets.Factory.CreateCustomSet(new ItemID.BannerEffect(1f));
            
            On.Terraria.Recipe.FindRecipes += FindRecipes_ElementalAssemblerGraveyardHack;
        }

        private static void FindRecipes_ElementalAssemblerGraveyardHack(
            On.Terraria.Recipe.orig_FindRecipes orig,
            bool canDelayCheck)
        {
            bool oldZoneGraveyard = Main.LocalPlayer.ZoneGraveyard;

            if (!Main.gameMenu && Main.LocalPlayer.active && Main.LocalPlayer.GetModPlayer<FargoPlayer>().ElementalAssemblerNearby > 0)
                Main.LocalPlayer.ZoneGraveyard = true;

            orig(canDelayCheck);

            Main.LocalPlayer.ZoneGraveyard = oldZoneGraveyard;
        }

        public override void Unload()
        {
            summonTracker = null;
            dialogueTracker = null;

            HomeKey = null;
            RodKey = null;
            CustomKey = null;
            StatKey = null;
            mods = null;
            ModLoaded = null;

            Instance = null;
        }

        public override void PostSetupContent()
        {
            try
            {
                foreach (string mod in mods)
                {
                    ModLoaded[mod] = ModLoader.TryGetMod(mod, out Mod otherMod);
                }
            }
            catch (Exception e)
            {
                Logger.Error("Fargowiltas PostSetupContent Error: " + e.StackTrace + e.Message);
            }

            //            Mod censusMod = ModLoader.GetMod("Census");
            //            if (censusMod != null)
            //            {
            //                censusMod.Call("TownNPCCondition", NPCType("Deviantt"), "Defeat any rare enemy or... embrace eternity");
            //                censusMod.Call("TownNPCCondition", NPCType("Mutant"), "Defeat any boss or miniboss");
            //                censusMod.Call("TownNPCCondition", NPCType("LumberJack"), $"Chop down enough trees");
            //                censusMod.Call("TownNPCCondition", NPCType("Abominationn"), "Clear any event");
            //                Mod fargoSouls = ModLoader.GetMod("FargowiltasSouls");
            //                if (fargoSouls != null)
            //                {
            //                    censusMod.Call("TownNPCCondition", NPCType("Squirrel"), $"Have a Top Hat Squirrel ([i:{fargoSouls.ItemType("TophatSquirrel")}]) in your inventory");
            //                }
            //            }

            //foreach (KeyValuePair<int, int> npc in CaughtNPCItem.CaughtTownies)
            //    Main.RegisterItemAnimation(npc.Key, new DrawAnimationVertical(6, Main.npcFrameCount[npc.Value]));

            //            /*Mod soulsMod = ModLoader.GetMod("FargowiltasSouls");
            //            if (soulsMod != null)
            //            {
            //                if (!ModRareEnemies.ContainsKey(soulsMod.NPCType("BabyGuardian")))
            //                    ModRareEnemies.Add(soulsMod.NPCType("BabyGuardian"), "babyGuardian");
            //            }*/
        }

        public override object Call(params object[] args)
        {
            try
            {
                string code = args[0].ToString();

                switch (code)
                {
                    //case "DebuffDisplay":
                    //    ModContent.GetInstance<FargoConfig>().DebuffDisplay = (bool)args[1];
                    //    break;

                    case "SwarmActive":
                        return SwarmActive;

                    case "AddSummon":
                        {
                            if (summonTracker.SummonsFinalized)
                                throw new Exception($"Call Error: Summons must be added before AddRecipes");
                            
                            int itemId;
                            int funcIndex;
                            if (args[2].GetType() == typeof(string))
                            {
                                //Logger.Warn("Fargowiltas: You should provide the summon item ID instead of strings (mod name) and (item name)!");
                                itemId = ModContent.Find<ModItem>(Convert.ToString(args[2]), Convert.ToString(args[3])).Type;
                                funcIndex = 4;
                            }
                            else
                            {
                                itemId = Convert.ToInt32(args[2]);
                                funcIndex = 3;
                            }

                            summonTracker.AddSummon(
                                Convert.ToSingle(args[1]),
                                itemId,
                                args[funcIndex] as Func<bool>,
                                Convert.ToInt32(args[funcIndex + 1])
                            );
                        }
                        break;

                    //                    case "AddEventSummon":
                    //                        if (summonTracker.SummonsFinalized)
                    //                            throw new Exception($"Call Error: Event summons must be added before AddRecipes");

                    //                        summonTracker.AddEventSummon(
                    //                            Convert.ToSingle(args[1]),
                    //                            args[2] as string,
                    //                            args[3] as string,
                    //                            args[4] as Func<bool>,
                    //                            Convert.ToInt32(args[5])
                    //                        );
                    //                        break;

                    //                    case "GetDownedEnemy":
                    //                        if (FargoWorld.DownedBools.ContainsKey(args[1] as string) && FargoWorld.DownedBools[args[1] as string])
                    //                            return true;
                    //                        return false;
                    case "AddDevianttHelpDialogue":
                        dialogueTracker.AddDialogue(
                            args[1] as string,
                            (byte)args[2],
                            args[3] as Predicate<string>
                        );
                        break;

                    case "LowRenderProj":
                        ((Projectile)args[1]).GetGlobalProjectile<FargoGlobalProjectile>().lowRender = true;
                        break;
                }

            }
            catch (Exception e)
            {
                Logger.Error("Call Error: " + e.StackTrace + e.Message);
            }

            return base.Call(args);
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte messageType = reader.ReadByte();

            switch (messageType)
            {
                // Regal statue
                case 1:
                    FargoWorld.CurrentSpawnRateTile[whoAmI] = reader.ReadBoolean();
                    break;

                // Abominationn clear events
                case 2:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        if (IsEventOccurring)
                        {
                            TryClearEvents();
                            NetMessage.SendData(MessageID.WorldData);
                        }
                    }

                    break;

                // Angler reset
                case 3:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        Main.AnglerQuestSwap();
                    }
                    break;

                // Sync npc max life
                case 4:
                    {
                        int n = reader.ReadInt32();
                        int lifeMax = reader.ReadInt32();
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            Main.npc[n].lifeMax = lifeMax;
                    }
                    break;

                // Kill super dummies
                case 5:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<NPCs.SuperDummy>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);

                                if (Main.netMode == NetmodeID.Server)
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, i);
                            }
                        }
                    }
                    break;

                    //client requested server to update world
                case 6:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                    break;

                    //client requested server to broadcast battle cry message
                case 7:
                    {
                        bool isBattle = reader.ReadBoolean();
                        int p = reader.ReadInt32();
                        bool cry = reader.ReadBoolean();
                        BattleCry.GenerateText(isBattle, Main.player[p], cry);
                    }
                    break;

                    //client sync battle cry states to others
                case 8:
                    {
                        int p = reader.ReadInt32();
                        Main.player[p].GetModPlayer<FargoPlayer>().BattleCry = reader.ReadBoolean();
                        Main.player[p].GetModPlayer<FargoPlayer>().CalmingCry = reader.ReadBoolean();
                    }
                    break;

                default:
                    break;
            }
        }

        internal static bool IsEventOccurring =>
            Main.invasionType != 0
            || Main.pumpkinMoon
            || Main.snowMoon
            || Main.eclipse
            || Main.bloodMoon
            || Main.WindyEnoughForKiteDrops
            || Main.IsItRaining
            || Main.IsItStorming
            || Main.slimeRain
            || BirthdayParty.PartyIsUp
            || DD2Event.Ongoing
            || Sandstorm.Happening
            || (NPC.downedTowers && (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0));

        internal static bool TryClearEvents()
        {
            bool canClearEvent = FargoWorld.AbomClearCD <= 0;
            if (canClearEvent)
            {
                if (Main.invasionType != 0)
                {
                    Main.invasionType = 0;
                    FargoUtils.PrintText("The invaders have left!", 175, 75, 255);
                }

                if (Main.pumpkinMoon)
                {
                    Main.pumpkinMoon = false;
                    FargoUtils.PrintText("The Pumpkin Moon is lowering...", 175, 75, 255);
                }

                if (Main.snowMoon)
                {
                    Main.snowMoon = false;
                    FargoUtils.PrintText("The Frost Moon is lowering...", 175, 75, 255);
                }

                if (Main.eclipse)
                {
                    Main.eclipse = false;
                    FargoUtils.PrintText("A solar eclipse is not happening!", 175, 75, 255);
                }

                if (Main.bloodMoon)
                {
                    Main.bloodMoon = false;
                    FargoUtils.PrintText("The blood moon is descending...", 175, 75, 255);
                }

                if (Main.WindyEnoughForKiteDrops)
                {
                    Main.windSpeedTarget = 0;
                    Main.windSpeedCurrent = 0;
                    FargoUtils.PrintText("The wind has ended!", 175, 75, 255);
                }

                if (Main.slimeRain)
                {
                    Main.StopSlimeRain();
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                }

                if (BirthdayParty.PartyIsUp)
                    BirthdayParty.CheckNight();

                if (DD2Event.Ongoing && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    DD2Event.StopInvasion();
                    FargoUtils.PrintText("The Old One's Army is leaving!", 175, 75, 255);
                }

                if (Sandstorm.Happening)
                {
                    Sandstorm.Happening = false;
                    Sandstorm.TimeLeft = 0;
                    Sandstorm.IntendedSeverity = 0;
                    FargoUtils.PrintText("The sandstorm has ended!", 175, 75, 255);
                }

                if (NPC.downedTowers && (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0))
                {
                    NPC.LunarApocalypseIsUp = false;
                    NPC.ShieldStrengthTowerNebula = 0;
                    NPC.ShieldStrengthTowerSolar = 0;
                    NPC.ShieldStrengthTowerStardust = 0;
                    NPC.ShieldStrengthTowerVortex = 0;

                    // Purge all towers
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        if (Main.npc[i].active
                            && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar
                            || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                        {
                            Main.npc[i].dontTakeDamage = false;
                            Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().NoLoot = true;
                            Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0f, 0);
                        }
                    }
                    FargoUtils.PrintText("Celestial creatures are not invading!", 175, 75, 255);
                }

                if (Main.IsItRaining || Main.IsItStorming)
                {
                    Main.StopRain();
                    Main.cloudAlpha = 0;
                    if (Main.netMode == NetmodeID.Server)
                        Main.SyncRain();
                    FargoUtils.PrintText("The rain has ended!", 175, 75, 255);
                }

                FargoWorld.AbomClearCD = 7200;
            }

            //foreach (MutantSummonInfo summon in summonTracker.EventSummons)
            //{
            //    if ((bool)ModLoader.GetMod(summon.modSource).Call("AbominationnClearEvents", canClearEvent))
            //    {
            //        eventOccurring = true;
            //    }
            //}

            return canClearEvent;
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, 0, 0, "DerpyBoi 2", false);
        internal static void SpawnBoss(Player player, int bossType, bool spawnMessage = true, int overrideDirection = 0, int overrideDirectionY = 0, string overrideDisplayName = "", bool namePlural = false)
        {
            if (overrideDirection == 0)
            {
                overrideDirection = Main.rand.NextBool(2) ? -1 : 1;
            }

            if (overrideDirectionY == 0)
            {
                overrideDirectionY = -1;
            }

            Vector2 npcCenter = player.Center + new Vector2(MathHelper.Lerp(500f, 800f, (float)Main.rand.NextDouble()) * overrideDirection, 800f * overrideDirectionY);
            SpawnBoss(player, bossType, spawnMessage, npcCenter, overrideDisplayName, namePlural);
        }

        // SpawnBoss(player, mod.NPCType("MyBoss"), true, player.Center + new Vector2(0, 800f), "DerpFromBelow", false);
        internal static int SpawnBoss(Player player, int bossType, bool spawnMessage = true, Vector2 npcCenter = default, string overrideDisplayName = "", bool namePlural = false)
        {
            if (npcCenter == default)
            {
                npcCenter = player.Center;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int npcID = NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)npcCenter.X, (int)npcCenter.Y, bossType);
                Main.npc[npcID].Center = npcCenter;
                Main.npc[npcID].netUpdate2 = true;

                if (spawnMessage)
                {
                    string npcName = !string.IsNullOrEmpty(Main.npc[npcID].GivenName) ? Main.npc[npcID].GivenName : overrideDisplayName;
                    //if ((npcName == null || string.IsNullOrEmpty(npcName)) && Main.npc[npcID].modNPC != null)
                    //{
                    //    npcName = Main.npc[npcID].modNPC.DisplayName.GetDefault();
                    //}

                    if (namePlural)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText(npcName + " have awoken!", 175, 75);
                        }
                        else
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(npcName + " have awoken!"), new Color(175, 75, 255));
                        }
                    }
                    else
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText(Language.GetTextValue("Announcement.HasAwoken", npcName), 175, 75);
                        }
                        else
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[] { NetworkText.FromLiteral(npcName) }), new Color(175, 75, 255));
                        }
                    }
                }
            }
            else
            {
                // I have no idea how to convert this to the standard system so im gonna post this method too lol
                FargoNet.SendNetMessage(FargoNet.SummonNPCFromClient, (byte)player.whoAmI, (short)bossType, spawnMessage, npcCenter.X, npcCenter.Y, overrideDisplayName, namePlural);
            }

            return 200;
        }

        //        private static void HookIntoLoad()
        //        {
        //            MonoModHooks.RequestNativeAccess();
        //            new Hook(
        //                typeof(ModContent).GetMethod("LoadModContent", BindingFlags.NonPublic | BindingFlags.Static),
        //                typeof(Fargowiltas).GetMethod(nameof(LoadHook), BindingFlags.NonPublic | BindingFlags.Static)).Apply();

        //            HookEndpointManager.Modify(
        //                typeof(ModContent).GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Static),
        //                Delegate.CreateDelegate(typeof(ILContext.Manipulator),
        //                    typeof(Fargowiltas).GetMethod(nameof(ModifyLoading),
        //                        BindingFlags.NonPublic | BindingFlags.Static) ?? throw new Exception("Couldn't create IL manipulator.")));
        //        }

        //        private static void ModifyLoading(ILContext il)
        //        {
        //            ILCursor c = new ILCursor(il);

        //            c.GotoNext(x => x.MatchCall(typeof(ModContent), "ResizeArrays"));
        //            c.Index++;

        //            c.EmitDelegate<Action>(() =>
        //            {
        //                FieldInfo loadInfo = typeof(Mod).GetField("loading", BindingFlags.Instance | BindingFlags.NonPublic);
        //                loadInfo?.SetValue(ModLoader.GetMod("Fargowiltas"), true);

        //                /*foreach (Mod mod in ModLoader.Mods.Where(x => x != ModLoader.GetMod("Fargowiltas")))
        //                {
        //                    foreach (ModNPC npc in (typeof(Mod).GetField("npcs", BindingFlags.Instance | BindingFlags.NonPublic)
        //                        ?.GetValue(mod) as IDictionary<string, ModNPC>)?.Values ?? new ModNPC[0])
        //                    {
        //                        try
        //                        {
        //                            npc.SetDefaults();

        //                            if (npc.npc.townNPC)
        //                                CaughtNPCItem.AddAutomatic(npc.Name, npc.npc.type);
        //                        }
        //                        catch
        //                        {
        //                            // ignore
        //                        }
        //                    }
        //                }*/
        //                loadInfo?.SetValue(ModLoader.GetMod("Fargowiltas"), false);

        //                typeof(ModContent).GetMethod("ResizeArrays", BindingFlags.NonPublic | BindingFlags.Static)?
        //                    .Invoke(null, new object[] {false});
        //            });
        //        }

        //        private static void LoadHook(Action<CancellationToken, Action<Mod>> orig, CancellationToken token,
        //            Action<Mod> loadAction)
        //        {
        //            PropertyInfo modsArray = typeof(ModLoader).GetProperty("Mods", BindingFlags.Public | BindingFlags.Static);

        //            if (modsArray is null)
        //            {
        //                orig(token, loadAction);
        //                return;
        //            }

        //            // Mod[] cachedArray = modsArray.GetValue(null) as Mod[];
        //            List<Mod> tempMods = (modsArray.GetValue(null) as Mod[])?.ToList();

        //            if (tempMods is null)
        //            {
        //                orig(token, loadAction);
        //                return;
        //            }

        //            Mod mod = tempMods.First(x => x.Name.Equals("Fargowiltas"));
        //            tempMods.Remove(mod);
        //            tempMods.Add(mod);
        //            modsArray.SetValue(null, tempMods.ToArray());

        //            orig(token, loadAction);

        //            // modsArray.SetValue(null, cachedArray);
        //        }
    }
}