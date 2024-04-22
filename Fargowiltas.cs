﻿using Fargowilta;
using Fargowiltas.Common.Configs;
using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Fargowiltas.NPCs;
using Fargowiltas.Projectiles;
using Fargowiltas.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Fargowiltas.FargoSets;

namespace Fargowiltas
{
    public class Fargowiltas : Mod
    {
        internal static MutantSummonTracker summonTracker;
        internal static DevianttDialogueTracker dialogueTracker;

        // Hotkeys
        public static ModKeybind HomeKey;

        public static ModKeybind StatKey;

        public static ModKeybind DashKey;

        public static ModKeybind SetBonusKey;

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

        public List<StatSheetUI.Stat> ModStats;
        public List<StatSheetUI.PermaUpgrade> PermaUpgrades;

        private string[] mods;

        internal static Fargowiltas Instance;

        public override uint ExtraPlayerBuffSlots => FargoServerConfig.Instance.ExtraBuffSlots;

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


        public override void Load()
        {
            Instance = this;

            ModStats = new();
            PermaUpgrades = new List<StatSheetUI.PermaUpgrade>
            {
                new(ContentSamples.ItemsByType[ItemID.AegisCrystal], () => Main.LocalPlayer.usedAegisCrystal),
                new(ContentSamples.ItemsByType[ItemID.AegisFruit], () => Main.LocalPlayer.usedAegisFruit),
                new(ContentSamples.ItemsByType[ItemID.ArcaneCrystal], () => Main.LocalPlayer.usedArcaneCrystal),
                new(ContentSamples.ItemsByType[ItemID.Ambrosia], () => Main.LocalPlayer.usedAmbrosia),
                new(ContentSamples.ItemsByType[ItemID.GummyWorm], () => Main.LocalPlayer.usedGummyWorm),
                new(ContentSamples.ItemsByType[ItemID.GalaxyPearl], () => Main.LocalPlayer.usedGalaxyPearl)
            };

            summonTracker = new MutantSummonTracker();
            dialogueTracker = new DevianttDialogueTracker();
            dialogueTracker.AddVanillaDialogue();

            HomeKey = KeybindLoader.RegisterKeybind(this, "Home", "Home");

            StatKey = KeybindLoader.RegisterKeybind(this, "Stat", "RightShift");

            DashKey = KeybindLoader.RegisterKeybind(this, "Dash", "C");

            SetBonusKey = KeybindLoader.RegisterKeybind(this, "SetBonus", "V");

            _userInterfaceManager = new UIManager();
            _userInterfaceManager.LoadUI();

            mods = new string[]
            {
                "FargowiltasSouls", // Fargo's Souls
                "FargowiltasSoulsDLC",
                "ThoriumMod",
                "CalamityMod",
                "MagicStorage",
                "WikiThis"
            };

            ModLoaded = new Dictionary<string, bool>();
            foreach (string mod in mods)
            {
                ModLoaded.Add(mod, false);
            }
            CaughtNPCItem.RegisterItems();

            // DD2 Banner Effect hack
            ItemID.Sets.BannerStrength = ItemID.Sets.Factory.CreateCustomSet(new ItemID.BannerEffect(1f));

            Terraria.On_Player.DoCommonDashHandle += OnVanillaDash;
            Terraria.On_Player.KeyDoubleTap += OnVanillaDoubleTapSetBonus;
            Terraria.On_Player.KeyHoldDown += OnVanillaHoldSetBonus;

            Terraria.On_Recipe.FindRecipes += FindRecipes_ElementalAssemblerGraveyardHack;
            Terraria.On_WorldGen.CountTileTypesInArea += CountTileTypesInArea_PurityTotemHack;
            Terraria.On_SceneMetrics.ExportTileCountsToMain += ExportTileCountsToMain_PurityTotemHack;
            Terraria.On_Player.HasUnityPotion += OnHasUnityPotion;
            Terraria.On_Player.TakeUnityPotion += OnTakeUnityPotion;
        }

        private static IEnumerable<Item> GetWormholes(Player self) =>
            self.inventory
                .Concat(self.bank.item)
                .Concat(self.bank2.item)
                .Where(x => x.type == ItemID.WormholePotion);

        private static void OnTakeUnityPotion(Terraria.On_Player.orig_TakeUnityPotion orig, Player self)
        {
            var wormholes = GetWormholes(self).ToList();

            if (
                FargoServerConfig.Instance.UnlimitedPotionBuffsOn120
                && wormholes.Select(x => x.stack).Sum() >= 30
            )
            {
                return;
            }

            // Can't be empty as we're gated by HasUnityPotion
            Item pot = wormholes.First();

            pot.stack -= 1;

            if (pot.stack <= 0)
                pot.SetDefaults(0, false);
        }

