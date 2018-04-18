using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class lumber : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Fargowiltas/NPCs/lumber";
			}
		}		
		public bool dayOver;
		public bool nightOver;

		public int woodAmount = 100;

		public override bool Autoload(ref string name)
		{
			name = "LumberJack";
			return mod.Properties.Autoload;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LumberJack");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 2;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 40;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public bool SacredToolsDownedSerpent
		{
			get { return SacredTools.ModdedWorld.FlariumSpawns; }
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if ((player.inventory[j].type == mod.ItemType("WoodenToken")) || (FargoWorld.movedLumberjack == true))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override void AI()
		{
			if (!Main.dayTime) nightOver = true;
			if (Main.dayTime) dayOver = true;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Griff";
				case 1:
					return "Jack";
				case 2:
					return "Bruce";
				case 3:
					return "Larry";
				default:
					return "Paul";
			}
		}

		public override string GetChat()
		{
			int dryad = NPC.FindFirstNPC(NPCID.Dryad);

			if (dryad >= 0 && Main.rand.Next(10) == 0)
			{
				return Main.npc[dryad].GivenName + " told me to start hugging trees... I hug trees with my chainsaw.";
			}

			switch (Main.rand.Next(9))
			{ 
				case 0:
					return "Dynasty wood? Between you and me, that stuff ain't real wood!";
				case 1:
					return "Sure cactus isn't wood, but I can still chop it with me trusty axe.";
				case 2:
					return "You wouldn't by chance have any fantasies about me... right?";
				case 3:
					return "I eat a bowl of woodchips for breakfast... without any milk.";
				case 4:
					return "TIIIIIIIIIMMMBEEEEEEEERRR!";
				case 5: 
					return "I'm a lumberjack and I'm okay, I sleep all night and I work all day!";
				case 6:
				    return "You won't ever need an axe again with me around.";	
				case 7:
				    return "I have heard of people cutting trees with fish, who does that?";	
				default:
					return "It's always flannel season.";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
			button2 = "Free Wood";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			Player player = Main.player[Main.myPlayer];
			FargoPlayer p = player.GetModPlayer<FargoPlayer>(mod);

			if (firstButton)
			{
				shop = true;
			}
			if (!firstButton)
			{
				if (dayOver & nightOver)
				{
					Main.npcChatText = "Here you go. I'm glad my wood put such a big smile on your face.";
					if(NPC.downedBoss1 == true)
					{
						woodAmount = 250;
					}
					if(Main.hardMode)
					{
						woodAmount = 600;
					}
					player.QuickSpawnItem(ItemID.Wood, woodAmount);
					dayOver = false;
					nightOver = false;
				}
				else
				{
					Main.npcChatText = "The trees need time to regrow, come back later for more wood.";
				}
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			
			shop.item[nextSlot].SetDefaults(ItemID.Wood);
			shop.item[nextSlot].value=10;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
			shop.item[nextSlot].value=10;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
			shop.item[nextSlot].value=15;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
			shop.item[nextSlot].value=15;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
			shop.item[nextSlot].value=15;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
			shop.item[nextSlot].value=15;
			nextSlot++;
			
			if(Fargowiltas.instance.tremorLoaded)
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GlacierWood"));
				shop.item[nextSlot].value=15;
				nextSlot++;
			}
			
			 if (ModLoader.GetLoadedMods().Contains("CrystiliumMod"))
             {
				 for (int k = 0; k < 255; k++)
				{
                Player player = Main.player[k];
                if (player.active)
					{
                    for (int j = 0; j < player.inventory.Length; j++)
						{
                        if (player.inventory[j].type == (ModLoader.GetMod("CrystiliumMod").ItemType("CrystalBlock")))
							{
							shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrystalWood"));
							shop.item[nextSlot].value=20;
							nextSlot++; 
							}
						}
					}
				}
			 }

			if (ModLoader.GetLoadedMods().Contains("CosmeticVariety") && (NPC.downedBoss2 == true))
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CosmeticVariety").ItemType("Starwood"));
				shop.item[nextSlot].value = 20;
				nextSlot++;
			}
			
			shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
			shop.item[nextSlot].value=20;
			nextSlot++;
			
			 if (ModLoader.GetLoadedMods().Contains("Ersion"))
             {
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Ersion").ItemType("ReinforcedWood"));
				shop.item[nextSlot].value=30;
				nextSlot++; 
			 }
			
			if (NPC.downedHalloweenKing == true)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SpookyWood);
				shop.item[nextSlot].value=50;
				nextSlot++;
			}

			 if (ModLoader.GetLoadedMods().Contains("EpicnessModRemastered"))
             {
				if (Main.hardMode == true)
				{
					shop.item[nextSlot].SetDefaults(ModLoader.GetMod("EpicnessModRemastered").ItemType("SuperWood"));
					shop.item[nextSlot].value=800;
					nextSlot++;
				}
			 }
			
			if (Fargowiltas.instance.sacredToolsLoaded)
             {
				 if (SacredToolsDownedSerpent)
				{	
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("FlameWood"));
				shop.item[nextSlot].value=2000;
				nextSlot++;
				}
			 }
			
			shop.item[nextSlot].SetDefaults(ItemID.Cactus);
			shop.item[nextSlot].value=10;
			nextSlot++;
			
			shop.item[nextSlot].SetDefaults(mod.ItemType("axe"));
			shop.item[nextSlot].value=10000;
			nextSlot++;
		}
		
		public override void NPCLoot()
        {
            FargoWorld.movedLumberjack = true;
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.PossessedHatchet;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}