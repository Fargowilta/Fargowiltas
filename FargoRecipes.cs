﻿using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Summons.VanillaCopy;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas
{
    internal class FargoRecipes
    {
        public static void AddRecipeGroups()
        {
            // Evil wood
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Wood", new int[] { ItemID.Ebonwood, ItemID.Shadewood });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            // PreHM anvils
            group = new RecipeGroup(() => "Any Anvil", new int[] { ItemID.IronAnvil, ItemID.LeadAnvil });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            // HM anvils
            group = new RecipeGroup(() => "Any Hardmode Anvil", ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            // HM forges
            group = new RecipeGroup(() => "Any Forge", ItemID.AdamantiteForge, ItemID.TitaniumForge);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            // Bookcases
            group = new RecipeGroup(() => "Any Bookcase", new int[]
            {
                ItemID.Bookcase,
                ItemID.BlueDungeonBookcase,
                ItemID.BoneBookcase,
                ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase,
                ItemID.CrystalBookCase,
                ItemID.DynastyBookcase,
                ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase,
                ItemID.FrozenBookcase,
                ItemID.GlassBookcase,
                ItemID.GoldenBookcase,
                ItemID.GothicBookcase,
                ItemID.GraniteBookcase,
                ItemID.GreenDungeonBookcase,
                ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase,
                ItemID.MarbleBookcase,
                ItemID.MeteoriteBookcase,
                ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase,
                ItemID.PalmWoodBookcase,
                ItemID.PearlwoodBookcase,
                ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase,
                ItemID.RichMahoganyBookcase,
                ItemID.ShadewoodBookcase,
                ItemID.SkywareBookcase,
                ItemID.SlimeBookcase,
                ItemID.SpookyBookcase,
                ItemID.SteampunkBookcase
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);

            // Bone banners
            int[] boneBanners = { ItemID.BlueArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.RustyArmoredBonesBanner };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Armored Bones Banner", boneBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyArmoredBones", group);

            int[] pirateBanners = { ItemID.PirateDeadeyeBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateBanner };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Pirate Banner", pirateBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPirateBanner", group);

            // Slimes (excluding ones that don't drop gel)
            int[] slimeBanners = {
                ItemID.SlimeBanner,
                ItemID.GreenSlimeBanner,
                ItemID.RedSlimeBanner,
                ItemID.PurpleSlimeBanner,
                ItemID.YellowSlimeBanner,
                ItemID.BlackSlimeBanner,
                ItemID.IceSlimeBanner,
                ItemID.SandSlimeBanner,
                ItemID.JungleSlimeBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.MotherSlimeBanner,
                ItemID.UmbrellaSlimeBanner,
                ItemID.ToxicSludgeBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.CrimslimeBanner,
                ItemID.GastropodBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.RainbowSlimeBanner
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Slime Banner", slimeBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnySlimes", group);

            // Any Hallow enemy
            int[] hallowBanners = {
                ItemID.PixieBanner,
                ItemID.UnicornBanner,
                ItemID.RainbowSlimeBanner,
                ItemID.GastropodBanner,
                ItemID.LightMummyBanner,
                ItemID.IlluminantBatBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.ChaosElementalBanner,
                ItemID.EnchantedSwordBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hallow Banner", hallowBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallows", group);

            // Any Corruption enemy
            int[] corruptionBanners = {
                ItemID.EaterofSoulsBanner,
                ItemID.CorruptorBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.DevourerBanner,
                ItemID.WorldFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CursedHammerBanner,
                ItemID.ClingerBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Corruption Banner", corruptionBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCorrupts", group);

            // Any Crimson enemy
            int[] crimsonBanners = {
                ItemID.BloodCrawlerBanner,
                ItemID.FaceMonsterBanner,
                ItemID.CrimeraBanner,
                ItemID.HerplingBanner,
                ItemID.CrimslimeBanner,
                ItemID.BloodJellyBanner,
                ItemID.BloodFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CrimsonAxeBanner,
                ItemID.IchorStickerBanner,
                ItemID.FloatyGrossBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Crimson Banner", crimsonBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsons", group);

            // Any Jungle enemy
            int[] jungleBanners = {
                ItemID.PiranhaBanner,
                ItemID.SnatcherBanner,
                ItemID.JungleBatBanner,
                ItemID.JungleSlimeBanner,
                ItemID.DoctorBonesBanner,
                ItemID.AnglerFishBanner,
                ItemID.ArapaimaBanner,
                ItemID.TortoiseBanner,
                ItemID.AngryTrapperBanner,
                ItemID.DerplingBanner,
                ItemID.GiantFlyingFoxBanner,
                ItemID.HornetBanner,
                ItemID.SpikedJungleSlimeBanner,
                ItemID.JungleCreeperBanner,
                ItemID.MothBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Jungle Banner", jungleBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyJungles", group);

            // Any Snow enemy
            int[] snowBanners = {
                ItemID.IceSlimeBanner,
                ItemID.ZombieEskimoBanner,
                ItemID.IceElementalBanner,
                ItemID.WolfBanner,
                ItemID.IceGolemBanner,
                ItemID.IceBatBanner,
                ItemID.SnowFlinxBanner,
                ItemID.SpikedIceSlimeBanner,
                ItemID.UndeadVikingBanner,
                ItemID.ArmoredVikingBanner,
                ItemID.IceTortoiseBanner,
                ItemID.IcyMermanBanner,
                ItemID.PigronBanner,
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Snow Banner", snowBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnySnows", group);

            // Any Crimson enemy
            int[] desertBanners = {
                ItemID.FlyingAntlionBanner,
                ItemID.WalkingAntlionBanner,
                ItemID.AntlionBanner,
                ItemID.DesertDjinnBanner,
                ItemID.DesertBasiliskBanner,
                ItemID.DesertLamiaBanner,
                ItemID.DesertGhoulBanner,
                //fill in more
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Desert Banner", desertBanners);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDeserts", group);

            // Caught NPCs
            int[] caughtNPCs = new int[]
            {
                ModContent.ItemType<Guide>(),
                ModContent.ItemType<Angler>(),
                ModContent.ItemType<ArmsDealer>(),
                ModContent.ItemType<Clothier>(),
                ModContent.ItemType<Cyborg>(),
                ModContent.ItemType<Demolitionist>(),
                ModContent.ItemType<Dryad>(),
                ModContent.ItemType<DyeTrader>(),
                ModContent.ItemType<GoblinTinkerer>(),
                ModContent.ItemType<LumberJack>(),
                ModContent.ItemType<Mechanic>(),
                ModContent.ItemType<Merchant>(),
                ModContent.ItemType<Nurse>(),
                ModContent.ItemType<Painter>(),
                ModContent.ItemType<PartyGirl>(),
                ModContent.ItemType<Pirate>(),
                ModContent.ItemType<SantaClaus>(),
                ModContent.ItemType<SkeletonMerchant>(),
                ModContent.ItemType<Steampunker>(),
                ModContent.ItemType<Stylist>(),
                ModContent.ItemType<Tavernkeep>(),
                ModContent.ItemType<TaxCollector>(),
                ModContent.ItemType<TravellingMerchant>(),
                ModContent.ItemType<WitchDoctor>(),
                ModContent.ItemType<Wizard>(),
            };
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Caught Town NPC", caughtNPCs);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Omnistation", ModContent.ItemType<Omnistation>(), ModContent.ItemType<Omnistation2>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOmnistation", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Wooden Crate", new int[] {
                ItemID.WoodenCrate,
                ItemID.WoodenCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodenCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron Crate", new int[] {
                ItemID.IronCrate,
                ItemID.IronCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyIronCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Crate", new int[] {
                ItemID.GoldenCrate,
                ItemID.GoldenCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldenCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Jungle Crate", new int[] {
                ItemID.JungleFishingCrate,
                ItemID.JungleFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyJungleCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Sky Crate", new int[] {
                ItemID.FloatingIslandFishingCrate,
                ItemID.FloatingIslandFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySkyCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Corrup Crate", new int[] {
                ItemID.CorruptFishingCrate,
                ItemID.CorruptFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCorruptCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Crimson Crate", new int[] {
                ItemID.CrimsonFishingCrate,
                ItemID.CrimsonFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsonCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hallowed Crate", new int[] {
                ItemID.HallowedFishingCrate,
                ItemID.HallowedFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallowedCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Dungeon Crate", new int[] {
                ItemID.DungeonFishingCrate,
                ItemID.DungeonFishingCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDungeonCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Frozen Crate", new int[] {
                ItemID.FrozenCrate,
                ItemID.FrozenCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyFrozenCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Oasis Crate", new int[] {
                ItemID.OasisCrate,
                ItemID.OasisCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOasisCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Obsidian Crate", new int[] {
                ItemID.LavaCrate,
                ItemID.LavaCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyObsidianCrate", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Ocean Crate", new int[] {
                ItemID.OceanCrate,
                ItemID.OceanCrateHard
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOceanCrate", group);
        }

        public static void AddRecipes()
        {
            AddSummonConversions();
            AddEvilConversions();
            AddMetalConversions();
            AddStatueRecipes();
            AddContainerLootRecipes();
            AddNPCRecipes();
            AddTreasureBagRecipes();
            AddFurnitureRecipes();
            AddMiscRecipes();
            AddVanillaRecipeChanges();

            if (ModContent.GetInstance<FargoConfig>().BannerRecipes)
            {
                AddBannerToItemRecipes();
            }
        }

        private static void AddSummonConversions()
        {
            void AddSummonConversion(int ingredient, int result)
            {
                Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                recipe.AddIngredient(ingredient);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            AddSummonConversion(ModContent.ItemType<FleshyDoll>(), ItemID.GuideVoodooDoll);
            AddSummonConversion(ModContent.ItemType<LihzahrdPowerCell2>(), ItemID.LihzahrdPowerCell);
            AddSummonConversion(ModContent.ItemType<TruffleWorm2>(), ItemID.TruffleWorm);
            AddSummonConversion(ModContent.ItemType<CelestialSigil2>(), ItemID.CelestialSigil);
            AddSummonConversion(ModContent.ItemType<MechEye>(), ItemID.MechanicalEye);
            AddSummonConversion(ModContent.ItemType<MechWorm>(), ItemID.MechanicalWorm);
            AddSummonConversion(ModContent.ItemType<MechSkull>(), ItemID.MechanicalSkull);
            AddSummonConversion(ModContent.ItemType<GoreySpine>(), ItemID.BloodySpine);
            AddSummonConversion(ModContent.ItemType<SlimyCrown>(), ItemID.SlimeCrown);
            AddSummonConversion(ModContent.ItemType<Abeemination2>(), ItemID.Abeemination);
            AddSummonConversion(ModContent.ItemType<WormyFood>(), ItemID.WormFood);
            AddSummonConversion(ModContent.ItemType<SuspiciousEye>(), ItemID.SuspiciousLookingEye);
        }

        private static void AddEvilConversions()
        {
            AddConvertRecipe(ItemID.Vertebrae, ItemID.RottenChunk);
            AddConvertRecipe(ItemID.ShadowScale, ItemID.TissueSample);
            AddConvertRecipe(ItemID.PurpleSolution, ItemID.RedSolution);
            AddConvertRecipe(ItemID.Ichor, ItemID.CursedFlame);
            AddConvertRecipe(ItemID.FleshKnuckles, ItemID.PutridScent);
            AddConvertRecipe(ItemID.DartPistol, ItemID.DartRifle);
            AddConvertRecipe(ItemID.WormHook, ItemID.TendonHook);
            AddConvertRecipe(ItemID.ChainGuillotines, ItemID.FetidBaghnakhs);
            AddConvertRecipe(ItemID.ClingerStaff, ItemID.SoulDrain);
            AddConvertRecipe(ItemID.ShadowOrb, ItemID.CrimsonHeart);
            AddConvertRecipe(ItemID.Musket, ItemID.TheUndertaker);
            AddConvertRecipe(ItemID.PanicNecklace, ItemID.BandofStarpower);
            AddConvertRecipe(ItemID.BallOHurt, ItemID.TheRottedFork);
            AddConvertRecipe(ItemID.CrimsonRod, ItemID.Vilethorn);
            AddConvertRecipe(ItemID.CrimstoneBlock, ItemID.EbonstoneBlock);
            AddConvertRecipe(ItemID.Shadewood, ItemID.Ebonwood);
            AddConvertRecipe(ItemID.VileMushroom, ItemID.ViciousMushroom);
            AddConvertRecipe(ItemID.Bladetongue, ItemID.Toxikarp);
            AddConvertRecipe(ItemID.VampireKnives, ItemID.ScourgeoftheCorruptor);
            AddConvertRecipe(ItemID.Ebonkoi, ItemID.CrimsonTigerfish);
            AddConvertRecipe(ItemID.Hemopiranha, ItemID.Ebonkoi);
            AddConvertRecipe(ItemID.BoneRattle, ItemID.EatersBone);
            AddConvertRecipe(ItemID.CrimsonSeeds, ItemID.CorruptSeeds);
            AddConvertRecipe(ItemID.DeadlandComesAlive, ItemID.LightlessChasms);
        }

        private static void AddMetalConversions()
        {
            AddConvertRecipe(ItemID.CopperOre, ItemID.TinOre);
            AddConvertRecipe(ItemID.CopperBar, ItemID.TinBar);
            AddConvertRecipe(ItemID.IronOre, ItemID.LeadOre);
            AddConvertRecipe(ItemID.IronBar, ItemID.LeadBar);
            AddConvertRecipe(ItemID.SilverOre, ItemID.TungstenOre);
            AddConvertRecipe(ItemID.SilverBar, ItemID.TungstenBar);
            AddConvertRecipe(ItemID.GoldOre, ItemID.PlatinumOre);
            AddConvertRecipe(ItemID.GoldBar, ItemID.PlatinumBar);
            AddConvertRecipe(ItemID.CobaltOre, ItemID.PalladiumOre);
            AddConvertRecipe(ItemID.CobaltBar, ItemID.PalladiumBar);
            AddConvertRecipe(ItemID.MythrilOre, ItemID.OrichalcumOre);
            AddConvertRecipe(ItemID.MythrilBar, ItemID.OrichalcumBar);
            AddConvertRecipe(ItemID.AdamantiteOre, ItemID.TitaniumOre);
            AddConvertRecipe(ItemID.AdamantiteBar, ItemID.TitaniumBar);
            AddConvertRecipe(ItemID.DemoniteOre, ItemID.CrimtaneOre);
            AddConvertRecipe(ItemID.DemoniteBar, ItemID.CrimtaneBar);
        }

        private static void AddBannerToItemRecipes()
        {
            void AddBannerToItemRecipe(int banner, int result, int bannerAmount = 1, int resultAmount = 1)
            {
                Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result, resultAmount);
                recipe.AddIngredient(banner, bannerAmount);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();
            }

            void AddBannerToItemsRecipe(int banner, int[] results, int bannerAmount = 1)
            {
                foreach (int result in results)
                {
                    Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                    recipe.AddIngredient(banner, bannerAmount);
                    recipe.AddTile(TileID.Solidifier);
                    recipe.Register();
                }
            }

            void AddGroupToItemRecipe(string group, int result, int station = TileID.Solidifier, int resultAmount = 1, int groupAmount = 1)
            {
                Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                recipe.AddRecipeGroup(group, groupAmount);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();
            }

            // Single recipe banners
            AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter);
            AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod);
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi);
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle);
            AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife);
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff);
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace);
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.BunnyHood);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw);
            AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins);
            AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold);
            AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff);
            AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe);
            AddBannerToItemRecipe(ItemID.DemonEyeBanner, ItemID.BlackLens);
            AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn);
            AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork);
            AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask);
            AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring);
            AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose);
            AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.BlessedApple);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon);
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet);
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather);
            AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone);
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.TatteredBeeWing);
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell);
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff);
            AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.JungleCreeperBanner, ItemID.Yelets);
            AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.HelFire);
            AddBannerToItemRecipe(ItemID.LavaSlimeBanner, ItemID.Cascade);
            AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg);
            AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings);
            AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun);
            AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff);
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace);
            AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat);
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone);
            AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife);
            AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat);
            AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet);
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher);
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand);
            AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher);
            AddBannerToItemRecipe(ItemID.TortoiseBanner, ItemID.TurtleShell);
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.Bezoar);
            AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar);
            AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe);
            AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick);
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm);
            AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.Amarok);
            AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion);
            AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock);
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun);
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 5);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass);

            // Multiple recipe banners
            AddBannerToItemsRecipe(ItemID.MimicBanner, new int[] { ItemID.DualHook, ItemID.MagicDagger, ItemID.TitanGlove, ItemID.PhilosophersStone, ItemID.CrossNecklace, ItemID.StarCloak, ItemID.Frostbrand, ItemID.IceBow, ItemID.FlowerofFrost, ItemID.ToySled });
            AddBannerToItemsRecipe(ItemID.ArmoredSkeletonBanner, new int[] { ItemID.ArmorPolish, ItemID.BeamSword });
            AddBannerToItemsRecipe(ItemID.BoneLeeBanner, new int[] { ItemID.BlackBelt, ItemID.Tabi });
            AddBannerToItemsRecipe(ItemID.DesertDjinnBanner, new int[] { ItemID.DjinnLamp, ItemID.DjinnsCurse });
            AddBannerToItemsRecipe(ItemID.DesertLamiaBanner, new int[] { ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants, ItemID.MoonMask, ItemID.SunMask });
            AddBannerToItemsRecipe(ItemID.FloatyGrossBanner, new int[] { ItemID.Vitamins, ItemID.MeatGrinder });
            AddBannerToItemsRecipe(ItemID.MedusaBanner, new int[] { ItemID.MedusaHead, ItemID.PocketMirror });
            AddBannerToItemsRecipe(ItemID.MummyBanner, new int[] { ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants });
            AddBannerToItemsRecipe(ItemID.PaladinBanner, new int[] { ItemID.PaladinsHammer, ItemID.PaladinsShield });
            AddBannerToItemsRecipe(ItemID.PenguinBanner, new int[] { ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants });
            AddBannerToItemsRecipe(ItemID.PirateBanner, new int[] { ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants });
            AddBannerToItemsRecipe(ItemID.RedDevilBanner, new int[] { ItemID.UnholyTrident, ItemID.FireFeather });
            AddBannerToItemsRecipe(ItemID.SkeletonArcherBanner, new int[] { ItemID.MagicQuiver, ItemID.Marrow });
            AddBannerToItemsRecipe(ItemID.SkeletonSniperBanner, new int[] { ItemID.RifleScope, ItemID.SniperRifle });
            AddBannerToItemsRecipe(ItemID.TacticalSkeletonBanner, new int[] { ItemID.TacticalShotgun, ItemID.SWATHelmet });
            AddBannerToItemsRecipe(ItemID.VampireBanner, new int[] { ItemID.BrokenBatWing, ItemID.MoonStone });
            AddBannerToItemsRecipe(ItemID.ZombieBanner, new int[] { ItemID.ZombieArm, ItemID.Shackle });
            AddBannerToItemsRecipe(ItemID.ZombieElfBanner, new int[] { ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants });
            AddBannerToItemsRecipe(ItemID.ZombieEskimoBanner, new int[] { ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants });

            // Ancient armor recipes
            AddBannerToItemsRecipe(ItemID.EaterofSoulsBanner, new int[] { ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves }, 2);
            AddBannerToItemsRecipe(ItemID.HornetBanner, new int[] { ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings }, 2);
            AddBannerToItemsRecipe(ItemID.SkeletonBanner, new int[] { ItemID.AncientIronHelmet, ItemID.AncientGoldHelmet }, 2);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 2);

            // Gladiator armor recipe
            AddBannerToItemsRecipe(ItemID.GreekSkeletonBanner, new int[] { ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings });

            // Boss trophy recipes
            AddBannerToItemRecipe(ItemID.KingSlimeTrophy, ItemID.SlimeStaff);
            AddBannerToItemRecipe(ItemID.EyeofCthulhuTrophy, ItemID.Binoculars);
            AddBannerToItemRecipe(ItemID.EaterofWorldsTrophy, ItemID.EatersBone);
            AddBannerToItemRecipe(ItemID.BrainofCthulhuTrophy, ItemID.BoneRattle);
            AddBannerToItemRecipe(ItemID.QueenBeeTrophy, ItemID.HoneyedGoggles);
            AddBannerToItemRecipe(ItemID.SkeletronTrophy, ItemID.BookofSkulls);
            AddBannerToItemRecipe(ItemID.PlanteraTrophy, ItemID.TheAxe);
            AddBannerToItemRecipe(ItemID.DukeFishronTrophy, ItemID.FishronWings);
            AddBannerToItemRecipe(ItemID.FairyQueenTrophy, ItemID.SparkleGuitar);
            AddBannerToItemRecipe(ItemID.FairyQueenTrophy, ItemID.RainbowWings);
            AddBannerToItemRecipe(ItemID.FlyingDutchmanTrophy, ItemID.PirateMinecart);

            // Priate banner recipes
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.Cutlass);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.GoldRing);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.PirateStaff);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.DiscountCard);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.LuckyCoin);

            // Armored bones banner recipes
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Keybrand);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Kraken);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.MagnetSphere);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.WispinaBottle);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.BoneFeather);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.MaceWhip);

            // Slime banner recipes
            AddGroupToItemRecipe("Fargowiltas:AnySlimes", ItemID.Gel, resultAmount: 200);

            // Biome banner recipes
            AddGroupToItemRecipe("Fargowiltas:AnyHallows", ItemID.HallowedKey, TileID.MythrilAnvil, groupAmount: 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCorrupts", ItemID.CorruptionKey, TileID.MythrilAnvil, groupAmount: 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCrimsons", ItemID.CrimsonKey, TileID.MythrilAnvil, groupAmount: 10);
            AddGroupToItemRecipe("Fargowiltas:AnyJungles", ItemID.JungleKey, TileID.MythrilAnvil, groupAmount: 10);
            AddGroupToItemRecipe("Fargowiltas:AnySnows", ItemID.FrozenKey, TileID.MythrilAnvil, groupAmount: 10);
            AddGroupToItemRecipe("Fargowiltas:AnyDeserts", ItemID.DungeonDesertKey, TileID.MythrilAnvil, groupAmount: 10);

            // Food recipes
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.ApplePie);
            AddBannerToItemRecipe(ItemID.IlluminantSlimeBanner, ItemID.ApplePie);
            AddBannerToItemRecipe(ItemID.IlluminantBatBanner, ItemID.ApplePie);
            AddBannerToItemRecipe(ItemID.AntlionBanner, ItemID.BananaSplit);
            AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, ItemID.BananaSplit);
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.BananaSplit);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.BBQRibs, resultAmount: 2);
            AddBannerToItemRecipe(ItemID.SkeletonSniperBanner, ItemID.BBQRibs, resultAmount: 2);
            AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, ItemID.BBQRibs, resultAmount: 2);
            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.Burger);
            AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.Burger);
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.ChickenNugget);
            AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.ChocolateChipCookie);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.CreamSoda);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.CreamSoda);
            AddBannerToItemRecipe(ItemID.SpiderBanner, ItemID.FriedEgg);
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.FriedEgg);
            AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, ItemID.FriedEgg);
            AddBannerToItemRecipe(ItemID.GiantFlyingFoxBanner, ItemID.Grapes);
            AddBannerToItemRecipe(ItemID.DerplingBanner, ItemID.Grapes);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.Bacon, resultAmount: 2);
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.Milkshake);
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.Milkshake);
            AddBannerToItemRecipe(ItemID.MedusaBanner, ItemID.Pizza);
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Pizza);
            AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemID.Spaghetti);
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.Spaghetti);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.Steak, resultAmount: 5);
            AddBannerToItemRecipe(ItemID.ThePossessedBanner, ItemID.Steak);
            AddBannerToItemRecipe(ItemID.BoneLeeBanner, ItemID.CoffeeCup, resultAmount: 5);
            AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.CoffeeCup);
            AddBannerToItemRecipe(ItemID.SnatcherBanner, ItemID.CoffeeCup);
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.CoffeeCup);
            AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.Hotdog);
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.Hotdog);
            AddBannerToItemRecipe(ItemID.IceSlimeBanner, ItemID.IceCream);
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.IceCream);
            AddBannerToItemRecipe(ItemID.SpikedIceSlimeBanner, ItemID.IceCream);
            AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.Nachos);
            AddBannerToItemRecipe(ItemID.TumbleweedBanner, ItemID.Nachos);
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.ShrimpPoBoy);
            AddBannerToItemRecipe(ItemID.CrabBanner, ItemID.ShrimpPoBoy);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.PotatoChips);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.PotatoChips);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.PotatoChips);
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.MilkCarton);

            // Kites and other novelties
            AddBannerToItemRecipe(ItemID.BloodNautilusBanner, ItemID.BloodMoonMonolith);
            AddBannerToItemRecipe(ItemID.FlyingFishBanner, ItemID.CarbonGuitar);
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.VampireFrogStaff);
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodFishingRod);
            AddBannerToItemRecipe(ItemID.ZombieMermanBanner, ItemID.BloodRainBow);
            AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.VampireFrogStaff);
            AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.BloodFishingRod);
            AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.BloodRainBow);
            AddBannerToItemRecipe(ItemID.GreekSkeletonBanner, ItemID.Gladius);
            AddBannerToItemRecipe(ItemID.EnchantedSwordBanner, ItemID.Smolstar);
            AddBannerToItemRecipe(ItemID.RockGolemBanner, ItemID.RockGolemHead);
            AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.PigronMinecart);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.KitePigron);
            AddBannerToItemRecipe(ItemID.CorruptBunnyBanner, ItemID.KiteBunnyCorrupt);
            AddBannerToItemRecipe(ItemID.CrimsonBunnyBanner, ItemID.KiteBunnyCrimson);
            AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemID.KiteManEater);
            AddBannerToItemRecipe(ItemID.JellyfishBanner, ItemID.KiteJellyfishBlue);
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.KiteJellyfishPink);
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.KiteShark);
            AddBannerToItemRecipe(ItemID.BoneSerpentBanner, ItemID.KiteBoneSerpent);
            AddBannerToItemRecipe(ItemID.WanderingEyeBanner, ItemID.KiteWanderingEye);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.KiteUnicorn);
            AddBannerToItemRecipe(ItemID.WorldFeederBanner, ItemID.KiteWorldFeeder);
            AddBannerToItemRecipe(ItemID.SandsharkBanner, ItemID.KiteSandShark);
            AddBannerToItemRecipe(ItemID.WyvernBanner, ItemID.KiteWyvern);
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.KiteAngryTrapper);
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.KiteBunny);
            AddBannerToItemRecipe(ItemID.GoldfishBanner, ItemID.KiteGoldfish);
            AddBannerToItemRecipe(ItemID.RedSlimeBanner, ItemID.KiteRed);
            AddBannerToItemRecipe(ItemID.SlimeBanner, ItemID.KiteBlue);
            AddBannerToItemRecipe(ItemID.YellowSlimeBanner, ItemID.KiteYellow);

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.KiteBlueAndYellow)
                .AddIngredient(ItemID.KiteBlue)
                .AddIngredient(ItemID.KiteYellow)
                .AddTile(TileID.Loom)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.KiteRedAndYellow)
                .AddIngredient(ItemID.KiteRed)
                .AddIngredient(ItemID.KiteYellow)
                .AddTile(TileID.Loom)
                .Register();

            // TODO: Super Star Shooter recipe (possibly using a Star Cannon?)

            // Thorium
            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                Mod thorium = Fargowiltas.LoadedMods["Thorium"];

                AddBannerToItemRecipe(thorium.ItemType("AncientChargerBanner"), thorium.ItemType("OlympicTorch"));
                AddBannerToItemRecipe(thorium.ItemType("AncientPhalanxBanner"), thorium.ItemType("AncientAegis"));
                AddBannerToItemRecipe(thorium.ItemType("ArmyAntBanner"), thorium.ItemType("HiveMind"));
                AddBannerToItemRecipe(thorium.ItemType("AstroBeetleBanner"), thorium.ItemType("AstroBeetleHusk"));
                AddBannerToItemRecipe(thorium.ItemType("BlisterPodBanner"), thorium.ItemType("BlisterSack"));
                AddBannerToItemRecipe(thorium.ItemType("BlizzardBatBanner"), thorium.ItemType("IceFairyStaff"));
                AddBannerToItemRecipe(thorium.ItemType("BoneFlayerBanner"), thorium.ItemType("BoneFlayerTail"));
                AddBannerToItemRecipe(thorium.ItemType("ChilledSpitterBanner"), thorium.ItemType("FrostPlagueStaff"));
                AddBannerToItemRecipe(thorium.ItemType("CoinBagBanner"), thorium.ItemType("AncientDrachma"));
                AddBannerToItemRecipe(thorium.ItemType("ColdlingBanner"), thorium.ItemType("SpineBuster"));
                AddBannerToItemRecipe(thorium.ItemType("CoolmeraBanner"), thorium.ItemType("MeatBallStaff"));
                AddBannerToItemRecipe(thorium.ItemType("CrownBanner"), thorium.ItemType("SpinyShell"));
                AddBannerToItemRecipe(thorium.ItemType("FlamekinCasterBanner"), thorium.ItemType("MoltenScale"));
                AddBannerToItemRecipe(thorium.ItemType("FrostBurntBanner"), thorium.ItemType("BlizzardsEdge"));
                AddBannerToItemRecipe(thorium.ItemType("GigaClamBanner"), thorium.ItemType("NanoClamCane"));
                AddBannerToItemRecipe(thorium.ItemType("GnomesBanner"), thorium.ItemType("GnomePick"));
                AddBannerToItemRecipe(thorium.ItemType("HammerHeadBanner"), thorium.ItemType("CartlidgedCatcher"));
                AddBannerToItemRecipe(thorium.ItemType("InfernalHoundBanner"), thorium.ItemType("MoltenCollar"));
                AddBannerToItemRecipe(thorium.ItemType("KrakenBanner"), thorium.ItemType("Leviathan"));
                AddBannerToItemRecipe(thorium.ItemType("LycanBanner"), thorium.ItemType("MoonlightStaff"));
                AddBannerToItemRecipe(thorium.ItemType("MoltenMortarBanner"), thorium.ItemType("MortarStaff"));
                AddBannerToItemRecipe(thorium.ItemType("NecroPotBanner"), thorium.ItemType("GhostlyGrapple"));
                AddBannerToItemRecipe(thorium.ItemType("ScissorStalkerBanner"), thorium.ItemType("StalkersSnippers"));
                AddBannerToItemRecipe(thorium.ItemType("ShamblerBanner"), thorium.ItemType("BallnChain"));
                AddBannerToItemRecipe(thorium.ItemType("SharptoothBanner"), thorium.ItemType("GoldenScale"), 4);
                AddBannerToItemRecipe(thorium.ItemType("SnowSingaBanner"), thorium.ItemType("EskimoBanjo"));
                AddBannerToItemRecipe(thorium.ItemType("SnowyOwlBanner"), thorium.ItemType("LostMail"));
                AddBannerToItemRecipe(thorium.ItemType("SpectrumiteBanner"), thorium.ItemType("PrismiteStaff"));
                AddBannerToItemRecipe(thorium.ItemType("StarvedBanner"), thorium.ItemType("DesecratedHeart"));
                AddBannerToItemRecipe(thorium.ItemType("TarantulaBanner"), thorium.ItemType("Arthropod"));
                AddBannerToItemRecipe(thorium.ItemType("UFOBanner"), thorium.ItemType("DetachedUFOBlaster"));
                AddBannerToItemRecipe(thorium.ItemType("UnderworldPotBanner"), thorium.ItemType("HotPot"));
                AddBannerToItemRecipe(thorium.ItemType("VampireSquidBanner"), thorium.ItemType("VampireGland"));
                AddBannerToItemRecipe(thorium.ItemType("VileSpitterBanner"), thorium.ItemType("VileSpitter"));
                AddBannerToItemRecipe(thorium.ItemType("VoltBanner"), thorium.ItemType("VoltHatchet"));
                AddBannerToItemRecipe(thorium.ItemType("WindElementalBanner"), thorium.ItemType("Zapper"));

                AddBannerToItemRecipe(ItemID.AngryBonesBanner, thorium.ItemType("GraveGoods"));
                AddBannerToItemRecipe(ItemID.BoneLeeBanner, thorium.ItemType("TechniqueShadowClone"));
                AddBannerToItemRecipe(ItemID.BoneSerpentBanner, thorium.ItemType("SpineBreaker"));
                AddBannerToItemRecipe(ItemID.FlyingSnakeBanner, thorium.ItemType("Spearmint"));
                AddBannerToItemRecipe(ItemID.FrankensteinBanner, thorium.ItemType("TeslaDefibrillator"));
                AddBannerToItemRecipe(ItemID.MartianOfficerBanner, thorium.ItemType("ShieldDroneBeacon"));
                AddBannerToItemRecipe(ItemID.MisterStabbyBanner, thorium.ItemType("BackStabber"));
                AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, thorium.ItemType("DeadEyePatch"));
                AddBannerToItemRecipe(ItemID.RaggedCasterBanner, thorium.ItemType("GatewayGlass"));
                AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, thorium.ItemType("EbonyTail"));
                AddBannerToItemRecipe(ItemID.RedDevilBanner, thorium.ItemType("DemonTongue"));
                AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, thorium.ItemType("LaunchJumper"));
                AddBannerToItemRecipe(ItemID.SnowBallaBanner, thorium.ItemType("HailBomber"));
                AddBannerToItemRecipe(ItemID.SnowmanGangstaBanner, thorium.ItemType("TommyGun"));
                AddBannerToItemRecipe(ItemID.SquirrelGold, thorium.ItemType("SinisterAcorn"), 10);
                AddBannerToItemRecipe(ItemID.SwampThingBanner, thorium.ItemType("SwampSpike"));
                AddBannerToItemRecipe(ItemID.WyvernBanner, thorium.ItemType("CloudyChewToy"));

                AddBannerToItemsRecipe(thorium.ItemType("DarksteelKnightBanner"), new int[] { thorium.ItemType("BrokenDarksteelHelmet"), thorium.ItemType("GrayDPaintingItem") });
                AddBannerToItemsRecipe(thorium.ItemType("InvaderBanner"), new int[] { thorium.ItemType("VegaPhaser"), thorium.ItemType("BioPod") });
                AddBannerToItemsRecipe(thorium.ItemType("NecroticImbuerBanner"), new int[] { thorium.ItemType("NecroticStaff"), thorium.ItemType("TechniqueBloodLotus") });
                AddBannerToItemsRecipe(thorium.ItemType("WargBanner"), new int[] { thorium.ItemType("BattleHorn"), thorium.ItemType("BlackCatEars"), thorium.ItemType("Bagpipe"), thorium.ItemType("BloodCellStaff") });
                AddBannerToItemsRecipe(ItemID.MimicBanner, new int[] { thorium.ItemType("LargeCoin"), thorium.ItemType("ProofAvarice") });
            }

            // Calamity
            if (Fargowiltas.ModLoaded("CalamityMod"))
            {
                Mod calamity = Fargowiltas.LoadedMods["Calamity"];

                AddBannerToItemRecipe(calamity.ItemType("AngryDogBanner"), calamity.ItemType("Cryophobia"), 2);
                AddBannerToItemRecipe(calamity.ItemType("ArmoredDiggerBanner"), calamity.ItemType("LeadWizard"));
                AddBannerToItemRecipe(calamity.ItemType("CnidrionBanner"), calamity.ItemType("TheTransformer"), 2);
                AddBannerToItemRecipe(calamity.ItemType("CrystalCrawlerBanner"), calamity.ItemType("CrystalBlade"));
                AddBannerToItemRecipe(calamity.ItemType("CuttlefishBanner"), calamity.ItemType("InkBomb"));
                AddBannerToItemRecipe(calamity.ItemType("EidolonWyrmJuvenileBanner"), calamity.ItemType("HalibutCannon"), 200);
                AddBannerToItemRecipe(calamity.ItemType("IceClasperBanner"), calamity.ItemType("FrostBarrier"));
                AddBannerToItemRecipe(calamity.ItemType("ImpiousImmolatorBanner"), calamity.ItemType("EnergyStaff"));
                AddBannerToItemRecipe(calamity.ItemType("IrradiatedSlimeBanner"), calamity.ItemType("LeadCore"));
                AddBannerToItemRecipe(calamity.ItemType("TrasherBanner"), calamity.ItemType("TrashmanTrashcan"));

                AddBannerToItemRecipe(ItemID.BoneSerpentBanner, calamity.ItemType("OldLordOathsword"));
                AddBannerToItemRecipe(ItemID.ClingerBanner, calamity.ItemType("CursedDagger"));
                AddBannerToItemRecipe(ItemID.DemonBanner, calamity.ItemType("BladecrestOathsword"));
                AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, calamity.ItemType("EvilSmasher"), 4);
                AddBannerToItemRecipe(ItemID.DungeonSpiritBanner, calamity.ItemType("PearlGod"), 4);
                AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, calamity.ItemType("MandibleBow"));
                AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, calamity.ItemType("PlasmaRod"));
                AddBannerToItemRecipe(ItemID.GoblinWarriorBanner, calamity.ItemType("Warblade"));
                AddBannerToItemRecipe(ItemID.HarpyBanner, calamity.ItemType("SkyGlaze"), 2);
                AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("IchorSpear"));
                AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("SpearofDestiny"), 4);
                AddBannerToItemRecipe(ItemID.MimicBanner, calamity.ItemType("TheBee"), 2);
                AddBannerToItemRecipe(ItemID.NecromancerBanner, calamity.ItemType("WrathoftheAncients"));
                AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("Arbalest"), 4);
                AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("RaidersGlory"));
                AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, calamity.ItemType("ProporsePistol"));
                AddBannerToItemRecipe(ItemID.PossessedArmorBanner, calamity.ItemType("PsychoticAmulet"), 4);
                AddBannerToItemRecipe(ItemID.RuneWizardBanner, calamity.ItemType("EyeofMagnus"));
                AddBannerToItemRecipe(ItemID.SandElementalBanner, calamity.ItemType("WifeinaBottlewithBoobs"));
                AddBannerToItemRecipe(ItemID.SharkBanner, calamity.ItemType("DepthBlade"));
                AddBannerToItemRecipe(ItemID.SkeletonBanner, calamity.ItemType("Waraxe"));
                AddBannerToItemRecipe(ItemID.SkeletonMageBanner, calamity.ItemType("AncientShiv"));
                AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, calamity.ItemType("TrueConferenceCall"), 4);
                AddBannerToItemRecipe(ItemID.TombCrawlerBanner, calamity.ItemType("BurntSienna"));
                AddBannerToItemRecipe(ItemID.TortoiseBanner, calamity.ItemType("FabledTortoiseShell"), 4);
                AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, calamity.ItemType("MandibleClaws"));
            }
        }

        private static void AddStatueRecipes()
        {
            Recipe recipe;

            void AddStatueRecipe(int statue, int ingredient, int ingredientAmount = 1)
            {
                recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(statue);

                if (ingredient != -1)
                {
                    recipe.AddIngredient(ingredient, ingredientAmount);
                }

                recipe.AddIngredient(ItemID.StoneBlock, 50);
                recipe.AddTile(TileID.HeavyWorkBench);
                recipe.Register();
            }

            // Functional statues
            AddStatueRecipe(ItemID.BatStatue, ItemID.BatBanner);
            AddStatueRecipe(ItemID.ChestStatue, ItemID.MimicBanner);
            AddStatueRecipe(ItemID.CrabStatue, ItemID.CrabBanner);
            AddStatueRecipe(ItemID.JellyfishStatue, ItemID.JellyfishBanner);
            AddStatueRecipe(ItemID.PiranhaStatue, ItemID.PiranhaBanner);
            AddStatueRecipe(ItemID.SharkStatue, ItemID.SharkBanner);
            AddStatueRecipe(ItemID.SkeletonStatue, ItemID.SkeletonBanner);
            AddStatueRecipe(ItemID.BoneSkeletonStatue, ItemID.SkeletonBanner);
            AddStatueRecipe(ItemID.SlimeStatue, ItemID.SlimeBanner);
            AddStatueRecipe(ItemID.WallCreeperStatue, ItemID.SpiderBanner);
            AddStatueRecipe(ItemID.UnicornStatue, ItemID.UnicornBanner);
            AddStatueRecipe(ItemID.DripplerStatue, ItemID.DripplerBanner);
            AddStatueRecipe(ItemID.WraithStatue, ItemID.WraithBanner);
            AddStatueRecipe(ItemID.UndeadVikingStatue, ItemID.UndeadVikingBanner);
            AddStatueRecipe(ItemID.MedusaStatue, ItemID.MedusaBanner);
            AddStatueRecipe(ItemID.HarpyStatue, ItemID.HarpyBanner);
            AddStatueRecipe(ItemID.PigronStatue, ItemID.PigronBanner);
            AddStatueRecipe(ItemID.HopliteStatue, ItemID.GreekSkeletonBanner);
            AddStatueRecipe(ItemID.GraniteGolemStatue, ItemID.GraniteGolemBanner);
            AddStatueRecipe(ItemID.BloodZombieStatue, ItemID.BloodZombieBanner);
            AddStatueRecipe(ItemID.BombStatue, ItemID.Bomb, 99);
            AddStatueRecipe(ItemID.HeartStatue, ItemID.LifeCrystal, 6);
            AddStatueRecipe(ItemID.StarStatue, ItemID.ManaCrystal, 6);
            AddStatueRecipe(ItemID.ZombieArmStatue, ItemID.ZombieBanner);
            AddStatueRecipe(ItemID.CorruptStatue, ItemID.EaterofSoulsBanner);
            AddStatueRecipe(ItemID.EyeballStatue, ItemID.DemonEyeBanner);
            AddStatueRecipe(ItemID.GoblinStatue, ItemID.GoblinPeonBanner);
            AddStatueRecipe(ItemID.HornetStatue, ItemID.HornetBanner);
            AddStatueRecipe(ItemID.ImpStatue, ItemID.FireImpBanner);

            // Non-functional statues
            AddStatueRecipe(ItemID.ShieldStatue, -1);
            AddStatueRecipe(ItemID.AnvilStatue, -1);
            AddStatueRecipe(ItemID.AxeStatue, -1);
            AddStatueRecipe(ItemID.BoomerangStatue, -1);
            AddStatueRecipe(ItemID.BootStatue, -1);
            AddStatueRecipe(ItemID.BowStatue, -1);
            AddStatueRecipe(ItemID.HammerStatue, -1);
            AddStatueRecipe(ItemID.PickaxeStatue, -1);
            AddStatueRecipe(ItemID.SpearStatue, -1);
            AddStatueRecipe(ItemID.SunflowerStatue, -1);
            AddStatueRecipe(ItemID.SwordStatue, -1);
            AddStatueRecipe(ItemID.PotionStatue, -1);
            AddStatueRecipe(ItemID.AngelStatue, -1);
            AddStatueRecipe(ItemID.CrossStatue, -1);
            AddStatueRecipe(ItemID.GargoyleStatue, -1);
            AddStatueRecipe(ItemID.GloomStatue, -1);
            AddStatueRecipe(ItemID.PillarStatue, -1);
            AddStatueRecipe(ItemID.PotStatue, -1);
            AddStatueRecipe(ItemID.ReaperStatue, -1);
            AddStatueRecipe(ItemID.WomanStatue, -1);
            AddStatueRecipe(ItemID.TreeStatue, -1);

            // Lihzahrd statues
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdGuardianStatue);
            recipe.AddIngredient(ItemID.LihzahrdBanner);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            recipe.AddTile(TileID.HeavyWorkBench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdStatue);
            recipe.AddIngredient(ItemID.LihzahrdBanner);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            recipe.AddTile(TileID.HeavyWorkBench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdWatcherStatue);
            recipe.AddIngredient(ItemID.LihzahrdBanner);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            recipe.AddTile(TileID.HeavyWorkBench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.KingStatue);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.QueenStatue);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);            recipe.Register();
        }

        private static void AddContainerLootRecipes()
        {
            Recipe recipe;

            void KeyToItemRecipe(int key, int result)
            {
                recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                recipe.AddIngredient(key);
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }

            KeyToItemRecipe(ItemID.CrimsonKey, ItemID.VampireKnives);
            KeyToItemRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor);
            KeyToItemRecipe(ItemID.JungleKey, ItemID.PiranhaGun);
            KeyToItemRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra);
            KeyToItemRecipe(ItemID.HallowedKey, ItemID.RainbowGun);
            KeyToItemRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff);

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                Mod thorium = Fargowiltas.LoadedMods["Thorium"];

                KeyToItemRecipe(thorium.ItemType("DesertBiomeKey"), thorium.ItemType("PharaohsSlab"));
                KeyToItemRecipe(thorium.ItemType("UnderworldBiomeKey"), thorium.ItemType("PheonixStaff"));
                KeyToItemRecipe(thorium.ItemType("AquaticDepthsBiomeKey"), thorium.ItemType("Fishbone"));
            }

            // Goodie Bag / Present recipes
            void AddGrabBagItemRecipe(int result, int grabBag = ItemID.Present, int grabBagAmount = 50, int keyType = -1)
            {
                recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                recipe.AddIngredient(grabBag, grabBagAmount);

                if (keyType != -1)
                {
                    recipe.AddIngredient(keyType);
                }

                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            void AddGrabBagGroupRecipe(int result, string grabBagGroup, int grabBagAmount = 50)
            {
                recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
                recipe.AddRecipeGroup(grabBagGroup, grabBagAmount);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            // Present items
            AddGrabBagItemRecipe(ItemID.DogWhistle);
            AddGrabBagItemRecipe(ItemID.Toolbox);
            AddGrabBagItemRecipe(ItemID.HandWarmer);
            AddGrabBagItemRecipe(ItemID.RedRyder);
            AddGrabBagItemRecipe(ItemID.CandyCaneSword);
            AddGrabBagItemRecipe(ItemID.CandyCaneHook);
            AddGrabBagItemRecipe(ItemID.FruitcakeChakram);
            AddGrabBagItemRecipe(ItemID.CnadyCanePickaxe);
            AddGrabBagItemRecipe(ItemID.UnluckyYarn, ItemID.GoodieBag);
            AddGrabBagItemRecipe(ItemID.BatHook, ItemID.GoodieBag, 100);

            // Wooden / Pearlwood Crate items
            AddGrabBagGroupRecipe(ItemID.SailfishBoots, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.TsunamiInABottle, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Aglet, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.CordageGuide, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Umbrella, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.ClimbingClaws, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Radar, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.WoodenBoomerang, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.WandofSparking, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Spear, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.PortableStool, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.BabyBirdStaff, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.LadybugMinecart, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.SunflowerMinecart, "Fargowiltas:AnyWoodenCrate", 5);
            AddGrabBagItemRecipe(ItemID.Extractinator, ItemID.WoodenCrate, 5);
            AddGrabBagItemRecipe(ItemID.Anchor, ItemID.WoodenCrateHard, 5);
            AddGrabBagItemRecipe(ItemID.Sundial, ItemID.WoodenCrateHard, 5);

            // Iron / Mythril Crate items
            AddGrabBagGroupRecipe(ItemID.FalconBlade, "Fargowiltas:AnyIronCrate", 5);
            AddGrabBagGroupRecipe(ItemID.TartarSauce, "Fargowiltas:AnyIronCrate", 5);
            AddGrabBagGroupRecipe(ItemID.GingerBeard, "Fargowiltas:AnyIronCrate", 5);
            AddGrabBagGroupRecipe(ItemID.SailfishBoots, "Fargowiltas:AnyIronCrate", 5);
            AddGrabBagGroupRecipe(ItemID.TsunamiInABottle, "Fargowiltas:AnyIronCrate", 5);
            AddGrabBagItemRecipe(ItemID.Sundial, ItemID.IronCrateHard, 5);

            // Golden / Titanium Crate items
            AddGrabBagGroupRecipe(ItemID.HardySaddle, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Sundial, "Fargowiltas:AnyGoldenCrate", 10);
            AddGrabBagGroupRecipe(ItemID.EnchantedSword, "Fargowiltas:AnyGoldenCrate", 10);
            AddGrabBagGroupRecipe(ItemID.BandofRegeneration, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.MagicMirror, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.FlareGun, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.HermesBoots, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.ShoeSpikes, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.CloudinaBottle, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagGroupRecipe(ItemID.Mace, "Fargowiltas:AnyGoldenCrate", 5);
            AddGrabBagItemRecipe(ItemID.Sundial, ItemID.GoldenCrateHard, 5);

            // Jungle / Bramble Crate items
            AddGrabBagGroupRecipe(ItemID.FlowerBoots, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.AnkletoftheWind, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Boomstick, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.FeralClaws, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.StaffofRegrowth, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.FiberglassFishingPole, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.HoneyDispenser, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.FlowerBoots, "Fargowiltas:AnyJungleCrate", 5);
            AddGrabBagGroupRecipe(ItemID.BeeMinecart, "Fargowiltas:AnyJungleCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Seaweed, "Fargowiltas:AnyJungleCrate", 10);

            // Sky / Azure Crate items
            AddGrabBagGroupRecipe(ItemID.ShinyRedBalloon, "Fargowiltas:AnySkyCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Starfury, "Fargowiltas:AnySkyCrate", 3);
            AddGrabBagGroupRecipe(ItemID.LuckyHorseshoe, "Fargowiltas:AnySkyCrate", 3);
            AddGrabBagGroupRecipe(ItemID.SkyMill, "Fargowiltas:AnySkyCrate", 3);

            // Corrupt / Defiled Crate items
            AddGrabBagGroupRecipe(ItemID.BallOHurt, "Fargowiltas:AnyCorruptCrate", 3);
            AddGrabBagGroupRecipe(ItemID.BandofStarpower, "Fargowiltas:AnyCorruptCrate", 3);
            AddGrabBagGroupRecipe(ItemID.ShadowOrb, "Fargowiltas:AnyCorruptCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Musket, "Fargowiltas:AnyCorruptCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Vilethorn, "Fargowiltas:AnyCorruptCrate", 3);

            // Crimson / Hematic Crate items
            AddGrabBagGroupRecipe(ItemID.TheUndertaker, "Fargowiltas:AnyCrimsonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.TheRottedFork, "Fargowiltas:AnyCrimsonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.CrimsonRod, "Fargowiltas:AnyCrimsonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.PanicNecklace, "Fargowiltas:AnyCrimsonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.CrimsonHeart, "Fargowiltas:AnyCrimsonCrate", 3);

            // Dungeon / Stockade Crate items
            AddGrabBagGroupRecipe(ItemID.WaterBolt, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Muramasa, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.CobaltShield, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.MagicMissile, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.AquaScepter, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Valor, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.Handgun, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.ShadowKey, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.BlueMoon, "Fargowiltas:AnyDungeonCrate", 3);
            AddGrabBagGroupRecipe(ItemID.BoneWelder, "Fargowiltas:AnyDungeonCrate", 3);

            // Golden Lock Box items
            AddGrabBagItemRecipe(ItemID.WaterBolt, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.Muramasa, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.CobaltShield, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.MagicMissile, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.AquaScepter, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.Valor, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.Handgun, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.ShadowKey, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.BlueMoon, ItemID.LockBox, 3, ItemID.GoldenKey);
            AddGrabBagItemRecipe(ItemID.BoneWelder, ItemID.LockBox, 3, ItemID.GoldenKey);

            // Frozen / Boreal Crate items
            AddGrabBagGroupRecipe(ItemID.IceBoomerang, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.IceBlade, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.IceSkates, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.SnowballCannon, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.BlizzardinaBottle, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.FlurryBoots, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.Extractinator, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.IceMachine, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.IceMirror, "Fargowiltas:AnyFrozenCrate", 1);
            AddGrabBagGroupRecipe(ItemID.Fish, "Fargowiltas:AnyFrozenCrate", 10);

            // Oasis / Mirage Crate items
            AddGrabBagGroupRecipe(ItemID.SandBoots, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.ThunderSpear, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.AncientChisel, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.ThunderStaff, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.MysticCoilSnake, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.MagicConch, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.CatBast, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.ScarabFishingRod, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.EncumberingStone, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.DesertMinecart, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.FlyingCarpet, "Fargowiltas:AnyOasisCrate", 5);
            AddGrabBagGroupRecipe(ItemID.SandstorminaBottle, "Fargowiltas:AnyOasisCrate", 5);

            // Obsidian / Hellstone Crate items
            AddGrabBagGroupRecipe(ItemID.LavaCharm, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.FlameWakerBoots, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.SuperheatedBlood, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.LavaFishbowl, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.LavaFishingHook, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.VolcanoSmall, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.PotSuspended, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.HellwingBow, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.Flamelash, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.FlowerofFire, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.Sunfury, "Fargowiltas:AnyObsidianCrate", 1);
            AddGrabBagGroupRecipe(ItemID.TreasureMagnet, "Fargowiltas:AnyObsidianCrate", 1);

            // Obsidian Lockbox items
            AddGrabBagItemRecipe(ItemID.HellwingBow, ItemID.ObsidianLockbox, 1, ItemID.ShadowKey);
            AddGrabBagItemRecipe(ItemID.Flamelash, ItemID.ObsidianLockbox, 1, ItemID.ShadowKey);
            AddGrabBagItemRecipe(ItemID.FlowerofFire, ItemID.ObsidianLockbox, 1, ItemID.ShadowKey);
            AddGrabBagItemRecipe(ItemID.Sunfury, ItemID.ObsidianLockbox, 1, ItemID.ShadowKey);
            AddGrabBagItemRecipe(ItemID.TreasureMagnet, ItemID.ObsidianLockbox, 1, ItemID.ShadowKey);

            // Ocean / Seaside Crate items
            AddGrabBagGroupRecipe(ItemID.Flipper, "Fargowiltas:AnyOceanCrate", 1);
            AddGrabBagGroupRecipe(ItemID.Trident, "Fargowiltas:AnyOceanCrate", 1);
            AddGrabBagGroupRecipe(ItemID.FloatingTube, "Fargowiltas:AnyOceanCrate", 1);
            AddGrabBagGroupRecipe(ItemID.BreathingReed, "Fargowiltas:AnyOceanCrate", 1);
            AddGrabBagGroupRecipe(ItemID.WaterWalkingBoots, "Fargowiltas:AnyOceanCrate", 5);
            AddGrabBagGroupRecipe(ItemID.SharkBait, "Fargowiltas:AnyOceanCrate", 5);
        }

        private static void AddNPCRecipes()
        {
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FleshBlock, 25);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.MeatGrinder);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DeepRedPaint, 20);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BluePaint, 20);
            recipe.AddIngredient(ModContent.ItemType<Truffle>());
            recipe.AddTile(TileID.DyeVat);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GrimDye, 2);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.DyeVat);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Bone, 25);
            recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
            recipe.AddTile(TileID.BoneWelder);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LeafWand);
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LivingWoodWand);
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TruffleWorm);
            recipe.AddIngredient(null, "Truffle");
            recipe.AddIngredient(ItemID.EnchantedNightcrawler);
            recipe.AddTile(TileID.Autohammer);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DyeTradersScimitar);
            recipe.AddIngredient(null, "DyeTrader");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AleThrowingGlove);
            recipe.AddIngredient(null, "Tavernkeep");
            recipe.AddIngredient(ItemID.Ale, 5);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StylistKilLaKillScissorsIWish);
            recipe.AddIngredient(null, "Stylist");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PainterPaintballGun);
            recipe.AddIngredient(null, "Painter");
            recipe.AddIngredient(ItemID.WoodenBow);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TaxCollectorsStickOfDoom);
            recipe.AddIngredient(null, "TaxCollector");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FishermansGuide);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WeatherRadio);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Sextant);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);            recipe.Register();

            // Travalling Merchant recipes
            // TODO: Add more.
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AngelHalo);
            recipe.AddIngredient(null, "TravellingMerchant", 5);
            recipe.AddTile(TileID.TinkerersWorkbench);            recipe.Register();

            // engineers combat rench recipe
            // engineer plus wrench
        }

        private static void AddTreasureBagRecipes()
        {
            //QB
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeesKnees);
            recipe.AddIngredient(ItemID.QueenBeeBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeGun);
            recipe.AddIngredient(ItemID.QueenBeeBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeKeeper);
            recipe.AddIngredient(ItemID.QueenBeeBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //WOF
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RangerEmblem);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SorcererEmblem);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SummonerEmblem);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WarriorEmblem);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ClockworkAssaultRifle);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BreakerBlade);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserRifle);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FireWhip);
            recipe.AddIngredient(ItemID.WallOfFleshBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //plantera
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GrenadeLauncher);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PygmyStaff);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.VenusMagnum);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NettleBurst);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LeafBlower);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Seedler);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FlowerPow);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WaspGun);
            recipe.AddIngredient(ItemID.PlanteraBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //golem
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Stynger);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PossessedHatchet);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SunStone);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EyeoftheGolem);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Picksaw);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HeatRay);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StaffofEarth);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GolemFist);
            recipe.AddIngredient(ItemID.GolemBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //duke
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Flairon);
            recipe.AddIngredient(ItemID.FishronBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Tsunami);
            recipe.AddIngredient(ItemID.FishronBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RazorbladeTyphoon);
            recipe.AddIngredient(ItemID.FishronBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TempestStaff);
            recipe.AddIngredient(ItemID.FishronBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BubbleGun);
            recipe.AddIngredient(ItemID.FishronBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FairyQueenMagicItem);
            recipe.AddIngredient(ItemID.FairyQueenBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FairyQueenRangedItem);
            recipe.AddIngredient(ItemID.FairyQueenBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RainbowWhip);
            recipe.AddIngredient(ItemID.FairyQueenBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PiercingStarlight);
            recipe.AddIngredient(ItemID.FairyQueenBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //moon lord
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Meowmere);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Terrarian);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StarWrath);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SDMG);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeGun);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LastPrism);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LunarFlareBook);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RainbowCrystalStaff);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MoonlordTurretStaff);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MeowmereMinecart);
            recipe.AddIngredient(ItemID.MoonLordBossBag);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //dark mage
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetDragon);
            recipe.AddIngredient(ItemID.BossTrophyDarkmage);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetGato);
            recipe.AddIngredient(ItemID.BossTrophyDarkmage);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //ogre
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ApprenticeScarf);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SquireShield);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HuntressBuckler);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkBelt);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PhoenixBow);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BookStaff);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2SquireDemonSword);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT1);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT2);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetGhost);
            recipe.AddIngredient(ItemID.BossTrophyOgre);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //besty
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BetsyWings);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2BetsyBow);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2SquireBetsySword);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ApprenticeStaffT3);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT3);
            recipe.AddIngredient(ItemID.BossBagBetsy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //mourning wood
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SpookyHook);
            recipe.AddIngredient(ItemID.MourningWoodTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SpookyTwig);
            recipe.AddIngredient(ItemID.MourningWoodTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StakeLauncher);
            recipe.AddIngredient(ItemID.MourningWoodTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CursedSapling);
            recipe.AddIngredient(ItemID.MourningWoodTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NecromanticScroll);
            recipe.AddIngredient(ItemID.MourningWoodTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //pumpking
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TheHorsemansBlade);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BatScepter);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RavenStaff);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CandyCornRifle);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.JackOLanternLauncher);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlackFairyDust);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ScytheWhip);
            recipe.AddIngredient(ItemID.PumpkingTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //everscream
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChristmasTreeSword);
            recipe.AddIngredient(ItemID.EverscreamTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChristmasHook);
            recipe.AddIngredient(ItemID.EverscreamTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Razorpine);
            recipe.AddIngredient(ItemID.EverscreamTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FestiveWings);
            recipe.AddIngredient(ItemID.EverscreamTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //santa nk1
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EldMelter);
            recipe.AddIngredient(ItemID.SantaNK1Trophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChainGun);
            recipe.AddIngredient(ItemID.SantaNK1Trophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //ice queen
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlizzardStaff);
            recipe.AddIngredient(ItemID.IceQueenTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SnowmanCannon);
            recipe.AddIngredient(ItemID.IceQueenTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NorthPole);
            recipe.AddIngredient(ItemID.IceQueenTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BabyGrinchMischiefWhistle);
            recipe.AddIngredient(ItemID.IceQueenTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ReindeerBells);
            recipe.AddIngredient(ItemID.IceQueenTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            //saucer
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Xenopopper);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.XenoStaff);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserMachinegun);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ElectrosphereLauncher);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.InfluxWaver);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CosmicCarKey);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AntiGravityHook);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChargedBlasterCannon);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserDrill);
            recipe.AddIngredient(ItemID.MartianSaucerTrophy);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            //dutchman
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LuckyCoin);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiscountCard);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CoinGun);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PirateStaff);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GoldRing);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Cutlass);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PirateMinecart);
            recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
            recipe.AddTile(TileID.Solidifier);            recipe.Register();
        }

        private static void AddMiscRecipes()
        {
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddTile(TileID.CrystalBall);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Terragrim);
            recipe.AddIngredient(ItemID.EnchantedSword, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddTile(TileID.CrystalBall);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MagicalPumpkinSeed);
            recipe.AddIngredient(ItemID.Pumpkin, 500);
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Seaweed);
            recipe.AddIngredient(ItemID.FishingSeaweed, 5);
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FlowerBoots);
            recipe.AddIngredient(ItemID.HermesBoots);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LivingLoom);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.JungleRose);
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.RedHusk);
            recipe.AddTile(TileID.LivingLoom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AmberMosquito);
            recipe.AddIngredient(ItemID.Amber, 15);
            recipe.AddIngredient(ItemID.Firefly);
            recipe.AddTile(TileID.CookingPots);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.Moonglow, 15);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.AlchemyTable);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SandstorminaBottle);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.AlchemyTable);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ShroomiteBar);
            recipe.AddIngredient(ItemID.ChlorophyteBar);
            recipe.AddIngredient(ItemID.DarkBlueSolution);
            recipe.AddTile(TileID.Autohammer);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WebSlinger);
            recipe.AddIngredient(ItemID.GrapplingHook);
            recipe.AddIngredient(ItemID.WebRopeCoil, 8);
            recipe.AddTile(TileID.CookingPots);            recipe.Register();
        }

        private static void AddFurnitureRecipes()
        {
            //Dungeon furniture pain
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueBrickPlatform, 2);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBathtub);
            recipe.AddIngredient(ItemID.BlueBrick, 14);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBed);
            recipe.AddIngredient(ItemID.BlueBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBookcase);
            recipe.AddIngredient(ItemID.BlueBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonCandelabra);
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonCandle);
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonChair);
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonChandelier);
            recipe.AddIngredient(ItemID.BlueBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockBlue);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonDoor);
            recipe.AddIngredient(ItemID.BlueBrick, 6);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonDresser);
            recipe.AddIngredient(ItemID.BlueBrick, 16);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonLamp);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.BlueBrick, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonPiano);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.BlueBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonSofa);
            recipe.AddIngredient(ItemID.BlueBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonTable);
            recipe.AddIngredient(ItemID.BlueBrick, 8);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonVase);
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonWorkBench);
            recipe.AddIngredient(ItemID.BlueBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueBrickWall, 4);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueSlabWall, 4);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueTiledWall, 4);
            recipe.AddIngredient(ItemID.BlueBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            //green
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenBrickPlatform, 2);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBathtub);
            recipe.AddIngredient(ItemID.GreenBrick, 14);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBed);
            recipe.AddIngredient(ItemID.GreenBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBookcase);
            recipe.AddIngredient(ItemID.GreenBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonCandelabra);
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonCandle);
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonChair);
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonChandelier);
            recipe.AddIngredient(ItemID.GreenBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockGreen);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonDoor);
            recipe.AddIngredient(ItemID.GreenBrick, 6);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonDresser);
            recipe.AddIngredient(ItemID.GreenBrick, 16);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonLamp);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.GreenBrick, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonPiano);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.GreenBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonSofa);
            recipe.AddIngredient(ItemID.GreenBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonTable);
            recipe.AddIngredient(ItemID.GreenBrick, 8);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonVase);
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonWorkBench);
            recipe.AddIngredient(ItemID.GreenBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenBrickWall, 4);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenSlabWall, 4);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenTiledWall, 4);
            recipe.AddIngredient(ItemID.GreenBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            //pink
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkBrickPlatform, 2);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBathtub);
            recipe.AddIngredient(ItemID.PinkBrick, 14);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBed);
            recipe.AddIngredient(ItemID.PinkBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBookcase);
            recipe.AddIngredient(ItemID.PinkBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonCandelabra);
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonCandle);
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonChair);
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonChandelier);
            recipe.AddIngredient(ItemID.PinkBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockPink);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonDoor);
            recipe.AddIngredient(ItemID.PinkBrick, 6);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonDresser);
            recipe.AddIngredient(ItemID.PinkBrick, 16);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonLamp);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.PinkBrick, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonPiano);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.PinkBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonSofa);
            recipe.AddIngredient(ItemID.PinkBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonTable);
            recipe.AddIngredient(ItemID.PinkBrick, 8);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonVase);
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonWorkBench);
            recipe.AddIngredient(ItemID.PinkBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkBrickWall, 4);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkSlabWall, 4);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkTiledWall, 4);
            recipe.AddIngredient(ItemID.PinkBrick);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            //obsidian
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBathtub);
            recipe.AddIngredient(ItemID.ObsidianBrick, 14);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBed);
            recipe.AddIngredient(ItemID.ObsidianBrick, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBookcase);
            recipe.AddIngredient(ItemID.ObsidianBrick, 20);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianCandelabra);
            recipe.AddIngredient(ItemID.ObsidianBrick, 5);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianCandle);
            recipe.AddIngredient(ItemID.ObsidianBrick, 4);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianChair);
            recipe.AddIngredient(ItemID.ObsidianBrick, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianChandelier);
            recipe.AddIngredient(ItemID.ObsidianBrick, 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddIngredient(ItemID.Chain, 4);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianClock);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(ItemID.ObsidianBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianDoor);
            recipe.AddIngredient(ItemID.ObsidianBrick, 6);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianDresser);
            recipe.AddIngredient(ItemID.ObsidianBrick, 16);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianLamp);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddIngredient(ItemID.ObsidianBrick, 3);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianPiano);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.ObsidianBrick, 15);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianSofa);
            recipe.AddIngredient(ItemID.ObsidianBrick, 5);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianTable);
            recipe.AddIngredient(ItemID.ObsidianBrick, 8);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianVase);
            recipe.AddIngredient(ItemID.ObsidianBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianWorkBench);
            recipe.AddIngredient(ItemID.ObsidianBrick, 10);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdFurnace);
            recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            //lanterns
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChainLantern);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BrassLantern);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CagedLantern);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CarriageLantern);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AlchemyLantern);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiablostLamp);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.OilRagSconse);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(ItemID.Bone, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianLantern);
            recipe.AddIngredient(ItemID.Obsidian, 6);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            //platforms
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonShelf, 5);
            recipe.AddIngredient(ItemID.WoodPlatform, 5);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WoodShelf, 5);
            recipe.AddIngredient(ItemID.WoodPlatform, 5);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MetalShelf, 5);
            recipe.AddIngredient(ItemID.WoodPlatform, 5);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BrassShelf, 5);
            recipe.AddIngredient(ItemID.WoodPlatform, 5);
            recipe.AddIngredient(ItemID.Bone);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();

            //banners
            //dungeon
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MarchingBonesBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NecromanticSign);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RustedCompanyStandard);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RaggedBrotherhoodSigil);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MoltenLegionFlag);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiabolicSigil);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            //sky island
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WorldBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SunBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GravityBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            //underworld
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HellboundBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HellHammerBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HelltowerBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LostHopesofManBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianWatcherBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LavaEruptsBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            //pyramid
            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AnkhBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SandstoneBrick, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SnakeBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SandstoneBrick, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.OmegaBanner);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.SandstoneBrick, 10);
            recipe.AddTile(TileID.Loom);            recipe.Register();
        }

        private static void AddConvertRecipe(int item, int item2)
        {
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(item2);
            recipe.AddIngredient(item);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(item);
            recipe.AddIngredient(item2);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(item2);
            recipe.AddIngredient(item);
            recipe.AddTile(TileID.AlchemyTable);            recipe.Register();

            recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(item);
            recipe.AddIngredient(item2);
            recipe.AddTile(TileID.AlchemyTable);            recipe.Register();
        }

        private static void AddVanillaRecipeChanges()
        {
            RecipeFinder recipeFinder = new RecipeFinder();
            recipeFinder.AddIngredient(ItemID.BeetleHusk);

            foreach (Recipe recipe in recipeFinder.SearchRecipes())
            {
                RecipeEditor editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TurtleHelmet);
                editor.DeleteIngredient(ItemID.TurtleScaleMail);
                editor.DeleteIngredient(ItemID.TurtleLeggings);
            }
        }
    }
}