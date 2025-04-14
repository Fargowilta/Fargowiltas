using Fargowiltas.Content.Items.Summons;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
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