using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
    public class CrucibleCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crucible of the Cosmos");
            Tooltip.SetDefault("'It seems to be hiding magnificent power' \nFunctions as nearly every crafting station");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("CrucibleCosmosSheet");
            item.expert = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.CookingPot);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddRecipeGroup("Fargowiltas:AnyBookcase");
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddRecipeGroup("Fargowiltas:AnyAnvil");
            recipe.AddRecipeGroup("Fargowiltas:AnyForge");
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


