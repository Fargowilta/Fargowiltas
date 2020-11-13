using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation2 : Omnistation
    {
        public override void SetDefaults() => item.createTile = ModContent.TileType<OmnistationTile2>();

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
                .AddIngredient(ItemID.TitaniumBar, 5)                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}