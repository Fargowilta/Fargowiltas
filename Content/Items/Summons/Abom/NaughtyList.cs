using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Abom
{
    public class NaughtyList : BaseSummon
    {
        public override int NPCType => NPCID.SantaNK1;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Naughty List");
            /* Tooltip.SetDefault("Summons Santa-NK1" +
                               "\nOnly usable at night"); */
        }

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;
    }
}