﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationSheet : ModTile
    {
        public virtual Color color => new Color(221, 85, 125);

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Omnistation");
            AddMapEntry(color, name);
            // TODO: Uncomment when tML adds this back
            //disableSmartCursor = true;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                if (Main.LocalPlayer.active && !Main.LocalPlayer.dead)
                {
                    Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.Omnistation>(), 10);
                }
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<Omnistation>();
        }

        public override bool RightClick(int i, int j)
        {
            Item item = Main.LocalPlayer.HeldItem;

            if (item.melee)
            {
                Main.LocalPlayer.AddBuff(BuffID.Sharpened, 60 * 60 * 10);
            }

            if (item.ranged)
            {
                Main.LocalPlayer.AddBuff(BuffID.AmmoBox, 60 * 60 * 10);
            }

            if (item.magic)
            {
                Main.LocalPlayer.AddBuff(BuffID.Clairvoyance, 60 * 60 * 10);
            }

            if (item.summon)
            {
                Main.LocalPlayer.AddBuff(BuffID.Bewitched, 60 * 60 * 10);
            }

            if (item.melee || item.ranged || item.magic || item.summon)
            {
                SoundEngine.PlaySound(SoundID.Item44, i * 16 + 8, j * 16 + 8);
            }

            return true;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            int height = tile.frameY == 36 ? 18 : 16;

            Main.spriteBatch.Draw(ModContent.GetTexture("Fargowiltas/Items/Tiles/OmnistationSheet_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}