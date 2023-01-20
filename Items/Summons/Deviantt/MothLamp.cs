using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class MothLamp : BaseSummon
    {
        public override int NPCType => NPCID.Moth;

        public override string NPCName => "Moth";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Moth Lamp");
            Tooltip.SetDefault("Summons Moth");
        }
    }
}