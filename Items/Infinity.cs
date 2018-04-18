using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items
{
    public class Infinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infinity Relic");
            Tooltip.SetDefault("'Is it really worth it?'\n" +
                                "You consume no ammo, mana, or consumables \n" +
                                "There is of course a catch (^:");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //nothing used son
            ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).infinity = true;
            player.manaCost -= 1f;

            //the price
            player.AddBuff(mod.BuffType("InfinityDebuff"), 7200, false);

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.EndlessQuiver);
            recipe.AddIngredient(ItemID.HolyArrow, 999);
            recipe.AddIngredient(ItemID.VenomArrow, 999);
            recipe.AddIngredient(ItemID.EndlessMusketPouch);
            recipe.AddIngredient(ItemID.PartyBullet, 999);
            recipe.AddIngredient(ItemID.ChlorophyteBullet, 999);
            recipe.AddIngredient(ItemID.RocketIII, 999);
            recipe.AddIngredient(ItemID.CrystalDart, 999);
            recipe.AddIngredient(ItemID.ManaCrystal, 10);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

