using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class AnglerEnchantment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angler Enchantment");
            Tooltip.SetDefault("'As long as they aren't all shoes, you can go home happily' \n" +
                                "Increases fishing skill\n" +
                                "All fishing rods will have 4 extra lures");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 100000;
            item.rare = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).fishSoul1 = true;

            player.fishingSkill += 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.AnglerHat);
            recipe.AddIngredient(ItemID.AnglerVest);
            recipe.AddIngredient(ItemID.AnglerPants);

            recipe.AddIngredient(ItemID.WoodFishingPole);
            recipe.AddIngredient(ItemID.ReinforcedFishingPole);
            recipe.AddIngredient(ItemID.FiberglassFishingPole);

            recipe.AddIngredient(ItemID.Rockfish);
            recipe.AddIngredient(ItemID.SawtoothShark);
            recipe.AddIngredient(ItemID.ReaverShark);

            recipe.AddIngredient(ItemID.OldShoe, 5);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


