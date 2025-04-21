using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class FestiveOrnament : BaseSummon
    {
        public override int NPCType => NPCID.Everscream;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Festive Ornament");
            /* Tooltip.SetDefault("Summons Everscream" +
                               "\nOnly usable at night"); */

            ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.NaughtyPresent]; // 15
		}

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;
    }
}