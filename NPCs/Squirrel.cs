using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.NPCs
{
	[AutoloadHead]
	public class Squirrel : ModNPC
	{
        private static int shopNum;
        private static bool showCycleShop;

        public enum SquirrelSellType
        {
            SoldBySquirrel,
            SomeMaterialsSold, //sells materials with names matching the associated shopgroup
            CraftableMaterialsSold,
            SoldAtThirtyStack,
            End
        }

        public enum ShopGroup
        {
            Enchant,
            Essence,
            Force,
            Soul,
            Potion,
            Other,
            Acorn,
            End
        }

        public override bool UsesPartyHat() => false;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squirrel");
			Main.npcFrameCount[NPC.type] = 6;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;

            NPCID.Sets.CannotSitOnFurniture[NPC.type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate);
            NPC.Happiness.SetNPCAffection<LumberJack>(AffectionLevel.Like);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.Fargowiltas.Bestiary.Squirrel")
            });
        }

        public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 50;
			NPC.height = 32;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = .25f;

			AnimationType = NPCID.Squirrel;
			NPC.aiStyle = 7;

            //if (GetInstance<FargoConfig>().CatchNPCs)
            //{
            //    Main.npcCatchable[NPC.type] = true;
            //    NPC.catchItem = (short)mod.ItemType("Squirrel");
            //}
        }

        public override void AI()
        {
            NPC.dontTakeDamage = Main.bloodMoon;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (FargoGlobalNPC.AnyBossAlive())
            {
                return false;
            }

            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && TryFind("FargowiltasSouls", "TopHatSquirrelCaught", out ModItem modItem))
            {
                for (int k = 0; k < Main.maxPlayers; k++)
                {
                    Player player = Main.player[k];
                    if (!player.active)
                    {
                        continue;
                    }

                    foreach (Item item in player.inventory)
                    {
                        if (item.type == modItem.Type)
                        {
                            return true;
                        }
                    }
                }
            }

            return GetInstance<FargoConfig>().Squirrel;
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override List<string> SetNPCNameList()
        {
            string[] names = { "Rick", "Acorn", "Puff", "Coco", "Truffle", "Furgo", "Squeaks" };

            return new List<string>(names);
        }

		public override string GetChat()
		{
            showCycleShop = GetSellableItems().Count / maxShop > 0 && !ModLoader.TryGetMod("ShopExpander", out _);

            if (Main.bloodMoon)
                return "[c/FF0000:You will suffer.]";

            switch (Main.rand.Next(3))
			{
				case 0:
					return "*squeak*";
				case 1:
					return "*chitter*";
				default:
					return "*crunch crunch*";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
            button = Language.GetTextValue("LegacyInterface.28");
            if (showCycleShop)
            {
                button += $" {shopNum + 1}";
                button2 = "Cycle Shop";
            }
        }

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
            else
            {
                /*if (Main.hardMode) //ask player why they don't have biocluster
                {
                    bool playerHasBiocluster = false;
                    int type = ModLoader.GetMod("FargowiltasSouls").ItemType("BionomicCluster");
                    foreach (Item item in Main.LocalPlayer.inventory)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    foreach (Item item in Main.LocalPlayer.armor)
                    {
                        if (item.type == type)
                        {
                            playerHasBiocluster = true;
                            break;
                        }
                    }
                    if (!playerHasBiocluster)
                    {
                        CombatText.NewText(NPC.Hitbox, Color.White, $"[i:{type}]?", true);
                    }
                }*/

                shopNum++;
            }

            //check this when just opening shop too in case shop shrinks
            if (shopNum > GetSellableItems().Count / maxShop)
                shopNum = 0;
        }

        private static int[] ItemsSoldDirectly => new int[]
        {
            ItemID.CellPhone,
            ItemID.AnkhShield,
            ItemID.RodofDiscord,
            ItemID.TerrasparkBoots,
            ItemID.TorchGodsFavor,
            ItemType<Omnistation>(),
            ItemType<Omnistation2>(),
            ItemType<CrucibleCosmos>(),
            ItemType<ElementalAssembler>(),
            ItemType<MultitaskCenter>(),
            ItemType<PortableSundial>(),
            ItemType<BattleCry>()
        };

        public static ShopGroup SquirrelSells(Item item, out SquirrelSellType sellType)
        {
            if (item.type == ItemID.Zenith)
            {
                sellType = SquirrelSellType.CraftableMaterialsSold;
                return ShopGroup.Other;
            }

            if (item.makeNPC != 0 || ItemsSoldDirectly.Contains(item.type))
            {
                sellType = SquirrelSellType.SoldBySquirrel;
                return ShopGroup.Other;
            }

            if ((item.maxStack >= 30 && item.buffType != 0 && item.type != ItemID.GrilledSquirrel) || item.type == ItemID.RecallPotion || item.type == ItemID.PotionOfReturn || item.type == ItemID.WormholePotion)
            {
                sellType = SquirrelSellType.SoldAtThirtyStack;
                return ShopGroup.Potion;
            }

            if (item.ModItem != null && (item.ModItem.Mod.Name.Equals("FargowiltasSouls") || item.ModItem.Mod.Name.Equals("FargowiltasSoulsDLC")))
            {
                if (item.ModItem.Name.EndsWith("Enchant"))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return ShopGroup.Enchant;
                }
                else if (item.ModItem.Name.EndsWith("Essence"))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return ShopGroup.Essence;
                }
                else if ((TryFind("FargowiltasSouls", "BionomicCluster", out ModItem cluster) && cluster.Type == item.type)
                    || (TryFind("FargowiltasSouls", "HeartoftheMasochist", out ModItem heart) && heart.Type == item.type))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return ShopGroup.Other;
                }
                else if (item.ModItem.Name.EndsWith("Force"))
                {
                    sellType = SquirrelSellType.SomeMaterialsSold;
                    return ShopGroup.Enchant;
                }
                else if ((TryFind("FargowiltasSouls", "MasochistSoul", out ModItem masoSoul) && masoSoul.Type == item.type)
                    || (TryFind("FargowiltasSouls", "AeolusBoots", out ModItem aeolusBoots) && item.type == aeolusBoots.Type)
                    || (TryFind("FargowiltasSouls", "ZephyrBoots", out ModItem zephyrBoots) && item.type == zephyrBoots.Type))
                {
                    sellType = SquirrelSellType.CraftableMaterialsSold;
                    return ShopGroup.Other;
                }
                else if (item.ModItem.Name.EndsWith("Soul"))
                {
                    //go through recipes and look for a sellable material
                    foreach (Recipe recipe in Main.recipe.Where(recipe => recipe.HasResult(item.type)))
                    {
                        foreach (Item material in recipe.requiredItem)
                        {
                            if (material.type != ItemID.None && material.ModItem != null)
                            {
                                if (material.ModItem.Name.EndsWith("Essence"))
                                {
                                    sellType = SquirrelSellType.SomeMaterialsSold;
                                    return ShopGroup.Essence;
                                }
                                else if (material.ModItem.Name.EndsWith("Force"))
                                {
                                    sellType = SquirrelSellType.SomeMaterialsSold;
                                    return ShopGroup.Force;
                                }
                                else if (material.ModItem.Name.EndsWith("Soul"))
                                {
                                    sellType = SquirrelSellType.SomeMaterialsSold;
                                    return ShopGroup.Soul;
                                }
                            }
                        }
                    }

                    //if nothing found, sell the soul itself
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return ShopGroup.Soul;
                }
            }

            sellType = SquirrelSellType.End;
            return ShopGroup.End;
        }

        private void AddToCollection(int type, ShopGroup group, List<int>[] itemCollections)
        {
            int groupCast = (int)group;
            if (!itemCollections[groupCast].Contains(type))
                itemCollections[groupCast].Add(type);
        }

        private void TryAddItem(Item item, List<int>[] itemCollections)
        {
            ShopGroup shopGroup = SquirrelSells(item, out SquirrelSellType sellType);
            switch (sellType)
            {
                case SquirrelSellType.SoldBySquirrel:
                    AddToCollection(item.type, shopGroup, itemCollections);
                    break;

                case SquirrelSellType.SomeMaterialsSold:
                    foreach (Recipe recipe in Main.recipe.Where(recipe => recipe.HasResult(item.type)))
                    {
                        foreach (Item material in recipe.requiredItem)
                        {
                            if (material.ModItem != null && material.ModItem.Name.EndsWith(shopGroup.ToString()))
                                AddToCollection(material.type, shopGroup, itemCollections);

                            if (material.type == ItemID.CellPhone && TryFind("FargowiltasSouls", "WorldShaperSoul", out ModItem worldShaperSoul) && item.type == worldShaperSoul.Type)
                                AddToCollection(material.type, ShopGroup.Other, itemCollections);

                            if (material.type == ItemID.Zenith && TryFind("FargowiltasSouls", "BerserkerSoul", out ModItem berserkerSoul) && item.type == berserkerSoul.Type)
                                AddToCollection(material.type, ShopGroup.Other, itemCollections);
                        }
                    }
                    break;

                case SquirrelSellType.CraftableMaterialsSold:
                    foreach (Recipe recipe in Main.recipe.Where(recipe => recipe.HasResult(item.type)))
                    {
                        foreach (Item material in recipe.requiredItem)
                        {
                            if (material.type != ItemID.None)
                            {
                                if (Main.recipe.Any(recipe => recipe.HasResult(material.type))) //only put in materials that have recipes themselves
                                    AddToCollection(material.type, shopGroup, itemCollections);
                            }
                        }
                    }
                    break;

                case SquirrelSellType.SoldAtThirtyStack:
                    if (item.stack >= 30)
                        AddToCollection(item.type, shopGroup, itemCollections);
                    break;

                case SquirrelSellType.End:
                default:
                    break;
            }
        }

        private List<int> GetSellableItems()
        {
            List<int>[] itemCollections = new List<int>[(int)ShopGroup.End]; //so they can be grouped by category
            for (int i = 0; i < itemCollections.Length; i++)
                itemCollections[i] = new List<int>();

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (!player.active)
                    continue;

                foreach (Item item in player.inventory)
                    TryAddItem(item, itemCollections);

                foreach (Item item in player.armor)
                    TryAddItem(item, itemCollections);

                foreach (Item item in player.bank.item)
                    TryAddItem(item, itemCollections);

                if (player.unlockedBiomeTorches)
                    AddToCollection(ItemID.TorchGodsFavor, ShopGroup.Other, itemCollections);
            }

            //add town npcs to shop
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].townNPC && Items.CaughtNPCs.CaughtNPCItem.CaughtTownies.ContainsKey(Main.npc[i].type))
                    AddToCollection(Items.CaughtNPCs.CaughtNPCItem.CaughtTownies[Main.npc[i].type], ShopGroup.Other, itemCollections);
            }

            //add acorns to shop
            AddToCollection(ItemID.Acorn, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeAmberSeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeAmethystSeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeDiamondSeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeEmeraldSeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeRubySeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeSapphireSeed, ShopGroup.Acorn, itemCollections);
            AddToCollection(ItemID.GemTreeTopazSeed, ShopGroup.Acorn, itemCollections);

            List<int> sellableItems = new List<int>();
            for (int i = 0; i < itemCollections.Length; i++)
            {
                itemCollections[i].Sort();

                sellableItems.AddRange(itemCollections[i]);
            }
            return sellableItems;
        }

        const int maxShop = 40;

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            nextSlot = 0; //ignore pylon and anything else inserted into shop

            if (shopNum == 0 && TryFind("FargowiltasSouls/TopHatSquirrelCaught", out ModItem modItem)) //only on page 1
            {
                shop.item[nextSlot].SetDefaults(modItem.Type);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                nextSlot++;
            }

            List<int> sellableItems = GetSellableItems();
            int i = 0;
            int startOffset = shopNum * maxShop;
            if (startOffset < 0)
                startOffset = 0;

            foreach (int type in sellableItems)
            {
                if (++i < startOffset) //skip up to the minimum
                    continue;

                if (nextSlot >= maxShop) //only fill shop up to capacity
                    break;

                shop.item[nextSlot].SetDefaults(type);
                if (shop.item[nextSlot].makeNPC != 0)
                {
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 10);
                    int[] pricier = new int[]
                    {
                        ItemID.TruffleWorm,
                        ItemID.EmpressButterfly,
                        ItemID.GoldBird,
                        ItemID.GoldBunny,
                        ItemID.GoldButterfly,
                        ItemID.GoldDragonfly,
                        ItemID.GoldFrog,
                        ItemID.GoldGoldfish,
                        ItemID.GoldGrasshopper,
                        ItemID.GoldLadyBug,
                        ItemID.GoldMouse,
                        ItemID.GoldSeahorse,
                        ItemID.SquirrelGold,
                        ItemID.GoldWaterStrider,
                        ItemID.GoldWorm
                    };
                    if (pricier.Contains(shop.item[nextSlot].type))
                        shop.item[nextSlot].shopCustomPrice *= 7;
                    else if (shop.item[nextSlot].ModItem is Items.CaughtNPCs.CaughtNPCItem)
                        shop.item[nextSlot].shopCustomPrice *= 3;
                }
                else if (type == ItemID.RodofDiscord)
                {
                    shop.item[nextSlot].shopCustomPrice = 250;
                    shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                }
                else
                {
                    shop.item[nextSlot].shopCustomPrice = shop.item[nextSlot].value * 5;
                }
                nextSlot++;
            }
        }

        public override bool CheckDead()
        {
            if (!FargoWorld.DownedBools["squirrel"])
            {
                FargoWorld.DownedBools["squirrel"] = true;
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.WorldData); //sync world
            }
            return base.CheckDead();
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture2D13 = Request<Texture2D>(Texture).Value;
            //int num156 = Main.NPCTexture[NPC.type].Height / Main.NPCFrameCount[NPC.type]; //ypos of lower right corner of sprite to draw
            //int y3 = num156 * NPC.frame.Y; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = NPC.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = Request<Texture2D>(Texture + "_Glow").Value;
                float scale = (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f;
                spriteBatch.Draw(texture2D14, NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY + 2), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * NPC.Opacity, NPC.rotation, origin2, scale, effects, 0f);
            }
            spriteBatch.Draw(texture2D13, NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY + 2), new Microsoft.Xna.Framework.Rectangle?(rectangle), NPC.GetAlpha(drawColor), NPC.rotation, origin2, NPC.scale, effects, 0f);
            return false;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = Request<Texture2D>(Texture + "_Eyes").Value;
                Rectangle rectangle = NPC.frame;
                Vector2 origin2 = rectangle.Size() / 2f;
                SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture2D14, NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY + 2), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * NPC.Opacity, NPC.rotation, origin2, NPC.scale, effects, 0f);
            }
        }
    }
}