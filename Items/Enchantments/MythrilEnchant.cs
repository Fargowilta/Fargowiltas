using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class MythrilEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Enchantment");
            Tooltip.SetDefault("'You feel the knowledge of your weapons seep into your mind' \n" +
                                "20% increased ranged weapon use speed \n" +
                                "10% increased ranged critical strike chance");
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
            player.rangedCrit += 10;

            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            //modPlayer.mythrilEnchant = true;


            modPlayer.firingSpeed += .20f;

            /*if (player.whoAmI == Main.myPlayer)
            {
				if(!hideVisual)
				{
					modPlayer.mythrilPet = true;
					
					if(player.FindBuffIndex(200) == -1)
					{
						if (player.ownedProjectileCounts[ProjectileID.DD2PetGato] < 1)
						{
							
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.DD2PetGato, 0, 2f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				else
				{
						modPlayer.mythrilPet = false;
				}
				
            }*/

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyMythrilHead");
            recipe.AddIngredient(ItemID.MythrilChainmail);
            recipe.AddIngredient(ItemID.MythrilGreaves);
            recipe.AddIngredient(ItemID.OnyxBlaster);
            recipe.AddIngredient(ItemID.ShadowFlameBow);
            recipe.AddIngredient(ItemID.DD2PhoenixBow);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}