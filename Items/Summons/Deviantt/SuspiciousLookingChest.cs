using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : BaseSummon
    {
        public override int NPCType => NPCID.Mimic;

        public override string NPCName => "Mimic";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Chest");
            Tooltip.SetDefault("Summons Mimic"
            + "\nSummons the Ice Mimic when in the underground snow biome");
        }
    }
}