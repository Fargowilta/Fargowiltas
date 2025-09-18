using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadBee : SwarmSummonBase
    {
        public OverloadBee() : base(NPCID.QueenBee, nameof(OverloadBee), 50, "Abeemination2")
        {
        }

        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Overstuffed Larva");
			// Tooltip.SetDefault("Summons several Queen Bees\nOnly Treasure Bags will be dropped");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.Abeemination]; // 5
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}