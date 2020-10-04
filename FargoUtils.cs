﻿using ReLogic.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public static int ItemType(this Mod mod, string itemName)
        {
            mod.TryFind(itemName, out ModItem item);

            return item.Type;
        }

        public static int NPCType(this Mod mod, string npcName)
        {
            mod.TryFind(npcName, out ModNPC npc);

            return npc.Type;
        }

        public static int ProjectileType(this Mod mod, string projectileName)
        {
            mod.TryFind(projectileName, out ModProjectile projectile);

            return projectile.Type;
        }

        public static int BuffType(this Mod mod, string buffName)
        {
            mod.TryFind(buffName, out ModBuff buff);

            return buff.Type;
        }

        public static int TileType(this Mod mod, string tileName)
        {
            mod.TryFind(tileName, out ModTile tile);

            return tile.Type;
        }

        public static class NPCIDUtils
        {
            public static string GetUniqueKey(int type)
            {
                if (type <= NPCID.NegativeIDCount || type >= NPCLoader.NPCCount)
                {
                    throw new ArgumentOutOfRangeException("Invalid NPC type: " + type);
                }

                if (type < NPCID.Count)
                {
                    return "Terraria " + NPCID.Search.GetName(type);
                }

                ModNPC npc = NPCLoader.GetNPC(type);

                return npc.Mod.Name + " " + npc.Name;
            }

            public static string GetUniqueKey(NPC npc) => GetUniqueKey(npc.type);

            public static int TypeFromUniqueKey(string key)
            {
                string[] parts = key.Split(new char[] { ' ' }, 2);

                if (parts.Length != 2)
                {
                    return 0;
                }

                return TypeFromUniqueKey(parts[0], parts[1]);
            }

            public static int TypeFromUniqueKey(string mod, string name)
            {
                if (mod == "Terraria")
                {
                    if (!NPCID.Search.ContainsName(name))
                    {
                        return 0;
                    }

                    return NPCID.Search.GetId(name);
                }

                ModLoader.TryGetMod(mod, out Mod resultMod);

                return resultMod?.NPCType(name) ?? 0;
            }
        }
    }
}