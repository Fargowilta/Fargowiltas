using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Tiles
{
    public class PurityTotem : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Purity Totem");
            /* Tooltip.SetDefault(@"Can be reused infinitely
Allows town NPCs to inhabit evil biomes
Prevents evil tiles from forming an evil biome
Prevents tombstones from forming Graveyards"); */
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1);
            Item.createTile = ModContent.TileType<PurityTotemSheet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sunflower, 50)
                .AddIngredient(ItemID.PurificationPowder, 100)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}