using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public static class FargoNet
    {
        public const byte summonNPCFromClient = 0;
        public const bool debug = true;

        public static void SendData(int dataType, int dataA, int dataB, string text, int playerID, float dataC, float dataD, float dataE, int clientType) => NetMessage.SendData(dataType, dataA, dataB, NetworkText.FromLiteral(text), playerID, dataC, dataD, dataE, clientType);

        public static ModPacket WriteToPacket(ModPacket packet, byte msg, params object[] param)
        {
            packet.Write(msg);

            for (int m = 0; m < param.Length; m++)
            {
                object obj = param[m];

                switch (obj)
                {
                    case byte[] _:
                        {
                            byte[] array = (byte[])obj;

                            foreach (byte b in array)
                            {
                                packet.Write(b);
                            }

                            break;
                        }

                    case bool _:
                        packet.Write((bool)obj);
                        break;

                    case byte _:
                        packet.Write((byte)obj);
                        break;

                    case short _:
                        packet.Write((short)obj);
                        break;

                    case int _:
                        packet.Write((int)obj);
                        break;

                    case float _:
                        packet.Write((float)obj);
                        break;
                }
            }

            return packet;
        }

        public static void SyncAI(Entity codable, float[] ai, int aitype)
        {
            int entityType = codable is NPC ? 0 : codable is Projectile ? 1 : -1;

            if (entityType != -1)
            {
                SyncAI(entityType, codable is NPC ? ((NPC)codable).whoAmI : ((Projectile)codable).identity, ai, aitype);
            }
        }

        /// <summary>
        /// Used to sync custom AI float arrays. (The NPC or Projectile requires a method called <c>public void SetAI(float[] ai, int type)</c> that sets the AI for this to work.)
        /// </summary>
        /// <param name="entType"></param>
        /// <param name="id"></param>
        /// <param name="ai"></param>
        /// <param name="aitype"></param>
        public static void SyncAI(int entType, int id, float[] ai, int aitype)
        {
            object[] ai2 = new object[ai.Length + 4];
            ai2[0] = (byte)entType;
            ai2[1] = (short)id;
            ai2[2] = (byte)aitype;
            ai2[3] = (byte)ai.Length;

            for (int i = 4; i < ai2.Length; i++)
            {
                ai2[i] = ai[i - 4];
            }

            SendFargoNetMessage(1, ai2);
        }

        /// <summary>
        /// Writes a <c>Vector2</c> array to an <c>obj[]</c> array that can be sent via NetMessaging.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static object[] WriteVector2Array(Vector2[] array)
        {
            List<object> list = new List<object>
            {
                array.Length,
            };

            foreach (Vector2 vec in array)
            {
                list.Add(vec.X);
                list.Add(vec.Y);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Writes a <c>Vector2</c> array to a binary writer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="writer"></param>
        public static void WriteVector2Array(Vector2[] array, BinaryWriter writer)
        {
            writer.Write(array.Length);

            foreach (Vector2 vec in array)
            {
                writer.Write(vec.X);
                writer.Write(vec.Y);
            }
        }

        /// <summary>
        /// Reads a <c>Vector2</c> array from a binary reader.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Vector2[] ReadVector2Array(BinaryReader reader)
        {
            int arrayLength = reader.ReadInt32();
            Vector2[] array = new Vector2[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            }

            return array;
        }

        public static void SendFargoNetMessage(int msg, params object[] param)
        {
            // Nothing to sync in SP
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                WriteToPacket(ModContent.GetInstance<Fargowiltas>().GetPacket(), (byte)msg, param).Send();
            }
        }

        public static void HandlePacket(BinaryReader bb)
        {
            byte msg = bb.ReadByte();

            if (debug)
            {
                ModContent.GetInstance<Fargowiltas>().Logger.Error((Main.netMode == NetmodeID.Server ? "--SERVER-- " : "--CLIENT-- ") + "HANDING MESSAGE: " + msg);
            }

            try
            {
                if (msg == summonNPCFromClient && Main.netMode == NetmodeID.Server)
                {
                    int playerID = bb.ReadByte();
                    int bossType = bb.ReadInt16();
                    bool spawnMessage = bb.ReadBoolean();
                    int npcCenterX = bb.ReadInt32();
                    int npcCenterY = bb.ReadInt32();
                    string overrideDisplayName = bb.ReadString();
                    bool namePlural = bb.ReadBoolean();

                    Fargowiltas.SpawnBoss(Main.player[playerID], bossType, spawnMessage, new Vector2(npcCenterX, npcCenterY), overrideDisplayName, namePlural);
                }
            }
            catch (Exception e)
            {
                ModContent.GetInstance<Fargowiltas>().Logger.Error((Main.netMode == NetmodeID.Server ? "--SERVER-- " : "--CLIENT-- ") + "ERROR HANDLING MSG: " + msg.ToString() + ": " + e.Message);
                ModContent.GetInstance<Fargowiltas>().Logger.Error(e.StackTrace);
                ModContent.GetInstance<Fargowiltas>().Logger.Error("-------");
            }
        }

        public static void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            if (debug)
            {
                ModContent.GetInstance<Fargowiltas>().Logger.Error((Main.netMode == NetmodeID.Server ? "--SERVER-- " : "--CLIENT-- ") + "SYNC PLAYER CALLED! NEWPLAYER: " + newPlayer + ". TOWHO: " + toWho + ". FROMWHO:" + fromWho);
            }

            if (Main.netMode == NetmodeID.Server && (toWho > -1 || fromWho > -1))
            {
                PlayerConnected();
            }
        }

        public static void PlayerConnected()
        {
            if (debug)
            {
                ModContent.GetInstance<Fargowiltas>().Logger.Info("--SERVER-- PLAYER JOINED!");
            }
        }

        public static void SendNetMessage(int msg, params object[] param) => SendNetMessageClient(msg, -1, param);

        public static void SendNetMessageClient(int msg, int client, params object[] param)
        {
            try
            {
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    WriteToPacket(ModContent.GetInstance<Fargowiltas>().GetPacket(), (byte)msg, param).Send(client);
                }
            }
            catch (Exception e)
            {
                ModContent.GetInstance<Fargowiltas>().Logger.Error((Main.netMode == NetmodeID.Server ? "--SERVER-- " : "--CLIENT-- ") + "ERROR SENDING MSG: " + msg.ToString() + ": " + e.Message);
                ModContent.GetInstance<Fargowiltas>().Logger.Error(e.StackTrace);
                ModContent.GetInstance<Fargowiltas>().Logger.Error("-------");

                string param2 = string.Empty;

                for (int m = 0; m < param.Length; m++)
                {
                    param2 += param[m];
                }

                ModContent.GetInstance<Fargowiltas>().Logger.Error("PARAMS: " + param2);
                ModContent.GetInstance<Fargowiltas>().Logger.Error("-------");
            }
        }
    }
}