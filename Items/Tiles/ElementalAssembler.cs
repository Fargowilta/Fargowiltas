using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class ElementalAssembler : ModItem
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
            item.createTile = ModContent.TileType<ElementalAssemblerTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Hellforge)
                .AddIngredient(ItemID.AlchemyTable)
                .AddIngredient(ItemID.TinkerersWorkshop)
                .AddIngredient(ItemID.ImbuingStation)
                .AddIngredient(ItemID.DyeVat)
                .AddIngredient(ItemID.LivingLoom)
                .AddIngredient(ItemID.GlassKiln)
                .AddIngredient(ItemID.IceMachine)
                .AddIngredient(ItemID.HoneyDispenser)
                .AddIngredient(ItemID.SkyMill)
                .AddIngredient(ItemID.Solidifier)
                .AddIngredient(ItemID.BoneWelder)                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}