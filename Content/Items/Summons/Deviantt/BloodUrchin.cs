using Fargowiltas.Common.Systems.Recipes;
using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class BloodUrchin : BaseSummon
    {
        public override int NPCType => NPCID.BloodEelHead;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Blood Urchin");
			/* Tooltip.SetDefault("Summons Blood Eel" +
                               "\nOnly usable during Blood Moon"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.BloodMoonStarter]; // 18
		}

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight && Main.bloodMoon;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BloodMoonStarter)
                .AddIngredient(ItemID.DeepRedPaint)
                .AddRecipeGroup(RecipeGroups.AnyFoodT3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}