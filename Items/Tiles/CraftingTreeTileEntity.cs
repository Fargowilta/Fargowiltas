using Fargowiltas.Common.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas.Items.Tiles
{
    public class CraftingTreeTileEntity : ModTileEntity
    {
        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return tile.HasTile && tile.TileType == ModContent.TileType<CraftingTreeSheet>();
        }
        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                int width = 6;
                int height = 8;
                NetMessage.SendTileSquare(Main.myPlayer, i, j, width, height);
                NetMessage.SendData(MessageID.TileEntityPlacement, number: i, number2: j, number3: Type);
            }
            Point16 tileOrigin = new Point16(1, 2);
            int placedEntity = Place(i - tileOrigin.X, j - tileOrigin.Y);
            return placedEntity;
        }
        public override void OnNetPlace()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.TileEntitySharing, number: ID, number2: Position.X, number3: Position.Y);
            }
        }
        public Item Item = null;
        public override void SaveData(TagCompound tag)
        {
            //dont save item if its null because ItemIO.Save will fuck up
            if (Item == null)
            {
                tag["hasItem"] = false;
            }
            else
            {
                tag["hasItem"] = true;
                tag["treeItem"] = ItemIO.Save(Item);
            }
        }
        public override void LoadData(TagCompound tag)
        {
            //only load if the bool sent indicated item is not null
            bool item = tag.Get<bool>("hasItem");
            if (item)
            {
                Item = ItemIO.Load((TagCompound)tag["treeItem"]);
            }
        }
        //same concept as save and load
        public override void NetSend(BinaryWriter writer)
        {
            if (Item == null)
            {
                writer.Write(false);
            }
            else
            {
                writer.Write(true);
                ItemIO.Send(Item, writer);
            }
        }
        public override void NetReceive(BinaryReader reader)
        {
            bool realItem = reader.ReadBoolean();
            if (realItem)
            {
                Item = ItemIO.Receive(reader);
            }
            else
            {
                Item = null;
            }
        }
    }
}
