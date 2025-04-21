using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class DemonicPlushie : BaseSummon
    {
        public override int NPCType => NPCID.RedDevil;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Demonic Plushie");
			/* Tooltip.SetDefault("Summons Red Devil" +
                               "\nOnly usable in the Underworld"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 10; // Places it right after the three mech boss summons
		}

        public override bool CanUseItem(Player player)
        {
            return player.ZoneUnderworldHeight;
        }
    }
}