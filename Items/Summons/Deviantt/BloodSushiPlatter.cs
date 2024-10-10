using Fargowiltas.Common.Systems.Recipes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class BloodSushiPlatter : BaseSummon
    {
        public override int NPCType => NPCID.BloodNautilus;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Blood Sushi Platter");
            /* Tooltip.SetDefault("Summons Dreadnautilus" +
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
                .AddRecipeGroup(RecipeGroups.AnyFoodT3, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}