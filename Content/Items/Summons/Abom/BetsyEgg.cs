using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Abom
{
    public class BetsyEgg : BaseSummon
    {
        public override int NPCType => NPCID.DD2Betsy;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 17; // Places it right after Solar Tablet
		}
    }
}