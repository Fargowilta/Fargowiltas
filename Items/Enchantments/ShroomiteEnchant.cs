using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class ShroomiteEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Enchantment");
            Tooltip.SetDefault("'Made with real shrooms!' \n" +
                                "12% increased ranged damage \n" +
                                "Not moving puts you in stealth \n" +
                                "You can only crit in stealth, but crits deal 4x damage\n" +
                                "Spores spawn on enemies when you attack in stealth");

            //remove spores? 
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {


            player.rangedDamage += .12f;
            if (Soulcheck.GetValue("Shroomite Stealth") == true)
            {
                player.shroomiteStealth = true;
                ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).shroomEnchant = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyShroomHead");
            recipe.AddIngredient(ItemID.ShroomiteBreastplate);
            recipe.AddIngredient(ItemID.ShroomiteLeggings);
            recipe.AddIngredient(ItemID.Hammush);
            recipe.AddIngredient(ItemID.Uzi);
            recipe.AddIngredient(ItemID.GrenadeLauncher);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

