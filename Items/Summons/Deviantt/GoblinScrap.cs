using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GoblinScrap : BaseSummon
    {
        public override int NPCType => NPCID.GoblinScout;

        public override string NPCName => "Goblin Scout";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Goblin Scrap");
            Tooltip.SetDefault("Summons Goblin Scout");
        }
    }
}