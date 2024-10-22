using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
	public class KohaCrystal : ModItem
	{
        SoundStyle DeathFruitSound = new SoundStyle("Fargowiltas/Assets/Sounds/DeathFruit");
        public override void SetStaticDefaults()
		{
			 
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Blue;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.consumable = true;

			Item.UseSound = SoundID.Item27;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ManaCrystal)
                .AddCondition(Condition.NearShimmer) 
                .Register();
        }
        public override void HoldItem(Player player)
        {
            if (player.ConsumedManaCrystals > 0)
            {
                Item.UseSound = DeathFruitSound;
            }
            else
            {
                Item.UseSound = SoundID.Item27;
            }
        }
        public override bool? UseItem(Player player)
		{
			if (player.ConsumedManaCrystals > 0)
			{
				if (player.altFunctionUse != 2)
				{
                    player.ManaEffect(-20);
                    player.ConsumedManaCrystals--;
                }
				
			}
			return true;
		}
        public override bool CanUseItem(Player player)
        {
            return player.ConsumedManaCrystals > 0;
        }
    }
}
