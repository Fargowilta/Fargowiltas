using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class MothLamp : BaseSummon
    {
        public override int NPCType => NPCID.Moth;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Moth Lamp");
            // Tooltip.SetDefault("Summons Moth");
        }
    }
}