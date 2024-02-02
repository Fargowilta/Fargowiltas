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
using Terraria.GameContent.ItemDropRules;
using Fargowiltas.Common.Configs;
using Fargowiltas.Items.Ammos.Coins;
using Fargowiltas.Items.CaughtNPCs;
using static System.Net.Mime.MediaTypeNames;
using Terraria.Localization;

namespace Fargowiltas.Items
{
    public class FargoGlobalItem : GlobalItem
    {
        private static readonly int[] Hearts = new int[] { ItemID.Heart, ItemID.CandyApple, ItemID.CandyCane };
        private static readonly int[] Stars = new int[] { ItemID.Star, ItemID.SoulCake, ItemID.SugarPlum };

        private bool firstTick = true;

        public override bool InstancePerEntity => true;

        static string ExpandedTooltipLoc(string line) => Language.GetTextValue($"Mods.Fargowiltas.ExpandedTooltips.{line}");

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }

        //public override bool CloneNewInstances => true;

        TooltipLine FountainTooltip(string biome) => new TooltipLine(Mod, "Tooltip0", $"[i:909] [c/AAAAAA:{ExpandedTooltipLoc($"Fountain{biome}")}]");
        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
        {
            //coin gun is broken as fucking shit codingwise so i'm fixing it
            if (weapon.type == ItemID.CoinGun)
            {
                if (ammo.type == ItemID.CopperCoin || ammo.type == ModContent.ItemType<CopperCoinBag>())
                {
                    type = ProjectileID.CopperCoin;
                }
                if (ammo.type == ItemID.SilverCoin || ammo.type == ModContent.ItemType<SilverCoinBag>())
                {
                    type = ProjectileID.SilverCoin;
                }
                if (ammo.type == ItemID.GoldCoin || ammo.type == ModContent.ItemType<GoldCoinBag>())
                {
                    type = ProjectileID.GoldCoin;
                }
                if (ammo.type == ItemID.PlatinumCoin || ammo.type == ModContent.ItemType<PlatinumCoinBag>())
                {
                    type = ProjectileID.PlatinumCoin;
                }
            }
        }
        public static List<int> BuffStations = new List<int>
        {
            ItemID.SharpeningStation,
            ItemID.AmmoBox,
            ItemID.CrystalBall,
            ItemID.BewitchingTable,
            ItemID.WarTable,
        };
        //For the shop sale tooltip system.
        internal class ShopTooltip
        {
            public List<int> NpcItemIDs = new();
            public List<string> NpcNames = new();
            public string Condition;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var fargoServerConfig = GetInstance<FargoServerConfig>();

