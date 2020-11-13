using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class MultitaskCenter : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Functions as several basic crafting stations");

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.createTile = ModContent.TileType<MultitaskCenterTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WorkBench)
                .AddIngredient(ItemID.HeavyWorkBench)
                .AddIngredient(ItemID.Furnace)
                .AddRecipeGroup("Fargowiltas:AnyAnvil")
                .AddIngredient(ItemID.Bottle)
                .AddIngredient(ItemID.Sawmill)
                .AddIngredient(ItemID.Loom)
                .AddIngredient(ItemID.WoodenTable)
                .AddIngredient(ItemID.WoodenChair)
                .AddIngredient(ItemID.CookingPot)
                .AddIngredient(ItemID.WoodenSink)                .AddIngredient(ItemID.Keg)                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}