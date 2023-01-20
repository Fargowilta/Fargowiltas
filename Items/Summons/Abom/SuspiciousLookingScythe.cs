using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SuspiciousLookingScythe : BaseSummon
    {
        public override int NPCType => NPCID.Pumpking;

        public override string NPCName => "Pumpking";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Suspicious Looking Scythe");
            Tooltip.SetDefault("Summons Pumpking" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;
    }
}