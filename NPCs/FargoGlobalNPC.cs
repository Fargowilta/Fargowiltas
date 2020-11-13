using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    public class FargoGlobalNPC : GlobalNPC
    {
        public static int LastWoFIndex = -1;
        public static int WoFDirection = 0;
        public static int Boss = -1;
        public static int EaterBoss = -1;
        public static int BrainBoss = -1;
        public static int PlantBoss = -1;
        public static int[] Bosses = new int[]
        {
            NPCID.KingSlime,
            NPCID.EyeofCthulhu,
            NPCID.BrainofCthulhu,
            NPCID.QueenBee,
            NPCID.SkeletronHead,
            NPCID.TheDestroyer,
            NPCID.SkeletronPrime,
            NPCID.Retinazer,
            NPCID.Spazmatism,
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.DukeFishron,
            NPCID.CultistBoss,
            NPCID.MoonLordCore,
            NPCID.MartianSaucerCore,
            NPCID.Pumpking,
            NPCID.IceQueen,
            NPCID.DD2Betsy,
            NPCID.DD2OgreT3,
            NPCID.IceGolem,
            NPCID.SandElemental,
            NPCID.Paladin,
            NPCID.Everscream,
            NPCID.MourningWood,
            NPCID.SantaNK1,
            NPCID.HeadlessHorseman,
            NPCID.PirateShip
        };

        public bool pillarSpawn = true;
        public bool swarmActive;
        public bool pandoraActive;
        public bool noLoot = false;

        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            if (ModContent.GetInstance<FargoConfig>().catchNPCs)
            {
                if (npc.townNPC && npc.type < NPCID.Count && npc.type != NPCID.OldMan && npc.type != NPCID.TownCat && npc.type != NPCID.TownDog && npc.type != NPCID.TownBunny)
                {
                    Main.npcCatchable[npc.type] = true;

                    if (npc.type == NPCID.DD2Bartender)
                    {
                        npc.catchItem = (short)ModContent.ItemType<Tavernkeep>();
                    }
                    else if (npc.type == NPCID.BestiaryGirl)
                    {
                        npc.catchItem = (short)ModContent.ItemType<Zoologist>();
                    }
                    else
                    {
                        npc.catchItem = npc.type == NPCID.DD2Bartender ? (short)ModContent.ItemType<Tavernkeep>() : (short)Mod.ItemType(NPCIDUtils.GetUniqueKey(npc.type).Replace("Terraria ", string.Empty));
                    }
                }

                if (npc.type == NPCID.SkeletonMerchant)
                {
                    Main.npcCatchable[npc.type] = true;
                    npc.catchItem = (short)ModContent.ItemType<SkeletonMerchant>();
                }
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.boss)
            {
                Boss = npc.whoAmI;
            }

            switch (npc.type)
            {
                case NPCID.EaterofWorldsHead:
                    EaterBoss = npc.whoAmI;
                    break;

                case NPCID.BrainofCthulhu:
                    BrainBoss = npc.whoAmI;
                    break;

                case NPCID.Plantera:
                    PlantBoss = npc.whoAmI;
                    break;
            }

            return true;
        }

        public override void AI(NPC npc)
        {
            // Wack ghost saucers begone
            if (FargoWorld.OverloadMartians && npc.type == NPCID.MartianSaucerCore && npc.dontTakeDamage)
            {
                npc.dontTakeDamage = false;
            }

            Mod thorium = Fargowiltas.ModLoaded("ThoriumMod") ? Fargowiltas.LoadedMods["ThoriumMod"] : null;

            if (Fargowiltas.SwarmActive && thorium != null)
            {
                if (npc.type == thorium.NPCType("BoreanStriderPopped") || npc.type == thorium.NPCType("FallenDeathBeholder2") || npc.type == thorium.NPCType("LichHeadless") || npc.type == thorium.NPCType("AbyssionReleased"))
                {
                    swarmActive = true;
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.LocalPlayer;

            if (ModContent.GetInstance<FargoConfig>().npcSales)
            {
                switch (type)
                {
                    case NPCID.Clothier:
                        shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
                        shop.item[nextSlot++].value = 10000;

                        shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
                        shop.item[nextSlot++].value = 10000;

                        if (player.anglerQuestsFinished >= 10)
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.AnglerHat);

                            if (player.anglerQuestsFinished >= 15)
                            {
                                shop.item[nextSlot++].SetDefaults(ItemID.AnglerVest);

                                if (player.anglerQuestsFinished >= 20)
                                {
                                    shop.item[nextSlot++].SetDefaults(ItemID.AnglerPants);
                                }
                            }
                        }

                        shop.item[nextSlot].SetDefaults(ItemID.BlueBrick);
                        shop.item[nextSlot++].value = 100;
                        shop.item[nextSlot].SetDefaults(ItemID.GreenBrick);
                        shop.item[nextSlot++].value = 100;
                        shop.item[nextSlot].SetDefaults(ItemID.PinkBrick);
                        shop.item[nextSlot++].value = 100;
                        break;

                    case NPCID.Merchant:
                        if (player.anglerQuestsFinished >= 5)
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.FuzzyCarrot);

                            if (player.anglerQuestsFinished >= 10)
                            {
                                shop.item[nextSlot++].SetDefaults(ItemID.AnglerEarring);
                                shop.item[nextSlot++].SetDefaults(ItemID.HighTestFishingLine);
                                shop.item[nextSlot++].SetDefaults(ItemID.TackleBox);
                                shop.item[nextSlot++].SetDefaults(ItemID.GoldenBugNet);
                                shop.item[nextSlot++].SetDefaults(ItemID.FishHook);

                                if (Main.hardMode)
                                {
                                    shop.item[nextSlot++].SetDefaults(ItemID.FinWings);
                                    shop.item[nextSlot++].SetDefaults(ItemID.SuperAbsorbantSponge);
                                    shop.item[nextSlot++].SetDefaults(ItemID.BottomlessBucket);

                                    if (player.anglerQuestsFinished >= 25)
                                    {
                                        shop.item[nextSlot++].SetDefaults(ItemID.HotlineFishingHook);

                                        if (player.anglerQuestsFinished >= 30)
                                        {
                                            shop.item[nextSlot++].SetDefaults(ItemID.GoldenFishingRod);
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case NPCID.Painter:
                        if (player.ZoneDungeon)
                        {
                            nextSlot = 15;

                            shop.item[nextSlot++].SetDefaults(ItemID.BloodMoonRising);
                            shop.item[nextSlot++].SetDefaults(ItemID.BoneWarp);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheCreationoftheGuide);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheCursedMan);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheDestroyer);
                            shop.item[nextSlot++].SetDefaults(ItemID.Dryadisque);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheEyeSeestheEnd);
                            shop.item[nextSlot++].SetDefaults(ItemID.FacingtheCerebralMastermind);
                            shop.item[nextSlot++].SetDefaults(ItemID.GloryoftheFire);
                            shop.item[nextSlot++].SetDefaults(ItemID.GoblinsPlayingPoker);
                            shop.item[nextSlot++].SetDefaults(ItemID.GreatWave);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheGuardiansGaze);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheHangedMan);
                            shop.item[nextSlot++].SetDefaults(ItemID.Impact);
                            shop.item[nextSlot++].SetDefaults(ItemID.ThePersistencyofEyes);
                            shop.item[nextSlot++].SetDefaults(ItemID.PoweredbyBirds);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheScreamer);
                            shop.item[nextSlot++].SetDefaults(ItemID.SkellingtonJSkellingsworth);
                            shop.item[nextSlot++].SetDefaults(ItemID.SparkyPainting);
                            shop.item[nextSlot++].SetDefaults(ItemID.SomethingEvilisWatchingYou);
                            shop.item[nextSlot++].SetDefaults(ItemID.StarryNight);
                            shop.item[nextSlot++].SetDefaults(ItemID.TrioSuperHeroes);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheTwinsHaveAwoken);
                            shop.item[nextSlot++].SetDefaults(ItemID.UnicornCrossingtheHallows);
                        }
                        else if (player.ZoneRockLayerHeight)
                        {
                            nextSlot = 19;

                            shop.item[nextSlot++].SetDefaults(ItemID.AmericanExplosive);
                            shop.item[nextSlot++].SetDefaults(ItemID.CrownoDevoursHisLunch);
                            shop.item[nextSlot++].SetDefaults(ItemID.Discover);
                            shop.item[nextSlot++].SetDefaults(ItemID.FatherofSomeone);
                            shop.item[nextSlot++].SetDefaults(ItemID.FindingGold);
                            shop.item[nextSlot++].SetDefaults(ItemID.GloriousNight);
                            shop.item[nextSlot++].SetDefaults(ItemID.GuidePicasso);
                            shop.item[nextSlot++].SetDefaults(ItemID.Land);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheMerchant);
                            shop.item[nextSlot++].SetDefaults(ItemID.NurseLisa);
                            shop.item[nextSlot++].SetDefaults(ItemID.OldMiner);
                            shop.item[nextSlot++].SetDefaults(ItemID.RareEnchantment);
                            shop.item[nextSlot++].SetDefaults(ItemID.Sunflowers);
                            shop.item[nextSlot++].SetDefaults(ItemID.TerrarianGothic);
                            shop.item[nextSlot++].SetDefaults(ItemID.Waldo);
                        }
                        else if (player.ZoneUnderworldHeight)
                        {
                            nextSlot = 19;

                            shop.item[nextSlot++].SetDefaults(ItemID.DarkSoulReaper);
                            shop.item[nextSlot++].SetDefaults(ItemID.Darkness);
                            shop.item[nextSlot++].SetDefaults(ItemID.DemonsEye);
                            shop.item[nextSlot++].SetDefaults(ItemID.FlowingMagma);
                            shop.item[nextSlot++].SetDefaults(ItemID.HandEarth);
                            shop.item[nextSlot++].SetDefaults(ItemID.ImpFace);
                            shop.item[nextSlot++].SetDefaults(ItemID.LakeofFire);
                            shop.item[nextSlot++].SetDefaults(ItemID.LivingGore);
                            shop.item[nextSlot++].SetDefaults(ItemID.OminousPresence);
                            shop.item[nextSlot++].SetDefaults(ItemID.ShiningMoon);
                            shop.item[nextSlot++].SetDefaults(ItemID.Skelehead);
                            shop.item[nextSlot++].SetDefaults(ItemID.TrappedGhost);
                        }
                        else if (player.ZoneDesert || player.ZoneUndergroundDesert)
                        {
                            nextSlot = 19;

                            shop.item[nextSlot++].SetDefaults(ItemID.AndrewSphinx);
                            shop.item[nextSlot++].SetDefaults(ItemID.WatchfulAntlion);
                            shop.item[nextSlot++].SetDefaults(ItemID.BurningSpirit);
                            shop.item[nextSlot++].SetDefaults(ItemID.JawsOfDeath);
                            shop.item[nextSlot++].SetDefaults(ItemID.TheSandsOfSlime);
                            shop.item[nextSlot++].SetDefaults(ItemID.SnakesIHateSnakes);
                            shop.item[nextSlot++].SetDefaults(ItemID.LifeAboveTheSand);
                            shop.item[nextSlot++].SetDefaults(ItemID.Oasis);
                            shop.item[nextSlot++].SetDefaults(ItemID.PrehistoryPreserved);
                            shop.item[nextSlot++].SetDefaults(ItemID.AncientTablet);
                            shop.item[nextSlot++].SetDefaults(ItemID.Uluru);
                            shop.item[nextSlot++].SetDefaults(ItemID.VisitingThePyramids);
                            shop.item[nextSlot++].SetDefaults(ItemID.BandageBoy);
                            shop.item[nextSlot++].SetDefaults(ItemID.DivineEye);
                        }
                        break;

                    case NPCID.Demolitionist:
                        if (Main.hardMode)
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.CopperOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.TinOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.IronOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.LeadOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.SilverOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.TungstenOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.GoldOre);
                            shop.item[nextSlot++].SetDefaults(ItemID.PlatinumOre);
                        }
                        break;

                    case NPCID.Steampunker:
                        shop.item[nextSlot++].SetDefaults(WorldGen.crimson ? ItemID.PurpleSolution : ItemID.RedSolution);
                        shop.item[nextSlot++].SetDefaults(WorldGen.crimson ? ItemID.LesionStation : ItemID.FleshCloningVaat);
                        break;

                    case NPCID.DyeTrader:
                        FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

                        if (modPlayer.firstDyeIngredients["RedHusk"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.RedHusk);
                        }

                        if (modPlayer.firstDyeIngredients["OrangeBloodroot"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.OrangeBloodroot);
                        }

                        if (modPlayer.firstDyeIngredients["YellowMarigold"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.YellowMarigold);
                        }

                        if (modPlayer.firstDyeIngredients["LimeKelp"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.LimeKelp);
                        }

                        if (modPlayer.firstDyeIngredients["GreenMushroom"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.GreenMushroom);
                        }

                        if (modPlayer.firstDyeIngredients["TealMushroom"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.TealMushroom);
                        }

                        if (modPlayer.firstDyeIngredients["CyanHusk"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.CyanHusk);
                        }

                        if (modPlayer.firstDyeIngredients["SkyBlueFlower"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.SkyBlueFlower);
                        }

                        if (modPlayer.firstDyeIngredients["BlueBerries"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.BlueBerries);
                        }
                        if
                            (modPlayer.firstDyeIngredients["PurpleMucos"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.PurpleMucos);
                        }

                        if (modPlayer.firstDyeIngredients["VioletHusk"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.VioletHusk);
                        }

                        if (modPlayer.firstDyeIngredients["PinkPricklyPear"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.PinkPricklyPear);
                        }

                        if (modPlayer.firstDyeIngredients["BlackInk"])
                        {
                            shop.item[nextSlot++].SetDefaults(ItemID.BlackInk);
                        }
                        break;

                    case NPCID.Dryad:
                        if (Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.NaturesGift);
                            shop.item[nextSlot++].value = 200000;
                            shop.item[nextSlot].SetDefaults(ItemID.JungleRose);
                            shop.item[nextSlot++].value = 100000;
                            shop.item[nextSlot].SetDefaults(ItemID.StrangePlant1);
                            shop.item[nextSlot++].value = 50000;
                            shop.item[nextSlot].SetDefaults(ItemID.StrangePlant2);
                            shop.item[nextSlot++].value = 50000;
                            shop.item[nextSlot].SetDefaults(ItemID.StrangePlant3);
                            shop.item[nextSlot++].value = 50000;
                            shop.item[nextSlot].SetDefaults(ItemID.StrangePlant4);
                            shop.item[nextSlot++].value = 50000;
                        }
                        break;
                }
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetFargoPlayer().battleCry)
            {
                spawnRate = (int)(spawnRate * 0.1);
                maxSpawns = (int)(maxSpawns * 10f);
            }

            if ((FargoWorld.OverloadGoblins || FargoWorld.OverloadPirates) && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                if (FargoWorld.OverloadGoblins)
                {
                    spawnRate = (int)(spawnRate * 0.2);
                    maxSpawns = (int)(maxSpawns * 10f);
                }
                else if (FargoWorld.OverloadPirates)
                {
                    spawnRate = (int)(spawnRate * 0.2);
                    maxSpawns = (int)(maxSpawns * 30f);
                }
            }

            if (FargoWorld.OverloadPumpkinMoon || FargoWorld.OverloadFrostMoon)
            {
                spawnRate = (int)(spawnRate * 0.2);
                maxSpawns = (int)(maxSpawns * 10f);
            }
            else if (FargoWorld.OverloadMartians)
            {
                spawnRate = (int)(spawnRate * 0.2);
                maxSpawns = (int)(maxSpawns * 30f);
            }

            if (ModContent.GetInstance<FargoConfig>().bossZen && AnyBossAlive())
            {
                maxSpawns = 0;
            }
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Player player = Main.LocalPlayer;

            if (FargoWorld.OverloadGoblins && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                // Literally nothing in the pool in the invasion so set everything to custom
                pool[NPCID.GoblinSummoner] = 1f;
                pool[NPCID.GoblinArcher] = 3f;
                pool[NPCID.GoblinPeon] = 5f;
                pool[NPCID.GoblinSorcerer] = 3f;
                pool[NPCID.GoblinWarrior] = 5f;
                pool[NPCID.GoblinThief] = 5f;
                pool[NPCID.GoblinScout] = 3f;
            }

            if (FargoWorld.OverloadPirates && player.position.X > Main.invasionX * 16.0 - 3000 && player.position.X < Main.invasionX * 16.0 + 3000)
            {
                // Literally nothing in the pool in the invasion so set everything to custom
                if (NPC.CountNPCS(NPCID.PirateShip) < 4)
                {
                    pool[NPCID.PirateShip] = .5f;
                }

                pool[NPCID.Parrot] = 2f;
                pool[NPCID.PirateCaptain] = 1f;
                pool[NPCID.PirateCrossbower] = 3f;
                pool[NPCID.PirateCorsair] = 5f;
                pool[NPCID.PirateDeadeye] = 4f;
                pool[NPCID.PirateDeckhand] = 5f;
            }

            if (FargoWorld.OverloadPumpkinMoon)
            {
                pool[NPCID.Pumpking] = 4f;
                pool[NPCID.MourningWood] = 4f;
                pool[NPCID.HeadlessHorseman] = 3f;
                pool[NPCID.Scarecrow1] = .5f;
                pool[NPCID.Scarecrow2] = .5f;
                pool[NPCID.Scarecrow3] = .5f;
                pool[NPCID.Scarecrow4] = .5f;
                pool[NPCID.Scarecrow5] = .5f;
                pool[NPCID.Scarecrow6] = .5f;
                pool[NPCID.Scarecrow7] = .5f;
                pool[NPCID.Scarecrow8] = .5f;
                pool[NPCID.Scarecrow9] = .5f;
                pool[NPCID.Scarecrow10] = .5f;
                pool[NPCID.Hellhound] = 3f;
                pool[NPCID.Poltergeist] = 3f;
                pool[NPCID.Splinterling] = 3f;
            }
            else if (FargoWorld.OverloadFrostMoon)
            {
                pool[NPCID.IceQueen] = 5f;
                pool[NPCID.Everscream] = 5f;
                pool[NPCID.SantaNK1] = 5f;
                pool[NPCID.ZombieElf] = 1f;
                pool[NPCID.ZombieElfBeard] = 1f;
                pool[NPCID.ZombieElfGirl] = 1f;
                pool[NPCID.GingerbreadMan] = 2f;
                pool[NPCID.ElfArcher] = 2f;
                pool[NPCID.Nutcracker] = 3f;
                pool[NPCID.ElfCopter] = 3f;
                pool[NPCID.Flocko] = 2f;
                pool[NPCID.Yeti] = 4f;
                pool[NPCID.PresentMimic] = 2f;
                pool[NPCID.Krampus] = 4f;
            }
            else if (FargoWorld.OverloadMartians)
            {
                pool[NPCID.MartianSaucerCore] = 1f;
                pool[NPCID.Scutlix] = 3f;
                pool[NPCID.MartianWalker] = 3f;
                pool[NPCID.MartianDrone] = 2f;
                pool[NPCID.GigaZapper] = 1f;
                pool[NPCID.MartianEngineer] = 2f;
                pool[NPCID.MartianOfficer] = 2f;
                pool[NPCID.RayGunner] = 1f;
                pool[NPCID.GrayGrunt] = 1f;
                pool[NPCID.BrainScrambler] = 1f;
            }
        }

        public override bool /*PreKill*/ PreNPCLoot(NPC npc)
        {
            if (swarmActive && Fargowiltas.SwarmActive)
            {
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        Swarm(npc, NPCID.KingSlime, NPCID.BlueSlime, ItemID.KingSlimeBossBag, ItemID.KingSlimeTrophy, "EnergizerSlime");
                        break;

                    case NPCID.EyeofCthulhu:
                        Swarm(npc, NPCID.EyeofCthulhu, NPCID.ServantofCthulhu, ItemID.EyeOfCthulhuBossBag, ItemID.EyeofCthulhuTrophy, "EnergizerEye");
                        break;

                    case NPCID.EaterofWorldsHead:
                        Swarm(npc, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail, ItemID.EaterOfWorldsBossBag, ItemID.EaterofWorldsTrophy, "EnergizerWorm");
                        break;

                    case NPCID.BrainofCthulhu:
                        Swarm(npc, NPCID.BrainofCthulhu, NPCID.Creeper, ItemID.BrainOfCthulhuBossBag, ItemID.BrainofCthulhuTrophy, "EnergizerBrain");
                        break;

                    case NPCID.QueenBee:
                        Swarm(npc, NPCID.QueenBee, NPCID.BeeSmall, ItemID.QueenBeeBossBag, ItemID.QueenBeeTrophy, "EnergizerBee");
                        break;

                    case NPCID.SkeletronHead:
                        Swarm(npc, NPCID.SkeletronHead, -1, ItemID.SkeletronBossBag, ItemID.SkeletronTrophy, "EnergizerSkele");
                        break;

                    case NPCID.WallofFlesh:
                        Swarm(npc, NPCID.WallofFlesh, NPCID.TheHungry, ItemID.WallOfFleshBossBag, ItemID.WallofFleshTrophy, "EnergizerWall");
                        break;

                    /*case ModContent.NPCType<>():
                        Swarm(npc, ModContent.NPCType("Destroyer"), mod.NPCType<DestroyerTail"), ItemID.DestroyerBossBag, "EnergizerDestroy>();
                        break;*/

                    case NPCID.Retinazer:
                        Swarm(npc, NPCID.Retinazer, -1, ItemID.TwinsBossBag, ItemID.RetinazerTrophy, "EnergizerTwins");
                        break;

                    case NPCID.Spazmatism:
                        Swarm(npc, NPCID.Spazmatism, -1, -1, ItemID.SpazmatismTrophy, string.Empty);
                        break;

                    case NPCID.SkeletronPrime:
                        Swarm(npc, NPCID.SkeletronPrime, -1, ItemID.SkeletronPrimeBossBag, ItemID.SkeletronPrimeTrophy, "EnergizerPrime");
                        break;

                    case NPCID.Plantera:
                        Swarm(npc, NPCID.Plantera, NPCID.PlanterasHook, ItemID.PlanteraBossBag, ItemID.PlanteraTrophy, "EnergizerPlant");
                        break;

                    case NPCID.Golem:
                        Swarm(npc, NPCID.Golem, NPCID.GolemHeadFree, ItemID.GolemBossBag, ItemID.GolemTrophy, "EnergizerGolem");
                        break;

                    case NPCID.DukeFishron:
                        Swarm(npc, NPCID.DukeFishron, NPCID.Sharkron, ItemID.FishronBossBag, ItemID.DukeFishronTrophy, "EnergizerFish");
                        break;

                    case NPCID.CultistBoss:
                        Swarm(npc, NPCID.CultistBoss, -1, ItemID.CultistBossBag, ItemID.AncientCultistTrophy, "EnergizerCultist");
                        break;

                    case NPCID.MoonLordCore:
                        Swarm(npc, NPCID.MoonLordCore, NPCID.MoonLordFreeEye, ItemID.MoonLordBossBag, ItemID.MoonLordTrophy, "EnergizerMoon");
                        break;

                    /*case NPCID.MourningWood:
                        Swarm(npc, NPCID.MourningWood, -1, -1, string.Empty);
                        break;

                    case NPCID.Pumpking:
                        Swarm(npc, NPCID.Pumpking, -1, -1, string.Empty);
                        break;

                    case NPCID.Everscream:
                        Swarm(npc, NPCID.Everscream, -1, -1, string.Empty);
                        break;

                    case NPCID.SantaNK1:
                        Swarm(npc, NPCID.SantaNK1, -1, -1, string.Empty);
                        break;

                    case NPCID.IceQueen:
                        Swarm(npc, NPCID.IceQueen, -1, -1, string.Empty);
                        break;

                    case NPCID.DD2Betsy:
                        Swarm(npc, NPCID.DD2Betsy, -1, -1, string.Empty);
                        break;

                    case NPCID.DD2OgreT3:
                        Swarm(npc, NPCID.DD2OgreT3, -1, -1, string.Empty);
                        break;

                    case NPCID.PirateShip:
                        Swarm(npc, NPCID.PirateShip, -1, -1, string.Empty);
                        break;

                    case NPCID.MartianSaucerCore:
                        Swarm(npc, NPCID.MartianSaucerCore, -1, -1, string.Empty);
                        break;*/

                    case NPCID.DungeonGuardian:
                        Swarm(npc, NPCID.DungeonGuardian, -1, -1, ItemID.BoneKey, "EnergizerDG");
                        break;
                }

                if (npc.type == ModContent.NPCType<Destroyer.Destroyer>())
                {
                    Swarm(npc, ModContent.NPCType<Destroyer.Destroyer>(), -1, ItemID.DestroyerBossBag, ItemID.DestroyerTrophy, "EnergizerDestroy");
                }
                
                Mod thorium = Fargowiltas.ModLoaded("ThoriumMod") ? Fargowiltas.LoadedMods["ThoriumMod"] : null;

                if (thorium != null)
                {
                    if (npc.type == thorium.NPCType("TheGrandThunderBirdv2"))
                    {
                        Swarm(npc, thorium.NPCType("TheGrandThunderBirdv2"), thorium.NPCType("Hatchling"), thorium.ItemType("ThunderBirdBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("QueenJelly"))
                    {
                        Swarm(npc, thorium.NPCType("QueenJelly"), thorium.NPCType("ZealousJelly"), thorium.ItemType("JellyFishBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("GraniteEnergyStorm"))
                    {
                        Swarm(npc, thorium.NPCType("GraniteEnergyStorm"), thorium.NPCType("EncroachingEnergy"), thorium.ItemType("GraniteBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("TheBuriedWarrior"))
                    {
                        Swarm(npc, thorium.NPCType("TheBuriedWarrior"), -1, thorium.ItemType("HeroBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("Viscount"))
                    {
                        Swarm(npc, thorium.NPCType("Viscount"), -1, thorium.ItemType("CountBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("ThePrimeScouter"))
                    {
                        Swarm(npc, thorium.NPCType("ThePrimeScouter"), -1, thorium.ItemType("ScouterBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("BoreanStriderPopped"))
                    {
                        Swarm(npc, thorium.NPCType("BoreanStrider"), thorium.ItemType("BoreanMyte1"), thorium.ItemType("BoreanBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("FallenDeathBeholder2"))
                    {
                        Swarm(npc, thorium.NPCType("FallenDeathBeholder"), thorium.ItemType("EnemyBeholder"), thorium.ItemType("BeholderBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("LichHeadless"))
                    {
                        Swarm(npc, thorium.NPCType("Lich"), -1, thorium.ItemType("LichBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("AbyssionReleased"))
                    {
                        Swarm(npc, thorium.NPCType("Abyssion"), thorium.NPCType("AbyssalSpawn"), thorium.ItemType("AbyssionBag"), -1, string.Empty);
                    }
                    else if (npc.type == thorium.NPCType("RealityBreaker"))
                    {
                        Swarm(npc, thorium.NPCType("Aquaius"), thorium.NPCType("AquaiusBubble"), thorium.ItemType("RagBag"), -1, string.Empty);
                        Swarm(npc, thorium.NPCType("Omnicide"), -1, -1, -1, string.Empty);
                        Swarm(npc, thorium.NPCType("SlagFury"), -1, -1, -1, string.Empty);
                    }
                }

                return false;
            }

            if (!pandoraActive)
            {
                return true;
            }

            //Swarm(npc, 0, -1, -1, string.Empty);

            return false;
        }

        // TODO: Wait for bestiary stuff.
        /*public override void ModifyNPCLoot(NPC npc, ItemDropDatabase database)
        {
            // Lumber Jaxe
            database.RegisterToGlobal(new ItemDropWithConditionRule(ItemID.Wood, 1, 10, 30, new ExtraItemDropRules.HasWoodDrop()));

            switch (npc.type)
            {
                case NPCID.GreekSkeleton:
                    database.RegisterToNPC(npc.type, ItemDropRule.OneFromOptions(15, new int[3] { ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings }));
                    break;

                case NPCID.Merchant:
                    database.RegisterToNPC(npc.type, ExtraItemDropRules.AllFromOptions(8, new int[2] { ItemID.MiningShirt, ItemID.MiningPants }));
                    break;

                case NPCID.Nurse:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.LifeCrystal, 5));
                    break;

                case NPCID.Demolitionist:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Dynamite, 2, 5, 5));
                    break;

                case NPCID.Dryad:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.HerbBag, 3));
                    break;

                case NPCID.DD2Bartender:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Ale, 2, 4, 4));
                    break;

                case NPCID.ArmsDealer:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.NanoBullet, 4, 30, 30));
                    break;

                case NPCID.Painter:
                    database.RegisterToNPC(npc.type, new ItemDropWithConditionRule(ModContent.ItemType<EchPainting>(), 1, 1, 1, new ExtraItemDropRules.MoonLordIsAlive()));
                    break;

                case NPCID.Clothier:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Skull, 20));
                    break;

                case NPCID.Mechanic:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Wire, 5, 40, 40));
                    break;

                case NPCID.Wizard:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.FallenStar, 5, 5, 5));
                    break;

                case NPCID.TaxCollector:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.GoldCoin, 8, 10, 10));
                    break;

                case NPCID.Truffle:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.MushroomStatue, 8));
                    break;

                case NPCID.GoblinTinkerer:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ModContent.ItemType<GoblinHead>(), 10));
                    break;

                case NPCID.DD2OgreT2:
                case NPCID.DD2OgreT3:
                    database.RegisterToNPC(npc.type, new ItemDropWithConditionRule(ItemID.BossMaskOgre, 14, 1, 1, new ExtraItemDropRules.DD2EventIsNotOngoing()));
                    database.RegisterToNPC(npc.type, ItemDropRule.OneFromOptions(1, new int[10] { ItemID.ApprenticeScarf, ItemID.SquireShield, ItemID.HuntressBuckler, ItemID.MonkBelt, ItemID.DD2SquireDemonSword, ItemID.MonkStaffT1, ItemID.MonkStaffT2, ItemID.BookStaff, ItemID.DD2PhoenixBow, ItemID.DD2PetGhost }));
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.GoldCoin, 1, 4, 7));
                    break;

                case NPCID.DD2DarkMageT1:
                case NPCID.DD2DarkMageT3:
                    database.RegisterToNPC(npc.type, new ItemDropWithConditionRule(ItemID.BossMaskDarkMage, 14, 1, 1, new ExtraItemDropRules.DD2EventIsNotOngoing()));
                    database.RegisterToNPC(npc.type, new OneFromOptionsWithConditionRule(new int[2] { ItemID.WarTableBanner, ItemID.WarTable }, 10, 1, 1, new ExtraItemDropRules.DD2EventIsNotOngoing()));
                    database.RegisterToNPC(npc.type, new OneFromOptionsWithConditionRule(new int[2] { ItemID.DD2PetGato, ItemID.DD2PetDragon }, 6, 1, 1, new ExtraItemDropRules.DD2EventIsNotOngoing()));
                    database.RegisterToNPC(npc.type, new ItemDropWithConditionRule(ItemID.DD2EnergyCrystal, 1, 1, 1, new ExtraItemDropRules.DD2EventIsNotOngoingShouldDropCrystals()));
                    break;

                case NPCID.Raven:
                    database.RegisterToNPC(NPCID.Raven, ItemDropRule.Common(ItemID.GoodieBag));
                    break;

                case NPCID.SlimeRibbonRed:
                case NPCID.SlimeRibbonGreen:
                case NPCID.SlimeRibbonWhite:
                case NPCID.SlimeRibbonYellow:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Present));
                    break;

                case NPCID.BloodZombie:
                    database.RegisterToNPC(npc.type, ItemDropRule.OneFromOptions(200, new int[2] { ItemID.BladedGlove, ItemID.BloodyMachete }));
                    break;

                case NPCID.Clown:
                    database.RegisterToNPC(npc.type, ItemDropRule.Common(ItemID.Bananarang));
                    break;
            }
        }*/
        public override void /*OnKill*/ NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                // Avoid lunar event with cultist summon
                case NPCID.CultistBoss:
                    if (!pillarSpawn)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            NPC npc2 = Main.npc[i];
                            NPC.LunarApocalypseIsUp = false;

                            if (npc2.type == NPCID.LunarTowerNebula || npc2.type == NPCID.LunarTowerSolar || npc2.type == NPCID.LunarTowerStardust || npc2.type == NPCID.LunarTowerVortex)
                            {
                                NPC.TowerActiveSolar = true;
                                npc2.active = false;
                            }

                            NPC.TowerActiveSolar = false;
                        }
                    }
                    break;

                case NPCID.DD2OgreT2:
                case NPCID.DD2OgreT3:
                    FargoWorld.DownedBools["ogre"] = true;
                    break;

                case NPCID.DD2DarkMageT1:
                case NPCID.DD2DarkMageT3:
                    FargoWorld.DownedBools["darkMage"] = true;
                    break;

                case NPCID.Clown:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["clown"] = true;
                    break;

                case NPCID.BlueSlime:
                    if (npc.netID == NPCID.Pinky)
                    {
                        FargoWorld.DownedBools["rareEnemy"] = true;
                        FargoWorld.DownedBools["pinky"] = true;
                    }
                    break;

                case NPCID.UndeadMiner:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["undeadMiner"] = true;
                    break;

                case NPCID.Tim:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["tim"] = true;
                    break;

                case NPCID.DoctorBones:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["doctorBones"] = true;
                    break;

                case NPCID.Mimic:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimic"] = true;
                    break;

                case NPCID.WyvernHead:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["wyvern"] = true;
                    break;

                case NPCID.RuneWizard:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["runeWizard"] = true;
                    break;

                case NPCID.Nymph:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["nymph"] = true;
                    break;

                case NPCID.Moth:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["moth"] = true;
                    break;

                case NPCID.RainbowSlime:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["rainbowSlime"] = true;
                    break;

                case NPCID.Paladin:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["paladin"] = true;
                    break;

                case NPCID.Medusa:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["medusa"] = true;
                    break;

                case NPCID.IceGolem:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["iceGolem"] = true;
                    break;

                case NPCID.SandElemental:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["sandElemental"] = true;
                    break;

                case NPCID.Mothron:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mothron"] = true;
                    break;

                case NPCID.BigMimicCorruption:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicCorrupt"] = true;
                    break;

                case NPCID.BigMimicHallow:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicHallow"] = true;
                    break;

                case NPCID.BigMimicCrimson:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicCrimson"] = true;
                    break;

                case NPCID.BigMimicJungle:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["mimicJungle"] = true;
                    break;

                case NPCID.GoblinSummoner:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["goblinSummoner"] = true;
                    break;

                case NPCID.PirateShip:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["flyingDutchman"] = true;
                    break;

                case NPCID.DungeonSlime:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["dungeonSlime"] = true;
                    break;

                case NPCID.PirateCaptain:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["pirateCaptain"] = true;
                    break;

                case NPCID.SkeletonSniper:
                case NPCID.TacticalSkeleton:
                case NPCID.SkeletonCommando:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["skeletonGun"] = true;
                    break;

                case NPCID.Necromancer:
                case NPCID.NecromancerArmored:
                case NPCID.DiabolistRed:
                case NPCID.DiabolistWhite:
                case NPCID.RaggedCaster:
                case NPCID.RaggedCasterOpenCoat:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["skeletonMage"] = true;
                    break;

                case NPCID.BoneLee:
                    FargoWorld.DownedBools["rareEnemy"] = true;
                    FargoWorld.DownedBools["boneLee"] = true;
                    break;

                case NPCID.HeadlessHorseman:
                    FargoWorld.DownedBools["headlessHorseman"] = true;
                    break;
            }

            if (Fargowiltas.ModRareEnemies.ContainsKey(npc.type))
            {
                FargoWorld.DownedBools["rareEnemy"] = true;
                FargoWorld.DownedBools[Fargowiltas.ModRareEnemies[npc.type]] = true;
            }
        }

        public override bool CheckDead(NPC npc)
        {
            if (npc.type == NPCID.DD2Betsy && !pandoraActive)
            {
                Main.NewText("Betsy has been defeated!", 175, 75);
                FargoWorld.DownedBools["betsy"] = true;
            }

            if (npc.boss)
            {
                FargoWorld.DownedBools["boss"] = true;
            }

            return true;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (ModContent.GetInstance<FargoConfig>().rottenEggs && projectile.type == ProjectileID.RottenEgg && npc.townNPC)
            {
                damage *= 20;
            }
        }

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            // No angler check enables luiafk compatibility
            if (ModContent.GetInstance<FargoConfig>().anglerQuestInstantReset && Main.anglerQuestFinished)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    // Broadcast swap request to server
                    ModPacket netMessage = Mod.GetPacket();
                    netMessage.Write((byte)3);
                    netMessage.Send();
                }
            }
        }

        private void SpawnBoss(NPC npc, int boss)
        {
            int spawn;

            if (swarmActive)
            {
                if (npc.type == NPCID.WallofFlesh)
                {
                    NPC currentWoF = Main.npc[LastWoFIndex];
                    int startingPos = (int)currentWoF.position.X;

                    spawn = NPC.NewNPC(startingPos + (400 * WoFDirection), (int)currentWoF.position.Y, NPCID.WallofFlesh, 0);
                    Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                    LastWoFIndex = spawn;
                }
                else
                {
                    spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), boss);

                    if (spawn < Main.maxNPCs)
                    {
                        Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;
                        NetMessage.SendData(MessageID.SyncNPC, number: boss);
                    }
                }
            }
            else
            {
                // Pandora
                int random;

                do
                {
                    random = Main.rand.Next(Bosses);
                }
                while (NPC.CountNPCS(random) >= 4);

                spawn = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-1000, 1000), (int)npc.position.Y + Main.rand.Next(-400, -100), random);
                Main.npc[spawn].GetGlobalNPC<FargoGlobalNPC>().pandoraActive = true;
                NetMessage.SendData(MessageID.SyncNPC, number: random);
            }
        }

        private void Swarm(NPC npc, int boss, int minion, int bossbag, int trophy, string reward)
        {
            if (bossbag >= 0)
            {
                npc.DropItemInstanced(npc.Center, npc.Size, bossbag);
            }

            int count = 0;

            if (swarmActive)
            {
                count = NPC.CountNPCS(boss) - 1; // Since this one is about to be dead
            }
            else
            {
                // Pandora
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Array.IndexOf(Bosses, Main.npc[i].type) > -1)
                    {
                        count++;
                    }
                }
            }

            int missing = Fargowiltas.SwarmSpawned - count;
            Fargowiltas.SwarmKills++;

            // Drop swarm reward every 100 kills
            if (Fargowiltas.SwarmKills % 100 == 0 && !string.IsNullOrEmpty(reward))
            {
                Item.NewItem(npc.Hitbox, ModContent.GetInstance<Fargowiltas>().ItemType(reward));
            }

            //drop trphy every 10 killa
            if (Fargowiltas.SwarmKills % 10 == 0 && trophy != -1)
            {
                Item.NewItem(npc.Hitbox, trophy);
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.Fargowiltas.Killed") + " " + Fargowiltas.SwarmKills), new Color(206, 12, 15));
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.Fargowiltas.Total") + " " + Fargowiltas.SwarmTotal), new Color(206, 12, 15));
            }
            else
            {
                Main.NewText("Killed: " + Fargowiltas.SwarmKills, new Color(206, 12, 15));
                Main.NewText("Total: " + Fargowiltas.SwarmTotal, new Color(206, 12, 15));
            }

            if (minion != -1 && NPC.CountNPCS(minion) >= Fargowiltas.SwarmSpawned)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].type == minion)
                    {
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }
            }

            // If theres still more to spawn
            if (Fargowiltas.SwarmKills <= Fargowiltas.SwarmTotal - Fargowiltas.SwarmSpawned)
            {
                int spawned = 0;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    // Count NPCs
                    int npcCount = 0;

                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            npcCount++;
                        }
                    }

                    // Kill a minion and spawn boss if too many npcs
                    if (npcCount >= Main.maxNPCs)
                    {
                        if (swarmActive && minion > 0 && i < Main.maxNPCs - 1)
                        {
                            if (Main.npc[i].type == minion)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                        else
                        {
                            // Pandora
                            if (Array.IndexOf(Bosses, Main.npc[i].type) == -1 && !Main.npc[i].boss)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                    }

                    SpawnBoss(npc, boss);

                    spawned++;

                    if (spawned <= missing)
                    {
                        continue;
                    }

                    break;
                }
            }
            else if (Fargowiltas.SwarmKills >= Fargowiltas.SwarmTotal)
            {
                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue("Mods.Fargowiltas.SwarmDefeated")), new Color(206, 12, 15));
                }
                else
                {
                    Main.NewText(Language.GetTextValue("Mods.Fargowiltas.SwarmDefeated"), new Color(206, 12, 15));
                }

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC kill = Main.npc[i];

                    if (kill.active && !kill.friendly && kill.type != NPCID.LunarTowerNebula && kill.type != NPCID.LunarTowerSolar && kill.type != NPCID.LunarTowerStardust && kill.type != NPCID.LunarTowerVortex)
                    {
                        Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().noLoot = true;
                        Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                    }
                }

                Fargowiltas.SwarmActive = false;
                LastWoFIndex = -1;
                WoFDirection = 0;
            }

            // Make sure theres enough left to beat it
            else
            {
                // Spawn more if needed
                if (count >= Fargowiltas.SwarmSpawned || Fargowiltas.SwarmTotal <= 20)
                {
                    return;
                }

                int extraSpawn = 0;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    // Count NPCs
                    int num = 0;

                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].active)
                        {
                            num++;
                        }
                    }

                    // Kill a minion and spawn boss if too many NPCs
                    if (num >= Main.maxNPCs)
                    {
                        if (swarmActive && minion > 0 && i < Main.maxNPCs - 1)
                        {
                            if (Main.npc[i].type == minion)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                        else
                        {
                            // Pandora
                            if (Array.IndexOf(Bosses, Main.npc[i].type) == -1 && !Main.npc[i].boss)
                            {
                                Main.npc[i].StrikeNPCNoInteraction(Main.npc[i].lifeMax, 0f, -Main.npc[i].direction, true);
                            }
                        }
                    }

                    SpawnBoss(npc, boss);

                    extraSpawn++;

                    if (extraSpawn < 5)
                    {
                        continue;
                    }

                    break;
                }
            }
        }

        public static void SpawnWalls(Player player)
        {
            int startingPos;

            if (LastWoFIndex == -1)
            {
                startingPos = (int)player.position.X;
            }
            else
            {
                startingPos = (int)Main.npc[LastWoFIndex].position.X;
            }

            Vector2 pos = player.position;

            if (WoFDirection == 0)
            {
                //1 is to the right, -1 is left
                WoFDirection = ((player.position.X / 16) > (Main.maxTilesX / 2)) ? 1 : -1;
            }

            int wof = NPC.NewNPC(startingPos + (400 * WoFDirection), (int)pos.Y, NPCID.WallofFlesh, 0);
            Main.npc[wof].GetGlobalNPC<FargoGlobalNPC>().swarmActive = true;

            LastWoFIndex = wof;
        }

        public static bool SpecificBossIsAlive(ref int bossID, int bossType)
        {
            if (bossID != -1)
            {
                if (Main.npc[bossID].active && Main.npc[bossID].type == bossType)
                {
                    return true;
                }
                else
                {
                    bossID = -1;

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool AnyBossAlive()
        {
            if (Boss == -1)
            {
                return false;
            }

            if (Main.npc[Boss].active && (Main.npc[Boss].boss || Main.npc[Boss].type == NPCID.EaterofWorldsHead))
            {
                return true;
            }

            Boss = -1;

            return false;
        }
    }
}