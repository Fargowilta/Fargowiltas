using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class LeesHeadband : BaseSummon
    {
        public override int NPCType => NPCID.BoneLee;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Lee's Headband");
			/* Tooltip.SetDefault("Summons Bone Lee" +
                               "\nOnly usable at night or underground"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 13; // Places it right before Pumpkin Moon Medallion and Naughty Present
		}

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}