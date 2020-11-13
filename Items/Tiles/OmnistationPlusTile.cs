using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class OmnistationPlusTile : ModTile
    {
        public virtual Color Color => new Color(221, 85, 125);

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Omnistation+");
            AddMapEntry(Color, name);
            // TODO: Uncomment when tML adds this back
            // disableSmartCursor = true;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                if (Main.LocalPlayer.active && !Main.LocalPlayer.dead)
                {
                    Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.OmnistationPlus>(), 10);

                    if (Fargowiltas.ModLoaded("CalamityMod"))
                    {
                        Calamity();
                    }
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

            if (item.DamageType == DamageClass.Melee)
            {
                Main.LocalPlayer.AddBuff(BuffID.Sharpened, 60 * 60 * 10);
            }

            if (item.DamageType == DamageClass.Ranged)
            {
                Main.LocalPlayer.AddBuff(BuffID.AmmoBox, 60 * 60 * 10);
            }

            if (item.DamageType == DamageClass.Magic)
            {
                Main.LocalPlayer.AddBuff(BuffID.Clairvoyance, 60 * 60 * 10);
            }

            if (item.DamageType == DamageClass.Summon)
            {
                Main.LocalPlayer.AddBuff(BuffID.Bewitched, 60 * 60 * 10);
            }

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                Thorium(item, i, j);
            }

            if (item.DamageType == DamageClass.Melee || item.DamageType == DamageClass.Ranged || item.DamageType == DamageClass.Magic || item.DamageType == DamageClass.Summon)
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

            Main.spriteBatch.Draw(ModContent.GetTexture("Fargowiltas/Items/Tiles/OmnistationSheet_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, tile.frameY == 36 ? 18 : 16), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        private void Thorium(Item item, int i, int j)
        {
            // TODO: BardItem & HealerItem
            /*BardItem bardItem = item.modItem as BardItem;
            ThoriumItem healerItem = item.modItem as ThoriumItem;

            //if (item.thrown)
            //{
            //    Main.LocalPlayer.AddBuff(thorium.BuffType("NinjaBuff"), 60 * 60 * 10);
            //}

            if (bardItem != null && bardItem.item.damage > 0)
            {
                Main.LocalPlayer.AddBuff(thorium.BuffType("ConductorBuff"), 60 * 60 * 10);
            }

            if (healerItem != null && healerItem.isHealer)
            {
                Main.LocalPlayer.AddBuff(thorium.BuffType("SpiritualConnection"), 60 * 60 * 10);
            }

            if ((bardItem != null && bardItem.item.damage > 0) || (healerItem != null && healerItem.isHealer)) // || item.thrown
            {
                SoundEngine.PlaySound(SoundID.Item44, i * 16 + 8, j * 16 + 8);
            }*/
        }

        private void Calamity()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].friendly)
                    {
                        Main.npc[k].buffImmune[Fargowiltas.LoadedMods["CalamityMod"].BuffType("YellowDamageCandle")] = false;

                        // TODO: CalamityGlobalNPC
                        /*if (Main.npc[k].GetGlobalNPC<CalamityGlobalNPC>().DR >= 0.99f)
                        {
                            Main.npc[k].buffImmune[Fargowiltas.LoadedMods["CalamityMod"].BuffType("YellowDamageCandle")] = true;
                        }*/

                        Main.npc[k].AddBuff(Fargowiltas.LoadedMods["CalamityMod"].BuffType("YellowDamageCandle"), 0x14, false);
                    }
                }
            }
        }
    }
}