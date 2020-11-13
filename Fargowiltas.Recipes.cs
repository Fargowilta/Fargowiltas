using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Summons.VanillaCopy;
using Fargowiltas.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    partial class Fargowiltas
    {
        public override void AddRecipes()
        {
            MutantSummonTracker.FinalizeSummonData();

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

            if (ModContent.GetInstance<FargoConfig>().bannerRecipes)
            {
                AddBannerToItemRecipes();
            }
        }

        public static void AddSummonConversion(int ingredient, int result)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(result)
                .AddIngredient(ingredient)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public static void AddBannerToItemRecipe(int banner, int result, int bannerAmount = 1, int resultAmount = 1)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(result, resultAmount)
                .AddIngredient(banner, bannerAmount)
                .AddTile(TileID.Solidifier)
                .Register();
        }

        public static void AddBannerToItemsRecipe(int banner, int[] results, int bannerAmount = 1)
        {
            foreach (int result in results)
            {
                ModContent.GetInstance<Fargowiltas>().CreateRecipe(result)
                    .AddIngredient(banner, bannerAmount)
                    .AddTile(TileID.Solidifier)
                    .Register();
            }
        }

        public static void AddGroupToItemRecipe(string group, int result, int station = TileID.Solidifier, int resultAmount = 1, int groupAmount = 1)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(result)
                .AddRecipeGroup(group, groupAmount)
                .AddTile(TileID.Solidifier)
                .Register();
        }

        public static void AddStatueRecipe(int statue, int ingredient, int ingredientAmount = 1)
        {
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(statue);

            if (ingredient != -1)
            {
                recipe.AddIngredient(ingredient, ingredientAmount);
            }

            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }

        public static void KeyToItemRecipe(int key, int result)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(result)
                .AddIngredient(key)
                .AddIngredient(ItemID.Ectoplasm, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public static void AddGrabBagItemRecipe(int result, int grabBag = ItemID.Present, int grabBagAmount = 50, int keyType = -1)
        {
            Recipe recipe = ModContent.GetInstance<Fargowiltas>().CreateRecipe(result);
            recipe.AddIngredient(grabBag, grabBagAmount);

            if (keyType != -1)
            {
                recipe.AddIngredient(keyType);
            }

            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public static void AddGrabBagGroupRecipe(int result, string grabBagGroup, int grabBagAmount = 50)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(result)
                .AddRecipeGroup(grabBagGroup, grabBagAmount)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public static void AddSummonConversions()
        {
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

        public static void AddEvilConversions()
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

        public static void AddMetalConversions()
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

        public static void AddBannerToItemRecipes()
        {
            // Single-recipe baners
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

            // Multiple-recipe banners
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

            // Recipes for ancient armors
            AddBannerToItemsRecipe(ItemID.EaterofSoulsBanner, new int[] { ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves }, 2);
            AddBannerToItemsRecipe(ItemID.HornetBanner, new int[] { ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings }, 2);
            AddBannerToItemsRecipe(ItemID.SkeletonBanner, new int[] { ItemID.AncientIronHelmet, ItemID.AncientGoldHelmet }, 2);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 2);

            // Recipe for gladiator armor
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

            // Recipes relating to kites and other novelties
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
            Mod thorium = ModLoaded("ThoriumMod") ? LoadedMods["Thorium"] : null;

            if (thorium != null)
            {
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
            Mod calamity = ModLoaded("CalamityMod") ? LoadedMods["CalamityMod"] : null;

            if (calamity != null)
            {
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

        public static void AddStatueRecipes()
        {
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
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdGuardianStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)                .AddTile(TileID.HeavyWorkBench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)                .AddTile(TileID.HeavyWorkBench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdWatcherStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)                .AddTile(TileID.HeavyWorkBench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.KingStatue)
                .AddIngredient(ItemID.Throne)
                .AddIngredient(ItemID.TeleportationPotion)
                .AddIngredient(ItemID.StoneBlock, 50)                .AddTile(TileID.HeavyWorkBench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.QueenStatue)
                .AddIngredient(ItemID.Throne)
                .AddIngredient(ItemID.TeleportationPotion)
                .AddIngredient(ItemID.StoneBlock, 50)                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }

        public static void AddContainerLootRecipes()
        {
            KeyToItemRecipe(ItemID.CrimsonKey, ItemID.VampireKnives);
            KeyToItemRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor);
            KeyToItemRecipe(ItemID.JungleKey, ItemID.PiranhaGun);
            KeyToItemRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra);
            KeyToItemRecipe(ItemID.HallowedKey, ItemID.RainbowGun);
            KeyToItemRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff);

            Mod thorium = ModLoaded("ThoriumMod") ? LoadedMods["Thorium"] : null;

            if (thorium != null)
            {
                KeyToItemRecipe(thorium.ItemType("DesertBiomeKey"), thorium.ItemType("PharaohsSlab"));
                KeyToItemRecipe(thorium.ItemType("UnderworldBiomeKey"), thorium.ItemType("PheonixStaff"));
                KeyToItemRecipe(thorium.ItemType("AquaticDepthsBiomeKey"), thorium.ItemType("Fishbone"));
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

        public static void AddNPCRecipes()
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FleshBlock, 25)
                .AddRecipeGroup("Fargowiltas:AnyCaughtNPC")                .AddTile(TileID.MeatGrinder)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DeepRedPaint, 20)
                .AddRecipeGroup("Fargowiltas:AnyCaughtNPC")                .AddTile(TileID.DyeVat)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BluePaint, 20)
                .AddIngredient(ModContent.ItemType<Truffle>())                .AddTile(TileID.DyeVat)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GrimDye, 2)
                .AddRecipeGroup("Fargowiltas:AnyCaughtNPC")                .AddTile(TileID.DyeVat)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Bone, 25)
                .AddRecipeGroup("Fargowiltas:AnyCaughtNPC")                .AddTile(TileID.BoneWelder)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LeafWand)
                .AddIngredient(ModContent.ItemType<Dryad>())                .AddTile(TileID.LivingLoom)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LivingWoodWand)
                .AddIngredient(ModContent.ItemType<Dryad>())                .AddTile(TileID.LivingLoom)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TruffleWorm)
                .AddIngredient(ModContent.ItemType<Truffle>())
                .AddIngredient(ItemID.EnchantedNightcrawler)                .AddTile(TileID.Autohammer)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DyeTradersScimitar)
                .AddIngredient(ModContent.ItemType<DyeTrader>())
                .AddIngredient(ItemID.WoodenSword)                .AddTile(TileID.DemonAltar)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AleThrowingGlove)
                .AddIngredient(ModContent.ItemType<Tavernkeep>())
                .AddIngredient(ItemID.Ale, 5)                .AddTile(TileID.DemonAltar)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StylistKilLaKillScissorsIWish)
                .AddIngredient(ModContent.ItemType<Stylist>())
                .AddIngredient(ItemID.WoodenSword)                .AddTile(TileID.DemonAltar)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PainterPaintballGun)
                .AddIngredient(ModContent.ItemType<Painter>())
                .AddIngredient(ItemID.WoodenBow)                .AddTile(TileID.DemonAltar)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TaxCollectorsStickOfDoom)
                .AddIngredient(ModContent.ItemType<TaxCollector>())
                .AddIngredient(ItemID.WoodenSword)                .AddTile(TileID.DemonAltar)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FishermansGuide)
                .AddIngredient(ModContent.ItemType<Angler>())                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WeatherRadio)
                .AddIngredient(ModContent.ItemType<Angler>())                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Sextant)
                .AddIngredient(ModContent.ItemType<Angler>())                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            // Travalling Merchant recipes
            // TODO: Add more.
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AngelHalo)
                .AddIngredient(ModContent.ItemType<TravellingMerchant>(), 5)                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CombatWrench)
                .AddIngredient(ItemID.Wrench)
                .AddIngredient(ModContent.ItemType<Mechanic>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }

        public static void AddTreasureBagRecipes()
        {
            // Queen Bee
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeesKnees)
                .AddIngredient(ItemID.QueenBeeBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeGun)
                .AddIngredient(ItemID.QueenBeeBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeKeeper)
                .AddIngredient(ItemID.QueenBeeBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            // Wall of Flesh
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RangerEmblem)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SorcererEmblem)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SummonerEmblem)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WarriorEmblem)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ClockworkAssaultRifle)
                .AddIngredient(ItemID.WallOfFleshBossBag)
                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BreakerBlade)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserRifle)
                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FireWhip)                .AddIngredient(ItemID.WallOfFleshBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            // Plantera
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GrenadeLauncher)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PygmyStaff)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.VenusMagnum)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NettleBurst)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LeafBlower)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Seedler)
                .AddIngredient(ItemID.PlanteraBossBag)                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FlowerPow)
                .AddIngredient(ItemID.PlanteraBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WaspGun)
                .AddIngredient(ItemID.PlanteraBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            // Golem
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Stynger)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PossessedHatchet)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SunStone)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EyeoftheGolem)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Picksaw)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HeatRay)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StaffofEarth)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GolemFist)
                .AddIngredient(ItemID.GolemBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            // Duke Fishron
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Flairon)
                .AddIngredient(ItemID.FishronBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Tsunami)
                .AddIngredient(ItemID.FishronBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RazorbladeTyphoon)
                .AddIngredient(ItemID.FishronBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TempestStaff)
                .AddIngredient(ItemID.FishronBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BubbleGun)
                .AddIngredient(ItemID.FishronBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FairyQueenMagicItem)
                .AddIngredient(ItemID.FairyQueenBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FairyQueenRangedItem)
                .AddIngredient(ItemID.FairyQueenBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RainbowWhip)
                .AddIngredient(ItemID.FairyQueenBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PiercingStarlight)
                .AddIngredient(ItemID.FairyQueenBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            // Moon Lord
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Meowmere)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Terrarian)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StarWrath)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SDMG)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BeeGun)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LastPrism)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LunarFlareBook)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RainbowCrystalStaff)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MoonlordTurretStaff)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MeowmereMinecart)
                .AddIngredient(ItemID.MoonLordBossBag)
                .AddTile(TileID.Solidifier)                .Register();

            // Dark Mage
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetDragon)
                .AddIngredient(ItemID.BossTrophyDarkmage)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetGato)
                .AddIngredient(ItemID.BossTrophyDarkmage)
                .AddTile(TileID.Solidifier)                .Register();

            // Ogre
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ApprenticeScarf)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SquireShield)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HuntressBuckler)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkBelt)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PhoenixBow)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BookStaff)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2SquireDemonSword)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT1)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT2)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2PetGhost)
                .AddIngredient(ItemID.BossTrophyOgre)
                .AddTile(TileID.Solidifier)                .Register();

            // Betsy
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BetsyWings)
                .AddIngredient(ItemID.BossBagBetsy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2BetsyBow)
                .AddIngredient(ItemID.BossBagBetsy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DD2SquireBetsySword)
                .AddIngredient(ItemID.BossBagBetsy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ApprenticeStaffT3)
                .AddIngredient(ItemID.BossBagBetsy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MonkStaffT3)
                .AddIngredient(ItemID.BossBagBetsy)
                .AddTile(TileID.Solidifier)                .Register();

            // Mourning (Morning) Wood
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SpookyHook)
                .AddIngredient(ItemID.MourningWoodTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SpookyTwig)
                .AddIngredient(ItemID.MourningWoodTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.StakeLauncher)
                .AddIngredient(ItemID.MourningWoodTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CursedSapling)
                .AddIngredient(ItemID.MourningWoodTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NecromanticScroll)
                .AddIngredient(ItemID.MourningWoodTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            // Pumpking
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.TheHorsemansBlade)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BatScepter)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RavenStaff)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CandyCornRifle)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.JackOLanternLauncher)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlackFairyDust)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ScytheWhip)
                .AddIngredient(ItemID.PumpkingTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            // Everscream
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChristmasTreeSword)
                .AddIngredient(ItemID.EverscreamTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChristmasHook)
                .AddIngredient(ItemID.EverscreamTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Razorpine)
                .AddIngredient(ItemID.EverscreamTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FestiveWings)
                .AddIngredient(ItemID.EverscreamTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            // Santa-NK1
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EldMelter)
                .AddIngredient(ItemID.SantaNK1Trophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChainGun)
                .AddIngredient(ItemID.SantaNK1Trophy)
                .AddTile(TileID.Solidifier)                .Register();

            // Ice Queen
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlizzardStaff)
                .AddIngredient(ItemID.IceQueenTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SnowmanCannon)
                .AddIngredient(ItemID.IceQueenTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NorthPole)
                .AddIngredient(ItemID.IceQueenTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BabyGrinchMischiefWhistle)
                .AddIngredient(ItemID.IceQueenTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ReindeerBells)
                .AddIngredient(ItemID.IceQueenTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            // Martian Saucer
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Xenopopper)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.XenoStaff)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserMachinegun)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ElectrosphereLauncher)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.InfluxWaver)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CosmicCarKey)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AntiGravityHook)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChargedBlasterCannon)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)
                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LaserDrill)
                .AddIngredient(ItemID.MartianSaucerTrophy)
                .AddTile(TileID.Solidifier)
                .Register();

            // Flying Dutchman
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LuckyCoin)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiscountCard)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CoinGun)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PirateStaff)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GoldRing)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Cutlass)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PirateMinecart)
                .AddIngredient(ItemID.FlyingDutchmanTrophy)
                .AddTile(TileID.Solidifier)                .Register();
        }

        public static void AddMiscRecipes()
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.EnchantedSword)
                .AddIngredient(ItemID.IceBlade)
                .AddTile(TileID.CrystalBall)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Terragrim)
                .AddIngredient(ItemID.EnchantedSword, 2)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.CrystalBall)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MagicalPumpkinSeed)
                .AddIngredient(ItemID.Pumpkin, 500)
                .AddTile(TileID.LivingLoom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.Seaweed)
                .AddIngredient(ItemID.FishingSeaweed, 5)
                .AddTile(TileID.LivingLoom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.FlowerBoots)
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Daybloom)
                .AddIngredient(ItemID.Blinkroot)
                .AddIngredient(ItemID.Shiverthorn)
                .AddIngredient(ItemID.Moonglow)
                .AddIngredient(ItemID.Waterleaf)
                .AddIngredient(ItemID.Deathweed)
                .AddIngredient(ItemID.Fireblossom)
                .AddTile(TileID.LivingLoom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LivingLoom)
                .AddIngredient(ItemID.Loom)
                .AddIngredient(ItemID.Vine, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.JungleRose)
                .AddIngredient(ItemID.NaturesGift)
                .AddIngredient(ItemID.RedHusk)
                .AddTile(TileID.LivingLoom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AmberMosquito)
                .AddIngredient(ItemID.Amber, 15)
                .AddIngredient(ItemID.Firefly)
                .AddTile(TileID.CookingPots)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NaturesGift)
                .AddIngredient(ItemID.Moonglow, 15)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.AlchemyTable)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SandstorminaBottle)
                .AddIngredient(ItemID.SandBlock, 50)
                .AddIngredient(ItemID.Bottle)
                .AddTile(TileID.AlchemyTable)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ShroomiteBar)
                .AddIngredient(ItemID.ChlorophyteBar)
                .AddIngredient(ItemID.DarkBlueSolution)
                .AddTile(TileID.Autohammer)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WebSlinger)
                .AddIngredient(ItemID.GrapplingHook)
                .AddIngredient(ItemID.WebRopeCoil, 8)
                .AddTile(TileID.CookingPots)                .Register();
        }

        public static void AddFurnitureRecipes()
        {
            // Blue dungeon brick
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueBrickPlatform, 2)
                .AddIngredient(ItemID.BlueBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBathtub)
                .AddIngredient(ItemID.BlueBrick, 14)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBed)
                .AddIngredient(ItemID.BlueBrick, 15)
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonBookcase)
                .AddIngredient(ItemID.BlueBrick, 20)
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonCandelabra)
                .AddIngredient(ItemID.BlueBrick, 5)
                .AddIngredient(ItemID.Torch, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonCandle)
                .AddIngredient(ItemID.BlueBrick, 4)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonChair)
                .AddIngredient(ItemID.BlueBrick, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonChandelier)
                .AddIngredient(ItemID.BlueBrick, 4)
                .AddIngredient(ItemID.Torch, 4)
                .AddIngredient(ItemID.Chain, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockBlue)
                .AddRecipeGroup("IronBar")
                .AddIngredient(ItemID.Glass, 6)
                .AddIngredient(ItemID.BlueBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonDoor)
                .AddIngredient(ItemID.BlueBrick, 6)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonDresser)
                .AddIngredient(ItemID.BlueBrick, 16)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonLamp)
                .AddIngredient(ItemID.Torch)
                .AddIngredient(ItemID.BlueBrick, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonPiano)
                .AddIngredient(ItemID.Bone, 4)
                .AddIngredient(ItemID.BlueBrick, 15)
                .AddIngredient(ItemID.Book)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonSofa)
                .AddIngredient(ItemID.BlueBrick, 5)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonTable)
                .AddIngredient(ItemID.BlueBrick, 8)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonVase)
                .AddIngredient(ItemID.BlueBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueDungeonWorkBench)
                .AddIngredient(ItemID.BlueBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueBrickWall, 4)
                .AddIngredient(ItemID.BlueBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueSlabWall, 4)
                .AddIngredient(ItemID.BlueBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BlueTiledWall, 4)
                .AddIngredient(ItemID.BlueBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            // Green dungeon brick
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenBrickPlatform, 2)
                .AddIngredient(ItemID.GreenBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBathtub)
                .AddIngredient(ItemID.GreenBrick, 14)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBed)
                .AddIngredient(ItemID.GreenBrick, 15)
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonBookcase)
                .AddIngredient(ItemID.GreenBrick, 20)
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonCandelabra)
                .AddIngredient(ItemID.GreenBrick, 5)
                .AddIngredient(ItemID.Torch, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonCandle)
                .AddIngredient(ItemID.GreenBrick, 4)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonChair)
                .AddIngredient(ItemID.GreenBrick, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonChandelier)
                .AddIngredient(ItemID.GreenBrick, 4)
                .AddIngredient(ItemID.Torch, 4)
                .AddIngredient(ItemID.Chain, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockGreen)
                .AddRecipeGroup("IronBar")
                .AddIngredient(ItemID.Glass, 6)
                .AddIngredient(ItemID.GreenBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonDoor)
                .AddIngredient(ItemID.GreenBrick, 6)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonDresser)
                .AddIngredient(ItemID.GreenBrick, 16)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonLamp)
                .AddIngredient(ItemID.Torch)
                .AddIngredient(ItemID.GreenBrick, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonPiano)
                .AddIngredient(ItemID.Bone, 4)
                .AddIngredient(ItemID.GreenBrick, 15)
                .AddIngredient(ItemID.Book)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonSofa)
                .AddIngredient(ItemID.GreenBrick, 5)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonTable)
                .AddIngredient(ItemID.GreenBrick, 8)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonVase)
                .AddIngredient(ItemID.GreenBrick, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenDungeonWorkBench)
                .AddIngredient(ItemID.GreenBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenBrickWall, 4)
                .AddIngredient(ItemID.GreenBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenSlabWall, 4)
                .AddIngredient(ItemID.GreenBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GreenTiledWall, 4)
                .AddIngredient(ItemID.GreenBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            // Pink dungeon brick
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkBrickPlatform, 2)
                .AddIngredient(ItemID.PinkBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBathtub)
                .AddIngredient(ItemID.PinkBrick, 14)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBed)
                .AddIngredient(ItemID.PinkBrick, 15)
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonBookcase)
                .AddIngredient(ItemID.PinkBrick, 20)
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonCandelabra)
                .AddIngredient(ItemID.PinkBrick, 5)
                .AddIngredient(ItemID.Torch, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonCandle)
                .AddIngredient(ItemID.PinkBrick, 4)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonChair)
                .AddIngredient(ItemID.PinkBrick, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonChandelier)
                .AddIngredient(ItemID.PinkBrick, 4)
                .AddIngredient(ItemID.Torch, 4)
                .AddIngredient(ItemID.Chain, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonClockPink)
                .AddRecipeGroup("IronBar")
                .AddIngredient(ItemID.Glass, 6)
                .AddIngredient(ItemID.PinkBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonDoor)
                .AddIngredient(ItemID.PinkBrick, 6)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonDresser)
                .AddIngredient(ItemID.PinkBrick, 16)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonLamp)
                .AddIngredient(ItemID.Torch)
                .AddIngredient(ItemID.PinkBrick, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonPiano)
                .AddIngredient(ItemID.Bone, 4)
                .AddIngredient(ItemID.PinkBrick, 15)
                .AddIngredient(ItemID.Book)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonSofa)
                .AddIngredient(ItemID.PinkBrick, 5)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonTable)
                .AddIngredient(ItemID.PinkBrick, 8)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonVase)
                .AddIngredient(ItemID.PinkBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkDungeonWorkBench)
                .AddIngredient(ItemID.PinkBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkBrickWall, 4)
                .AddIngredient(ItemID.PinkBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkSlabWall, 4)
                .AddIngredient(ItemID.PinkBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.PinkTiledWall, 4)
                .AddIngredient(ItemID.PinkBrick)
                .AddTile(TileID.WorkBenches)                .Register();

            // Obsidian
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBathtub)
                .AddIngredient(ItemID.ObsidianBrick, 14)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBed)
                .AddIngredient(ItemID.ObsidianBrick, 15)
                .AddIngredient(ItemID.Silk, 5)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianBookcase)
                .AddIngredient(ItemID.ObsidianBrick, 20)
                .AddIngredient(ItemID.Book, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianCandelabra)
                .AddIngredient(ItemID.ObsidianBrick, 5)
                .AddIngredient(ItemID.Torch, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianCandle)
                .AddIngredient(ItemID.ObsidianBrick, 4)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianChair)
                .AddIngredient(ItemID.ObsidianBrick, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianChandelier)
                .AddIngredient(ItemID.ObsidianBrick, 4)
                .AddIngredient(ItemID.Torch, 4)
                .AddIngredient(ItemID.Chain, 4)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianClock)
                .AddRecipeGroup("IronBar")
                .AddIngredient(ItemID.Glass, 6)
                .AddIngredient(ItemID.ObsidianBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianDoor)
                .AddIngredient(ItemID.ObsidianBrick, 6)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianDresser)
                .AddIngredient(ItemID.ObsidianBrick, 16)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianLamp)
                .AddIngredient(ItemID.Torch)
                .AddIngredient(ItemID.ObsidianBrick, 3)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianPiano)
                .AddIngredient(ItemID.Bone, 4)
                .AddIngredient(ItemID.ObsidianBrick, 15)
                .AddIngredient(ItemID.Book)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianSofa)
                .AddIngredient(ItemID.ObsidianBrick, 5)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianTable)
                .AddIngredient(ItemID.ObsidianBrick, 8)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianVase)
                .AddIngredient(ItemID.ObsidianBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianWorkBench)
                .AddIngredient(ItemID.ObsidianBrick, 10)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LihzahrdFurnace)
                .AddIngredient(ItemID.LihzahrdBrick, 25)
                .AddTile(TileID.WorkBenches)                .Register();

            // Lanterns
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ChainLantern)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BrassLantern)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CagedLantern)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.CarriageLantern)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AlchemyLantern)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiablostLamp)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.OilRagSconse)
                .AddRecipeGroup("IronBar", 6)
                .AddIngredient(ItemID.Bone, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianLantern)
                .AddIngredient(ItemID.Obsidian, 6)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)
                .Register();

            // Platforms
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DungeonShelf, 5)
                .AddIngredient(ItemID.WoodPlatform, 5)
                .AddIngredient(ItemID.Bone)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WoodShelf, 5)
                .AddIngredient(ItemID.WoodPlatform, 5)
                .AddIngredient(ItemID.Bone)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MetalShelf, 5)
                .AddIngredient(ItemID.WoodPlatform, 5)
                .AddIngredient(ItemID.Bone)
                .AddTile(TileID.WorkBenches)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.BrassShelf, 5)
                .AddIngredient(ItemID.WoodPlatform, 5)
                .AddIngredient(ItemID.Bone)
                .AddTile(TileID.WorkBenches)                .Register();

            // Dungeon banners
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MarchingBonesBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.NecromanticSign)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RustedCompanyStandard)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.RaggedBrotherhoodSigil)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.MoltenLegionFlag)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.DiabolicSigil)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)                .Register();

            // Sky island banners
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.WorldBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SunplateBlock, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SunBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SunplateBlock, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.GravityBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SunplateBlock, 10)
                .AddTile(TileID.Loom)                .Register();

            // Underworld banners
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HellboundBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HellHammerBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.HelltowerBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LostHopesofManBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.ObsidianWatcherBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.LavaEruptsBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.Obsidian, 10)
                .AddTile(TileID.Loom)                .Register();

            // Pyramid banners
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.AnkhBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SandstoneBrick, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.SnakeBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SandstoneBrick, 10)
                .AddTile(TileID.Loom)                .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(ItemID.OmegaBanner)
                .AddIngredient(ItemID.Silk, 3)
                .AddIngredient(ItemID.SandstoneBrick, 10)
                .AddTile(TileID.Loom)                .Register();
        }

        public static void AddConvertRecipe(int item, int item2)
        {
            ModContent.GetInstance<Fargowiltas>().CreateRecipe(item2)
               .AddIngredient(item)
               .AddTile(TileID.DemonAltar)               .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(item)
               .AddIngredient(item2)
               .AddTile(TileID.DemonAltar)               .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(item2)
               .AddIngredient(item)
               .AddTile(TileID.AlchemyTable)               .Register();

            ModContent.GetInstance<Fargowiltas>().CreateRecipe(item)
               .AddIngredient(item2)
               .AddTile(TileID.AlchemyTable)               .Register();
        }

        public static void AddVanillaRecipeChanges()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ItemID.BeetleHusk))
                {
                    if (recipe.TryGetIngredient(ItemID.TurtleHelmet, out Item turtleHelmet))
                    {
                        recipe.RemoveIngredient(turtleHelmet);
                    }

                    if (recipe.TryGetIngredient(ItemID.TurtleScaleMail, out Item turtleScalemail))
                    {
                        recipe.RemoveIngredient(turtleScalemail);
                    }

                    if (recipe.TryGetIngredient(ItemID.TurtleLeggings, out Item turtleLeggings))
                    {
                        recipe.RemoveIngredient(turtleLeggings);
                    }
                }
            }
        }
    }
}