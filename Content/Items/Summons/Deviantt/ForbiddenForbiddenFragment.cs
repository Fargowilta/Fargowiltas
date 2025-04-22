using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class ForbiddenForbiddenFragment : BaseSummon
    {
        public override int NPCType => NPCID.SandElemental;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Forbidden Forbidden Fragment");
			// Tooltip.SetDefault("Summons Sand Elemental");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
    }
}