        private static bool OnHasUnityPotion(Terraria.On_Player.orig_HasUnityPotion orig, Player self)
        {
            return GetWormholes(self).Select(x => x.stack).Sum() > 0;
        }

        private static void FindRecipes_ElementalAssemblerGraveyardHack(
            Terraria.On_Recipe.orig_FindRecipes orig,
            bool canDelayCheck)
        {
            bool oldZoneGraveyard = Main.LocalPlayer.ZoneGraveyard;

            if (!Main.gameMenu && Main.LocalPlayer.active && Main.LocalPlayer.GetModPlayer<FargoPlayer>().ElementalAssemblerNearby > 0)
                Main.LocalPlayer.ZoneGraveyard = true;

            orig(canDelayCheck);

            Main.LocalPlayer.ZoneGraveyard = oldZoneGraveyard;
        }

        //for town npc housing check, independent from player biome
        private static void CountTileTypesInArea_PurityTotemHack(
            Terraria.On_WorldGen.orig_CountTileTypesInArea orig,
            int[] tileTypeCounts, int startX, int endX, int startY, int endY)
        {
            orig(tileTypeCounts, startX, endX, startY, endY);

            if (tileTypeCounts[ModContent.TileType<PurityTotemSheet>()] > 0)
            {
                const int sunflowerWeight = 5;
                tileTypeCounts[TileID.Sunflower] += PurityTotemSheet.TILES_NEGATED / sunflowerWeight;
            }
        }

        //for current biome
        private void ExportTileCountsToMain_PurityTotemHack(
            Terraria.On_SceneMetrics.orig_ExportTileCountsToMain orig,
            SceneMetrics self)
        {
            orig(self);

            //for visible biome effect
            if (self.GetTileCount((ushort)ModContent.TileType<PurityTotemSheet>()) > 0)
            {
                const int tilesNegated = PurityTotemSheet.TILES_NEGATED;

                //reduce biome counts, floor at zero
                self.BloodTileCount = Math.Max(self.BloodTileCount - tilesNegated, 0);
                self.EvilTileCount = Math.Max(self.EvilTileCount - tilesNegated, 0);
                self.GraveyardTileCount = Math.Max(self.GraveyardTileCount - tilesNegated, 0);

                //reenable if disabled by graveyard
                if (self.GetTileCount(TileID.Sunflower) > 0)
                    self.HasSunflower = true;
            }
        }

