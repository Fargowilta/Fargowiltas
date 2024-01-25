using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class ForbiddenTome : BaseSummon
    {
        public override int NPCType => NPCID.DD2DarkMageT1;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Forbidden Tome");
            // Tooltip.SetDefault("Summons a Dark Mage");
        }
    }
}