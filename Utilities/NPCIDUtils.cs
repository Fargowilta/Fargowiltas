using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Utilities
{
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
