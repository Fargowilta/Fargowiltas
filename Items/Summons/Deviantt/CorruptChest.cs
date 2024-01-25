using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CorruptChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicCorruption;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Corrupt Chest");
            // Tooltip.SetDefault("Summons Corrupt Mimic");
        }
    }
}