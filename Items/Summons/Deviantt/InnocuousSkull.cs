using Fargowiltas.Utilities;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    [Autoload(false)]
    public class InnocuousSkull : BaseSummon
    {
        public override string Texture => "Fargowiltas/Items/Placeholder";

        public override int NPCType => Fargowiltas.LoadedMods["FargowiltasSouls"].NPCType("BabyGuardian");

        public override string NPCName => "Baby Guardian";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Innocuous Skull");
            Tooltip.SetDefault("Summons Baby Guardian");
        }
    }
}