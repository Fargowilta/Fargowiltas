using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class FrostEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Enchantment");
            Tooltip.SetDefault(@"'Let's coat the world with a deep freeze' 
10% increased melee and ranged damage 
You are immune to chilled and frozen debuffs 
Melee and ranged attacks cause frostburn and emit light");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += .1f;
            player.rangedDamage += .1f;
            player.frostBurn = true;

            player.buffImmune[46] = true; //chilled
            player.buffImmune[47] = true; //frozen

            //if slowing enemies is a thing add later
            //FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            //modPlayer.frostEnchant = true;


        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostHelmet);
            recipe.AddIngredient(ItemID.FrostBreastplate);
            recipe.AddIngredient(ItemID.FrostLeggings);
            recipe.AddIngredient(ItemID.IceBow);
            recipe.AddIngredient(ItemID.Amarok);
            recipe.AddIngredient(ItemID.ColdWatersintheWhiteLand);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


