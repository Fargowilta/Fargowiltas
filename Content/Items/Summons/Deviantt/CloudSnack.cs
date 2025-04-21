using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class CloudSnack : BaseSummon
    {
        public override int NPCType => NPCID.WyvernHead;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Cloud Snack");
			// Tooltip.SetDefault("Summons Wyvern");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
    }
}