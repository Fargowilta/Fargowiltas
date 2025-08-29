using Fargowiltas.Common.Systems.Recipes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Tiles
{
    public class MultitaskCenter : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Multitask Center");
            // Tooltip.SetDefault("Functions as several basic crafting stations");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 30);
            Item.createTile = ModContent.TileType<MultitaskCenterSheet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WorkBench)
                .AddIngredient(ItemID.HeavyWorkBench)
                .AddIngredient(ItemID.Furnace)
                .AddRecipeGroup(RecipeGroups.AnyAnvil)
                .AddIngredient(ItemID.Bottle)
                .AddIngredient(ItemID.Sawmill)
                .AddIngredient(ItemID.Loom)
                .AddRecipeGroup(RecipeGroups.AnyWoodenTable)
                .AddRecipeGroup(RecipeGroups.AnyWoodenChair)
                .AddRecipeGroup(RecipeGroups.AnyCookingPot)
                .AddRecipeGroup(RecipeGroups.AnyWoodenSink)
                .AddIngredient(ItemID.Keg)
                //.AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
