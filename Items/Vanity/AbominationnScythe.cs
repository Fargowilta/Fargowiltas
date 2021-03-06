﻿using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.HandsOff)]
    public class AbominationnScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn's Scythe");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.accessory = true;
            item.rare = ItemRarityID.Blue;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DeathSickle);
            recipe.AddIngredient(ItemID.ChristmasHook); //meme ass recipe might change
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
