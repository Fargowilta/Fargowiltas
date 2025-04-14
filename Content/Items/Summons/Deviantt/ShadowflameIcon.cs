using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class ShadowflameIcon : BaseSummon
    {
        public override int NPCType => NPCID.GoblinSummoner;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Shadowflame Icon");
            /* Tooltip.SetDefault("Summons Goblin Summoner" +
                               "\nOnly usable during Goblin Army"); */
        }

        public override bool CanUseItem(Player player)
        {
            return Main.invasionType == InvasionID.GoblinArmy;
        }
    }
}