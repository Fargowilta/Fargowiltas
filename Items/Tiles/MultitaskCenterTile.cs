using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class MultitaskCenterTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Multitask Center");
            AddMapEntry(new Color(200, 200, 200), name);
            // TODO: Uncomment when tML adds this back
            //disableSmartCursor = true;

            //counts as
            adjTiles = new int[] { TileID.WorkBenches, TileID.HeavyWorkBench, TileID.Furnaces, TileID.Anvils, TileID.Bottles, TileID.Sawmill, TileID.Loom, TileID.Tables, TileID.Chairs, TileID.CookingPots, TileID.Sinks, TileID.Kegs };
            animationFrameHeight = 54;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<MultitaskCenter>());
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;

            if (frameCounter >= 10) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 7;
            }
        }
    }
}