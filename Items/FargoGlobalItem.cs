using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;
using Fargowiltas.Items.Ammos.Rockets;
using System.Text.RegularExpressions;
using System.Linq;

namespace Fargowiltas.Items
{
    public class FargoGlobalItem : GlobalItem
    {
        private static readonly int[] Hearts = new int[] { ItemID.Heart, ItemID.CandyApple, ItemID.CandyCane };
        private static readonly int[] Stars = new int[] { ItemID.Star, ItemID.SoulCake, ItemID.SugarPlum };

        private bool firstTick = true;

        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }

        //public override bool CloneNewInstances => true;

        TooltipLine FountainTooltip(string biome) => new TooltipLine(Mod, "Tooltip0", $"[i:909] [c/AAAAAA:Forces surrounding biome state to {biome} upon activation]");

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            FargoConfig fargoConfig = GetInstance<FargoConfig>();

            if (fargoConfig.ExpandedTooltips)
            {
                TooltipLine line;

                switch (item.type)
                {
                    case ItemID.PureWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Ocean"));
                        break;

                    case ItemID.OasisFountain:
                    case ItemID.DesertWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Desert"));
                        break;

                    case ItemID.JungleWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Jungle"));
                        break;

                    case ItemID.IcyWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Snow"));
                        break;

                    case ItemID.CorruptWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Corruption"));
                        break;

                    case ItemID.CrimsonWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Crimson"));
                        break;

                    case ItemID.HallowedWaterFountain:
                        if (fargoConfig.Fountains)
                            tooltips.Add(FountainTooltip("Hallow (in hardmode only)"));
                        break;

                    //cavern fountain?

                    case ItemID.BugNet:
                    case ItemID.GoldenBugNet:
                    case ItemID.FireproofBugNet:
                        if (fargoConfig.CatchNPCs)
                            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "[i:1991] [c/AAAAAA:Can also catch townsfolk]"));
                        break;

                }

                if (fargoConfig.ExtraLures)
                {
                    if (item.type == ItemID.FishingPotion)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", "[i:2373] [c/AAAAAA:Also grants one extra lure]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.FiberglassFishingPole || item.type == ItemID.FisherofSouls || item.type == ItemID.Fleshcatcher || item.type == ItemID.ScarabFishingRod || item.type == ItemID.BloodFishingRod)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", "[i:2373] [c/AAAAAA:This rod fires 2 lures]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.MechanicsRod || item.type == ItemID.SittingDucksFishingRod)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", "[i:2373] [c/AAAAAA:This rod fires 3 lures]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.GoldenFishingRod || item.type == ItemID.HotlineFishingHook)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", "[i:2373] [c/AAAAAA:This rod fires 5 lures]");
                        tooltips.Insert(3, line);
                    }
                }

                if (fargoConfig.TorchGodEX && item.type == ItemID.TorchGodsFavor)
                {
                    line = new TooltipLine(Mod, "TooltipTorchGod1", "[i:5043] [c/AAAAAA:Automatically swaps placed torches to boost luck]");
                    tooltips.Add(line);
                    line = new TooltipLine(Mod, "TooltipTorchGod2", "[i:5043] [c/AAAAAA:Obeys true torch luck when replacing torches, which may differ from default choices]");
                    tooltips.Add(line);
                }

                if (fargoConfig.UnlimitedPotionBuffsOn120 && item.maxStack > 1)
                {
                    if (item.buffType != 0)
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", "[i:87] [c/AAAAAA:Unlimited buff at 30 stack in inventory, Piggy Bank, or Safe]");
                        tooltips.Add(line);
                    }
                    else if (item.type == ItemID.SharpeningStation
                            || item.type == ItemID.AmmoBox
                            || item.type == ItemID.CrystalBall
                            || item.type == ItemID.BewitchingTable
                            || item.type == ItemID.SliceOfCake)
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", "[i:87] [c/AAAAAA:Unlimited buff at 3 stack in inventory, Piggy Bank, or Safe]");
                        tooltips.Add(line);
                    }
                }

                if (fargoConfig.PiggyBankAcc)
                {
                    if (Informational.Contains(item.type) || Construction.Contains(item.type))
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", "[i:87] [c/AAAAAA:Works from Piggy Bank and Safe]");
                        tooltips.Add(line);
                    }
                }

                if (Squirrel.SquirrelSells(item, out Squirrel.SquirrelSellType sellType) != Squirrel.ShopGroup.End)
                {
                    string text = Regex.Replace(sellType.ToString(), "([a-z])([A-Z])", "$1 $2");
                    line = new TooltipLine(Mod, "TooltipSquirrel",
                        $"[i:{CaughtNPCs.CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{text}]");
                    tooltips.Add(line);
                }
            }
        }

        public override void SetDefaults(Item item)
        {
            if (GetInstance<FargoConfig>().IncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 9999;
                }
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            switch (arg)
            {
                case ItemID.KingSlimeBossBag:
                    if (Main.rand.NextBool(25))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.SlimeStaff), ItemID.SlimeStaff);
                    }

                    break;

                case ItemID.WoodenCrate:
                //case Pearlwood
                    if (Main.rand.NextBool(40))
                    {
                        int drop = Main.rand.Next(new int[] { ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang });
                        player.QuickSpawnItem(player.GetSource_OpenItem(drop), drop);
                    }

                    break;

                case ItemID.GoldenCrate:
                //case Titanium
                    if (Main.rand.NextBool(10))
                    {
                        int drop = Main.rand.Next( new int[] { ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet });
                        player.QuickSpawnItem(player.GetSource_OpenItem(drop), drop);
                    }

                    if (Main.rand.NextBool(20) && !Main.hardMode)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Sundial), ItemID.Sundial);
                    }

                        break;
            }

            if (context == "lockBox")
            {
                if (Main.rand.NextBool(7))
                {
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Valor), ItemID.Valor);
                }
            }
        }

        public override void PostUpdate(Item item)
        {
            if (GetInstance<FargoConfig>().Halloween == SeasonSelections.AlwaysOn && GetInstance<FargoConfig>().Christmas == SeasonSelections.AlwaysOn && firstTick)
            {
                if (Array.IndexOf(Hearts, item.type) >= 0)
                {
                    item.type = Hearts[Main.rand.Next(Hearts.Length)];
                }

                if (Array.IndexOf(Stars, item.type) >= 0)
                {
                    item.type = Stars[Main.rand.Next(Stars.Length)];
                }

                firstTick = false;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.SiltBlock || item.type == ItemID.SlushBlock || item.type == ItemID.DesertFossil)
            {
                if (GetInstance<FargoConfig>().ExtractSpeed && player.GetModPlayer<FargoPlayer>().extractSpeed)
                {
                    item.useTime = 2;
                    item.useAnimation = 3;
                }
                else
                {
                    item.useTime = 10;
                    item.useAnimation = 15;
                }  
            }

            return base.CanUseItem(item, player);
        }

        public static void TryUnlimBuff(Item item, Player player)
        {
            if (item.IsAir || !GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120)
                return;

            if (item.stack >= 30 && item.buffType != 0)
            {
                player.AddBuff(item.buffType, 2);

                //compensate to account for luck potion being weaker based on remaining duration wtf
                if (item.type == ItemID.LuckPotion)
                    player.GetModPlayer<FargoPlayer>().luckPotionBoost = Math.Max(player.GetModPlayer<FargoPlayer>().luckPotionBoost, 0.1f);
                else if (item.type == ItemID.LuckPotionGreater)
                    player.GetModPlayer<FargoPlayer>().luckPotionBoost = Math.Max(player.GetModPlayer<FargoPlayer>().luckPotionBoost, 0.2f);
            }

            if (item.stack >= 3)
            {
                if (item.type == ItemID.SharpeningStation)
                    player.AddBuff(BuffID.Sharpened, 2);
                else if (item.type == ItemID.AmmoBox)
                    player.AddBuff(BuffID.AmmoBox, 2);
                else if (item.type == ItemID.CrystalBall)
                    player.AddBuff(BuffID.Clairvoyance, 2);
                else if (item.type == ItemID.BewitchingTable)
                    player.AddBuff(BuffID.Bewitched, 2);
                else if (item.type == ItemID.SliceOfCake)
                    player.AddBuff(BuffID.SugarRush, 2);
            }
        }

        static int[] Informational = { ItemID.DPSMeter, ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone };
        static int[] Construction = { ItemID.Toolbelt, ItemID.Toolbox, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.BrickLayer, ItemID.PortableCementMixer, ItemID.ActuationAccessory, ItemID.ArchitectGizmoPack };
        public static void TryPiggyBankAcc(Item item, Player player)
        {
            if (item.IsAir || item.maxStack > 1 || !GetInstance<FargoConfig>().PiggyBankAcc)
                return;

            if (Informational.Contains(item.type))
            {
                player.VanillaUpdateInventory(item);
            }
            else if (Construction.Contains(item.type))
            {
                Item fakeItem = new Item();
                fakeItem.SetDefaults(item.type);
                player.VanillaUpdateEquip(fakeItem);
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            TryUnlimBuff(item, player);
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.MusicBox && Main.curMusic > 0 && Main.curMusic <= 41)
            {
                int itemId = 0;

                //still better than vanilla (fear)
                switch (Main.curMusic)
                {
                    case 1:
                        itemId = 0 + 562;
                        break;
                    case 2:
                        itemId = 1 + 562;
                        break;
                    case 3:
                        itemId = 2 + 562;
                        break;
                    case 4:
                        itemId = 4 + 562;
                        break;
                    case 5:
                        itemId = 5 + 562;
                        break;
                    case 6:
                        itemId = 3 + 562;
                        break;
                    case 7:
                        itemId = 6 + 562;
                        break;
                    case 8:
                        itemId = 7 + 562;
                        break;
                    case 9:
                        itemId = 9 + 562;
                        break;
                    case 10:
                        itemId = 8 + 562;
                        break;
                    case 11:
                        itemId = 11 + 562;
                        break;
                    case 12:
                        itemId = 10 + 562;
                        break;
                    case 13:
                        itemId = 12 + 562;
                        break;
                    case 28:
                        itemId = 1963;
                        break;
                    case 29:
                        itemId = 1610;
                        break;
                    case 30:
                        itemId = 1963;
                        break;
                    case 31:
                        itemId = 1964;
                        break;
                    case 32:
                        itemId = 1965;
                        break;
                    case 33:
                        itemId = 2742;
                        break;
                    case 34:
                        itemId = 3370;
                        break;
                    case 35:
                        itemId = 3236;
                        break;
                    case 36:
                        itemId = 3237;
                        break;
                    case 37:
                        itemId = 3235;
                        break;
                    case 38:
                        itemId = 3044;
                        break;
                    case 39:
                        itemId = 3371;
                        break;
                    case 40:
                        itemId = 3796;
                        break;
                    case 41:
                        itemId = 3869;
                        break;
                    default:
                        itemId = 1596 + Main.curMusic - 14;
                        break;
                }

                for (int i = 0; i < player.armor.Length; i++)
                {
                    Item accessory = player.armor[i];

                    if (accessory.accessory && accessory.type == item.type)
                    {
                        player.armor[i].SetDefaults(itemId, false);
                        break;
                    }
                }
            }
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedAmmo && Main.hardMode && ammo.ammo != 0 && ammo.stack >= 3996)
                return false;

            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedConsumableWeapons && Main.hardMode && item.damage > 0 && item.ammo == 0 && item.stack >= 3996)
                return false;
            if (GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120 && (item.buffType > 0 || item.type == ItemID.RecallPotion || item.type == ItemID.PotionOfReturn || item.type == ItemID.WormholePotion) && (item.stack >= 30 || player.inventory.Any(i => i.type == item.type && !i.IsAir && i.stack >= 30)))
                return false;
            return true;
        }

        public override bool OnPickup(Item item, Player player)
        {
            String dye = "";

            switch (item.type)
            {
                case ItemID.RedHusk:
                    dye = "RedHusk";
                    break;
                case ItemID.OrangeBloodroot:
                    dye = "OrangeBloodroot";
                    break;
                case ItemID.YellowMarigold:
                    dye = "YellowMarigold";
                    break;
                case ItemID.LimeKelp:
                    dye = "LimeKelp";
                    break;
                case ItemID.GreenMushroom:
                    dye = "GreenMushroom";
                    break;
                case ItemID.TealMushroom:
                    dye = "TealMushroom";
                    break;
                case ItemID.CyanHusk:
                    dye = "CyanHusk";
                    break;
                case ItemID.SkyBlueFlower:
                    dye = "SkyBlueFlower";
                    break;
                case ItemID.BlueBerries:
                    dye = "BlueBerries";
                    break;
                case ItemID.PurpleMucos:
                    dye = "PurpleMucos";
                    break;
                case ItemID.VioletHusk:
                    dye = "VioletHusk";
                    break;
                case ItemID.PinkPricklyPear:
                    dye = "PinkPricklyPear";
                    break;
                case ItemID.BlackInk:
                    dye = "BlackInk";
                    break;
            }

            if (dye != "")
            {
                player.GetModPlayer<FargoPlayer>().FirstDyeIngredients[dye] = true;
            }

            return base.OnPickup(item, player);
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (equippedItem.wingSlot != 0 && incomingItem.wingSlot != 0)
                player.GetModPlayer<FargoPlayer>().ResetStatSheetWings();

            return base.CanAccessoryBeEquippedWith(equippedItem, incomingItem, player);
        }

        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            player.GetModPlayer<FargoPlayer>().StatSheetMaxAscentMultiplier = maxAscentMultiplier;
            player.GetModPlayer<FargoPlayer>().CanHover = ArmorIDs.Wing.Sets.Stats[item.wingSlot].HasDownHoverStats || ArmorIDs.Wing.Sets.Stats[player.wingsLogic].HasDownHoverStats;
        }

        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
            player.GetModPlayer<FargoPlayer>().StatSheetWingSpeed = speed;
        }
    }
}
