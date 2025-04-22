using Fargowiltas.Content.Items.Summons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.VanillaCopy
{
    public class SlimyCrown : BaseSummon
    {

        public override int NPCType => NPCID.KingSlime;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Slimy Crown");
			// Tooltip.SetDefault("Summons King Slime");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SlimeCrown]; // 2
		}

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SlimeCrown)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}