using Fargowiltas.Items.CaughtNPCs;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class WiresPainting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wires Painting");
            Tooltip.SetDefault("'Look inside'");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<WiresPaintingSheet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wire, 30)
                .AddIngredient(CaughtNPCItem.CaughtTownies[NPCID.TownCat], 1)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}