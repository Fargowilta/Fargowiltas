using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace Fargowiltas.Items
{
	public class FargoGlobalItem : GlobalItem
	{
	
		public class UseSpeed : GlobalItem
		{
			
			
			public override float UseTimeMultiplier(Item item, Player player)
			{
				FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);
				if (item.ranged && item.damage > 0 && item.useTime > 5 && item.useAnimation > 5)
				{
					return 1f + p.firingSpeed;
				}
				if (item.magic && item.width != 25 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.castingSpeed;
				}
				if ((item.thrown && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1) || (item.ranged && item.width == 29 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1))
				{
					return 1f + p.throwingSpeed;
				}
				if (item.width == 27 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.radiantSpeed;
				}
				if (item.width == 25 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.symphonicSpeed;
				}
				if (item.magic && item.damage < 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.healingSpeed;
				}
				if (item.axe >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.axeSpeed;
				}
				if (item.hammer >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.hammerSpeed;
				}
				if (item.pick >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.pickSpeed;
				}
				return 1f;
			}
			
			public override float MeleeSpeedMultiplier(Item item, Player player)
			{
				FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);
				if (item.ranged && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.firingSpeed;
				}
				if (item.magic && item.width != 25 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.castingSpeed;
				}
				if ((item.thrown && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1) || (item.ranged && item.width == 29 && item.damage > 0 && item.useTime > 1 && item.useAnimation > 1))
				{
					return 1f + p.throwingSpeed;
				}
				if (item.width == 27 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.radiantSpeed;
				}
				if (item.width == 25 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.symphonicSpeed;
				}
				if (item.magic && item.damage < 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.healingSpeed;
				}
				if (item.axe >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.axeSpeed;
				}
				if (item.hammer >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.hammerSpeed;
				}
				if (item.pick >= 1 && item.useTime > 1 && item.useAnimation > 1)
				{
					return 1f + p.pickSpeed;
				}
				return 1f;
			}
			
			
		}
		
		public override void ModifyTooltips (Item item, List< TooltipLine > tooltips)
		{
			if(item.type == ItemID.CrystalBall)
			{
				TooltipLine line = new TooltipLine(mod, "fun", "Functions as a Demon altar as well");
				//line.overrideColor = Color.LimeGreen;
				tooltips.Add(line);
			}
			
			if(item.type == ItemID.DogWhistle)
			{
				TooltipLine line = new TooltipLine(mod, "fun", "Shoutout to Browny and Paca");
				tooltips.Add(line);
			}
		}
		
		public override void SetDefaults (Item item)
		{
			if(item.maxStack == 999 || item.maxStack == 99)
			{
				item.maxStack = item.maxStack * 10 + 9;
			}
			else if(item.maxStack > 10 && item.maxStack != 100 && item.type != 71 && item.type != 72 && item.type != 73 && item.type != 74)
			{
				item.maxStack = 99;
			}
		}
		
		public override void UpdateAccessory (Item item, Player player, bool hideVisual)
		{
			if(player.manaCost <= 0f)
			{
				player.manaCost = 0f;
			}
		}
		
		public override void GrabRange(Item item, Player player, ref int grabRange)
		{
			FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);
			//ignore money, hearts, mana stars
			if(p.ironEnchant && item.type != 71 && item.type != 72 && item.type != 73 && item.type != 74 && item.type != 54 && item.type != 1734 && item.type != 1735 && item.type != 184)
			{
				grabRange += 300;
			}
		}
		
		public override void PickAmmo (Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            if (modPlayer.jammed)
            {
                type = ProjectileID.ConfettiGun;
            }
		}

        public override bool ConsumeItem (Item item, Player player)
		{
			FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);
			
			if(p.infinity && item.createTile == -1 && item.type != ItemID.LifeFruit)
			{
				return false;
			}
			
			if(p.builderMode && (item.createTile != -1 || item.createWall != -1))
			{
				return false;
			}
			return true;
		}
		
		public override void OpenVanillaBag (string context, Player player, int arg)
		{
			if(arg == ItemID.KingSlimeBossBag)
			{
				if(Main.rand.Next(50) == 0)
				{
					player.QuickSpawnItem(ItemID.SlimeStaff);
				}
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("SlimeKingsSlasher"));
				}
			}
			if(arg == ItemID.EyeOfCthulhuBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("EyeFlail"));
				}
			}
			if(arg == ItemID.EaterOfWorldsBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("EaterStaff"));
				}
			}
			if(arg == ItemID.BrainOfCthulhuBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("BrainStaff"));
				}
			}
			if(arg == ItemID.SkeletronBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("Bonezone"));
				}
			}
			if(arg == ItemID.QueenBeeBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("QueenStinger"));
				}
			}
			if(arg == ItemID.DestroyerBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("Probe"));
				}
			}
			if(arg == ItemID.TwinsBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("TwinBoomerangs"));
				}
			}
			if(arg == ItemID.SkeletronPrimeBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("PrimeStaff"));
				}
			}
			if(arg == ItemID.PlanteraBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("Dicer"));
				}
			}
			if(arg == ItemID.GolemBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("GolemStaff"));
				}
			}
			if(arg == ItemID.FishronBossBag)
			{
				if(Main.rand.Next(10) == 0)
				{
					player.QuickSpawnItem(mod.ItemType("FishStick"));
				}
			}

		}
		
		public override bool OnPickup (Item item, Player player)
		{
			bool returnVal = true;
			FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);

            if(p.chloroEnchant && (item.type == ItemID.Daybloom || item.type == ItemID.Blinkroot || item.type == ItemID.Deathweed || item.type == ItemID.Fireblossom || item.type == ItemID.Moonglow || item.type == ItemID.Shiverthorn || item.type == ItemID.Waterleaf || item.type == ItemID.Mushroom || item.type == ItemID.VileMushroom || item.type == ItemID.ViciousMushroom || item.type == ItemID.GlowingMushroom))
            {
                item.stack *= 2;
            }
			
			if(p.goldEnchant)
			{
				if(item.type == ItemID.CopperCoin)
				{
					for (int i = 0; i < 3; i++)
					{
						float randX, randY;
						
						do
						{
							randX = (float)Main.rand.Next(-10, 10);
						} while(randX <= 4f && randX >= -4f);
						
						do
						{
							randY = (float)Main.rand.Next(-10, 10);
						} while(randY <= 4f && randY >= -4f);
						
						Projectile.NewProjectile(player.Center.X, player.Center.Y, randX, randY, ProjectileID.CopperCoin, 25, 2, Main.myPlayer, 0f, 0f);
					}
					
					returnVal = false;
				}
				
				if(item.type == ItemID.SilverCoin)
				{
					for (int i = 0; i < 8; i++)
					{
						float randX, randY;
						
						do
						{
							randX = (float)Main.rand.Next(-10, 10);
						} while(randX <= 4f && randX >= -4f);
						
						do
						{
							randY = (float)Main.rand.Next(-10, 10);
						} while(randY <= 4f && randY >= -4f);
						
						Projectile.NewProjectile(player.Center.X, player.Center.Y, randX, randY, ProjectileID.SilverCoin, 50, 2, Main.myPlayer, 0f, 0f);
					}
					
					returnVal = false;
				}
				if(item.type == ItemID.GoldCoin)
				{
					int x = Main.rand.Next(2);
					
					switch(x)
					{
						case 0:
							player.AddBuff(BuffID.Regeneration, 600);
							break;
						default:
							player.AddBuff(BuffID.Swiftness, 600);
							break;
					}
					
					//item.stack = 2;
					
				}
			}
				
			
			return returnVal;
		}
		
	}
}