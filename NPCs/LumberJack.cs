using System.Collections.Generic;
using System.Linq;
using Fargowiltas.Common.Configs;
using Fargowiltas.Items.Tiles;
using Fargowiltas.Items.Vanity;
using Fargowiltas.Items.Weapons;
using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class LumberJack : ModNPC
    {
        private bool dayOver;
        private bool nightOver;


        //public override bool Autoload(ref string name)
        //{
        //    name = "LumberJack";
        //    return mod.Properties.Autoload;
        //}

        public override ITownNPCProfile TownNPCProfile()
        {
            return new LumberJackProfile();
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("LumberJack");

            Main.npcFrameCount[NPC.type] = 25;

            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

            NPCID.Sets.ShimmerTownTransform[NPC.type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);

            NPC.Happiness.SetNPCAffection<Squirrel>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.Dryad, AffectionLevel.Dislike);
            NPC.Happiness.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate);

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.Fargowiltas.Bestiary.LumberJack")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;

            //if (GetInstance<FargoConfig>().CatchNPCs)
            //{
            //    Main.npcCatchable[NPC.type] = true;
            //    NPC.catchItem = (short)mod.ItemType("LumberJack");
            //}
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            return GetInstance<FargoServerConfig>().Lumber && FargoWorld.DownedBools.TryGetValue("lumberjack", out bool down) && down;
        }


        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override void AI()
        {
            if (!Main.dayTime)
            {
                nightOver = true;
            }

            if (Main.dayTime)
            {
                dayOver = true;
            }
        }

        public override List<string> SetNPCNameList()
        {
            string[] names = { "Griff", "Jack", "Bruce", "Larry", "Will", "Jerry", "Liam", "Stan", "Lee", "Woody", "Leif", "Paul" };

            return new List<string>(names);
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                dialogue.Add(LumberChat($"Normal{i}"));
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurse >= 0)
            {
                dialogue.Add(LumberChat("Nurse", Main.npc[nurse].GivenName));
            }

            Player player = Main.LocalPlayer;

            if (player.HeldItem.type == ItemID.LucyTheAxe)
            {
                dialogue.Add(LumberChat("LucyTheAxe"));
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = Language.GetTextValue("Mods.Fargowiltas.NPCs.LumberJack.TreeTreasures");
        }

        public const string ShopName = "Shop";

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Player player = Main.LocalPlayer;

            if (firstButton)
            {
                shopName = ShopName;
                return;
            }

            if (dayOver && nightOver)
            {
                string finalQuote = "";
                bool givenBiomeTreasure = false;

                foreach (var (condition, spawn, quote) in BiomeTreeTreasures)
                {
                    if (condition())
                    {
                        spawn();
                        finalQuote = quote;
                        givenBiomeTreasure = true;
                        break; // break true; in c# when
                    }
                }

                if (!givenBiomeTreasure)
                {
                    // purity things, put in a separate list to make the biome list easier to use.

                    for (int i = 0; i < 5; i++)
                    {
                        int itemType = Main.rand.Next(new int[] { ItemID.Lemon, ItemID.Peach, ItemID.Apricot, ItemID.Grapefruit, ItemID.Apple });
                        player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
                    }
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Wood), ItemID.Wood, 50);

                    foreach (var (condition, spawn, quote) in PurityTreeTreasures)
                    {
                        if (condition())
                        {
                            spawn();
                            finalQuote = quote;
                            givenBiomeTreasure = true;
                            break;
                        }
                    }
                }

                Main.npcChatText = finalQuote;
                dayOver = false;
                nightOver = false;
            }
            else
            {
                Main.npcChatText = LumberChat("Rest");
            }
        }

        private readonly static List<Tuple<Func<bool>, Action, string>> BiomeTreeTreasures = new();
        private readonly static List<Tuple<Func<bool>, Action, string>> PurityTreeTreasures = new();
        public static void AddTreeTreasure(Func<bool> condition, Action items, string quote, int insertIndex = -1)
        {
            if (insertIndex == -1)
            {
                BiomeTreeTreasures.Add(new(condition, items, quote));
            }
            else 
            {
                BiomeTreeTreasures.Insert(insertIndex, new(condition, items, quote));
            }
        }

        internal static void AddVanillaTreeTreasures()
        {
            // if-else loop advanced edition
            AddTreeTreasure(() => Main.LocalPlayer.ZoneDesert && !Main.LocalPlayer.ZoneBeach, () =>
            {
                int itemType = Main.rand.Next(new int[] { ItemID.Scorpion, ItemID.BlackScorpion });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.Cactus), ItemID.Cactus, 100);
            }, LumberChat("Desert"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneJungle, () =>
            {
                int itemType = Main.rand.Next(new int[] { ItemID.Buggy, ItemID.Sluggy, ItemID.Grubby, ItemID.Frog });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                itemType = Main.rand.Next(new int[] { ItemID.Mango, ItemID.Pineapple });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.RichMahogany), ItemID.RichMahogany, 50);
            }, LumberChat("Jungle"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneHallow, () =>
            {
                int itemType;
                for (int i = 0; i < 5; i++)
                {
                    itemType = Main.rand.Next(new int[] { ItemID.LightningBug, ItemID.FairyCritterBlue, ItemID.FairyCritterGreen, ItemID.FairyCritterPink });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType);
                }
                itemType = Main.rand.Next(new int[] { ItemID.Starfruit, ItemID.Dragonfruit });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.Pearlwood), ItemID.Pearlwood, 50);

                //add prismatic lacewing if post plantera
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.EmpressButterfly), ItemID.EmpressButterfly, 1);
            }, LumberChat("Hallow"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneGlowshroom && Main.hardMode, () =>
            {
                int itemType = Main.rand.Next(new int[] { ItemID.GlowingSnail, ItemID.TruffleWorm });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.GlowingMushroom), ItemID.GlowingMushroom, 50);
                //add mushroom grass seeds
            }, LumberChat("GlowshroomHM"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneCorrupt || Main.LocalPlayer.ZoneCrimson, () =>
            {
                int itemType;
                for (int i = 0; i < 5; i++)
                {
                    itemType = Main.rand.Next(new int[] { ItemID.Elderberry, ItemID.BlackCurrant, ItemID.BloodOrange, ItemID.Rambutan });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType);
                }
            }, LumberChat("Evil"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneSnow, () =>
            {
                int itemType;
                itemType = Main.rand.Next(new int[] { ItemID.Cherry, ItemID.Plum });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.BorealWood), ItemID.BorealWood, 50);
            }, LumberChat("Snow"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneBeach, () =>
            {
                int itemType;
                itemType = Main.rand.Next(new int[] { ItemID.Coconut, ItemID.Banana });
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.Seagull), ItemID.Seagull, 5);
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.PalmWood), ItemID.PalmWood, 50);
            }, LumberChat("Beach"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneUnderworldHeight, () =>
            {
                int itemType;
                for (int i = 0; i < 5; i++)
                {
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.AshWood), ItemID.AshWood, 50);
                    itemType = Main.rand.Next(new int[] { ItemID.HellButterfly, ItemID.MagmaSnail, ItemID.Lavafly });
                    itemType = Main.rand.Next(new int[] { ItemID.SpicyPepper, ItemID.Pomegranate });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType);
                }
            }, LumberChat("Underworld"));
            AddTreeTreasure(() => (Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneDirtLayerHeight) && Main.rand.NextBool(2), () =>
            {
                int itemType;
                for (int i = 0; i < 5; i++)
                {
                    itemType = Main.rand.Next(new int[] { ItemID.Diamond, ItemID.Ruby, ItemID.Amethyst, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amber });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 3);

                    itemType = Main.rand.Next(new int[] { ItemID.GemSquirrelDiamond, ItemID.GemSquirrelAmber, ItemID.GemSquirrelAmethyst, ItemID.GemSquirrelEmerald, ItemID.GemSquirrelRuby, ItemID.GemSquirrelSapphire, ItemID.GemSquirrelTopaz, ItemID.GemBunnyAmber, ItemID.GemBunnyAmethyst, ItemID.GemBunnyDiamond, ItemID.GemBunnyEmerald, ItemID.GemBunnyRuby, ItemID.GemBunnySapphire, ItemID.GemBunnyTopaz });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 1);
                }
            }, LumberChat("DirtRockGem"));
            AddTreeTreasure(() => Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneDirtLayerHeight, () =>
            {
                int itemType = ItemID.Mouse;
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
            }, LumberChat("DirtRockMouse"));

            PurityTreeTreasures.Add(new(() => Main.dayTime && Main.WindyEnoughForKiteDrops && Main.rand.NextBool(2), () =>
            {
                int itemType = ItemID.LadyBug;
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType, 5);
            }, LumberChat("CommonDayTimeWindy")));
            PurityTreeTreasures.Add(new(() => Main.dayTime && Main.rand.NextBool(3), () =>
            {
                for (int i = 0; i < 5; i++)
                {
                    int itemType = Main.rand.Next(new int[] { ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType);
                }
            }, LumberChat("CommonDayTimeButterfly")));
            PurityTreeTreasures.Add(new(() => Main.dayTime && Main.rand.NextBool(20), () =>
            {
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.EucaluptusSap), ItemID.EucaluptusSap);
            }, LumberChat("CommonDayTimeEucaluptusSap")));
            PurityTreeTreasures.Add(new(() => Main.dayTime, () =>
            {
                for (int i = 0; i < 5; i++)
                {
                    int itemType = Main.rand.Next(new int[] { ItemID.Grasshopper, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.Bird, ItemID.BlueJay, ItemID.Cardinal });
                    Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(itemType), itemType);
                }
            }, LumberChat("CommonDayTimeCritter")));
            PurityTreeTreasures.Add(new(() => !Main.dayTime, () =>
            {
                Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_OpenItem(ItemID.Firefly), ItemID.Firefly);
            }, LumberChat("CommonNightTime")));
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(new Item(ItemID.WoodPlatform) { shopCustomPrice = Item.buyPrice(copper: 5) })
                .Add(new Item(ItemID.Wood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                .Add(new Item(ItemID.BorealWood) { shopCustomPrice = Item.buyPrice(copper: 10) })
                .Add(new Item(ItemID.RichMahogany) { shopCustomPrice = Item.buyPrice(copper: 15) })
                .Add(new Item(ItemID.PalmWood) { shopCustomPrice = Item.buyPrice(copper: 15) })
                .Add(new Item(ItemID.Ebonwood) { shopCustomPrice = Item.buyPrice(copper: 15) })
                .Add(new Item(ItemID.Shadewood) { shopCustomPrice = Item.buyPrice(copper: 15) })
                .Add(new Item(ItemID.AshWood) { shopCustomPrice = Item.buyPrice(copper: 20) })
                .Add(new Item(ItemID.Pearlwood) { shopCustomPrice = Item.buyPrice(copper: 20) }, Condition.Hardmode)
                .Add(new Item(ItemID.SpookyWood) { shopCustomPrice = Item.buyPrice(copper: 50) }, Condition.DownedPumpking)
                .Add(new Item(ItemID.Cactus) { shopCustomPrice = Item.buyPrice(copper: 10) })
                .Add(new Item(ItemID.BambooBlock) { shopCustomPrice = Item.buyPrice(copper: 10) })
                .Add(new Item(ItemID.LivingWoodWand) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemType<LumberjackMask>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemType<LumberjackBody>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemType<LumberjackPants>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemType<Items.Weapons.LumberJaxe>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                .Add(new Item(ItemID.SharpeningStation) { shopCustomPrice = Item.buyPrice(copper: 100000) })
                .Add(new Item(ItemType<WoodenToken>()) { shopCustomPrice = Item.buyPrice(copper: 10000) })
                ;

            npcShop.Register();
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
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
            projType = ModContent.ProjectileType<Projectiles.LumberJaxe>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void OnKill()
        {
            FargoWorld.DownedBools["lumberjack"] = true;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "LumberGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "LumberGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("Fargowiltas", "LumberGore1").Type);
                }
            }
            else
            {
                for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hit.HitDirection, -1f, Scale: 0.6f);
                }
            }
        }

        private static string LumberChat(string key, params object[] args) => Language.GetTextValue($"Mods.Fargowiltas.NPCs.LumberJack.Chat.{key}", args);
    }

    public class LumberJackProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
                return ModContent.Request<Texture2D>("Fargowiltas/NPCs/LumberJack");
            if (npc.IsABestiaryIconDummy && npc.ForcePartyHatOn)
                return ModContent.Request<Texture2D>("Fargowiltas/NPCs/LumberJack_Party");

            if (npc.IsShimmerVariant)
            {
                if (npc.altTexture == 1)
                {
                    return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Lumberjack_Shimmer_Party");
                }
                else
                {
                    return ModContent.Request<Texture2D>("Fargowiltas/NPCs/Lumberjack_Shimmer");
                }
            }

            if (npc.altTexture == 1)
                return ModContent.Request<Texture2D>("Fargowiltas/NPCs/LumberJack_Party");

            return ModContent.Request<Texture2D>("Fargowiltas/NPCs/LumberJack");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Fargowiltas/NPCs/LumberJack_Head");
    }
}
