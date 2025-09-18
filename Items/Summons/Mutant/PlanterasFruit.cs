using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class PlanterasFruit : BaseSummon
    {
        public override int NPCType => NPCID.Plantera;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Plantera's Fruit");
			// Tooltip.SetDefault("Summons Plantera");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 11; // Places it right after the three mech summons and Pirate Map, but before the Truffle Worm
		}

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.ChlorophyteBar, 2)
               .AddIngredient(ItemID.Moonglow, 5)
               .AddIngredient(ItemID.Blinkroot, 5)
               .AddTile(TileID.DemonAltar)
               .DisableDecraft()
               .Register();
        }
    }
}