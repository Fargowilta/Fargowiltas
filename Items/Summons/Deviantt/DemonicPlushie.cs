using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class DemonicPlushie : BaseSummon
    {
        public override int NPCType => NPCID.RedDevil;

        public override string NPCName => "Red Devil";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Demonic Plushie");
            Tooltip.SetDefault("Summons Red Devil" +
                               "\nOnly usable in the Underworld");
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneUnderworldHeight;
        }
    }
}