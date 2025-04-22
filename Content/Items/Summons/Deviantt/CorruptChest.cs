using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class CorruptChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicCorruption;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Corrupt Chest");
			// Tooltip.SetDefault("Summons Corrupt Mimic");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
    }
}