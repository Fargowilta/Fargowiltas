using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Abom
{
    public class SuspiciousLookingScythe : BaseSummon
    {
        public override int NPCType => NPCID.Pumpking;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Suspicious Looking Scythe");
            /* Tooltip.SetDefault("Summons Pumpking" +
                               "\nOnly usable at night"); */
        }

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;
    }
}