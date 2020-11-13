using Fargowiltas.NPCs;
using Fargowiltas.Utilities;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        public bool battleCry;
        public int originalSelectedItem;
        public bool autoRevertSelectedItem = false;
        public Dictionary<string, bool> firstDyeIngredients = new Dictionary<string, bool>();

        private readonly string[] tags = new string[13]
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

        private int[] Informational = new int[23]
        {
            ItemID.CopperWatch,
            ItemID.TinWatch,
            ItemID.TungstenWatch,
            ItemID.SilverWatch,
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
            ItemID.DepthMeter,
            ItemID.Compass,
            ItemID.Radar,
            ItemID.LifeformAnalyzer,
            ItemID.TallyCounter,
            ItemID.MetalDetector,
            ItemID.Stopwatch,
            ItemID.DPSMeter,
            ItemID.FishermansGuide,
            ItemID.Sextant,
            ItemID.WeatherRadio,
            ItemID.GPS,
            ItemID.REK,
            ItemID.GoblinTech,
            ItemID.FishFinder,
            ItemID.PDA,
            ItemID.CellPhone
        };

        public override TagCompound Save()
        {
            string name = "FargoDyes" + player.name;
            List<string> dyes = new List<string>();

            foreach (string tag in tags)
            {
                if (firstDyeIngredients.TryGetValue(tag, out bool _))
                {
                    dyes.AddWithCondition(tag, firstDyeIngredients[tag]);
                }
                else
                {
                    dyes.AddWithCondition(tag, false);
                }
            }

            return new TagCompound
            {
                { name, dyes },
            };
        }

        public override void Load(TagCompound tag)
        {
            string name = "FargoDyes" + player.name;
            IList<string> dyes = tag.GetList<string>(name);

            foreach (string downedTag in tags)
            {
                firstDyeIngredients[downedTag] = dyes.Contains(downedTag);
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            foreach (string tag in tags)
            {
                firstDyeIngredients[tag] = false;
            }

            return new[] { new Item(ModContent.ItemType<Items.Misc.Stats>()) };
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Fargowiltas.QuickUseCustomKey.JustPressed)
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
        }

        /*private void Fargos()
        {
            if (player.GetModPlayer<FargowiltasSouls.FargoPlayer>().NinjaEnchant)
            {
                player.AddBuff(Fargowiltas.FargosGetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
            }
        }*/

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (player.itemTime == 0 && player.itemAnimation == 0)
                {
                    player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }
        }

        public override void PostUpdateEquips()
        {
            if (Fargowiltas.SwarmActive)
            {
                player.buffImmune[BuffID.Horrified] = true;
            }

            for (int i = 0; i < player.bank.item.Length; i++)
            {
                Item item = player.bank.item[i];

                if (item.active && Array.IndexOf(Informational, item.type) > -1)
                {
                    player.VanillaUpdateEquip(item);
                }
            }
        }

        public override void UpdateBiomes()
        {
            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.EaterBoss, NPCID.EaterofWorldsHead))
            {
                player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.BrainBoss, NPCID.BrainofCthulhu))
            {
                player.ZoneCrimson = true;
            }

            if (FargoGlobalNPC.SpecificBossIsAlive(ref FargoGlobalNPC.PlantBoss, NPCID.Plantera))
            {
                player.ZoneJungle = true;
            }

            if (ModContent.GetInstance<FargoConfig>().fountains)
            {
                switch (Main.SceneMetrics.ActiveFountainColor)
                {
                    case 0:
                        player.ZoneBeach = true;
                        break;

                    case 2:
                        player.ZoneCorrupt = true;
                        break;

                    case 3:
                        player.ZoneJungle = true;
                        break;

                    case 4:
                        if (Main.hardMode)
                        {
                            player.ZoneHallow = true;
                        }
                        break;

                    case 5:
                        player.ZoneSnow = true;
                        break;

                    case 6:
                        // This is the oasis. The oasis itself is determined by water in a surface desert biome, which we can't replicate properly and reliably.
                        player.ZoneDesert = true;
                        break;

                    case 8:
                        player.ZoneRockLayerHeight = true;
                        break;

                    case 10:
                        player.ZoneCrimson = true;
                        break;

                    case 12:
                        player.ZoneUndergroundDesert = true;
                        break;
                }
            }
        }

        public void AutoUseMirror()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                switch (player.inventory[i].type)
                {
                    case ItemID.RecallPotion:
                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                        QuickUseItemAt(i);
                        break;
                }
            }
        }

        public void AutoUseRod()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ItemID.RodofDiscord)
                {
                    QuickUseItemAt(i);

                    break;
                }
            }
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && player.selectedItem != index && player.inventory[index].type != ItemID.None)
            {
                originalSelectedItem = player.selectedItem;
                autoRevertSelectedItem = true;
                player.selectedItem = index;
                player.controlUseItem = true;

                if (use)
                {
                    player.ItemCheck(Main.myPlayer);
                }
            }
        }
    }
}