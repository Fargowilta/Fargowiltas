using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CoreoftheFrostCore : BaseSummon
    {
        public override int NPCType => NPCID.IceGolem;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Core of the Frost Core");
            // Tooltip.SetDefault("Summons Ice Golem");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
    }
}