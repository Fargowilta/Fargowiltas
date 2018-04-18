using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public class FargoBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amalgamated Bullet Pouch");
            Tooltip.SetDefault("Chases after your enemy\n" +
                                "Bounces several times\n" +
                                "Each impact causes an explosion of crystal bullets\n" +
                                "Inflicts several debuffs");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.knockBack = 4f; //same as explosive
            item.rare = 10;
            item.shoot = mod.ProjectileType("FargoBulletProj");
            item.shootSpeed = 15f; // same as high velocity bullets                 
            item.ammo = AmmoID.Bullet;
        }

        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Placeholder";
            }
        }

        //do later
        // public override void AddRecipes()
        // {
        // ModRecipe recipe = new ModRecipe(mod);
        // recipe.AddIngredient(ItemID.MusketBall, 50);
        // recipe.AddIngredient(null, "ExampleItem", 1);
        // recipe.AddTile(null, "ExampleWorkbench");
        // recipe.SetResult(this, 50);
        // recipe.AddRecipe();
        // }
    }
}
