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

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
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
            List<string> dialogue = new List<string>
            {
                "Dynasty wood? Between you and me, that stuff ain't real wood!",
                "Sure cactus isn't wood, but I can still chop it with me trusty axe.",
                "You wouldn't by chance have any fantasies about me... right?",
                "I eat a bowl of woodchips for breakfast... without any milk.",
                "TIIIIIIIIIMMMBEEEEEEEERRR!",
                "I'm a lumberjack and I'm okay, I sleep all night and I work all day!",
                "You won't ever need an axe again with me around.",
                "I have heard of people cutting trees with fish, who does that?",
                "You wanna see me work without my shirt on? Maybe in 2030.",
                "You ever seen the world tree?",
                "You want what? ...Sorry that's not the kind of wood I'm selling.",
                "Why don't I sell acorns? ...I replant all the trees I chop, don't you?",
                "What's the best kind of tree? ... Any if I can chop it.",
                "Can I axe you a question?",
                "Might take a nap under a tree later, care to join me?",
                "I'm an expert in all wood types.",
                "I'm glad there's more trees to chop here at journey's end.",
                "Red is one of my favourite colors, right after wood.",
                "It's always flannel season.",
                "I'm glad my wood put such a big smile on your face."
            };

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurse >= 0)
            {
                dialogue.Add($"I always see {Main.npc[nurse].GivenName} looking at my biceps when I'm working. Wonder if she wants some of my wood.");
            }

            Player player = Main.LocalPlayer;

            if (player.HeldItem.type == ItemID.LucyTheAxe)
            {
                dialogue.Add($"Lucy from that universe.. Interesting things await you.");
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
                string quote = "";
                int itemType;

                if (player.ZoneDesert && !player.ZoneBeach)
                {
                    quote = "While I was chopping down a cactus these things leaped at me, why don't you take care of them?";
                    itemType = Main.rand.Next(new int[] { ItemID.Scorpion, ItemID.BlackScorpion });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Cactus), ItemID.Cactus, 100);
                }
                else if (player.ZoneJungle)
                {
                    quote = "These mahogany trees are full of life, but a tree only has one purpose: to be chopped. Oh yea these fell out of the last one.";
                    itemType = Main.rand.Next(new int[] { ItemID.Buggy, ItemID.Sluggy, ItemID.Grubby, ItemID.Frog });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    itemType = Main.rand.Next(new int[] { ItemID.Mango, ItemID.Pineapple });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.RichMahogany), ItemID.RichMahogany, 50);
                }
                else if (player.ZoneHallow)
                {
                    quote = "This place is a bit fanciful for my tastes, but the wood's as choppable as any. Nighttime has these cool bugs though, take a few.";
                    for (int i = 0; i < 5; i++)
                    {
                        itemType = Main.rand.Next(new int[] { ItemID.LightningBug, ItemID.FairyCritterBlue, ItemID.FairyCritterGreen, ItemID.FairyCritterPink });
                        player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
                    }
                    itemType = Main.rand.Next(new int[] { ItemID.Starfruit, ItemID.Dragonfruit });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Pearlwood), ItemID.Pearlwood, 50);

                    //add prismatic lacewing if post plantera
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.EmpressButterfly), ItemID.EmpressButterfly, 1);
                }
                else if (player.ZoneGlowshroom && Main.hardMode)
                {
                    quote = "Whatever causes these to glow is beyond me, you're probably gonna eat them anyway so have this while you're at it.";
                    itemType = Main.rand.Next(new int[] { ItemID.GlowingSnail, ItemID.TruffleWorm });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.GlowingMushroom), ItemID.GlowingMushroom, 50);
                    //add mushroom grass seeds

                }
                else if (player.ZoneCorrupt || player.ZoneCrimson)
                {
                    quote = "The trees here are probably the toughest in this branch of reality.. Sorry, just tree puns. I found these for you here.";
                    for (int i = 0; i < 5; i++)
                    {
                        itemType = Main.rand.Next(new int[] { ItemID.Elderberry, ItemID.BlackCurrant, ItemID.BloodOrange, ItemID.Rambutan });
                        player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
                    }
                }
                else if (player.ZoneSnow)
                {
                    //penguin
                    quote = "This neck of the woods is pretty eh? Here I've got some of my favorite wood for you.";
                    itemType = Main.rand.Next(new int[] { ItemID.Cherry, ItemID.Plum });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.BorealWood), ItemID.BorealWood, 50);
                }
                else if (player.ZoneBeach)
                {
                    quote = "Even on vacation, I always fit in a little chopping. A couple annoying birds fell out of a palm tree. Take them off my hands.. maybe cook them up?";
                    itemType = Main.rand.Next(new int[] { ItemID.Coconut, ItemID.Banana });
                    player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Seagull), ItemID.Seagull, 5);
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.PalmWood), ItemID.PalmWood, 50);
                }
                else if (player.ZoneUnderworldHeight)
                {
                    quote = "I looked around here for a while and eventually found some weird, ashy trees. Very fragile. I also found these little guys. Please take them, they're hot to hold.";
                    for (int i = 0; i < 5; i++)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.AshWood), ItemID.AshWood, 50);
                        itemType = Main.rand.Next(new int[] { ItemID.HellButterfly, ItemID.MagmaSnail, ItemID.Lavafly });
                        itemType = Main.rand.Next(new int[] { ItemID.SpicyPepper, ItemID.Pomegranate});
                        player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
                    }
                }
                else if (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight)
                {
					if (Main.rand.NextBool(2))
					{
						quote = "I certainly didn't expect to find such wonderful trees down here. Check this out.";

						for (int i = 0; i < 5; i++)
						{
							itemType = Main.rand.Next(new int[] { ItemID.Diamond, ItemID.Ruby, ItemID.Amethyst, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amber });
							player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 3);
							
							itemType = Main.rand.Next(new int[] { ItemID.GemSquirrelDiamond, ItemID.GemSquirrelAmber, ItemID.GemSquirrelAmethyst, ItemID.GemSquirrelEmerald, ItemID.GemSquirrelRuby, ItemID.GemSquirrelSapphire, ItemID.GemSquirrelTopaz, ItemID.GemBunnyAmber, ItemID.GemBunnyAmethyst, ItemID.GemBunnyDiamond, ItemID.GemBunnyEmerald, ItemID.GemBunnyRuby, ItemID.GemBunnySapphire, ItemID.GemBunnyTopaz });
							player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 1);
						}
					}
					else
					{
						quote = "Went for a long haul today, but there were only so many of those strange trees to go around. I did find a lot of these, why don't you give some of them a new home?";
						
						itemType = ItemID.Mouse;
						player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
					}
                }
                //purity, most common option likely
                else// if (player.position.Y > Main.worldSurface)
                {
                    if (Main.dayTime)
                    {
						if (Main.WindyEnoughForKiteDrops && Main.rand.NextBool(2)) //ladybug
						{
							quote = "Seems like the wind brought a bunch of these out of hiding. Some people say they're good luck. All I know is, the only luck I need is a sharp axe!";
							itemType = ItemID.LadyBug;
							player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType, 5);
						}
                        else if (Main.rand.NextBool(3)) //butterfly
                        {
                            quote = "Back in the day, people used to forge butterflies into powerful gear. We try to forget those days... but here have one.";
							for (int i = 0; i < 5; i++)
                            {
								itemType = Main.rand.Next(new int[] { ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly });
								player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
							}
                        }
                        else if (Main.rand.NextBool(20))
                        {
                            quote = "I found this, but I'm not a sappy person. You can have it instead.";
                            player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.EucaluptusSap), ItemID.EucaluptusSap);
                        }
                        else
                        {
                            quote = "These little critters are always falling out of the trees I cut down. Maybe you can find a use for them?";
							for (int i = 0; i < 5; i++)
                            {
								itemType = Main.rand.Next(new int[] { ItemID.Grasshopper, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.Bird, ItemID.BlueJay, ItemID.Cardinal });
								player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
							}
                        }
                    }
                    else
                    {
                        quote = "Chopping trees at night is always relaxing... well except for the flying eyeballs. Have one of these little guys to keep you company.";
                        player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Firefly), ItemID.Firefly);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        itemType = Main.rand.Next(new int[] { ItemID.Lemon, ItemID.Peach, ItemID.Apricot, ItemID.Grapefruit, ItemID.Apple });
                        player.QuickSpawnItem(player.GetSource_OpenItem(itemType), itemType);
                    }
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.Wood), ItemID.Wood, 50);
                }

                Main.npcChatText = quote;
                dayOver = false;
                nightOver = false;
            }
            else
            {
                Main.npcChatText = "I'm resting after a good day of chopping, come back tomorrow and maybe I'll have something else for you.";
            }
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
