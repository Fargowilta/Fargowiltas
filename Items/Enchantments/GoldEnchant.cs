using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class GoldEnchant : ModItem
    {
        public float damage = 0f;

        public override bool CloneNewInstances
        {
            get { return true; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Enchantment");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            TooltipLine[] lines = new TooltipLine[8];

            lines[0] = new TooltipLine(mod, "1", "'Gold makes the world go round'");
            lines[1] = new TooltipLine(mod, "2", "Increased damage based on current coin count");
            lines[2] = new TooltipLine(mod, "3", "Current: " + (damage * 100).ToString("0.00") + "% increased damage");
            lines[2].overrideColor = Color.LimeGreen;
            lines[3] = new TooltipLine(mod, "4", "Picking up gold coins gives you extra life regen or movement speed for a short time");
            lines[4] = new TooltipLine(mod, "5", "You will throw away any lesser valued coins you pick up");
            lines[5] = new TooltipLine(mod, "6", "Increases coin pickup range and shops have lower prices");
            lines[6] = new TooltipLine(mod, "7", "Hitting enemies will sometimes drop extra coins");
            lines[7] = new TooltipLine(mod, "8", "Your attacks also inflict Midas");


            for (int i = 0; i < lines.Length; i++)
            {
                tooltips.Add(lines[i]);
            }

        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 200000;
        }

        public static long GetCoins(Player player)
        {
            bool overflowing;
            long inventoryCoins = Utils.CoinsCount(out overflowing, player.inventory, new int[] { 58, 57, 56, 55, 54 });
            long piggyBankCoins = Utils.CoinsCount(out overflowing, player.bank.item, new int[0]);
            long safeCoins = Utils.CoinsCount(out overflowing, player.bank2.item, new int[0]);
            long defendersForgeCoins = Utils.CoinsCount(out overflowing, player.bank3.item, new int[0]);
            long totalCoins = Utils.CoinsCombineStacks(out overflowing, new long[]
            {
                inventoryCoins,
                piggyBankCoins,
                safeCoins,
                defendersForgeCoins
            });
            return totalCoins;
        }

        public void UpdateDamage(Player player)
        {
            long totalCoins = GetCoins(player);
            int[] coins = Utils.CoinsSplit(totalCoins);
            int plat = coins[3];
            int gold = coins[2];

            if (plat <= 0)
            {
                damage = coins[2] * .0004f;
            }
            else if (plat < 5) // 1-4 plat
            {
                damage = .05f;
            }
            else if (plat < 15) // 5-14 plat
            {
                damage = .10f;
            }
            else if (plat < 30) // 15-29 plat 
            {
                damage = .15f;
            }
            else if (plat < 50) // 30-49 plat
            {
                damage = .20f;
            }
            else if (plat < 75) // 50-74 plat
            {
                damage = .25f;
            }
            else // 75+ plat
            {
                damage = .30f;
            }

        }

        public override void UpdateInventory(Player player)
        {
            UpdateDamage(player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            UpdateDamage(player);

            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            modPlayer.goldEnchant = true;

            //gold ring
            player.goldRing = true;
            //lucky coin
            player.coins = true;
            //discount card
            player.discount = true;

            player.magicDamage += damage;
            player.meleeDamage += damage;
            player.rangedDamage += damage;
            player.minionDamage += damage;
            player.thrownDamage += damage;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.GoldHelmet);
            recipe.AddIngredient(ItemID.GoldChainmail);
            recipe.AddIngredient(ItemID.GoldGreaves);
            recipe.AddIngredient(ItemID.GreedyRing);
            recipe.AddIngredient(ItemID.RubyStaff);
            recipe.AddIngredient(ItemID.SquirrelGold);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

