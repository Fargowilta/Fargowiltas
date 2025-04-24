using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class BatteredClub : BaseSummon
    {
        public override int NPCType => NPCID.DD2OgreT2;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Battered Club");
			// Tooltip.SetDefault("Summons the Ogre");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 11; // Places it right after Pirate Map
		}
    }
}