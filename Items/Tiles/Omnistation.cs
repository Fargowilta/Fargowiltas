using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Effects of all vanilla buff stations" +
                "\nGrants Honey when touched" +
                "\nRight click while holding a weapon for its respective buff");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<OmnistationTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sunflower, 30)
                .AddIngredient(ItemID.Campfire, 30)
                .AddIngredient(ItemID.HeartLantern, 30)
                .AddIngredient(ItemID.StarinaBottle, 30)
                .AddIngredient(ItemID.HoneyBucket, 30)
                .AddIngredient(ItemID.SharpeningStation, 5)
                .AddIngredient(ItemID.AmmoBox, 5)
                .AddIngredient(ItemID.CrystalBall, 5)
                .AddIngredient(ItemID.BewitchingTable, 5)
                .AddIngredient(ItemID.AdamantiteBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}