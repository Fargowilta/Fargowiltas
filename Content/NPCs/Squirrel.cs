using Fargowiltas.Common.Configs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.Content;
using Fargowiltas.Content.UI.Emotes;

namespace Fargowiltas.Content.NPCs
{
    [AutoloadHead]
    public class Squirrel : ModNPC
    {
        private static int shopNum;
        private static bool showCycleShop;
        private static Profiles.StackedNPCProfile NPCProfile;
        private static int ShimmerHeadIndex;

        public override void Load()
        {
            ShimmerHeadIndex = ModContent.GetModHeadSlot(Texture + "_Shimmer_Head");
        }

        private const string ShopName = "Shop";

        private Asset<Texture2D> GlowAsset => ModContent.Request<Texture2D>(Texture + "_Glow");

        private Asset<Texture2D> EyesAsset => ModContent.Request<Texture2D>(Texture + "_Eyes");

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 6;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            //NPCID.Sets.HatOffsetY[Type] = 4;
            NPCID.Sets.FaceEmote[NPC.type] = ModContent.EmoteBubbleType<SquirrelEmote>();

            NPCID.Sets.CannotSitOnFurniture[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate);
            NPC.Happiness.SetNPCAffection<LumberJack>(AffectionLevel.Like);

            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party")
                //new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, null)
            );
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 34;
            NPC.height = 42;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = .25f;

