using Fargowiltas.Common.Systems.Recipes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HemoclawCrab : BaseSummon
    {
        public override int NPCType => NPCID.GoblinShark;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Hemoclaw Crab");
            /* Tooltip.SetDefault("Summons Hemogoblin Shark" +
                               "\nOnly usable during Blood Moon"); */
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