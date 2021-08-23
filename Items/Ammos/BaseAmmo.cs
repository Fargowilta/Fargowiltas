using System.Text.RegularExpressions;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Ammos
{
    public abstract class BaseAmmo : ModItem
    {
        public abstract int AmmunitionItem { get; }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"Endless {Regex.Replace(Name, "([A-Z])", " $1").Trim()}");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(AmmunitionItem);
            Item.width = 26;
            Item.height = 26;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.value *= GetInstance<FargoConfig>().AmmoStackSize;
            Item.rare += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(AmmunitionItem, GetInstance<FargoConfig>().AmmoStackSize)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
