using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class ChlorophytePouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Chlorophyte Pouch");
            Tooltip.SetDefault("Chases after your enemy");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 5f;
            item.shoot = ProjectileID.ChlorophyteBullet;
            item.damage = 10;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 4.5f;
            item.rare = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}