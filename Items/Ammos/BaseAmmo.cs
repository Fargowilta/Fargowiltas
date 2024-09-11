using Fargowiltas.Items.Ammos.Rockets;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Ammos
{
    public abstract class BaseAmmo : ModItem
    {
        public abstract int AmmunitionItem { get; }


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault($"Endless {Regex.Replace(Name, "([A-Z])", " $1").Trim()}");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(AmmunitionItem);
            Item.width = 26;
            Item.height = 26;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.value *= 3996;
            Item.rare += 1;
        }

        public override void AddRecipes()
        {
            int amount = 1;
            CreateRecipe(amount)
                .AddIngredient(AmmunitionItem, 3996)
                .AddTile(TileID.CrystalBall)
                .Register();
                
        }
    }
}
