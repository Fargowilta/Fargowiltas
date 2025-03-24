using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationSheet2 : OmnistationSheet
    {
        public override Color color => new Color(102, 116, 130);

        /*public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemType<Omnistation2>();
        }*/
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            if (++frameCounter >= 6)
            {
                frameCounter = 0;

                if (++frame >= 42)
                    frame = 0;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Tile[Type].Value;
            int num156 = Terraria.GameContent.TextureAssets.Tile[Type].Value.Height / 42; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Main.tileFrame[Type]; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new(tile.TileFrameX, tile.TileFrameY + y3, 16, 16);
            Vector2 origin2 = rectangle.Size() / 2f;
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            //Rectangle frame = new(tile.TileFrameX, tile.TileFrameY + Main.tileFrame[Type], texture2D13.Width, texture2D13.Height);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(Request<Texture2D>(Texture + "_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle?(rectangle), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}