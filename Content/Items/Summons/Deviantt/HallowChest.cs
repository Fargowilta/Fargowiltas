using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class HallowChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicHallow;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Hallow Chest");
            // Tooltip.SetDefault("Summons Hallowed Mimic");
        }
    }
}