            if (GetInstance<FargoClientConfig>().ExpandedTooltips)
            {
                TooltipLine line;
                //Shop sale tooltips. Very engineered. Adds tooltips to ALL npc shop sales. Aims to handle any edge case as well as possible.
                List<ShopTooltip> registeredShopTooltips = new();
                foreach (var shop in NPCShopDatabase.AllShops)
                {
                    foreach (var entry in shop.ActiveEntries.Where(e => !e.Item.IsAir && e.Item.type == item.type))
                    {
                        Item npcItem = null;
                        foreach (var tryNPCItem in ContentSamples.ItemsByType.Where(i => i.Value.ModItem != null && i.Value.ModItem is CaughtNPCItem modItem && modItem.AssociatedNpcId == shop.NpcType))
                        {
                            npcItem = tryNPCItem.Value;
                            break;
                        }
                        
                        if (npcItem == null)
                        {
                            npcItem = item;
                        }
                        
                        string conditions = "";
                        int i = 0;
                        foreach (var condition in entry.Conditions)
                        {
                            string grammar = i > 0 ? ", " : "";
                            conditions += grammar + condition.Description.Value;
                            i++;
                        }
                        string conditionLine = i > 0 ? ": " + conditions : "";
                        string npcName = ContentSamples.NpcsByNetId[shop.NpcType].FullName;
                        
                        if (registeredShopTooltips.Any(t => t.NpcNames.Any(n => n == npcName) && t.Condition == conditionLine)) //sometimes it makes duplicates otherwise
                            continue;

                        bool registered = false;
                        
                        foreach (ShopTooltip regTooltip in registeredShopTooltips)
                        {
                            if (regTooltip.Condition == conditionLine && !regTooltip.NpcNames.Contains(npcName))
                            {
                                regTooltip.NpcNames.Add(npcName);
                                regTooltip.NpcItemIDs.Add(npcItem.type);
                                registered = true;
                                break;
                            }
                        }
                        if (!registered)
                        {
                            ShopTooltip tooltip = new();
                            tooltip.NpcItemIDs.Add(npcItem.type);
                            tooltip.NpcNames.Add(npcName);
                            tooltip.Condition = conditionLine;
                            registeredShopTooltips.Add(tooltip);
                        }
                        
                        break; //only one line per npc
                    }
                }
                foreach (ShopTooltip tooltip in registeredShopTooltips)
                {

                    List<int> displayIDs = tooltip.NpcItemIDs.Where(i => i != item.type)?.ToList();
                    int id = item.type;
                    if (displayIDs.Any())
                    {
                        int timer = (int)(Main.GlobalTimeWrappedHourly * 60);
                        int index = timer / 60;
                        index %= displayIDs.Count;
                        id = displayIDs[index];
                    }
                    
                    string names = "";
                    int i = 0;
                    foreach (string npcName in tooltip.NpcNames)
                    {
                        string grammar = i > 0 ? ", " : "";
                        names += grammar + npcName;
                        i++;
                    }
                    if (i > 5)
                        names = ExpandedTooltipLoc("SeveralVendors");
                    string text = $"[i:{id}] [c/AAAAAA:{ExpandedTooltipLoc("SoldBy")} {names}{tooltip.Condition}]";
                    line = new TooltipLine(Mod, "TooltipNPCSold", text);
                    tooltips.Add(line);
                }

                switch (item.type)
                {
                    case ItemID.PureWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Ocean"));
                        break;

                    case ItemID.OasisFountain:
                    case ItemID.DesertWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Desert"));
                        break;

                    case ItemID.JungleWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Jungle"));
                        break;

                    case ItemID.IcyWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Snow"));
                        break;

                    case ItemID.CorruptWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Corruption"));
                        break;

                    case ItemID.CrimsonWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Crimson"));
                        break;

                    case ItemID.HallowedWaterFountain:
                        if (fargoServerConfig.Fountains)
                            tooltips.Add(FountainTooltip("Hallow"));
                        break;

                    //cavern fountain?

                    case ItemID.BugNet:
                    case ItemID.GoldenBugNet:
                    case ItemID.FireproofBugNet:
                        if (fargoServerConfig.CatchNPCs)
                            tooltips.Add(new TooltipLine(Mod, "Tooltip0", $"[i:1991] [c/AAAAAA:{ExpandedTooltipLoc("CatchNPCs")}]"));
                        break;

                }

                if (fargoServerConfig.ExtraLures)
                {
                    if (item.type == ItemID.FishingPotion)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", $"[i:2373] [c/AAAAAA:{ExpandedTooltipLoc("ExtraLure1")}]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.FiberglassFishingPole || item.type == ItemID.FisherofSouls || item.type == ItemID.Fleshcatcher || item.type == ItemID.ScarabFishingRod || item.type == ItemID.BloodFishingRod)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", $"[i:2373] [c/AAAAAA:{ExpandedTooltipLoc("Lures2")}]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.MechanicsRod || item.type == ItemID.SittingDucksFishingRod)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", $"[i:2373] [c/AAAAAA:{ExpandedTooltipLoc("Lures3")}]");
                        tooltips.Insert(3, line);
                    }

