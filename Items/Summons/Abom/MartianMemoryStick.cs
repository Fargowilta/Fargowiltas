using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class MartianMemoryStick : BaseSummon
    {
        public override int NPCType => NPCID.MartianSaucerCore;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Martian Memory Stick");
			// Tooltip.SetDefault("Summons Martian Saucer");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 17; // Places it right after Lihzahrd Power Cell and Solar Tablet
		}
    }
}