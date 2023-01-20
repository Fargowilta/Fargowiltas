using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class LeesHeadband : BaseSummon
    {
        public override int NPCType => NPCID.BoneLee;

        public override string NPCName => "Bone Lee";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Lee's Headband");
            Tooltip.SetDefault("Summons Bone Lee" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}