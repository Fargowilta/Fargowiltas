using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Content.Items.Tiles
{
    public class CrucibleCosmosSheet : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
            TileID.Sets.DisableSmartCursor[Type] = true;

            #region Counts as
            AdjTiles = 
                [TileID.WorkBenches, 
                TileID.HeavyWorkBench, 
                TileID.Furnaces,  
                TileID.Anvils,  
                TileID.Bottles, 
                TileID.Sawmill, 
                TileID.Loom, 
                TileID.Tables, 
                TileID.Chairs, 
                TileID.CookingPots, 
                TileID.Sinks, 
                TileID.Kegs, 
                TileID.Hellforge, 
                TileID.AlchemyTable, 
                TileID.TinkerersWorkbench, 
                TileID.ImbuingStation, 
                TileID.DyeVat, 
                TileID.LivingLoom, 
                TileID.GlassKiln, 
                TileID.IceMachine, 
                TileID.HoneyDispenser, 
                TileID.SkyMill, 
                TileID.Solidifier, 
                TileID.BoneWelder, 
                TileID.MythrilAnvil, 
                TileID.AdamantiteForge, 
                TileID.DemonAltar, 
                TileID.Bookcases, 
                TileID.CrystalBall, 
                TileID.Autohammer,  
                TileID.LunarCraftingStation, 
                TileID.LesionStation, 
                TileID.FleshCloningVat, 
                TileID.LihzahrdFurnace, 
                TileID.SteampunkBoiler, 
                TileID.Blendomatic, 
                TileID.MeatGrinder, 
                TileID.Tombstones, 
                ModContent.TileType<GoldenDippingVatSheet>()];

            TileID.Sets.CountsAsHoneySource[Type] = true;
            TileID.Sets.CountsAsLavaSource[Type] = true;
            TileID.Sets.CountsAsWaterSource[Type] = true;
            #endregion

            //if (ModLoader.GetMod("ThoriumMod") != null)
            //{
            //    Array.Resize(ref AdjTiles, AdjTiles.Length + 3);
            //    AdjTiles[AdjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil");
            //    AdjTiles[AdjTiles.Length - 2] = ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator");
            //    AdjTiles[AdjTiles.Length - 3] = ModLoader.GetMod("ThoriumMod").TileType("SoulForge");
            //}

            AnimationFrameHeight = 54;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        /*
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<CrucibleCosmos>());
        }
        */
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 5) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 16;
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.LocalPlayer.Distance(new Vector2(i * 16 + 8, j * 16 + 8)) < 16 * 5)
            {
                Main.LocalPlayer.GetModPlayer<FargoPlayer>().ElementalAssemblerNearby = 6;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Tile[Type].Value;
            int num156 = Terraria.GameContent.TextureAssets.Tile[Type].Value.Height / 16; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Main.tileFrame[Type]; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new(tile.TileFrameX, tile.TileFrameY + y3, 16, 16);
            Vector2 origin2 = rectangle.Size() / 2f;
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle?(rectangle), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}