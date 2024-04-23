using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationSheet : ModTile
    {
        public virtual Color color => new Color(221, 85, 125);

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Omnistation");
            AddMapEntry(color, name);
            AnimationFrameHeight = 72;
        }

        public override bool CanDrop(int i, int j) => false;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                if (Main.LocalPlayer.active && !Main.LocalPlayer.dead && !Main.LocalPlayer.ghost)
                    Main.LocalPlayer.AddBuff(BuffType<Content.Buffs.Omnistation>(), 30);
            }
        }

        //public override void MouseOver(int i, int j)
        //{
        //    Player player = Main.LocalPlayer;
        //    player.noThrow = 2;
        //    player.cursorItemIconEnabled = true;
        //    player.cursorItemIconID = ItemType<Omnistation>();
        //}

        //public override bool RightClick(int i, int j)
        //{
        //    Item item = Main.LocalPlayer.HeldItem;
        //    if (item.CountsAsClass(DamageClass.Melee))
        //    {
        //        Main.LocalPlayer.AddBuff(BuffID.Sharpened, 60 * 60 * 10);
        //    }

        //    if (item.CountsAsClass(DamageClass.Ranged))
        //    {
        //        Main.LocalPlayer.AddBuff(BuffID.AmmoBox, 60 * 60 * 10);
        //    }

        //    if (item.CountsAsClass(DamageClass.Magic))
        //    {
        //        Main.LocalPlayer.AddBuff(BuffID.Clairvoyance, 60 * 60 * 10);
        //    }

        //    if (item.CountsAsClass(DamageClass.Summon))
        //    {
        //        Main.LocalPlayer.AddBuff(BuffID.Bewitched, 60 * 60 * 10);
        //    }

        //    SoundEngine.PlaySound(SoundID.Item44, new Vector2(i * 16 + 8, j * 16 + 8));

        //    return true;
        //}

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.TileFrameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(Request<Texture2D>(Texture + "_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            AnimateTile;
        }
       
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 5) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 42;
            }
        }






    }
}