using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AthenianIdol : BaseSummon
    {
        public override int NPCType => NPCID.Medusa;

        public override string NPCName => "Medusa";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Athenian Idol");
            Tooltip.SetDefault("Summons Medusa" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}