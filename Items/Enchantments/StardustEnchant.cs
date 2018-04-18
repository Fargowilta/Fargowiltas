using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class StardustEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Enchantment");
			Tooltip.SetDefault(@"'The power of the Stand is yours' 
15% increased minion damage 
Increases max minions by 2 
Double tap down to direct your guardian");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 10; 
			item.value = 400000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.maxMinions += 2;
			player.minionDamage += 0.15f;
			if(Soulcheck.GetValue("Stardust Guardian") == true)
			{
			player.setStardust = true;
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.FindBuffIndex(187) == -1)
				{
					player.AddBuff(187, 3600, true);
				}
				if (player.ownedProjectileCounts[623] < 1)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, 623, 0, 0f, Main.myPlayer, 0f, 0f);
				}
			}
			}
			
			((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).stardustEnchant = true;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StardustHelmet);
			recipe.AddIngredient(ItemID.StardustBreastplate);
			recipe.AddIngredient(ItemID.StardustLeggings);
			recipe.AddIngredient(ItemID.StardustCellStaff);
			recipe.AddIngredient(ItemID.StardustDragonStaff);
			recipe.AddIngredient(ItemID.RainbowCrystalStaff);
			
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}	
}
		
	





