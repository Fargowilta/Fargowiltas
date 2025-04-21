using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class Pincushion : BaseSummon
    {
        public override int NPCType => NPCID.Nailhead;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Pincushion");
			/* Tooltip.SetDefault("Summons Nailhead" +
                               "\nOnly usable during Solar Eclipse"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SolarTablet]; // 17
		}

        public override bool CanUseItem(Player player)
        {
            return Main.eclipse;
        }
    }
}