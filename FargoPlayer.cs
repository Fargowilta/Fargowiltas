using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;
using System;
using System.Linq;
using Terraria.ModLoader.IO;
using Fargowiltas.Projectiles;
using Fargowiltas.Items;
using Terraria.GameContent.Events;

////using Fargowiltas.Toggler;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        //        //public ToggleBackend Toggler = new ToggleBackend();
        //        public Dictionary<string, bool> TogglesToSync = new Dictionary<string, bool>();



        public bool extractSpeed;
        public bool HasDrawnDebuffLayer;
        internal bool BattleCry;
        internal bool CalmingCry;

        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem;

        public float luckPotionBoost;
        public float ElementalAssemblerNearby;

        public float StatSheetMaxAscentMultiplier;
        public float StatSheetWingSpeed;
        public bool? CanHover = null;

        internal Dictionary<string, bool> FirstDyeIngredients = new Dictionary<string, bool>();

        private readonly string[] tags = new string[]
        {
            "RedHusk",
            "OrangeBloodroot",
            "YellowMarigold",
            "LimeKelp",
            "GreenMushroom",
            "TealMushroom",
            "CyanHusk",
            "SkyBlueFlower",
            "BlueBerries",
            "PurpleMucos",
            "VioletHusk",
            "PinkPricklyPear",
            "BlackInk"
        };

        public override void SaveData(TagCompound tag)
        {
            string name = "FargoDyes" + Player.name;
            List<string> dyes = new List<string>();

            foreach (string tagString in tags)
            {
                bool value;

                if (FirstDyeIngredients.TryGetValue(tagString, out value))
                {
                    dyes.AddWithCondition(tagString, FirstDyeIngredients[tagString]);
                }
                else
                {
                    dyes.AddWithCondition(tagString, false);
                }
            }

            tag.Add(name, dyes);

            if (BattleCry)
                tag.Add($"FargoBattleCry{Player.name}", true);

            if (CalmingCry)
                tag.Add($"FargoCalmingCry{Player.name}", true);
        }

        //        public override void Initialize()
        //        {
        //            //Toggler.Load(this);
        //        }

        public override void LoadData(TagCompound tag)
        {
            string name = "FargoDyes" + Player.name;

            IList<string> dyes = tag.GetList<string>(name);
            foreach (string downedTag in tags)
            {
                FirstDyeIngredients[downedTag] = dyes.Contains(downedTag);
            }

            BattleCry = tag.ContainsKey($"FargoBattleCry{Player.name}");
            CalmingCry = tag.ContainsKey($"FargoCalmingCry{Player.name}");
        }

        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            foreach (string tag in tags)
            {
                FirstDyeIngredients[tag] = false;
            }
        }

        public override void ResetEffects()
        {
            extractSpeed = false;
            HasDrawnDebuffLayer = false;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Fargowiltas.CustomKey.JustPressed)
            {
                QuickUseItemAt(40);
            }

            if (Fargowiltas.RodKey.JustPressed)
            {
                AutoUseRod();
            }

            if (Fargowiltas.HomeKey.JustPressed)
            {
                AutoUseMirror();
            }

            if (Fargowiltas.StatKey.JustPressed)
            {
                Fargowiltas.UserInterfaceManager.ToggleStatSheet();
            }
        }

        public override void PostUpdateBuffs()
        {
            if (GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120)
            {
                foreach (Item item in Player.bank.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }

                foreach (Item item in Player.bank2.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }

                foreach (Item item in Player.bank3.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }

                foreach (Item item in Player.bank4.item)
                {
                    FargoGlobalItem.TryUnlimBuff(item, Player);
                }
            }
        }

        public override void PostUpdateEquips()
        {
            FargoGlobalItem.ToolbeltEffectApplied = false;
            FargoGlobalItem.ToolboxEffectApplied = false;
            if (Fargowiltas.SwarmActive)
            {
                Player.buffImmune[BuffID.Horrified] = true;
            }

            if (GetInstance<FargoConfig>().PiggyBankAcc)
            {
                // This won't work in UpdateInventory, since the equippedAny buffs are set to false after UpdateInventory
                foreach (Item item in Player.inventory)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player, true);
                }

                foreach (Item item in Player.bank.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player, false);
                }

                foreach (Item item in Player.bank2.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player, false);
                }

                foreach (Item item in Player.bank3.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player, false);
                }

                foreach (Item item in Player.bank4.item)
                {
                    FargoGlobalItem.TryPiggyBankAcc(item, Player, false);
                }
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (ElementalAssemblerNearby > 0)
            {
                ElementalAssemblerNearby -= 1;
                Player.alchemyTable = true;
            }

            if (Player.equippedWings == null)
                ResetStatSheetWings();

            ForceBiomes();
        }

        public void ResetStatSheetWings()
        {
            StatSheetMaxAscentMultiplier = 0;
            StatSheetWingSpeed = 0;
            CanHover = null;
        }

        private void ForceBiomes()
        {
            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.eaterBoss, NPCID.EaterofWorldsHead)
                && Player.Distance(Main.npc[FargoGlobalNPC.eaterBoss].Center) < 3000)
            {
                Player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.brainBoss, NPCID.BrainofCthulhu)
                && Player.Distance(Main.npc[FargoGlobalNPC.brainBoss].Center) < 3000)
            {
                Player.ZoneCrimson = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.plantBoss, NPCID.Plantera)
                && Player.Distance(Main.npc[FargoGlobalNPC.plantBoss].Center) < 3000)
            {
                Player.ZoneJungle = true;
            }

            if (GetInstance<FargoConfig>().Fountains)
            {
                switch (Main.SceneMetrics.ActiveFountainColor)
                {
                    case -1: //no fountain active
                        goto default;

                    case 0: //pure water, ocean
                        Player.ZoneBeach = true;
                        break;

                    case 2: //corrupt
                        Player.ZoneCorrupt = true;
                        break;

                    case 3: //jungle
                        Player.ZoneJungle = true;
                        break;

                    case 4: //hallow
                        if (Main.hardMode)
                            Player.ZoneHallow = true;
                        break;

                    case 5: //ice
                        Player.ZoneSnow = true;
                        break;

                    case 6: //oasis
                        goto case 12;

                    case 8: //cavern
                        goto default;

                    case 9: //blood fountain
                        goto default;

                    case 10: //crimson
                        Player.ZoneCrimson = true;
                        break;

                    case 12: //desert fountain
                        Player.ZoneDesert = true;
                        if (Player.Center.Y > 3200f)
                            Player.ZoneUndergroundDesert = true;
                        break;

                    default:
                        break;
                }
            }
        }

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (Player.itemTime == 0 && Player.itemAnimation == 0)
                {
                    Player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }

            if (FargoWorld.OverloadedSlimeRain && Main.rand.Next(20) == 0)
            {
                SlimeRainSpawns();
            }
        }

        public void SlimeRainSpawns()
        {
            int type = NPCID.GreenSlime;

            int[] slimes = { NPCID.SlimeSpiked, NPCID.SandSlime, NPCID.IceSlime, NPCID.SpikedIceSlime, NPCID.MotherSlime, NPCID.SpikedJungleSlime, NPCID.DungeonSlime, NPCID.UmbrellaSlime, NPCID.ToxicSludge, NPCID.CorruptSlime, NPCID.Crimslime, NPCID.IlluminantSlime };

            int rand = Main.rand.Next(50);

            if (rand == 0)
            {
                type = NPCID.Pinky;
            }
            else if (rand < 20)
            {
                type = slimes[Main.rand.Next(slimes.Length)];
            }

            Vector2 pos = new Vector2((int)Player.position.X + Main.rand.Next(-800, 800), (int)Player.position.Y + Main.rand.Next(-800, -250));

            //Projectile.NewProjectile( pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, type);
        }

        public override bool PreModifyLuck(ref float luck)
        {
            if (FargoWorld.Matsuri && !Main.IsItRaining && !Main.IsItStorming)
            {
                LanternNight.GenuineLanterns = true;
                LanternNight.ManualLanterns = false;
            }

            return base.PreModifyLuck(ref luck);
        }

        public override void ModifyLuck(ref float luck)
        {
            luck += luckPotionBoost;

            luckPotionBoost = 0; //look nowhere else works ok
        }

        public void AutoUseMirror()
        {
            int potionofReturn = -1;
            int recallPotion = -1;
            int magicMirror = -1;

            for (int i = 0; i < Player.inventory.Length; i++)
            {
                switch (Player.inventory[i].type)
                {
                    case ItemID.PotionOfReturn:
                        potionofReturn = i;
                        break;

                    case ItemID.RecallPotion:
                        recallPotion = i;
                        break;

                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                        magicMirror = i;
                        break;
                }
            }

            if (potionofReturn != -1)
                QuickUseItemAt(potionofReturn);
            else if (recallPotion != -1)
                QuickUseItemAt(recallPotion);
            else if (magicMirror != -1)
                QuickUseItemAt(magicMirror);
        }

        public void AutoUseRod()
        {
            for (int i = 0; i < Player.inventory.Length; i++)
            {
                if (Player.inventory[i].type == ItemID.RodofDiscord)
                {
                    QuickUseItemAt(i);
                    break;
                }
            }
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && Player.selectedItem != index && Player.inventory[index].type != 0)
            {
                originalSelectedItem = Player.selectedItem;
                autoRevertSelectedItem = true;
                Player.selectedItem = index;
                Player.controlUseItem = true;
                if (use)
                {
                    Player.ItemCheck(Main.myPlayer);
                }
            }
        }

        //        /*public override void clientClone(ModPlayer clientClone)
        //        {
        //            FargoPlayer modPlayer = clientClone as FargoPlayer;
        //            modPlayer.Toggler = Toggler;
        //        }*/

        //        /*public void SyncToggle(string key)
        //        {
        //            if (!TogglesToSync.ContainsKey(key))
        //                TogglesToSync.Add(key, player.GetToggle(key).ToggleBool);
        //        }*/

        //        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        //        {
        //            foreach (KeyValuePair<string, bool> toggle in TogglesToSync)
        //            {
        //                ModPacket packet = mod.GetPacket();

        //                packet.Write((byte)80);
        //                packet.Write((byte)player.whoAmI);
        //                packet.Write(toggle.Key);
        //                packet.Write(toggle.Value);

        //                packet.Send(toWho, fromWho);
        //            }

        //            TogglesToSync.Clear();
        //        }

        //        /*public override void SendClientChanges(ModPlayer clientPlayer)
        //        {
        //            FargoPlayer modPlayer = clientPlayer as FargoPlayer;
        //            if (modPlayer.Toggler.Toggles != Toggler.Toggles)
        //            {
        //                ModPacket packet = mod.GetPacket();
        //                packet.Write((byte)79);
        //                packet.Write((byte)player.whoAmI);
        //                packet.Write((byte)Toggler.Toggles.Count);

        //                for (int i = 0; i < Toggler.Toggles.Count; i++)
        //                {
        //                    packet.Write(Toggler.Toggles.Values.ElementAt(i).ToggleBool);
        //                }

        //                packet.Send();
        //            }
        //        }*/
    }
}
