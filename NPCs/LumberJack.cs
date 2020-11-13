using Fargowiltas.Gores;
using Fargowiltas.Items.Vanity;
using Fargowiltas.Items.Weapons;
using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;

//using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class LumberJack : ModNPC
    {
        private bool dayOver;
        private bool nightOver;
        //private int woodAmount = 100;

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
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Velocity = 1f });
        }

        /*public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[1] { BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface });
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("LUMBERJACK WOOD MAN (Placeholder Text)"));
        }*/

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
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)ModContent.ItemType<Items.CaughtNPCs.LumberJack>();
        }

        public override bool CanTownNPCSpawn(int numTownnpcs, int money) => ModContent.GetInstance<FargoConfig>().lumber && (FargoWorld.MovedLumberjack || Main.player.Where(player => player.active).Any(player => player.HasItem(ModContent.ItemType<Items.Tiles.WoodenToken>())));

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

        public override string TownNPCName() => Language.GetTextValue("Mods.Fargowiltas.NPC_Names_LumberJack." + Main.rand.Next(12));

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Dynasty"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Cactus"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Fantasies"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.BowlofWoodchips"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Timber"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.LumberJack"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Axe"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Fish"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.TwentyThrity"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.WorldTree"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.NotSellingSexJoke"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Acrons"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.BestTree"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.AxeYouAQuestion"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Nap"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.WoodExpert"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.FavoriteColors"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.FlannelSeason"),
                Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.SexJoke")
            };

            int dryad = NPC.FindFirstNPC(NPCID.Dryad);

            if (dryad >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Dryad", Main.npc[dryad].GivenName));
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);

            if (nurse >= 0)
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.Nurse", Main.npc[nurse].GivenName));
            }

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.ThoriumAstroturf"));
                dialogue.Add(Language.GetTextValue("Mods.Fargowiltas.NPC_Dialogue_LumberJack.ThoriumYew"));
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = Language.GetTextValue("Mods.Fargowiltas.NPC_ChatButtons_LumberJack.TreeTreasures");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Player player = Main.LocalPlayer;

            if (firstButton)
            {
                shop = true;

                return;
            }

            if (dayOver && nightOver)
            {
                string quote = "";

                if (player.ZoneDesert && !player.ZoneBeach)
                {
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Desert");

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Scorpion, ItemID.BlackScorpion }));
                }
                else if (player.ZoneJungle)
                {
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Jungle");

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Buggy, ItemID.Sluggy, ItemID.Grubby, ItemID.Frog }));
                    //add mango and pineapple
                }
                else if (player.ZoneHallow)
                {
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Hallow");

                    List<int> items = new List<int>
                    {
                        ItemID.LightningBug,
                        ItemID.FairyCritterPink,
                        ItemID.FairyCritterBlue,
                        ItemID.FairyCritterGreen,
                        ItemID.Starfruit,
                        ItemID.Dragonfruit
                    };

                    if (Main.hardMode)
                    {
                        items.Add(ItemID.EmpressButterfly);
                    }

                    player.QuickSpawnItem(Main.rand.Next(items));
                }
                else if (player.ZoneGlowshroom && Main.hardMode)
                {
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Glowshroom");

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.GlowingSnail, ItemID.TruffleWorm, ItemID.MushroomGrassSeeds }));
                }
                else if (player.ZoneCorrupt || player.ZoneCrimson)
                {
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Evil");

                    if (player.ZoneCorrupt)
                    {
                        player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Elderberry, ItemID.BlackCurrant }));
                    }
                    else
                    {
                        player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.BloodOrange, ItemID.Rambutan }));
                    }
                }
                //purity, most common option likely
                else if (!player.ZoneSnow && player.position.Y > Main.worldSurface)
                {
                    if (Main.dayTime)
                    {
                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Purity0");

                                player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly }));
                                break;

                            case 1:
                                quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Purity1");

                                player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Grasshopper, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.Bird, ItemID.Cardinal, ItemID.BlueJay }));
                                break;

                            case 2:
                                // TODO: Dialogue.
                                quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Purity2");

                                List<int> items = new List<int>()
                                {
                                    ItemID.Apple,
                                    ItemID.Peach,
                                    ItemID.Apricot,
                                    ItemID.Grapefruit,
                                    ItemID.Lemon
                                };

                                if (Main.rand.NextBool(2))
                                {
                                    items.Add(ItemID.EucaluptusSap);
                                }

                                if (Main.IsItAHappyWindyDay)
                                {
                                    items.Add(ItemID.LadyBug);
                                }

                                if (player.ZoneGraveyard)
                                {
                                    items.Add(ItemID.Rat);
                                }

                                player.QuickSpawnItem(Main.rand.Next(items));
                                break;
                        }
                    }
                    else
                    {
                        quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Night");

                        player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Firefly }));
                    }
                }
                else if (player.ZoneBeach)
                {
                    // TODO: Dialogue.
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Beach");

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Seagull, ItemID.Coconut, ItemID.Banana }));
                }
                else if (player.ZoneSnow)
                {
                    // TODO: Dialogue.
                    quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Snow");

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Plum, ItemID.Cherry, ItemID.Penguin }));
                }
                else if (player.ZoneRockLayerHeight)
                {
                    if (player.ZoneRockLayerHeight)
                    {
                        // TODO: Dialogue.
                        quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Underground1");
                    }
                    else
                    {
                        quote = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.Underground2");
                    }

                    player.QuickSpawnItem(Main.rand.Next(new int[] { ItemID.Snail }));
                }

                Main.npcChatText = quote;
                dayOver = false;
                nightOver = false;
            }
            else
            {
                Main.npcChatText = Language.GetTextValue("Mods.Fargowiltas.LumberJackTreasures.LazyAss");
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Wood);
            shop.item[nextSlot++].value = 10;

            shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
            shop.item[nextSlot++].value = 10;

            shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
            shop.item[nextSlot++].value = 15;

            shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
            shop.item[nextSlot++].value = 15;

            shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
            shop.item[nextSlot++].value = 15;

            shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
            shop.item[nextSlot++].value = 15;

            if (Fargowiltas.ModLoaded("CrystiliumMod"))
            {
                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["CrystiliumMod"].ItemType("CrystalWood"));
                shop.item[nextSlot++].value = 20;
            }

            if (Fargowiltas.ModLoaded("CosmeticVariety") && NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["CosmeticVariety"].ItemType("Starwood"));
                shop.item[nextSlot++].value = 20;
            }

            shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
            shop.item[nextSlot++].value = 20;

            if (NPC.downedHalloweenKing)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SpookyWood);
                shop.item[nextSlot++].value = 50;
            }

            if (Fargowiltas.ModLoaded("Redemption"))
            {
                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["Redemption"].ItemType("AncientWood"));
                shop.item[nextSlot++].value = 20;
            }

            if (Fargowiltas.ModLoaded("AAMod"))
            {
                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["AAmod"].ItemType("Razewood"));
                shop.item[nextSlot++].value = 50;

                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["AAmod"].ItemType("Bogwood"));
                shop.item[nextSlot++].value = 50;

                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["AAmod"].ItemType("OroborosWood"));
                shop.item[nextSlot++].value = 50;
            }

            shop.item[nextSlot].SetDefaults(ItemID.Cactus);
            shop.item[nextSlot++].value = 10;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<LumberjackMask>());
            shop.item[nextSlot++].value = 10000;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<LumberjackBody>());
            shop.item[nextSlot++].value = 10000;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<LumberjackPants>());
            shop.item[nextSlot++].value = 10000;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<LumberJaxe>());
            shop.item[nextSlot++].value = 10000;

            shop.item[nextSlot].SetDefaults(ItemID.SharpeningStation);
            shop.item[nextSlot++].value = 100000;
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
            projType = ModContent.ProjectileType<Projectiles.LumberJaxeProj>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void /*OnKill*/ NPCLoot() => FargoWorld.MovedLumberjack = true;

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                /*Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, ModContent.GoreType<LumberGore1>());

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, ModContent.GoreType<LumberGore2>());

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, ModContent.GoreType<LumberGore3>());*/
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}