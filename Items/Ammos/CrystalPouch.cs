using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class CrystalPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Crystal Pouch");
            Tooltip.SetDefault("Creates several crystal shards on impact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 5f;
            item.shoot = ProjectileID.CrystalBullet;
            item.damage = 9;
            item.width = 26;
            item.height = 26;
            item.ranged = true;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 1f;
            item.rare = 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalBullet, 3996);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}