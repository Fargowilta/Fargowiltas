using Fargowiltas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class CraftingTreeItemBehavior : GlobalItem
    {
        public override bool InstancePerEntity => true;
        //true if currently part of the tree. Cannot be picked up and moves towards a set position.
        public bool PartOfTree = false;
        //true if the tree spawned this item. will be drawn special and float in the air.
        //Item will not be affected by this class at all if this is false
        public bool CameFromTree = false;
        //whether or not this item should split into its ingredients when clicked
        public bool Split = false;
        //the itemID of the item that was placed into the crafting tree tile to eventually result in the spawning of this item
        public int OriginalItem = -1;
        //The whoami of the item this came from in the order of the tree. A line will be drawn from the FromItem to this item. If -1, draw a line from the starting point of the tree to this item.
        public int FromItem = -1;
        //timer used for despawning
        public int timer = 0;
        //Timer determining if the item can be dragged with the mouse at that moment. Decreases by 1 every frame and can be dragged when at 0.
        //Will be used when a item is split into one that is on the tree and one that isnt, in order to allow the one on the tree to stop being dragged and return to its position.
        public int DragTimer = 0;
        //whoami of the player dragging this item
        public int playerDragging = -1;
        //timer used for special drawing effect
        public float DrawTimer = 0;
        //opacity to draw the item in. used to fade out when despawning.
        public float opacity = 0;
        //World position to move to while part of the tree.
        public Vector2 PositionInTree = Vector2.Zero;
        //The tile position of the tile this item came from. Kill the item if it is part of a tree that no longer exists.
        public Vector2 HomeTilePos = Vector2.Zero;
        //the item whoamis that are ingredients to this item. used for drawing lines
        public List<int> Ingredients = new List<int>();
        
        
        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(PartOfTree);
            writer.Write(CameFromTree);
            writer.Write7BitEncodedInt(FromItem);
            writer.Write7BitEncodedInt(DragTimer);
            writer.WriteVector2(PositionInTree);
            writer.WriteVector2(HomeTilePos);
            writer.Write7BitEncodedInt(playerDragging);
            writer.Write7BitEncodedInt(timer);
            writer.Write(Split);
            writer.Write(opacity);
            writer.Write7BitEncodedInt(OriginalItem);
            writer.Write7BitEncodedInt(Ingredients.Count);
            for (int i = 0; i <  Ingredients.Count; i++)
            {
                writer.Write7BitEncodedInt(Ingredients[i]);
            }
        }
        public override void NetReceive(Item item, BinaryReader reader)
        {
            PartOfTree = reader.ReadBoolean();
            CameFromTree = reader.ReadBoolean();
            FromItem = reader.Read7BitEncodedInt();
            DragTimer = reader.Read7BitEncodedInt();
            PositionInTree = reader.ReadVector2();
            HomeTilePos = reader.ReadVector2();
            playerDragging = reader.Read7BitEncodedInt();
            timer = reader.Read7BitEncodedInt();
            Split = reader.ReadBoolean();
            opacity = reader.ReadSingle();
            OriginalItem = reader.Read7BitEncodedInt();
            int count = reader.Read7BitEncodedInt();
            Ingredients = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Ingredients.Add(reader.Read7BitEncodedInt());
            }
        }
        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            if (!CameFromTree) return base.PreDrawInWorld(item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
            DrawTimer += 0.03f;
            if (DrawTimer >= 2*MathHelper.Pi) DrawTimer = 0;
            Asset<Texture2D> t = TextureAssets.Item[item.type];
            Asset<Texture2D> line = TextureAssets.Extra[178];
            //needed for true item center because item hitboxes are fucked up and for animated items
            Rectangle frame;
            Main.GetItemDrawFrame(item.type, out Texture2D useless, out frame);
            Vector2 itemCenter = item.Bottom - new Vector2(0, frame.Height / 2);

            if (PartOfTree)
            {
                //drawing lines from item to its ingredients. dont draw from FromItem to this item because it will draw in front of the fromitem which looks bad, even though that drawcode would be simpler
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    if (Main.item[Ingredients[i]].active && Main.item[Ingredients[i]] != null && Main.item[Ingredients[i]].GetGlobalItem<CraftingTreeItemBehavior>() != null && Main.item[Ingredients[i]].GetGlobalItem<CraftingTreeItemBehavior>().FromItem == item.whoAmI)
                    {
                        //once again for true item center
                        Rectangle otherFrame;
                        Main.GetItemDrawFrame(Main.item[Ingredients[i]].type, out Texture2D useless2, out otherFrame);
                        Vector2 otherCenter = Main.item[Ingredients[i]].Bottom - new Vector2(0, otherFrame.Height / 2);
                        Main.EntitySpriteDraw(line.Value, itemCenter - Main.screenPosition, null, Color.White * opacity, itemCenter.AngleTo(otherCenter), new Vector2(0, line.Height() / 2), new Vector2(otherCenter.Distance(itemCenter) * 0.002f, 1), SpriteEffects.None);
                        //line backglow
                        for (int j = 0; j < 12; j++)
                        {
                            Vector2 afterimageOffset = (MathHelper.TwoPi * j / 12f).ToRotationVector2() * 2;
                            Color glowColor = Color.White with { A = 0 } * 0.1f;


                            Main.EntitySpriteDraw(line.Value, itemCenter + afterimageOffset - Main.screenPosition, null, glowColor * opacity, itemCenter.AngleTo(otherCenter), new Vector2(0, line.Height() / 2), new Vector2(otherCenter.Distance(itemCenter) * 0.002f, 1), SpriteEffects.None);
                        }

                    }
                }
                //draw tile to item if there is no valid from item
                //turned off because it draws over the floating tile drawn item
                //if (FromItem < 0 || Main.item[FromItem] == null || !Main.item[FromItem].active || !Main.item[FromItem].GetGlobalItem<CraftingTreeItemBehavior>().PartOfTree)
                //{
                //    Vector2 pos = (HomeTilePos ).ToWorldCoordinates() + new Vector2(24, 40);
                //    Main.EntitySpriteDraw(line.Value, pos - Main.screenPosition, null, Color.White * opacity, pos.AngleTo(itemCenter), new Vector2(0, line.Height() / 2), new Vector2(itemCenter.Distance(pos) * 0.002f, 1), SpriteEffects.None);
                //}
            }
            if (CameFromTree)
            {
                //draw white shifting backglow thing and manually draw with lower alpha
                for (int i = 1; i < 6; i++)
                {
                    Main.EntitySpriteDraw(t.Value, item.Bottom + new Vector2(0, -frame.Height/2) - Main.screenPosition + new Vector2((float)Math.Sin((DrawTimer - MathHelper.PiOver2) + i), (float)Math.Cos((DrawTimer - MathHelper.PiOver2) + i))*5, frame, Color.White with { A = 70 } * opacity, 0, new Vector2(frame.Width, frame.Height)/2, item.scale, SpriteEffects.None);
                }
                Main.EntitySpriteDraw(t.Value, itemCenter - Main.screenPosition, frame, Color.White with { A = 200 } * opacity, 0, frame.Size() / 2, 1, SpriteEffects.None);
                return false;
            }


            return base.PreDrawInWorld(item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }
        public override bool OnPickup(Item item, Player player)
        {
            CameFromTree = false;
            PartOfTree = false;
            return base.OnPickup(item, player);
        }
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            base.Update(item, ref gravity, ref maxFallSpeed);
            if (!CameFromTree) return;
            //true item center and offset from "real" center
            Rectangle frame;
            Main.GetItemDrawFrame(item.type, out Texture2D useless, out frame);
            Vector2 itemCenter = item.Bottom - new Vector2(0, frame.Height / 2);
            Vector2 centerOffset = itemCenter - item.Center;

            
            if (DragTimer > 0) DragTimer--;
            //all items float
            if (CameFromTree) maxFallSpeed = 0;
            //everything to do with dragging around and clicking items
            if (CameFromTree && Main.netMode != NetmodeID.Server)
            {
                Player player = Main.LocalPlayer;
                //only drag if this player isnt dragging another item already
                bool playerIsDraggingSomethingAlready = false;
                foreach (Item fard in Main.item)
                {
                    if (fard != null && fard.active)
                    {
                        CraftingTreeItemBehavior d = fard.GetGlobalItem<CraftingTreeItemBehavior>();
                        if (d != null && d.playerDragging == player.whoAmI && fard.whoAmI != item.whoAmI) playerIsDraggingSomethingAlready = true;
                    }
                }
                //you know
                if (!player.controlUseItem && playerDragging == player.whoAmI)
                {
                    if (DragTimer < 0) DragTimer = 0;
                    playerDragging = -1;
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, number: item.whoAmI, number2: 1f);
                    }
                }
                
                //if holding and mouse close enough and part of tree (items that only came from tree are not draggable once released) and drag timer is at 0 or already being dragged and the player is not dragging a different item
                if (((player.controlUseItem && Main.MouseWorld.Distance(itemCenter) < 20 && PartOfTree && DragTimer == 0) || DragTimer == -1) && !playerIsDraggingSomethingAlready)
                {
                    //combat text of cost on first frame of drag
                    if (DragTimer != -1)
                    {
                        int fargonium = item.value / 100000 * 4;
                        fargonium += fargonium == 0 ? 1 : 0;
                        CombatText.NewText(new Rectangle((int)itemCenter.X, (int)itemCenter.Y, 0, 0), Color.Cyan, fargonium);
                    }
                    DragTimer = -1;
                    //move to mouse
                    item.Center = Vector2.Lerp(item.Center, Main.MouseWorld - centerOffset, 0.06f);
                    playerDragging = player.whoAmI;
                    //split into ingredients if havent already
                    if (!Split && PartOfTree)
                    {
                        Split = true;
                        for (int i = 0; i < Fargowiltas.UncraftingRecipes[item.type].Count; i++)
                        {
                            int jeye = Item.NewItem(item.GetSource_FromAI(), item.Center, Fargowiltas.UncraftingRecipes[item.type][i]);
                            Item ingredient = Main.item[jeye];
                            CraftingTreeItemBehavior globalI = ingredient.GetGlobalItem<CraftingTreeItemBehavior>();
                            globalI.FromItem = item.whoAmI;
                            Ingredients.Add(jeye);
                            globalI.PartOfTree = true;
                            globalI.CameFromTree = true;
                            globalI.HomeTilePos = HomeTilePos;
                            globalI.PositionInTree = PositionInTree + new Vector2(50 * (i - ((Fargowiltas.UncraftingRecipes[item.type].Count / 2)) + (Fargowiltas.UncraftingRecipes[item.type].Count % 2 == 0 ? 0.5f : 0)), -100).RotatedBy(MathHelper.ToRadians(5 * (i - ((Fargowiltas.UncraftingRecipes[item.type].Count / 2))) + (Fargowiltas.UncraftingRecipes[item.type].Count % 2 == 0 ? 0.5f : 0)));
                            globalI.PositionInTree.Y -= 100;
                            globalI.OriginalItem = OriginalItem;
                            globalI.DragTimer = 45; //dont be clickable first 45 frames so you dont accidentally buy something
                            ingredient.velocity *= 0;
                            //NetMessage.SendData(MessageID.SyncItem, number: jeye, number2: 1f);
                            if (Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.SendData(MessageID.SyncItem, number: ingredient.whoAmI, number2: 1f);
                            }
                        }
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncItem, number: item.whoAmI, number2: 1f);
                    }
                }
                
            }
            if (PartOfTree)
            {
                
                timer++;
                //reduce opacity if shouldnt exist anymore and kill when opacity is 0
                if (OriginalItem < 0 || timer > 4000 || Main.tile[HomeTilePos.ToPoint()].TileType != ModContent.TileType<CraftingTreeSheet>() || FargoUtils.GetTopLeftTileInMultitile((int)HomeTilePos.X, (int)HomeTilePos.Y) != HomeTilePos.ToPoint16() || !FargoUtils.TryGetTileEntityAs<CraftingTreeTileEntity>((int)HomeTilePos.X, (int)HomeTilePos.Y, out CraftingTreeTileEntity entity) || entity == null || entity.Item == null || entity.Item.type != OriginalItem)
                {
                    opacity -= 0.05f;
                    if (opacity <= 0)
                    {
                        item.active = false;
                    }
                }
                //if should exist and opacity is low, increase opacity and play sound if opacity is 0 (spawning sound effect)
                else if (opacity < 1)
                {
                    if (opacity == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        SoundEngine.PlaySound(SoundID.Item130 with { Pitch = 0.25f }, item.Center);
                    }
                    opacity += 0.05f;
                }
                //start opacity reduction if it came from another item in the tree but that item is fake
                if (FromItem != -1 && !Main.item[FromItem].active)
                {
                    timer = 4001;
                }
            }
            //same fade in code but for items that arent part of tree
            if (CameFromTree && !PartOfTree)
            {
                if (opacity < 1)
                {
                    opacity += 0.05f;
                }
            }
            //move to its position. will fight against dragging movement but dragging is stronger (intended)
            if (PositionInTree != Vector2.Zero && PartOfTree)
            {
                item.Center = Vector2.Lerp(item.Center, PositionInTree - centerOffset, 0.03f);
            }
            //split into collectable item and stop being dragged and make the collectable item be dragged instead
            if (item.Distance(PositionInTree) > 100 && PartOfTree && DragTimer == -1 && playerDragging >= 0)
            {
                int fargonium = item.value / 100000 * 4;
                fargonium += fargonium == 0 ? 1 : 0;
                Player player = Main.player[playerDragging];
                //only dupe if player has the coin on hand
                if (player != null && player.active && player.CountItem(ModContent.ItemType<Misc.Fargonium>()) >= fargonium)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Item newItem = Main.item[Item.NewItem(item.GetSource_FromAI(), item.Center, item.type, 1)];
                        CraftingTreeItemBehavior globalI = newItem.GetGlobalItem<CraftingTreeItemBehavior>();
                        globalI.DragTimer = -1;
                        globalI.CameFromTree = true;
                        globalI.HomeTilePos = HomeTilePos;
                        globalI.playerDragging = playerDragging;
                        SoundEngine.PlaySound(SoundID.Item176 with { Pitch = 3f }, item.Center);
                        for (int i = 0; i < fargonium; i++) player.ConsumeItem(ModContent.ItemType<Misc.Fargonium>());
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncItem, number: newItem.whoAmI);
                        }
                    }
                }
                //erm, what the freak you have no coin
                else
                {
                    SoundEngine.PlaySound(SoundID.Item150 with { Pitch = -10f }, item.Center);
                    
                }
                playerDragging = -1;
                DragTimer = 30;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncItem, number: item.whoAmI);
                }
            }

            
        }
        public override bool CanPickup(Item item, Player player)
        {
            return !PartOfTree;
        }
    }
}
