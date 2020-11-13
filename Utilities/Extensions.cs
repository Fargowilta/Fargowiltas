using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Utilities
{
    public static class Extensions
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
    }
}
