using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadSlimeCrown : SwarmSummonBase
    {
        public OverloadSlimeCrown() : base(NPCID.KingSlime, nameof(OverloadSlimeCrown), 50, "SlimyCrown")
        {
        }

        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Swarm Crown");
			// Tooltip.SetDefault("Summons several King Slimes\nOnly Treasure Bags will be dropped");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SlimeCrown]; // 2
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}