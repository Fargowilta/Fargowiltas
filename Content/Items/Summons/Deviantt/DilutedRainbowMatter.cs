using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class DilutedRainbowMatter : BaseSummon
    {
        public override int NPCType => NPCID.RainbowSlime;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Diluted Rainbow Matter");
			// Tooltip.SetDefault("Summons Rainbow Slime");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
    }
}