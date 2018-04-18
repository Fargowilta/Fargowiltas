using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class PumpkinEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpkin Enchantment");
            Tooltip.SetDefault("'You suddenly have the urge to hide in a shell' \n" +
                                "15% increased defense \n" +
                                "100% of damage taken by melee attacks is reflected \n" +
                                "Enemies are more likely to target you");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 200000;
        }

        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Placeholder";
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            //heal on hit

            player.aggro += 50;
            player.thorns = 1f;
            player.turtleThorns = true;
            player.statDefense = (int)(player.statDefense * 1.15);

            /*if (player.whoAmI == Main.myPlayer)
            {
				if(!hideVisual)
				{
					modPlayer.turtPet = true;
					
					if(player.FindBuffIndex(52) == -1)
					{
						if (player.ownedProjectileCounts[ProjectileID.TikiSpirit] < 1)
						{
							
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.TikiSpirit, 0, 2f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				else
				{
						modPlayer.turtPet = false;
				}
            }*/
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            //pumpkin armor
            //jack o lantern
            //squashling
            //sickle

            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.Yelets);
            recipe.AddIngredient(ItemID.Seedler);
            recipe.AddIngredient(ItemID.ButchersChainsaw);



            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

