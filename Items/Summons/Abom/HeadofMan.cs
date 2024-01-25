using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class HeadofMan : BaseSummon
    {
        public override int NPCType => NPCID.HeadlessHorseman;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Head of Man");
            /* Tooltip.SetDefault("Summons Headless Horseman" +
                              "\nOnly usable at night"); */
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;
    }
}