        public override void Unload()
        {
            Terraria.On_Player.DoCommonDashHandle -= OnVanillaDash;
            Terraria.On_Player.KeyDoubleTap -= OnVanillaDoubleTapSetBonus;
            Terraria.On_Player.KeyHoldDown -= OnVanillaHoldSetBonus;

            Terraria.On_Recipe.FindRecipes -= FindRecipes_ElementalAssemblerGraveyardHack;
            Terraria.On_WorldGen.CountTileTypesInArea -= CountTileTypesInArea_PurityTotemHack;
            Terraria.On_SceneMetrics.ExportTileCountsToMain -= ExportTileCountsToMain_PurityTotemHack;
            Terraria.On_Player.HasUnityPotion -= OnHasUnityPotion;
            Terraria.On_Player.TakeUnityPotion -= OnTakeUnityPotion;

            summonTracker = null;
            dialogueTracker = null;

            HomeKey = null;
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

            if (ModLoader.TryGetMod("Wikithis", out Mod wikithis) && !Main.dedServ)
            {
                wikithis.Call("AddModURL", this, "https://fargosmods.wiki.gg/wiki/{}");

                // You can also use call ID for some calls!
                //wikithis.Call(0, this, "https://examplemod.wiki.gg/wiki/{}");

                // Alternatively, you can use this instead, if your wiki is on terrariamods.fandom.com
                //wikithis.Call(0, this, "https://terrariamods.fandom.com/wiki/Example_Mod/{}");
                //wikithis.Call("AddModURL", this, "https://terrariamods.fandom.com/wiki/Example_Mod/{}");

                // If there wiki on other languages (such as russian, spanish, chinese, etch), then you can also call that:
                //wikithis.Call(0, this, "https://examplemod.wiki.gg/zh/wiki/{}", GameCulture.CultureName.Chinese)

                // If you want to replace default icon for your mod, then call this. Icon should be 30x30, either way it will be cut.
                //wikithis.Call("AddWikiTexture", this, ModContent.Request<Texture2D>(pathToIcon));
                //wikithis.Call(3, this, ModContent.Request<Texture2D>(pathToIcon));
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
                    case "AddIndestructibleRectangle":
                        {
                            if (args[1].GetType() == typeof(Rectangle))
                            {
                                Rectangle rectangle = (Rectangle)args[1];
                                FargoGlobalProjectile.CannotDestroyRectangle.Add(rectangle);
                            }
                        }
                        break;
                    case "AddIndestructibleTileType":
                        {
                            if (args[1].GetType() == typeof(int))
                            {
                                int tile = (int)args[1];
                                FargoSets.Tiles.InstaCannotDestroy[tile] = true;
                            }
                        }
                        break;
                    case "AddIndestructibleWallType":
                        {
                            if (args[1].GetType() == typeof(int))
                            {
                                int wall = (int)args[1];
                                FargoSets.Walls.InstaCannotDestroy[wall] = true;
                            }
                        }
                        break;
                    case "AddStat":
                        {
                            if (args[1].GetType() != typeof(int))
                                throw new Exception($"Call Error (Fargo Mutant Mod AddStat): args[1] must be of type int");
                            if (args[2].GetType() != typeof(Func<string>))
                                throw new Exception($"Call Error (Fargo Mutant Mod AddStat): args[2] must be of type Func<string>");

                            int itemID = (int)args[1];
                            Func<string> TextFunction = (Func<string>)args[2];
                            ModStats.Add(new StatSheetUI.Stat(itemID, TextFunction));
                        }
                        break;
                    case "AddPermaUpgrade":
                        {
                            if (args[1].GetType() != typeof(Item))
                                throw new Exception($"Call Error (Fargo Mutant Mod AddStat): args[1] must be of type Item");
                            if (args[2].GetType() != typeof(Func<bool>))
                                throw new Exception($"Call Error (Fargo Mutant Mod AddStat): args[2] must be of type Func<bool>");

                            Item item = (Item)args[1];
                            Func<bool> ConsumedFunction = (Func<bool>)args[2];
                            PermaUpgrades.Add(new StatSheetUI.PermaUpgrade(item, ConsumedFunction));
                        }
                        break;
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
                        if (args[4].GetType() == typeof(string) && args[4].ToString().Length > 0)
                            dialogueTracker.AddDialogue(args[1] as string, (byte)args[2], args[3] as Predicate<string>, args[4] as string);
                        else
                            dialogueTracker.AddDialogue(args[1] as string, (byte)args[2], args[3] as Predicate<string>);

                        break;

                    case "LowRenderProj":
                        ((Projectile)args[1]).GetGlobalProjectile<FargoGlobalProjectile>().lowRender = true;
                        break;

                    case "DoubleTapDashDisabled":
                        return FargoClientConfig.Instance.DoubleTapDashDisabled;
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
                case 0:
                    FargoNet.HandlePacket(reader, messageType);
                    break;
                // Regal statue
                case 1:
                    {
                        if (whoAmI >= 0 && whoAmI < FargoWorld.CurrentSpawnRateTile.Length)
                        {
                            FargoWorld.CurrentSpawnRateTile[whoAmI] = reader.ReadBoolean();
                        }                        
                    }
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
                        if (Main.netMode == NetmodeID.MultiplayerClient && n >= 0 && n < Main.maxNPCs)
                            Main.npc[n].lifeMax = lifeMax;
                    }
                    break;

                // Kill super dummies
                case 5:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i] != null && Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<NPCs.SuperDummy>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                Main.npc[i].SimpleStrikeNPC(int.MaxValue, 0, false, 0, null, false, 0, true);
                                //Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);

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
                    FargoUtils.PrintLocalization("MessageInfo.CancelEvent", new Color(175, 75, 255));
                }

                if (Main.pumpkinMoon)
                {
                    Main.pumpkinMoon = false;
                    FargoUtils.PrintLocalization("MessageInfo.CancelPumpkinMoon", new Color(175, 75, 255));
                }

                if (Main.snowMoon)
                {
                    Main.snowMoon = false;
                    FargoUtils.PrintLocalization("MessageInfo.CancelFrostMoon", new Color(175, 75, 255));
                }

                if (Main.eclipse)
                {
                    Main.eclipse = false;
                    FargoUtils.PrintLocalization("MessageInfo.CancelEclipse", new Color(175, 75, 255));
                }

                if (Main.bloodMoon)
                {
                    Main.bloodMoon = false;
                    FargoUtils.PrintLocalization("MessageInfo.CancelBloodMoon", new Color(175, 75, 255));
                }

