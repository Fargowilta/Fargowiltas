using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ClownLicense : BaseSummon
    {
        public override int NPCType => NPCID.Clown;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Clown License");
            /* Tooltip.SetDefault("Summons Clown" +
                               "\nOnly usable at night or underground"); */
        }

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}