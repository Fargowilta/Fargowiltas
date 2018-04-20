using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class ChlorophyteQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Chlorophyte Quiver");
            Tooltip.SetDefault("Bounces back after hitting a wall");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 4.5f;
            item.shoot = ProjectileID.ChlorophyteArrow;
            item.damage = 16;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 3.5f;
            item.rare = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteArrow, 3996);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}