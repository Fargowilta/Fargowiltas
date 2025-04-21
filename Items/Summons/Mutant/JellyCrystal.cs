using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class JellyCrystal : BaseSummon
    {

        public override int NPCType => NPCID.QueenSlimeBoss;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Jelly Crystal");
			// Tooltip.SetDefault("Summons Queen Slime");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.QueenSlimeCrystal]; // 6
		}

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.QueenSlimeCrystal)
               .AddTile(TileID.WorkBenches)
               .Register();

            CreateRecipe()
               .AddIngredient(ItemID.CrystalShard, 5)
               .AddIngredient(ItemID.SoulofLight, 3)
               .AddTile(TileID.MythrilAnvil)
               .Register();
        }
    }
}