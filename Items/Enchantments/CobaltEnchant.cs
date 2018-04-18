using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
	public class CobaltEnchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Enchantment");
			Tooltip.SetDefault(@"'I can't believe it's not palladium' 
10% increased melee and movement speed 
Chance to confuse enemies 
Enemies will explode into cobalt shards on death");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.rare = 4; 
			item.value = 40000; 
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			(player.GetModPlayer<FargoPlayer>(mod)).cobaltEnchant = true;
			player.meleeSpeed += .1f;
			player.moveSpeed += 0.1f;
        }
		
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Fargowiltas:AnyCobaltHead");
			recipe.AddIngredient(ItemID.CobaltBreastplate);
			recipe.AddIngredient(ItemID.CobaltLeggings);
			recipe.AddIngredient(ItemID.HelFire);
			recipe.AddRecipeGroup("Fargowiltas:AnyPhasesaber");
			recipe.AddIngredient(ItemID.DaoofPow);
			recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
		
	





