using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : BaseSummon
    {
        public override int NPCType => Main.LocalPlayer.ZoneSnow ? NPCID.IceMimic : NPCID.Mimic;

        public override string NPCName => "Mimic";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Suspicious Looking Chest");
            Tooltip.SetDefault("Summons Mimic"
            + "\nSummons Ice Mimic when in snow biome");
        }
    }
}
