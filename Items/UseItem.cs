using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
	public class UseItem : GlobalItem
	{
		public override bool ConsumeItem(Item item, Player player)
		{
			
				
			if ((player.GetModPlayer<FargoPlayer>(mod)).universeEffect == true)
			{
				if (item.thrown)
				{
					if (Main.rand.Next(100) < 99)
					{
						return false;
					}
				}
				else
				{
					return true;
				}
			}
			return true;
		}
	}
}