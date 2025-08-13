using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadEye : SwarmSummonBase
    {
        public OverloadEye() : base(NPCID.EyeofCthulhu, nameof(OverloadEye), 50, ItemID.SuspiciousLookingEye)
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SuspiciousLookingEye]; // 1
        }
        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && FargoUtils.ActuallyNight;
        }
    }
}