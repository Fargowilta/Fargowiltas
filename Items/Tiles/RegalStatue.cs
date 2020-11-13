using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class RegalStatue : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Town NPCs respawn extremely quickly when nearby");

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
            item.createTile = ModContent.TileType<RegalStatueTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.KingStatue)
                .AddIngredient(ItemID.QueenStatue)
                .AddIngredient(ItemID.Bone, 15)                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }
    }
}