using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class ElementalAssemblerTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Elemental Assembler");
            AddMapEntry(new Color(200, 200, 200), name);
            // TODO: Uncomment when tML adds this back
            // disableSmartCursor = true;

            //counts as
            adjTiles = new int[] { TileID.Hellforge, TileID.Furnaces, TileID.AlchemyTable, TileID.TinkerersWorkbench, TileID.ImbuingStation, TileID.DyeVat, TileID.LivingLoom, TileID.GlassKiln, TileID.IceMachine, TileID.HoneyDispenser, TileID.SkyMill, TileID.Solidifier, TileID.BoneWelder, TileID.Bottles };
            animationFrameHeight = 54;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

        public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<ElementalAssembler>());

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;

            if (frameCounter >= 10) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 12;
            }
        }
    }
}