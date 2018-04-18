using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class JungleEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Enchantment");
            Tooltip.SetDefault("'The wrath of the jungle dwells within' \nReduces mana usage by 10% \nTaking damage will release a spore explosion");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 20000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Soulcheck.GetValue("Spore Explosion") == true)
            {
                (player.GetModPlayer<FargoPlayer>(mod)).jungleEnchant = true;
            }
            player.manaCost -= .1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleHat);
            recipe.AddIngredient(ItemID.JungleShirt);
            recipe.AddIngredient(ItemID.JunglePants);
            recipe.AddIngredient(ItemID.StaffofRegrowth);
            recipe.AddIngredient(ItemID.DoNotStepontheGrass);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
