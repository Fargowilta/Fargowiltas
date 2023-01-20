using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;

namespace Fargowiltas
{
    internal static class FargoUtils
    {
        public static bool HasAnyItem(this Player player, params int[] itemIDs) => itemIDs.Any(itemID => player.HasItem(itemID));

        public static FargoPlayer GetFargoPlayer(this Player player) => player.GetModPlayer<FargoPlayer>();

        public static void AddWithCondition<T>(this List<T> list, T type, bool condition)
        {
            if (condition)
            {
                list.Add(type);
            }
        }

        public static void TryDowned(NPC npc, string seller, Color color, params string[] names)
        {
            TryDowned(npc, seller, color, true, names);
        }

        // condition is so that display text is hidden if the kill is done early, BUT the kill is still counted
        // e.g. kill an enemy early, whose spawner is sold in hm, then get into hm, then spawner is unlocked
        // however, text is hidden on that first kill so people don't think it's sold right away
        public static void TryDowned(NPC npc, string seller, Color color, bool conditions, params string[] names)
        {
            bool update = false;

            foreach (string name in names)
            {
                if (!FargoWorld.DownedBools[name])
                {
                    FargoWorld.DownedBools[name] = true;
                    update = true;
                }
            }

            if (update)
            {
                string text = $"A new item has been unlocked in {seller}'s shop!";
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    if (conditions)
                        Main.NewText(text, color);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    if (conditions)
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
                    NetMessage.SendData(MessageID.WorldData); //sync world
                }
            }
        }

        public static void PrintText(string text)
        {
            PrintText(text, Color.White);
        }

        public static void PrintText(string text, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, color);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
            }
        }

        public static void PrintText(string text, int r, int g, int b) => PrintText(text, new Color(r, g, b));
    }
}
