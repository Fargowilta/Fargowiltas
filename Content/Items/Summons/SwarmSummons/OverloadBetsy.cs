using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadBetsy : SwarmSummonBase
    {
        public OverloadBetsy() : base(NPCID.DD2Betsy, nameof(OverloadBetsy), 25, "BetsyEgg")
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 17; // Puts it right after Lihzahrd Power Cell and Solar Tablet
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}