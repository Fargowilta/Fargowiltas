using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Items.Ammos.Rockets;

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

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line;

            switch (item.type)
            {
                case ItemID.PureWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip0", "Forces surrounding biome state to Ocean upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.DesertWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip0", "Forces surrounding biome state to Desert upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.JungleWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip0", "Forces surrounding biome state to Jungle upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.IcyWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip0", "Forces surrounding biome state to Snow upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.CorruptWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip0", "Forces surrounding biome state to Corruption upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.CrimsonWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip1", "Forces surrounding biome state to Crimson upon activation");
                    tooltips.Add(line);
                    break;

                case ItemID.HallowedWaterFountain:
                    line = new TooltipLine(Mod, "Tooltip1", "In hardmode, forces surrounding biome state to Hallow upon activation");
                    tooltips.Add(line);
                    break;

                //oasis and cavern? fountains

                case ItemID.BugNet:
                case ItemID.GoldenBugNet:
                    line = new TooltipLine(Mod, "Tooltip0", "Can also catch townsfolk");
                    tooltips.Add(line);
                    break;

            }

            if (GetInstance<FargoConfig>().ExtraLures)
            {
                if (item.type == ItemID.FishingPotion)
                {
                    line = new TooltipLine(Mod, "Tooltip1", "Also grants one extra lure");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.FiberglassFishingPole || item.type == ItemID.FisherofSouls || item.type == ItemID.Fleshcatcher)
                {
                    line = new TooltipLine(Mod, "Tooltip1", "This rod fires 2 lures");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.MechanicsRod || item.type == ItemID.SittingDucksFishingRod)
                {
                    line = new TooltipLine(Mod, "Tooltip1", "This rod fires 3 lures");
                    tooltips.Insert(3, line);
                }

                if (item.type == ItemID.GoldenFishingRod || item.type == ItemID.HotlineFishingHook)
                {
                    line = new TooltipLine(Mod, "Tooltip1", "This rod fires 5 lures");
                    tooltips.Insert(3, line);
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

                if (item.type == ItemID.PirateMap || item.type == ItemID.SnowGlobe)
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
                        player.QuickSpawnItem(ItemID.SlimeStaff);
                    }

                    break;

                case ItemID.WoodenCrate:
                //case Pearlwood
                    if (Main.rand.NextBool(40))
                    {
                        int[] drops = { ItemID.Spear, ItemID.Blowpipe, ItemID.WandofSparking, ItemID.WoodenBoomerang };
                        player.QuickSpawnItem(Main.rand.Next(drops));
                    }

                    break;

                case ItemID.GoldenCrate:
                //case Titanium
                    if (Main.rand.NextBool(10))
                    {
                        int[] drops = { ItemID.BandofRegeneration, ItemID.MagicMirror, ItemID.CloudinaBottle, ItemID.EnchantedBoomerang, ItemID.ShoeSpikes, ItemID.FlareGun, ItemID.HermesBoots, ItemID.LavaCharm, ItemID.SandstorminaBottle, ItemID.FlyingCarpet };
                        player.QuickSpawnItem(Main.rand.Next(drops));
                    }

                    if (Main.rand.NextBool(20) && !Main.hardMode)
                    {
                        player.QuickSpawnItem(ItemID.Sundial);
                    }

                        break;
            }

            if (context == "lockBox")
            {
                if (Main.rand.NextBool(7))
                {
                    player.QuickSpawnItem(ItemID.Valor);
                }
            }
        }

        public override void PostUpdate(Item item)
        {
            if (GetInstance<FargoConfig>().Halloween && GetInstance<FargoConfig>().Christmas && firstTick)
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

        public override void UpdateInventory(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120)
            {
                if (item.stack >= GetInstance<FargoConfig>().PotionStackSize && item.buffType != 0)
                    player.AddBuff(item.buffType, 2);

                if (item.stack >= GetInstance<FargoConfig>().StationStackSize)
                {
                    if (item.type == ItemID.SharpeningStation)
                        player.AddBuff(BuffID.Sharpened, 2);
                    else if (item.type == ItemID.AmmoBox)
                        player.AddBuff(BuffID.AmmoBox, 2);
                    else if (item.type == ItemID.CrystalBall)
                        player.AddBuff(BuffID.Clairvoyance, 2);
                    else if (item.type == ItemID.BewitchingTable)
                        player.AddBuff(BuffID.Bewitched, 2);
                }
            }
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

        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            if (weapon.type == ItemID.SnowmanCannon)
            {
                if (ammo.type == ItemType<Rocket1Bag>())
                    type = ProjectileID.RocketSnowmanI;
                else if (ammo.type == ItemType<Rocket2Bag>())
                    type = ProjectileID.RocketSnowmanII;
                else if (ammo.type == ItemType<Rocket3Bag>())
                    type = ProjectileID.RocketSnowmanIII;
                else if (ammo.type == ItemType<Rocket4Bag>())
                    type = ProjectileID.RocketSnowmanIV;
            }
        }

        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedAmmo && Main.hardMode && item.ammo != 0 && item.stack >= GetInstance<FargoConfig>().AmmoStackSize)
                return false;
            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (GetInstance<FargoConfig>().UnlimitedConsumableWeapons && Main.hardMode && item.damage > 0 && item.ammo == 0 && item.stack >= GetInstance<FargoConfig>().WeaponStackSize)
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
    }
}
