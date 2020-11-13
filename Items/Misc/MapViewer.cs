using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MapViewer : ModItem
    {
        public override string Texture => "Terraria/Map_4";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ancient Master's Map of the Lost King's Great Ancestors");

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Tooltip.SetDefault("Reveals the whole map");
            }
            else
            {
                Tooltip.SetDefault("Reveals an area of the map around you");
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.White;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        if (WorldGen.InWorld(i, j))
                        {
                            Main.Map.Update(i, j, 255);
                        }
                    }
                }

                Main.refreshMap = true;
            }
            else
            {
                Point center = Main.LocalPlayer.Center.ToTileCoordinates();
                int range = 300;

                for (int i = center.X - range / 2; i < center.X + range / 2; i++)
                {
                    for (int j = center.Y - range / 2; j < center.Y + range / 2; j++)
                    {
                        if (WorldGen.InWorld(i, j))
                        {
                            Main.Map.Update(i, j, 255);
                        }
                    }
                }

                Main.refreshMap = true;
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TrifoldMap)
                .AddIngredient(ItemID.Goggles)
                .AddIngredient(ItemID.Sunglasses)
                .AddIngredient(ItemID.SuspiciousLookingEye)
                .AddIngredient(ItemID.MechanicalEye)                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}