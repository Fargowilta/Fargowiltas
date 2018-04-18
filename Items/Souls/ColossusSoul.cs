using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using CalamityMod;

namespace Fargowiltas.Items.Souls
{
	public class ColossusSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Colossus Soul");
			
			String tooltip = "'Nothing can stop you' \n20% chance to instantly heal back 50% of any damage taken\n20% damage reduction \n15% increased defense \nIncreases life regeneration by 8 \nIncreases HP by 100 \nGrants immunity to knockback and most debuffs \nEnemies are more likely to target you";
			
			if(Fargowiltas.instance.calamityLoaded)
			{
				tooltip += "\nEffects of the Absorber and Asgardian Aegis";
			}
			
			if(Fargowiltas.instance.thoriumLoaded)
			{
				 tooltip += "\nEffects of the Star Veil and Terrarium Defender";
			}
			else
			{
				tooltip += "\nEffects of the Star Veil, Paladin's Shield, and Frozen Turtle Shell";
			}

			Tooltip.SetDefault(tooltip);
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.defense = 8;
			item.value = 750000;
			item.expert = true;
			item.rare = -12;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			
			(player.GetModPlayer<FargoPlayer>(mod)).tankEffect = true;
			
			//thorium
			if(Fargowiltas.instance.thoriumLoaded)
			{
				if (player.statLife < 75)
				{
				player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("TerrariumRegen"), 60);
				player.lifeRegen += 20;
				}
				if (player.statLife < 100)
				{
				player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("TerrariumDefense"), 60);
				player.statDefense += 20;
				}
			}			
			
           player.endurance += 0.20f;
		   player.lifeRegen += 8;
		   player.aggro += 50;
		   player.statLifeMax2 += 100;
		   player.hasPaladinShield = true;
		   
		   player.statDefense = (int)(player.statDefense * 1.15);
		   
		   //ankh shield
		    player.buffImmune[46] = true;
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[30] = true;
			player.buffImmune[20] = true;
			player.buffImmune[32] = true;
			player.buffImmune[31] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[22] = true;
			
			player.buffImmune[156] = true; //Stoned
			
		   //paladin
			if (player.statLife > player.statLifeMax2 * .25)
			{
				for (int k = 0; k < 255; k++)
				{
					Player target = Main.player[k];
			
					if (target.active && player != target && Vector2.Distance(target.Center, player.Center) < 400)
					{
						target.AddBuff(BuffID.PaladinsShield, 30, true);
					}
				}
			}
		   
		   //frozenshell
		   
		    if (player.statLife < player.statLifeMax2 * .5)
            {
                player.AddBuff(BuffID.IceBarrier, 30, true);
            }
				
				
		    // shiny stone
		    player.shinyStone = true;
			
			// sweet vengeance or star veil
			if(Fargowiltas.instance.thoriumLoaded)
			{
				player.bee = true;
				player.panic = true;
			}

				player.starCloak = true;
				player.longInvince = true;
			
			//charm of myths
			player.pStone = true;
			
			//celestial shell
			player.accMerman = true;
			player.wolfAcc = true;
			if (hideVisual)
			{
				player.hideMerman = true;
				player.hideWolf = true;
			}
			

			if(Fargowiltas.instance.calamityLoaded)
			{
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("BrimstoneFlames")] = true;
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("HolyLight")] = true;
				player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("GlacialState")] = true;
				
				CalamityTank(player);
			}
			
			if(Fargowiltas.instance.blueMagicLoaded)
			{
				BlueTank(player);
			}
        }
		
		public void CalamityTank(Player player)
		{
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianAegis = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).dashMod = 4;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).aSpark = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).gShell = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).fCarapace = true;
				player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).absorber = true;
		}
		
		public void BlueTank(Player player)
		{
				player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).lifeMagnet2 = true;
				player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).crystalCloak = true;
		}
		
		public override void AddRecipes()
        {
            ModRecipe tank = new ModRecipe(mod);
			
			if(Fargowiltas.instance.thoriumLoaded)
			{
				if(Fargowiltas.instance.calamityLoaded)
				{
						tank.AddIngredient(ItemID.HandWarmer);
						tank.AddIngredient(ItemID.PocketMirror);
					
					if(Fargowiltas.instance.blueMagicLoaded)
					{
						//all 3
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("MoonlightCharm"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CrystalVeil"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialLegend"));	
					}

					else
					{
						//thorium and calamity	
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SweetVengeance"));
						tank.AddIngredient(ItemID.CelestialShell); 
					}
						
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("OceanRetaliation"));
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DeathEmbrace"));	//cape of the survivor? wtf diver
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("BlastShield"));
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DemonRageBadge"));
						tank.AddIngredient(ItemID.ShinyStone);
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumDefender"));	
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AsgardianAegis"));	
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralArcanum"));
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Sponge"));	
				}
				
				if(!Fargowiltas.instance.calamityLoaded)
				{
						tank.AddIngredient(ItemID.HandWarmer);
						tank.AddIngredient(ItemID.PocketMirror);
						tank.AddRecipeGroup("Fargowiltas:AnyEvilExpert");
					
					if(Fargowiltas.instance.blueMagicLoaded)
					{
						//blue and thorium
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("MoonlightCharm"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CrystalVeil"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialLegend"));	
					}
					
					else
					{
						//just thorium
						tank.AddIngredient(ItemID.CharmofMyths);
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SweetVengeance"));
						tank.AddIngredient(ItemID.CelestialShell); 
					}
						
						tank.AddRecipeGroup("Fargowiltas:AnyEvilMimic");	
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AstroBeetleHusk"));	
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("OceanRetaliation"));
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DeathEmbrace"));	//cape of the survivor? wtf diver
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("BlastShield"));
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DemonRageBadge"));
						tank.AddIngredient(ItemID.ShinyStone);
						tank.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumDefender"));	
				}
			}
				
			if(!Fargowiltas.instance.thoriumLoaded)
			{
				if(Fargowiltas.instance.calamityLoaded)
				{
						tank.AddIngredient(ItemID.LifeCrystal, 10);
						tank.AddIngredient(ItemID.HandWarmer);
						tank.AddIngredient(ItemID.PocketMirror);
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodyWormScarf"));	
					
					if(Fargowiltas.instance.blueMagicLoaded)
					{
						//calamity and blue
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("MoonlightCharm"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CrystalVeil"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialLegend"));	
					}
				
					else
					{
						//just calamity	
						tank.AddIngredient(ItemID.StarVeil);
						tank.AddIngredient(ItemID.CelestialShell); 
					}
						
						tank.AddIngredient(ItemID.FrozenTurtleShell);
						tank.AddIngredient(ItemID.PaladinsShield);
						tank.AddRecipeGroup("Fargowiltas:AnyEvilMimic");
						tank.AddIngredient(ItemID.ShinyStone);	
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AsgardianAegis"));	
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AstralArcanum"));
						tank.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Sponge"));
				}
			
				if(!Fargowiltas.instance.calamityLoaded)
				{
						tank.AddIngredient(ItemID.LifeCrystal, 10);
						tank.AddIngredient(ItemID.HandWarmer);
						tank.AddIngredient(ItemID.PocketMirror);
						tank.AddRecipeGroup("Fargowiltas:AnyEvilExpert");
					
					if(Fargowiltas.instance.blueMagicLoaded)
					{
						//just blue
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("MoonlightCharm"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CrystalVeil"));	
						tank.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialLegend"));	
					}
			
					else
					{
						//no others
						tank.AddIngredient(ItemID.CharmofMyths);
						tank.AddIngredient(ItemID.StarVeil);
						tank.AddIngredient(ItemID.CelestialShell); 
					}
					
						tank.AddIngredient(ItemID.FrozenTurtleShell);
						tank.AddIngredient(ItemID.PaladinsShield);
						tank.AddIngredient(ItemID.AnkhShield);
						tank.AddRecipeGroup("Fargowiltas:AnyEvilMimic");
						tank.AddIngredient(ItemID.ShinyStone);
				}
			}
			
            tank.AddTile(null, "CrucibleCosmosSheet");
            tank.SetResult(this);
            tank.AddRecipe();
		}
	}
}