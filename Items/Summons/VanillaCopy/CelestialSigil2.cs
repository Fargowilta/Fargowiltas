using Terraria.ID;
using Terraria.Localization;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class CelestialSigil2 : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_3601";

        public override string NPCName => Language.GetTextValue("Enemies.MoonLord");

        public override int NPCType => NPCID.MoonLordCore;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Celestially Sigil");
			// Tooltip.SetDefault("Summons the Moon Lord instantly");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.CelestialSigil]; // 19
		}

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.CelestialSigil)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}