using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadSkele : SwarmSummonBase
    {
        public OverloadSkele() : base(NPCID.SkeletronHead, nameof(OverloadSkele), 40, "SuspiciousSkull")
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 5; // Puts it right after Deer Thing and Abeemination
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}