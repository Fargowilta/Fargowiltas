using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class MothronEgg : BaseSummon
    {
        public override int NPCType => NPCID.Mothron;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Mothron Egg");
			/* Tooltip.SetDefault("Summons Mothron" +
                               "\nOnly usable during Solar Eclipse"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SolarTablet]; // 17
		}

        public override bool CanUseItem(Player player)
        {
            return Main.eclipse;
        }
    }
}