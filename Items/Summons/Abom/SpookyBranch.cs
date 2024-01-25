using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SpookyBranch : BaseSummon
    {
        public override int NPCType => NPCID.MourningWood;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Spooky Branch");
            /* Tooltip.SetDefault("Summons Mourning Wood" +
                               "\nOnly usable at night"); */
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;
    }
}