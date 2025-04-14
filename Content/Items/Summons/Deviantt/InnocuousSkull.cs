//using Terraria.ID;
//using Terraria.ModLoader;

//namespace Fargowiltas.Items.Summons.Deviantt
//{
//    public class InnocuousSkull : BaseSummon
//    {
//        public override string Texture => "Fargowiltas/Items/Placeholder";

//        public override int Type => ModLoader.GetMod("FargowiltasSouls").NPCType("BabyGuardian");

//        public override string NPCName => "Baby Guardian";

//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Innocuous Skull");
//            Tooltip.SetDefault("Summons Baby Guardian");
//        }

//        public override bool Autoload(ref string name)
//        {
//            return ModLoader.GetMod("FargowiltasSouls") != null;
//        }
//    }
//}