                    if (item.type == ItemID.GoldenFishingRod || item.type == ItemID.HotlineFishingHook)
                    {
                        line = new TooltipLine(Mod, "Tooltip1", $"[i:2373] [c/AAAAAA:{ExpandedTooltipLoc("Lures5")}]");
                        tooltips.Insert(3, line);
                    }
                }

                if (fargoServerConfig.TorchGodEX && item.type == ItemID.TorchGodsFavor)
                {
                    line = new TooltipLine(Mod, "TooltipTorchGod1", $"[i:5043] [c/AAAAAA:{ExpandedTooltipLoc("AutoTorch")}]");
                    tooltips.Add(line);
                    line = new TooltipLine(Mod, "TooltipTorchGod2", $"[i:5043] [c/AAAAAA:{ExpandedTooltipLoc("TrueTorchLuck")}]");
                    tooltips.Add(line);
                }

                if (fargoServerConfig.UnlimitedPotionBuffsOn120 && item.maxStack > 1)
                {
                    if (item.buffType != 0)
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", $"[i:87] [c/AAAAAA:{ExpandedTooltipLoc("UnlimitedBuff30")}]");
                        tooltips.Add(line);
                    }
                    else if (item.bait > 0)
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", $"[i:5139] [c/AAAAAA:{ExpandedTooltipLoc("UnlimitedUse30")}]");
                        tooltips.Add(line);
                    }
                    
                    else if (BuffStations.Contains(item.type))
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", $"[i:87] [c/AAAAAA:{ExpandedTooltipLoc("PermanentEffectNearby")}]");
                        tooltips.Add(line);
                    }
                    
                }

                if (fargoServerConfig.PiggyBankAcc)
                {
                    if (Informational.Contains(item.type) || Construction.Contains(item.type))
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", $"[i:87] [c/AAAAAA:{ExpandedTooltipLoc("WorksFromBanks")}]");
                        tooltips.Add(line);
                    }
                }

                if (Squirrel.SquirrelSells(item, out SquirrelSellType sellType) != SquirrelShopGroup.End)
                {
                    line = new TooltipLine(Mod, "TooltipSquirrel",
                        $"[i:{CaughtNPCs.CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{ExpandedTooltipLoc(sellType.ToString())}]");
                    tooltips.Add(line);
                }
            }
        }

        public override void SetDefaults(Item item)
        {
            if (GetInstance<FargoServerConfig>().IncreaseMaxStack)
            {
                if (item.maxStack > 10 && (item.maxStack != 100) && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
                {
                    item.maxStack = 9999;
                }
            }
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            switch (item.type)
            {
                case ItemID.KingSlimeBossBag:
                    itemLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 25));
                    break;

                case ItemID.WoodenCrate:
                    if (!Main.remixWorld && !Main.zenithWorld)
                    {
                        itemLoot.Add(ItemDropRule.OneFromOptions(40, ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang));
                    }
                    else
                    {
                        itemLoot.Add(ItemDropRule.OneFromOptions(40, ItemID.Spear, ItemID.Blowpipe, ItemID.WoodenBoomerang));
                    }

                    break;

                case ItemID.GoldenCrate:
                    itemLoot.Add(ItemDropRule.OneFromOptions(10, ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet));
                    itemLoot.Add(ItemDropRule.Common(ItemID.Sundial, 20));

                    break;
            }

        }

        public override void PostUpdate(Item item)
        {
            if (GetInstance<FargoServerConfig>().Halloween == SeasonSelections.AlwaysOn && GetInstance<FargoServerConfig>().Christmas == SeasonSelections.AlwaysOn && firstTick)
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
                if (GetInstance<FargoServerConfig>().ExtractSpeed && player.GetModPlayer<FargoPlayer>().extractSpeed)
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
            if (item.IsAir || !GetInstance<FargoServerConfig>().UnlimitedPotionBuffsOn120)
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
            
        }

        static int[] Informational = { ItemID.DPSMeter, ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone };
        static int[] Construction = { ItemID.Toolbelt, ItemID.Toolbox, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.BrickLayer, ItemID.PortableCementMixer, ItemID.ActuationAccessory, ItemID.ArchitectGizmoPack };
        public static void TryPiggyBankAcc(Item item, Player player)
        {
            if (item.IsAir || item.maxStack > 1 || !GetInstance<FargoServerConfig>().PiggyBankAcc)
                return;

            if (Informational.Contains(item.type))
            {
                player.RefreshInfoAccsFromItemType(item);
            }
            else if (Construction.Contains(item.type))
            {
                player.ApplyEquipFunctional(item, true);
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
                int itemId;

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
            if (GetInstance<FargoServerConfig>().UnlimitedAmmo && Main.hardMode && ammo.ammo != 0 && ammo.stack >= 3996)
                return false;

            return true;
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (GetInstance<FargoServerConfig>().UnlimitedPotionBuffsOn120 && bait.stack >= 30)
                return false;

            return base.CanConsumeBait(player, bait);
        }

        public static List<int> NonBuffPotions = new List<int>
        {
            ItemID.RecallPotion,
            ItemID.PotionOfReturn,
            ItemID.WormholePotion,
            ItemID.TeleportationPotion
        };
        public override bool ConsumeItem(Item item, Player player)
        {
            if (GetInstance<FargoServerConfig>().UnlimitedConsumableWeapons && Main.hardMode && item.damage > 0 && item.ammo == 0 && item.stack >= 3996)
                return false;
            if (GetInstance<FargoServerConfig>().UnlimitedPotionBuffsOn120 && (item.buffType > 0 || NonBuffPotions.Contains(item.type)) && (item.stack >= 30 || player.inventory.Any(i => i.type == item.type && !i.IsAir && i.stack >= 30)))
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