            AnimationType = NPCID.Squirrel;
            NPC.aiStyle = NPCAIStyleID.Passive;
        }

        public override void ChatBubblePosition(ref Vector2 position, ref SpriteEffects spriteffects)
        {   
            if (!NPC.IsShimmerVariant)
                position.Y += 17f;
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.Fargowiltas.Bestiary.Squirrel")
            });
        }

        public override List<string> SetNPCNameList()
        {
            string[] names =
               [Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName1"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName2"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName3"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName4"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName5"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName6"),
                Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.NPCName7")];

            return new List<string>(names);
        }
        public override void OnSpawn(IEntitySource source)
        {
            FargoWorld.DownedBools["squirrel"] = true;
            base.OnSpawn(source);
        }
        public override void AI()
        {
            NPC.dontTakeDamage = Main.bloodMoon;
            DrawOffsetY = -2;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (FargoGlobalNPC.AnyBossAlive() || !FargoServerConfig.Instance.Squirrel)
            {
                return false;
            }
            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

            if (!Fargowiltas.ModLoaded["FargowiltasSouls"] && NPC.downedSlimeKing)
                return true;

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && ModContent.TryFind("FargowiltasSouls", "TopHatSquirrelCaught", out ModItem modItem) && 
                Main.player.Any(p => p.active && p.HasItem(modItem.Type)))
            {
                return true;
            }

            return false;
        }

        public override string GetChat()
        {
            showCycleShop = GetSellableItems().Count / MaxItems > 0; // && !ModLoader.TryGetMod("ShopExpander", out _);

            if (Main.bloodMoon)
            {
                return SquirrelChat("BloodMoon");
            }

            return Main.rand.Next(3) switch
            {
                0 => SquirrelChat("Normal1"),
                1 => SquirrelChat("Normal2"),
                _ => SquirrelChat("Normal3"),
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            if (showCycleShop)
            {
                button += $" {shopNum + 1}";
                button2 = Language.GetTextValue("Mods.Fargowiltas.NPCs.Mutant.CycleShop");
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopName;
            }
            else
            {
                shopNum++;
            }

            //check this when just opening shop too in case shop shrinks
            if (shopNum > GetSellableItems().Count / MaxItems)
            {
                shopNum = 0;
            }
        }
        public static List<(string, string)> SquirrelSellsModded = 
            [
            ("FargowiltasSouls", "BionomicCluster"),
            ("FargowiltasSouls","HeartoftheMasochist"),
            ("FargowiltasSouls","ChaliceoftheMoon"),
            ("FargowiltasSouls","DubiousCircuitry"),
            ("FargowiltasSouls","LumpOfFlesh"),
            ("FargowiltasSouls","PureHeart"),
            ("FargowiltasSouls","SupremeDeathbringerFairy"),
            ];
        public static List<(string, string)> SquirrelSellsMaterialsModded =
            [
            ("FargowiltasSouls", "MasochistSoul"),
            ("FargowiltasSouls", "AeolusBoots"),
            ("FargowiltasSouls", "ZephyrBoots")
            ];
        public static SquirrelShopGroup SquirrelSells(Item item, out SquirrelSellType sellType)
        {

            if (item.type == ItemID.Zenith)
            {
                sellType = SquirrelSellType.CraftableMaterialsSold;
                return SquirrelShopGroup.Other;
            }

            if (item.makeNPC != 0 || FargoSets.Items.SquirrelSellsDirectly[item.type])
            {
                sellType = SquirrelSellType.SoldBySquirrel;
                return SquirrelShopGroup.Other;
            }

            bool Potion = item.buffType != 0 && item.type != ItemID.GrilledSquirrel || FargoSets.Items.NonBuffPotion[item.type];
            if (Potion && item.maxStack >= 30)
            {
                sellType = SquirrelSellType.SoldAtThirtyStack;
                return SquirrelShopGroup.Potion;
            }
            bool soulsEnabled = ModLoader.TryGetMod("FargowiltasSouls", out Mod soulsMod);

            if (IsFargoSoulsItem(item))
            {
                if (item.ModItem.Name.EndsWith("Enchant"))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return SquirrelShopGroup.Enchant;
                }
                else if (item.ModItem.Name.EndsWith("Essence"))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return SquirrelShopGroup.Essence;
                }
                else if (soulsEnabled && SquirrelSellsModded.Any(s => ModContent.TryFind(s.Item1, s.Item2, out ModItem modItem) && modItem.Type == item.type))
                {
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return SquirrelShopGroup.Other;
                }
                else if (item.ModItem.Name.EndsWith("Force"))
                {
                    sellType = SquirrelSellType.SomeMaterialsSold;
                    return SquirrelShopGroup.Enchant;
                }
                else if (soulsEnabled && SquirrelSellsMaterialsModded.Any(s => ModContent.TryFind(s.Item1, s.Item2, out ModItem modItem) && modItem.Type == item.type))
                {
                    sellType = SquirrelSellType.CraftableMaterialsSold;
                    return SquirrelShopGroup.Other;
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
                                    return SquirrelShopGroup.Essence;
                                }
                                else if (material.ModItem.Name.EndsWith("Force"))
                                {
                                    sellType = SquirrelSellType.SomeMaterialsSold;
                                    return SquirrelShopGroup.Force;
                                }
                                else if (material.ModItem.Name.EndsWith("Soul"))
                                {
                                    sellType = SquirrelSellType.SomeMaterialsSold;
                                    return SquirrelShopGroup.Soul;
                                }
                            }
                        }
                    }

                    //if nothing found, sell the soul itself
                    sellType = SquirrelSellType.SoldBySquirrel;
                    return SquirrelShopGroup.Soul;
                }
            }

            sellType = SquirrelSellType.End;
            return SquirrelShopGroup.End;
        }
        public void TryAddItem(Item item, Dictionary<SquirrelShopGroup, SortedSet<int>> itemCollections)
        {
            var shopGroup = SquirrelSells(item, out SquirrelSellType sellType);
            switch (sellType)
            {
                case SquirrelSellType.SoldBySquirrel:
                    {
                        itemCollections[shopGroup].Add(item.type);
                    } 
                    break;

                case SquirrelSellType.SomeMaterialsSold:
                    foreach (var recipe in Main.recipe.Where(recipe => recipe.HasResult(item.type)))
                    {
                        foreach (var material in recipe.requiredItem)
                        {
                            if (material.ModItem is not null && material.ModItem.Name.EndsWith(shopGroup.ToString()))
                            {
                                itemCollections[shopGroup].Add(material.type);
                            }
                        }
                    }
                    break;

                case SquirrelSellType.CraftableMaterialsSold:
                    //var materialTypes = new HashSet<int>(Main.recipe.SelectMany(recipe => recipe.requiredItem.Select(item => item.type)).Where(type => type != ItemID.None));
                    foreach (var recipe in Main.recipe.Where(recipe => recipe.HasResult(item.type)))
                    {
                        foreach (var material in recipe.requiredItem)
                        {
                            if (material.type != ItemID.None && Main.recipe.Any(r => r.HasResult(material.type)))
                            {
                                itemCollections[shopGroup].Add(material.type);
                            }
                        }
                    }
                    break;

                case SquirrelSellType.SoldAtThirtyStack:
                    foreach (Player player in Main.player.Where(p => p.active))
                    {
                        if (player.GetFargoPlayer().ItemHasBeenOwnedAtThirtyStack[item.type])
                            itemCollections[shopGroup].Add(item.type);
                    }
                    break;

                default:
                    break;
            }
        }

        private List<int> GetSellableItems()
        {
            Dictionary<SquirrelShopGroup, SortedSet<int>> itemCollections = new();
            for (int i = 0; i < (int)SquirrelShopGroup.End; i++)
            {
                itemCollections[(SquirrelShopGroup)i] = [];
            }

            foreach (var player in Main.player.Where(p => p.active))
            {
                FargoPlayer modPlayer = player.GetFargoPlayer();

                foreach (var item in player.inventory)
                {
                    if (SquirrelSells(item, out SquirrelSellType _) == SquirrelShopGroup.End)
                        continue;
                    modPlayer.ItemHasBeenOwned[item.type] = true;
                    if (item.stack >= 30)
                        modPlayer.ItemHasBeenOwnedAtThirtyStack[item.type] = true;
                }
                    
                foreach (var item in player.bank.item)
                {
                    if (SquirrelSells(item, out SquirrelSellType _) == SquirrelShopGroup.End)
                        continue;
                    modPlayer.ItemHasBeenOwned[item.type] = true;
                    if (item.stack >= 30)
                        modPlayer.ItemHasBeenOwnedAtThirtyStack[item.type] = true;
                }
                   
                foreach (var item in player.armor)
                {
                    if (SquirrelSells(item, out SquirrelSellType _) == SquirrelShopGroup.End)
                        continue;
                    modPlayer.ItemHasBeenOwned[item.type] = true;
                    if (item.stack >= 30)
                        modPlayer.ItemHasBeenOwnedAtThirtyStack[item.type] = true;
                }

                foreach (var item in ContentSamples.ItemsByType)
                {
                    if (modPlayer.ItemHasBeenOwned[item.Key])
                    {
                        TryAddItem(item.Value, itemCollections);
                    }
                }

                if (player.unlockedBiomeTorches)
                {
                    itemCollections[SquirrelShopGroup.Other].Add(ItemID.TorchGodsFavor);
                }
            }



            

            //add town npcs to shop
            foreach (var npc in Main.npc.Where(n => n.active && n.townNPC && Items.CaughtNPCs.CaughtNPCItem.CaughtTownies.ContainsKey(n.type)))
            {
                itemCollections[SquirrelShopGroup.Other].Add(Items.CaughtNPCs.CaughtNPCItem.CaughtTownies[npc.type]);
            }

            //add acorns to shop
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.Acorn);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeAmberSeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeAmethystSeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeDiamondSeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeEmeraldSeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeRubySeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeSapphireSeed);
            itemCollections[SquirrelShopGroup.Acorn].Add(ItemID.GemTreeTopazSeed);

            return itemCollections.OrderBy(kv => kv.Key).SelectMany(kv => kv.Value).ToList();
        }
        public static bool IsFargoSoulsItem(Item item)
        {
            if (item.ModItem is not null)
            {
                string modName = item.ModItem.Mod.Name;
                return modName.Equals("FargowiltasSouls") || modName.Equals("FargowiltasSoulsDLC");
            }

            return false;
        }
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName);

            npcShop.Register();
        }
        public static int MaxItems => ModLoader.HasMod("ShopExpander") ? Chest.maxItems - 2 : Chest.maxItems;
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            int nextSlot = 0; //ignore pylon and anything else inserted into shop ( how does this work in new system?
            int index = 0;
            int startOffset = shopNum * MaxItems;

            List<int> sellableItems = GetSellableItems();
            if (shopNum == 0 && ModContent.TryFind("FargowiltasSouls", "TopHatSquirrelCaught", out ModItem modItem)) //only on page 1
            {
                items[nextSlot] = new Item(modItem.Type) { shopCustomPrice = Item.buyPrice(copper: 100000) };
                nextSlot++;
            }
            foreach (int type in sellableItems)
            {
                if (++index < startOffset) //skip up to the minimum
                {
                    continue;
                }

                if (nextSlot >= MaxItems) //only fill shop up to capacity
                {
                    break;
                }

                var item = new Item(type);
                int price;
                bool medals = false;

                if (item.makeNPC != 0)
                {
                    price = Item.buyPrice(gold: 10);
                    int[] pricier =
                    [
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
                    ];

                    if (pricier.Contains(item.type))
                    {
                        price *= 5;
                    }
                    else if (item.ModItem is Items.CaughtNPCs.CaughtNPCItem)
                    {
                        price *= 2;
                    }
                }
                else if (type == ItemID.RodofDiscord)
                {
                    price = 250;
                    medals = true;
                }
                else
                {
                    price = item.value * 2;
                }

                if (medals)
                {
                    items[nextSlot] = new Item(type) { shopCustomPrice = Item.buyPrice(copper: price), shopSpecialCurrency = CustomCurrencyID.DefenderMedals };
                }
                else
                {
                    items[nextSlot] = new Item(type) { shopCustomPrice = Item.buyPrice(copper: price) };
                }

                nextSlot++;
            }
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return toKingStatue;
        }

        public override bool UsesPartyHat()
        {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (!Main.bloodMoon)
            {
                return true;
            }
                    

            Rectangle frame = NPC.frame;
            SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            //Vector2 position = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY + 2);
            float scale = (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f;
            //glow
            for (int j = 0; j < 12; j++)
            {
                Vector2 afterimageOffset = (MathHelper.TwoPi * j / 12f).ToRotationVector2() * 4f + Vector2.UnitY * 3;
                Color glowColor = Color.Red with { A = 0 };
                Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
                Main.EntitySpriteDraw(texture, NPC.Center + afterimageOffset - screenPos + Vector2.UnitY * (NPC.gfxOffY - 1), NPC.frame, glowColor, NPC.rotation, new Vector2(texture.Width / 2, texture.Height / 2 / Main.npcFrameCount[NPC.type]), NPC.scale, effects, 0f);
            }
            return true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (!Main.bloodMoon)
            {
                return;
            }

            Rectangle frame = NPC.frame;
            SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Vector2 position = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY + 2);

            spriteBatch.Draw(EyesAsset.Value, position, frame, Color.White * NPC.Opacity, NPC.rotation, frame.Size() / 2f, NPC.scale, effects, 0f);
        }


        private static string SquirrelChat(string key) => Language.GetTextValue($"Mods.Fargowiltas.NPCs.Squirrel.Chat.{key}");
    }
}