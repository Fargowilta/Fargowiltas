using Terraria.ID;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class CultistSummon : BaseSummon
    {
        public override int NPCType => NPCID.CultistBoss;

        public override string NPCName => "Lunatic Cultist";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Zealot's Possession");
            Tooltip.SetDefault("Summons the Lunatic Cultist\nDoes not spawn the pillars if Lunatic Cultist has been defeated before");
        }
    }
}