                if (Main.WindyEnoughForKiteDrops)
                {
                    Main.windSpeedTarget = 0;
                    Main.windSpeedCurrent = 0;
                    FargoUtils.PrintLocalization("MessageInfo.CancelWindyDay", new Color(175, 75, 255));
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
                    FargoUtils.PrintLocalization("MessageInfo.CancelOOA", new Color(175, 75, 255));
                }

                if (Sandstorm.Happening)
                {
                    Sandstorm.Happening = false;
                    Sandstorm.TimeLeft = 0;
                    Sandstorm.IntendedSeverity = 0;
                    FargoUtils.PrintLocalization("MessageInfo.CancelSandstorm", new Color(175, 75, 255));
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
                            Main.npc[i].StrikeInstantKill();
                            //Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0f, 0);
                        }
                    }
                    FargoUtils.PrintLocalization("MessageInfo.CancelLunarEvent", new Color(175, 75, 255));
                }

                if (Main.IsItRaining || Main.IsItStorming)
                {
                    Main.StopRain();
                    Main.cloudAlpha = 0;
                    if (Main.netMode == NetmodeID.Server)
                        Main.SyncRain();
                    FargoUtils.PrintLocalization("MessageInfo.CancelRain", new Color(175, 75, 255));
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
                            Main.NewText(Language.GetTextValue("Mods.Fargowiltas.MessageInfo.HaveAwoken", npcName), 175, 75);
                        }
                        else
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.Fargowiltas.MessageInfo.HaveAwoken", npcName), new Color(175, 75, 255));
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
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", npcName), new Color(175, 75, 255));
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
        private static void OnVanillaDash(Terraria.On_Player.orig_DoCommonDashHandle orig, Terraria.Player player, out int dir, out bool dashing, Player.DashStartAction dashStartAction)
        {
            if (FargoClientConfig.Instance.DoubleTapDashDisabled)
            {
                player.dashTime = 0;
                /*
                if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
                {
                    Main.NewText(calamity);
                    if (calamity.TryFind("CalamityPlayer", out ModPlayer modPlayer))
                    {
                        FieldInfo dashTimeMod = modPlayer.GetType().GetField("dashTimeMod");
                        Main.NewText(dashTimeMod.Name);
                        if (dashTimeMod != null)
                            dashTimeMod.SetValue(modPlayer, 0);
                    }
                }
                */
            }
                

            orig.Invoke(player, out dir, out dashing, dashStartAction);

            if (player.whoAmI == Main.myPlayer && DashKey.JustPressed && !player.CCed)
            {
                InputManager modPlayer = player.GetModPlayer<InputManager>();
                if (player.controlRight && player.controlLeft)
                {
                    dir = modPlayer.latestXDirPressed;
                }
                else if (player.controlRight)
                {
                    dir = 1;
                }
                else if (player.controlLeft)
                {
                    dir = -1;
                }
                if (dir == 0) // this + commented out below because changed to not have an effect when not holding any movement keys; primarily so it's affected by stun effects
                    return;
                //else if (modPlayer.latestXDirReleased != 0)
                //{
                //    dir = modPlayer.latestXDirReleased;
                //}
                //else
                //{
                //    dir = player.direction;
                //}
                player.direction = dir;
                dashing = true;
                if (player.dashTime > 0)
                {
                    player.dashTime--;
                }
                if (player.dashTime < 0)
                {
                    player.dashTime++;
                }
                if ((player.dashTime <= 0 && player.direction == -1) || (player.dashTime >= 0 && player.direction == 1))
                {
                    player.dashTime = 15;
                    return;
                }
                dashing = true;
                player.dashTime = 0;
                player.timeSinceLastDashStarted = 0;
                if (dashStartAction != null)
                    dashStartAction?.Invoke(dir);
            }

        }
        private static void OnVanillaDoubleTapSetBonus(On_Player.orig_KeyDoubleTap orig, Player player, int keyDir)
        {
            if (!FargoClientConfig.Instance.DoubleTapSetBonusDisabled || SetBonusKey.JustPressed)
            {
                orig.Invoke(player, keyDir);
            }
        }
        private static void OnVanillaHoldSetBonus(On_Player.orig_KeyHoldDown orig, Player player, int keyDir, int holdTime)
        {
            if (!FargoClientConfig.Instance.DoubleTapSetBonusDisabled || SetBonusKey.Current)
            {
                orig.Invoke(player, keyDir, holdTime);
            }
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

