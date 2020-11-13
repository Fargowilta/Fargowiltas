using System.Text.RegularExpressions;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public abstract class BaseAmmo : ModItem
    {
        public abstract int AmmunitionItem { get; }

        public override void SetStaticDefaults() => DisplayName.SetDefault($"Endless {Regex.Replace(Name, "([A-Z])", " $1").Trim()}");

        public override void SetDefaults()
        {
            item.CloneDefaults(AmmunitionItem);
            item.width = 26;
            item.height = 26;
            item.consumable = false;
            item.maxStack = 1;
            item.value *= 3996;
            item.rare += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(AmmunitionItem, 3996)                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}