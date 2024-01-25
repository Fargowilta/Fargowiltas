using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SlimyLockBox : BaseSummon
    {
        public override int NPCType => NPCID.DungeonSlime;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Slimy Lock Box");
            // Tooltip.SetDefault("Summons Dungeon Slime");
        }
    }
}