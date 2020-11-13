using Fargowiltas.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    [Autoload(false)]
    public class OmnistationPlus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnistation+");
            Tooltip.SetDefault("Effects of all buff stations, modded and vanilla" +
                "\nGrants Honey when touched" +
                "\nRight click while holding a weapon for its respective buff" +
                "\nCurrently only supports Thorium and Calamity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<OmnistationPlusTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Fargowiltas:AnyOmnistation", 1);

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                Mod thorium = Fargowiltas.LoadedMods["ThoriumMod"];
                recipe.AddIngredient(thorium.ItemType("Mistletoe"), 30);
                recipe.AddIngredient(thorium.ItemType("ConductorsStand"), 5);
                recipe.AddIngredient(thorium.ItemType("Altar"), 5);
                recipe.AddIngredient(thorium.ItemType("NinjaRack"), 5);
            }
            if (Fargowiltas.ModLoaded("CalamityMod"))
            {
                Mod calamity = Fargowiltas.LoadedMods["CalamityMod"];
                recipe.AddIngredient(calamity.ItemType("PurpleCandle"), 5);
                recipe.AddIngredient(calamity.ItemType("YellowCandle"), 5);
                recipe.AddIngredient(calamity.ItemType("PinkCandle"), 5);
                recipe.AddIngredient(calamity.ItemType("BlueCandle"), 5);
            }

            recipe.AddTile(TileID.MythrilAnvil);            recipe.Register();
        }
    }
}