using Fargowiltas.Common.Configs;
using Fargowiltas.Items.Tiles;
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

namespace Fargowiltas.Content.TileEntities
{
    public class CraftingTreeTileEntity : ModTileEntity
    {
        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            Console.WriteLine(tile.HasTile);

            return tile.HasTile && tile.TileType == ModContent.TileType<CraftingTreeSheet>();
        }
        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                int width = 3;
                int height = 4;
                NetMessage.SendTileSquare(Main.myPlayer, i, j, width, height);
                NetMessage.SendData(MessageID.TileEntityPlacement, number: i, number2: j, number3: Type);
                return -1;
            }

            int placedEntity = Place(i, j);
            return placedEntity;
        }
        public override void OnNetPlace()
        {
            if (Main.netMode == NetmodeID.Server)
            {

                NetMessage.SendData(MessageID.TileEntitySharing, number: ID, number2: Position.X, number3: Position.Y);
            }
        }
        //ID of item held for saving
        public int ItemType = -1;
        //internal name of item held (takes priority, for modded items)
        public string ItemName = "";
        //reforge of held item
        public int Prefix = 0;
        public override void SaveData(TagCompound tag)
        {
            //dont save item if its null because ItemIO.Save will fuck up
            tag["ItemID"] = ItemType;
            tag["Prefix"] = Prefix;
            tag["ItemName"] = ItemName;
        }
        public override void LoadData(TagCompound tag)
        {
            //only load if the bool sent indicated item is not null
            ItemType = tag.GetAsInt("ItemID");
            Prefix = tag.GetAsInt("Prefix");
            ItemName = tag.GetString("ItemName");
        }
        //same concept as save and load
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write7BitEncodedInt(ItemType);
            writer.Write7BitEncodedInt(Prefix);
            writer.Write(ItemName);
        }
        public override void NetReceive(BinaryReader reader)
        {
            ItemType = reader.Read7BitEncodedInt();
            Prefix = reader.Read7BitEncodedInt();
            ItemName = reader.ReadString();
        }
    }
}
