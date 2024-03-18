
using Fargowiltas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace Fargowiltas.Items.Tiles
{
    public class CraftingTreeSheet : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            DustType = DustID.Stone;
            AddMapEntry(Color.DarkGray);
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 6;
            TileObjectData.newTile.Height = 8;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16, 18 };
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<CraftingTreeTileEntity>().Hook_AfterPlacement, -3, 0, false);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.addTile(Type);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            //drop item currently inside it
            if (FargoUtils.TryGetTileEntityAs<CraftingTreeTileEntity>(i, j, out CraftingTreeTileEntity entity) == true && entity.Item != null && entity.Item.type >= ItemID.None)
            {
                
                int item = Item.NewItem(Item.GetSource_NaturalSpawn(), new Rectangle(i*16 + 50, j*16 + 50, 1, 1), entity.Item.type, 1, prefixGiven:entity.Item.prefix);
                NetMessage.SendData(MessageID.SyncItem, item);
            }
            ModContent.GetInstance<CraftingTreeTileEntity>().Kill(i, j);
            base.KillMultiTile(i, j, frameX, frameY);
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            
            base.PostDraw(i, j, spriteBatch);
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            //allow drawing in front of the tile
            if (new Point16(i, j) == FargoUtils.GetTopLeftTileInMultitile(i, j))
            {
                Main.instance.TilesRenderer.AddSpecialLegacyPoint(i, j);
            }
        }
        //timer for drawing disco backglow
        public float drawTimer = 0;
        public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
        {
            drawTimer += 0.1f;
            //arbitrary number change to a multiple of 2 pi if theres a noticeable cut in the rotation of the backglow but make sure you change float x to be correct if you do
            if (drawTimer >= 20)
            {
                drawTimer = 0;
            }
            //lerp values, lerper is a bell curve
            float x = drawTimer / 20f;
            float lerper = (float)Math.Sin(6 * x - 1.5) / 2 + 0.5f;

            
            CraftingTreeTileEntity entity = null;
            FargoUtils.TryGetTileEntityAs<CraftingTreeTileEntity>(i, j, out entity);

            if (entity == null || entity.Item == null)
            {
                return;
            }
            
            Asset<Texture2D> item = TextureAssets.Item[entity.Item.type];
            Main.instance.LoadItem(entity.Item.type);
            //needed for animated item sprites
            Rectangle frame;
            Main.GetItemDrawFrame(entity.Item.type, out Texture2D useless, out frame);
            //disco backglow
            for (int n = 0; n < 5; n++)
            {
                Main.EntitySpriteDraw(item.Value, new Vector2(i, j).ToWorldCoordinates() - Main.screenPosition + new Vector2(230 + (float)Math.Sin(drawTimer + n*2f)*3, 280 + MathHelper.Lerp(-10, 10, lerper) + (float)Math.Cos(drawTimer + n*3f)*3), frame, Main.DiscoColor * 0.5f, 0, new Vector2(frame.Width, frame.Height) / 2, 1, SpriteEffects.None, 0);
            }
            //real item
            Main.EntitySpriteDraw(item.Value, new Vector2(i, j).ToWorldCoordinates() - Main.screenPosition + new Vector2(230, 280 + MathHelper.Lerp(-10, 10, lerper)), frame, Color.White, 0, new Vector2(frame.Width, frame.Height)/2, 1, SpriteEffects.None, 0);
            

            base.SpecialDraw(i, j, spriteBatch);
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player != null && player.active && !player.dead && Main.netMode != NetmodeID.Server)
            {
                FargoUtils.TryGetTileEntityAs<CraftingTreeTileEntity>(i, j, out CraftingTreeTileEntity entity);
                //set tile entity's item to held item of the player and reduce stack of player's held item
                if (entity != null && player.HeldItem != null && player.HeldItem.type >= ItemID.None && entity.Item == null && player.HeldItem.stack > 0)
                {
                    entity.Item = player.HeldItem;
                    player.HeldItem.stack -= 1;
                    NetMessage.SendData(MessageID.TileEntitySharing, number: entity.ID, number2: entity.Position.X, number3: entity.Position.Y);
                }
                //if the entity has item already drop it and set it to null
                else if (entity != null && entity.Item != null)
                {
                    int it = Item.NewItem(player.GetSource_TileInteraction(i, j), new Vector2(i, j).ToWorldCoordinates(), entity.Item.type, 1, prefixGiven: entity.Item.prefix);
                    NetMessage.SendData(MessageID.SyncItem, player.whoAmI, number: it, number2: 1f);
                    entity.Item = null;
                    NetMessage.SendData(MessageID.TileEntitySharing, number: entity.ID, number2: entity.Position.X, number3: entity.Position.Y);
                }
                //spawning first item in the tree
                if (entity != null && entity.Item != null && Fargowiltas.UncraftingAllowedItems.Contains(entity.Item.type))
                {
                    //dont spawn it if it already exists (might be left over if the player spams putting in and taking out the same item fast enough)
                    bool hasItemAlready = false;
                    for (int k = 0; k < Main.item.Length; k++)
                    {
                        Item grah = Main.item[k];
                        if (grah != null && grah.active && grah.GetGlobalItem<CraftingTreeItemBehavior>() != null && grah.GetGlobalItem<CraftingTreeItemBehavior>().HomeTilePos.ToPoint16() == FargoUtils.GetTopLeftTileInMultitile(i, j) && grah.type == entity.Item.type && grah.GetGlobalItem<CraftingTreeItemBehavior>().FromItem == -1 && grah.GetGlobalItem<CraftingTreeItemBehavior>().PartOfTree)
                        {
                            hasItemAlready = true;
                        }
                    }
                    if (!hasItemAlready)
                    {
                        //i farded
                        
                        int it = Item.NewItem(player.GetSource_TileInteraction(i, j), new Vector2(i, j).ToWorldCoordinates(), entity.Item.type, 1, prefixGiven: entity.Item.prefix);
                        Item fard = Main.item[it];
                        CraftingTreeItemBehavior farg = fard.GetGlobalItem<CraftingTreeItemBehavior>();
                        farg.CameFromTree = true;
                        farg.PartOfTree = true;
                        farg.PositionInTree = entity.Position.ToWorldCoordinates() + new Vector2(40, -50);
                        fard.position = entity.Position.ToWorldCoordinates() + new Vector2(30, 80);
                        farg.HomeTilePos = FargoUtils.GetTopLeftTileInMultitile(i, j).ToVector2();
                        farg.OriginalItem = entity.Item.type;
                        fard.velocity *= 0;
                        NetMessage.SendData(MessageID.SyncItem, number: it, number2: 1f);
                        //if (Main.netMode == NetmodeID.MultiplayerClient)
                        //{
                        //    FargoNet.SyncCraftingTreeBehavior(fard, farg, true);
                        //}
                    }
                }
            }
            return base.RightClick(i, j);
        }
    }
}
