using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HallowChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicHallow;

        public override string NPCName => "Hallowed Mimic";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hallow Chest");
            Tooltip.SetDefault("Summons Hallowed Mimic");
        }
    }
}