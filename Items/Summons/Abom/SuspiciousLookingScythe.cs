using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SuspiciousLookingScythe : BaseSummon
    {
        public override int NPCType => NPCID.Pumpking;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Suspicious Looking Scythe");
			/* Tooltip.SetDefault("Summons Pumpking" +
                               "\nOnly usable at night"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.PumpkinMoonMedallion]; // 14
		}

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;
    }
}