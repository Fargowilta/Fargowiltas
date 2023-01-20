using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class IceKingsRemains : BaseSummon
    {
        public override int NPCType => NPCID.IceQueen;

        public override string NPCName => "Ice Queen";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Ice King's Remains");
            Tooltip.SetDefault("Summons Ice Queen" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;
    }
}