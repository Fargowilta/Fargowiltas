using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GnomeHat : BaseSummon
    {
        public override int NPCType => NPCID.Gnome;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Gnome Hat");
			// Tooltip.SetDefault("Summons Gnome");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 0; // Places it before any other bosses
		}
    }
}