using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class WoodenTokenTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            dustType = 7;
            // TODO: Uncomment when tML adds this back
            // disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<WoodenToken>());

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (!FargoWorld.MovedLumberjack)
            {
                FargoWorld.MovedLumberjack = true;
            }
        }
    }
}