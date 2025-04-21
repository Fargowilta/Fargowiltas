using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class NaughtyList : BaseSummon
    {
        public override int NPCType => NPCID.SantaNK1;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Naughty List");
			/* Tooltip.SetDefault("Summons Santa-NK1" +
                               "\nOnly usable at night"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.NaughtyPresent]; // 15
		}

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;
    }
}