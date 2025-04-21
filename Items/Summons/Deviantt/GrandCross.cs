using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GrandCross : BaseSummon
    {
        public override int NPCType => NPCID.Paladin;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Grand Cross");
			/* Tooltip.SetDefault("Summons Paladin" +
                               "\nOnly usable at night or underground"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 13; // Places it right before Pumpkin Moon Medallion and Naughty Present
		}

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}