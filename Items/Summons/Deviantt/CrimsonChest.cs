using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CrimsonChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicCrimson;

        public override string NPCName => "Crimson Mimic";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Crimson Chest");
            Tooltip.SetDefault("Summons Crimson Mimic");
        }
    }
}