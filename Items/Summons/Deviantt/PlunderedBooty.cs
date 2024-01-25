using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PlunderedBooty : BaseSummon
    {
        public override int NPCType => NPCID.PirateShip;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Plundered Booty");
            // Tooltip.SetDefault("Summons Flying Dutchman");
        }
    }
}