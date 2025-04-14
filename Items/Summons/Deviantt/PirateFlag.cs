using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PirateFlag : BaseSummon
    {
        public override int NPCType => NPCID.PirateCaptain;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Pirate Flag");
			// Tooltip.SetDefault("Summons Pirate Captain");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.PirateMap]; // 11
		}
    }
}