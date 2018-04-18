using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class OrichalcumEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Enchantment");
            Tooltip.SetDefault(@"'Nature blesses you' 
10% increased critical strike chance 
Flower petals will cause extra damage to your target 
Chance for a fireball to spew from a hit enemy");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            if (Soulcheck.GetValue("Orichalcum Fireball") == true)
            {
                modPlayer.oriEnchant = true;
                player.onHitPetal = true;
            }
            player.magicCrit += 10;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;

            /*if (player.whoAmI == Main.myPlayer)
            {
				if(!hideVisual)
				{
					modPlayer.oriPet = true;
					
					if(player.FindBuffIndex(54) == -1)
					{
						if (player.ownedProjectileCounts[ProjectileID.Parrot] < 1)
						{
							
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Parrot, 0, 2f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				else
				{
						modPlayer.oriPet = false;
				}
				
            }*/
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyOriHead");
            recipe.AddIngredient(ItemID.OrichalcumBreastplate);
            recipe.AddIngredient(ItemID.OrichalcumLeggings);
            recipe.AddIngredient(ItemID.FlowerofFire);
            recipe.AddIngredient(ItemID.FlowerofFrost);
            recipe.AddIngredient(ItemID.CursedFlames);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

