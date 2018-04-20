using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class CursedQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Cursed Quiver");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 4f;
            item.shoot = ProjectileID.CursedArrow;
            item.damage = 17;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 3f;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedArrow, 3996);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}