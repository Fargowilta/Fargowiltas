using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class GoblinScrap : BaseSummon
    {
        public override int NPCType => NPCID.GoblinScout;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Goblin Scrap");
            // Tooltip.SetDefault("Summons Goblin Scout");
        }
    }
}