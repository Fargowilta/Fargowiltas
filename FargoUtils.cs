using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
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
        public static void AddDebuffImmunities(this NPC npc, List<int> debuffs)
        {
            foreach (int buffType in debuffs)
            {
                NPCID.Sets.SpecificDebuffImmunity[npc.type][buffType] = true;
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
                string text = Language.GetTextValue("Mods.Fargowiltas.MessageInfo.NewItemUnlocked", seller);
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

        public static void PrintLocalization(string fargoKey, params object[] args) => PrintText(Language.GetTextValue($"Mods.Fargowiltas.{fargoKey}", args));

        public static void PrintLocalization(string fargoKey, Color color, params object[] args) => PrintText(Language.GetTextValue($"Mods.Fargowiltas.{fargoKey}", args), color);

        public static void SpawnBossNetcoded(Player player, int bossType)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // If the player using the item is the client
                // (explicitely excluded serverside here)
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // If the player is not in multiplayer, spawn directly
                    NPC.SpawnOnPlayer(player.whoAmI, bossType);
                }
                else
                {
                    // If the player is in multiplayer, request a spawn
                    // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, set in NPC code
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: bossType);
                }
            }
        }
    }
}
