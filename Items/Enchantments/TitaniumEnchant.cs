using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class TitaniumEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Enchantment");
            Tooltip.SetDefault(@"'Hit me with your best shot' 
Briefly become invulnerable after striking an enemy 
While a dodge is active, damage is increased by 20% 
When dodge is on cooldown, damage is decreased by 20% 
Increases all knockback");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 60000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            player.onHitDodge = true;
            player.kbBuff = true;

            if (player.FindBuffIndex(59) == -1)
            {
                player.magicDamage -= .2f;
                player.meleeDamage -= .2f;
                player.rangedDamage -= .2f;
                player.minionDamage -= .2f;
                player.thrownDamage -= .2f;
            }
            else
            {
                player.magicDamage += .2f;
                player.meleeDamage += .2f;
                player.rangedDamage += .2f;
                player.minionDamage += .2f;
                player.thrownDamage += .2f;
            }



        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyTitaHead");
            recipe.AddIngredient(ItemID.TitaniumBreastplate);
            recipe.AddIngredient(ItemID.TitaniumLeggings);
            recipe.AddIngredient(ItemID.SlapHand);
            recipe.AddIngredient(ItemID.Anchor);
            recipe.AddIngredient(ItemID.MonkStaffT1);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


