using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
    public class WoodenToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Token");
            Tooltip.SetDefault("'The sign of a true wood lover' \nWill summon one if you keep it around for a while");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.createTile = mod.TileType("woodtokenSheet");

            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddIngredient(ItemID.BorealWood, 25);
            recipe.AddIngredient(ItemID.RichMahogany, 25);
            recipe.AddIngredient(ItemID.PalmWood, 25);

            recipe.AddRecipeGroup("Fargowiltas:AnyEvilWood", 25);


            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}