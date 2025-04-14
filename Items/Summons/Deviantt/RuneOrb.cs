using Fargowiltas.Common.Systems.Recipes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class RuneOrb : BaseSummon
    {
        public override int NPCType => NPCID.RuneWizard;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Rune Orb");
			/* Tooltip.SetDefault("Summons Rune Wizard" +
                               "\nOnly usable at night or underground"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                  .AddIngredient(ItemID.WizardHat)
                  .AddRecipeGroup(RecipeGroups.AnyGemRobe)
                  .AddIngredient(ItemID.Bone, 10)
                  .AddTile(TileID.MythrilAnvil)
                  .Register();
        }
    }
}