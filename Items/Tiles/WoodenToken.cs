using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class WoodenToken : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("'The sign of a true wood lover'");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<WoodenTokenTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 25)
                .AddIngredient(ItemID.BorealWood, 25)
                .AddIngredient(ItemID.RichMahogany, 25)
                .AddIngredient(ItemID.PalmWood, 25)
                .AddRecipeGroup("Fargowiltas:AnyEvilWood", 25)                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}