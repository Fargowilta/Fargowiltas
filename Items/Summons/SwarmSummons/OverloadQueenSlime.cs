using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadQueenSlime : SwarmSummonBase
    {
        public OverloadQueenSlime() : base(NPCID.QueenSlimeBoss, nameof(OverloadQueenSlime), 25, "JellyCrystal")
        {
        }

        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Swarm Crystal");
			// Tooltip.SetDefault("Summons several Queen Slimes\nOnly Treasure Bags will be dropped");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.QueenSlimeCrystal]; // 6
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}