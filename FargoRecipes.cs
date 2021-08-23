using System.Linq;
//using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.Items.Summons.VanillaCopy;

namespace Fargowiltas
{
    internal class FargoRecipes
    {
        private Mod mod;

        public FargoRecipes(Mod mod)
        {
            this.mod = mod;
        }

        public static void AddRecipeGroups()
        {
            // Evil Wood
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Wood", new int[] { ItemID.Ebonwood, ItemID.Shadewood });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            //iron anvil
            group = new RecipeGroup(() => "Any Demon Altar", new int[] { ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>() });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDemonAltar", group);

            //iron anvil
            group = new RecipeGroup(() => "Any Iron Anvil", new int[] { ItemID.IronAnvil, ItemID.LeadAnvil});
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //anvil HM
            group = new RecipeGroup(() => "Any Mythril Anvil", ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            //forge HM
            group = new RecipeGroup(() => "Any Adamantite Forge", ItemID.AdamantiteForge, ItemID.TitaniumForge);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //book cases
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


            // Bone Banners
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
                ItemID.ManEaterBanner
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

            //group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Caught Town NPC", CaughtNPCItem.CaughtTownies.Keys.ToArray());
            //RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Omnistation", ModContent.ItemType<Omnistation>(), ModContent.ItemType<Omnistation2>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOmnistation", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cooking Pot", ItemID.CookingPot, ItemID.Cauldron);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCookingPot", group);
        }

        public void AddRecipes()
        {
            if (ModContent.GetInstance<FargoConfig>().SummonConversion)
            {
                AddSummonConversions();
            }
            
            if (ModContent.GetInstance<FargoConfig>().EvilConversion)
            {
                AddEvilConversions();
            }
            
            if (ModContent.GetInstance<FargoConfig>().MetalConversion)
            {
                AddMetalConversions();
            }
            
            if (ModContent.GetInstance<FargoConfig>().BannerRecipes)
            {
                AddBannerToItemRecipes();
            }
            
            if (ModContent.GetInstance<FargoConfig>().StatueRecipes)
            {
                AddStatueRecipes();
            }
            
            if (ModContent.GetInstance<FargoConfig>().CrateRecipes)
            {
                AddContainerLootRecipes();
            }
            
            //AddNPCRecipes();
            //AddTreasureBagRecipes();
            //AddFurnitureRecipes();
            //AddMiscRecipes();
            //AddVanillaRecipeChanges();
        }

        private void AddSummonConversions()
        {
            void AddSummonConversion(int ingredient, int result)
            {
                mod.CreateRecipe(result)
                .AddIngredient(ingredient)
                .AddTile(TileID.WorkBenches)
                .Register();
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

        private void AddEvilConversions()
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

        private void AddMetalConversions()
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

        private void AddBannerToItemRecipes()
        {
            void AddBannerToItemRecipe(int banner, int result, int bannerAmount = 1, int resultAmount = 1, int item2type = -1, int item2amount = 1, int tile = TileID.Solidifier)
            {
                var recipe = mod.CreateRecipe(result, resultAmount);

                recipe.AddIngredient(banner, bannerAmount);
                if (item2type > -1)
                    recipe.AddIngredient(item2type, item2amount);
                recipe.AddTile(tile);
                recipe.Register();
            }

            void AddBannerToItemsRecipe(int banner, int[] results, int bannerAmount = 1, int tile = TileID.Solidifier)
            {
                foreach (int result in results)
                {
                    var recipe = mod.CreateRecipe(result);
                    recipe.AddIngredient(banner, bannerAmount);
                    recipe.AddTile(tile);
                    recipe.Register();
                }
            }

            void AddGroupToItemRecipe(string group, int result, int station = TileID.Solidifier, int resultAmount = 1, int groupAmount = 1)
            {
                var recipe = mod.CreateRecipe(result, resultAmount);
                recipe.AddRecipeGroup(group, groupAmount);
                recipe.AddTile(station);
                recipe.Register();
            }

            AddBannerToItemRecipe(ItemID.MeteorHeadBanner, ItemID.Meteorite, 1, 25);
            AddBannerToItemRecipe(ItemID.AnglerFishBanner, ItemID.AdhesiveBandage, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.AdhesiveBandage, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.TallyCounter);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.Bone, 1, 100);
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.Bone, 1, 100);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Bone, 1, 100);
            AddBannerToItemRecipe(ItemID.AngryNimbusBanner, ItemID.NimbusRod, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.AngryTrapperBanner, ItemID.Uzi, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.ArmoredVikingBanner, ItemID.IceSickle, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.BatBanner, ItemID.ChainKnife);
            AddBannerToItemRecipe(ItemID.BlackRecluseBanner, ItemID.PoisonStaff, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.SharkToothNecklace);
            AddBannerToItemRecipe(ItemID.BloodZombieBanner, ItemID.KOCannon, 4, 1, ItemID.SoulofNight);
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.BunnyHood);
            AddBannerToItemRecipe(ItemID.ButcherBanner, ItemID.ButchersChainsaw, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.CorruptorBanner, ItemID.Vitamins, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.CorruptSlimeBanner, ItemID.Blindfold, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.CreatureFromTheDeepBanner, ItemID.NeptunesShell, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.CursedSkullBanner, ItemID.Nazar);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.DarkShard, 1, 5);
            AddBannerToItemRecipe(ItemID.LightMummyBanner, ItemID.LightShard, 1, 5);
            AddBannerToItemRecipe(ItemID.DarkMummyBanner, ItemID.Blindfold, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.DeadlySphereBanner, ItemID.DeadlySphereStaff, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.DemonBanner, ItemID.DemonScythe);
            AddBannerToItemRecipe(ItemID.DemonEyeBanner, ItemID.BlackLens);
            AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, ItemID.AncientHorn, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.DiablolistBanner, ItemID.InfernoFork, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.DripplerBanner, ItemID.MoneyTrough);
            AddBannerToItemRecipe(ItemID.DrManFlyBanner, ItemID.ToxicFlask, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.EyezorBanner, ItemID.EyeSpring, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.FireImpBanner, ItemID.ObsidianRose);
            AddBannerToItemRecipe(ItemID.GastropodBanner, ItemID.BlessedApple, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.TrifoldMap, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.GiantBatBanner, ItemID.ChainKnife, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.GoblinArcherBanner, ItemID.Harpoon);
            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemID.NightVisionHelmet);
            AddBannerToItemRecipe(ItemID.HarpyBanner, ItemID.GiantHarpyFeather, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.HellbatBanner, ItemID.MagmaStone);
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.TatteredBeeWing, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.IceBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.IceTortoiseBanner, ItemID.FrozenTurtleShell, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.IcyMermanBanner, ItemID.FrostStaff, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.JungleBatBanner, ItemID.DepthMeter);
            AddBannerToItemRecipe(ItemID.JungleCreeperBanner, ItemID.Yelets, item2type: ItemID.HallowedBar);
            AddBannerToItemRecipe(ItemID.LavaBatBanner, ItemID.HelFire, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.LavaSlimeBanner, ItemID.Cascade, item2type: ItemID.Bone);
            AddBannerToItemRecipe(ItemID.LihzahrdBanner, ItemID.LizardEgg, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.MartianScutlixGunnerBanner, ItemID.BrainScrambler, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.MothronBanner, ItemID.MothronWings, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.NailheadBanner, ItemID.NailGun, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.NecromancerBanner, ItemID.ShadowbeamStaff, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.PinkJellyfishBanner, ItemID.JellyfishNecklace);
            AddBannerToItemRecipe(ItemID.PiranhaBanner, ItemID.RobotHat);
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.Megaphone, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.PsychoBanner, ItemID.PsychoKnife, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.RaggedCasterBanner, ItemID.SpectreStaff, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainHat);
            AddBannerToItemRecipe(ItemID.RaincoatZombieBanner, ItemID.RainCoat);
            AddBannerToItemRecipe(ItemID.ReaperBanner, ItemID.DeathSickle, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Rally);
            AddBannerToItemRecipe(ItemID.ScutlixBanner, ItemID.BrainScrambler);
            AddBannerToItemRecipe(ItemID.SharkBanner, ItemID.DivingHelmet);
            AddBannerToItemRecipe(ItemID.SkeletonBanner, ItemID.BoneSword);
            AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, ItemID.RocketLauncher, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemID.BoneWand);
            AddBannerToItemRecipe(ItemID.SnowFlinxBanner, ItemID.SnowballLauncher);
            AddBannerToItemRecipe(ItemID.TortoiseBanner, ItemID.TurtleShell, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.Bezoar);
            AddBannerToItemRecipe(ItemID.ToxicSludgeBanner, ItemID.Bezoar);
            AddBannerToItemRecipe(ItemID.UmbrellaSlimeBanner, ItemID.UmbrellaHat);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.BonePickaxe);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningShirt);
            AddBannerToItemRecipe(ItemID.UndeadMinerBanner, ItemID.MiningPants);
            AddBannerToItemRecipe(ItemID.UndeadVikingBanner, ItemID.VikingHelmet);
            AddBannerToItemRecipe(ItemID.UnicornBanner, ItemID.UnicornonaStick, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, ItemID.AntlionClaw);
            AddBannerToItemRecipe(ItemID.WerewolfBanner, ItemID.MoonCharm, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.WolfBanner, ItemID.Amarok, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.WormBanner, ItemID.WhoopieCushion);
            AddBannerToItemRecipe(ItemID.WraithBanner, ItemID.FastClock, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemID.CoinGun, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.ChaosElementalBanner, ItemID.RodofDiscord, 4, tile: TileID.MythrilAnvil);
            AddBannerToItemRecipe(ItemID.SalamanderBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.CrawdadBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.GiantShellyBanner, ItemID.Compass);
            AddBannerToItemRecipe(ItemID.EnchantedSwordBanner, ItemID.Smolstar);
            AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance);
            //critters
            AddBannerToItemRecipe(ItemID.BirdBanner, ItemID.Bird, 1, 100);
            AddBannerToItemRecipe(ItemID.BirdBanner, ItemID.BlueJay, 1, 100);
            AddBannerToItemRecipe(ItemID.BirdBanner, ItemID.Cardinal, 1, 100);
            AddBannerToItemRecipe(ItemID.BunnyBanner, ItemID.Bunny, 1, 100);
            //gem bunnies
            AddBannerToItemRecipe(ItemID.PenguinBanner, ItemID.Penguin, 1, 100);
            AddBannerToItemRecipe(ItemID.GoldfishBanner, ItemID.Goldfish, 1, 100);



            AddBannerToItemsRecipe(ItemID.MimicBanner, new int[] { ItemID.DualHook, ItemID.MagicDagger, ItemID.TitanGlove, ItemID.PhilosophersStone, ItemID.CrossNecklace, ItemID.StarCloak, ItemID.Frostbrand, ItemID.IceBow, ItemID.FlowerofFrost, ItemID.ToySled }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.ArmoredSkeletonBanner, new int[] { ItemID.ArmorPolish, ItemID.BeamSword, ItemID.BoneSword, ItemID.AncientGoldHelmet, ItemID.AncientIronHelmet }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.BoneLeeBanner, new int[] { ItemID.BlackBelt, ItemID.Tabi }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.DesertDjinnBanner, new int[] { ItemID.DjinnLamp, ItemID.DjinnsCurse }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.DesertLamiaBanner, new int[] { ItemID.LamiaHat, ItemID.LamiaShirt, ItemID.LamiaPants, ItemID.MoonMask, ItemID.SunMask }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.FloatyGrossBanner, new int[] { ItemID.Vitamins, ItemID.MeatGrinder }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.MedusaBanner, new int[] { ItemID.MedusaHead, ItemID.PocketMirror }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.MummyBanner, new int[] { ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.PaladinBanner, new int[] { ItemID.PaladinsHammer, ItemID.PaladinsShield }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.PenguinBanner, new int[] { ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants });
            AddBannerToItemsRecipe(ItemID.PirateBanner, new int[] { ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.RedDevilBanner, new int[] { ItemID.UnholyTrident, ItemID.FireFeather }, tile: TileID.MythrilAnvil);
			AddBannerToItemsRecipe(ItemID.SkeletonArcherBanner, new int[] { ItemID.MagicQuiver, ItemID.Marrow}, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.SkeletonSniperBanner, new int[] { ItemID.RifleScope, ItemID.SniperRifle }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.TacticalSkeletonBanner, new int[] { ItemID.TacticalShotgun, ItemID.SWATHelmet }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.VampireBanner, new int[] { ItemID.BrokenBatWing, ItemID.MoonStone }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.ZombieBanner, new int[] { ItemID.ZombieArm, ItemID.Shackle });
            AddBannerToItemsRecipe(ItemID.ZombieElfBanner, new int[] { ItemID.ElfHat, ItemID.ElfShirt, ItemID.ElfPants }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.ZombieEskimoBanner, new int[] { ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants });
            //ancient armors
            AddBannerToItemsRecipe(ItemID.EaterofSoulsBanner, new int[] { ItemID.AncientShadowHelmet, ItemID.AncientShadowScalemail, ItemID.AncientShadowGreaves }, 2);
            AddBannerToItemsRecipe(ItemID.HornetBanner, new int[] { ItemID.AncientCobaltHelmet, ItemID.AncientCobaltBreastplate, ItemID.AncientCobaltLeggings }, 2);
            AddBannerToItemsRecipe(ItemID.SkeletonBanner, new int[] { ItemID.AncientIronHelmet, ItemID.AncientGoldHelmet }, 2);
            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemID.AncientNecroHelmet, 2);
            //gladiator
            AddBannerToItemsRecipe(ItemID.GreekSkeletonBanner, new int[] { ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings, ItemID.Gladius });
            
            //boss trophy recipes
            AddBannerToItemRecipe(ItemID.KingSlimeTrophy, ItemID.SlimeStaff);
            AddBannerToItemRecipe(ItemID.EyeofCthulhuTrophy, ItemID.Binoculars);
            AddBannerToItemRecipe(ItemID.EaterofWorldsTrophy, ItemID.EatersBone);
            AddBannerToItemRecipe(ItemID.BrainofCthulhuTrophy, ItemID.BoneRattle);
            AddBannerToItemRecipe(ItemID.QueenBeeTrophy, ItemID.HoneyedGoggles);
            AddBannerToItemRecipe(ItemID.QueenBeeTrophy, ItemID.Nectar);
            AddBannerToItemRecipe(ItemID.SkeletronTrophy, ItemID.BookofSkulls);
            AddBannerToItemRecipe(ItemID.PlanteraTrophy, ItemID.TheAxe);
            AddBannerToItemRecipe(ItemID.PlanteraTrophy, ItemID.Seedling);
            AddBannerToItemRecipe(ItemID.DukeFishronTrophy, ItemID.FishronWings);
            //empress of light trophy = stellar tune or empress wings
            //dutchamn trophy = the dutchman cart

            //pirates
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.Cutlass, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.GoldRing, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.PirateStaff, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.DiscountCard, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyPirateBanner", ItemID.LuckyCoin, TileID.MythrilAnvil);

            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Keybrand, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.Kraken, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.MagnetSphere, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.WispinaBottle, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.BoneFeather, TileID.MythrilAnvil);
            AddGroupToItemRecipe("Fargowiltas:AnyArmoredBones", ItemID.MaceWhip, TileID.MythrilAnvil);

            AddGroupToItemRecipe("Fargowiltas:AnySlimes", ItemID.Gel, resultAmount: 200);

            AddGroupToItemRecipe("Fargowiltas:AnyHallows", ItemID.HallowedKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCorrupts", ItemID.CorruptionKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyCrimsons", ItemID.CrimsonKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnyJungles", ItemID.JungleKey, TileID.MythrilAnvil, 1, 10);
            AddGroupToItemRecipe("Fargowiltas:AnySnows", ItemID.FrozenKey, TileID.MythrilAnvil, 1, 10);
            //desert key

            AddGroupToItemRecipe("Fargowiltas:AnyCorrupts", ItemID.MeatGrinder, TileID.MythrilAnvil, 1, 5);
            AddGroupToItemRecipe("Fargowiltas:AnyCrimsons", ItemID.MeatGrinder, TileID.MythrilAnvil, 1, 5);


            //FOOD
            //chaos ele, illum slime, illum bat = apple pie
            //antlion, antlion swarmer, antlion charger = banana split
            //skeleton commando, skeleton sniper, tactical skeleton = ribs give 2
            //eater of souls and crimera = burger
            //harpies = chicken nugget
            //gastropod = chocolate chip cookie
            //cursed skull and giant cursed skull = cream soda
            //wall creeper, black recluse, sand poacher = fried egg
            //flying fish = fries
            //giant flying fox and derpling = grapes
            //pigron = 2 bacon
            //icy merman, ice tortoise = milkshake
            //medusa and hoplites = pizza
            //granite golem and elemental = spaghetti
            //undead miner = 5 steaks
            //the possessed = 1 steak
            //bone lee = 5 coffee
            //man eater, snatcher, angry trapper = 1 coffee
            //bone serpent and red devil = hotdog
            //ice slime, ice bat, spiked ice slime = ice cream
            //sand sharks and angry tumblers = nachos
            //sharks and crabs = shrimp po boy
            //salamanders, crawdad, giant shelly = potato chip
            //skeletons = carton of milk

            //dreadnaut banner = blood moon monolith
            //flying fish = rain song
            //super star shooter crafted from star cannon?
            //zombie merman/wandering eye = vampire frog staff, chum caster, blood rain bow
            //enchanted sword banner = blade staff
            //rock golem = rock golem head
            //pigron = pigron minecart, pigron kite
            //corrupt bunny = corrupt bunny kite
            //crimson bunny = crimson bunny kite
            //man eater = man eater kite
            //blu jelly = blue jelly kite
            //pink jelly = pink jelly kite
            //shark = shark kite
            //bone serpent = bone serpent kite
            //wandering eye = wandering eye kite
            //unicorn = unicorn kite
            //world feeder = world feeder kite
            //sand shark bannr = sand shark kite
            //wyvern = wyvern kite
            //angry trapper = angry trapper kite
            //bunny banner = bunny kite
            //gold fish = goldfish kite
            //red slime = red kite
            //blue slime = blue kite
            //yellow slime = yellow kite
            //they craft together to make the others

            // Thorium
            //if (Fargowiltas.ModLoaded["ThoriumMod"])
            //{
            //    Mod thorium = ModLoader.GetMod("ThoriumMod");

            //    AddBannerToItemRecipe(thorium.ItemType("AncientChargerBanner"), thorium.ItemType("OlympicTorch"));
            //    AddBannerToItemRecipe(thorium.ItemType("AncientPhalanxBanner"), thorium.ItemType("AncientAegis"));
            //    AddBannerToItemRecipe(thorium.ItemType("ArmyAntBanner"), thorium.ItemType("HiveMind"));
            //    AddBannerToItemRecipe(thorium.ItemType("AstroBeetleBanner"), thorium.ItemType("AstroBeetleHusk"));
            //    AddBannerToItemRecipe(thorium.ItemType("BlisterPodBanner"), thorium.ItemType("BlisterSack"));
            //    AddBannerToItemRecipe(thorium.ItemType("BlizzardBatBanner"), thorium.ItemType("IceFairyStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("BoneFlayerBanner"), thorium.ItemType("BoneFlayerTail"));
            //    AddBannerToItemRecipe(thorium.ItemType("ChilledSpitterBanner"), thorium.ItemType("FrostPlagueStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("CoinBagBanner"), thorium.ItemType("AncientDrachma"));
            //    AddBannerToItemRecipe(thorium.ItemType("ColdlingBanner"), thorium.ItemType("SpineBuster"));
            //    AddBannerToItemRecipe(thorium.ItemType("CoolmeraBanner"), thorium.ItemType("MeatBallStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("CrownBanner"), thorium.ItemType("SpinyShell"));
            //    AddBannerToItemRecipe(thorium.ItemType("FlamekinCasterBanner"), thorium.ItemType("MoltenScale"));
            //    AddBannerToItemRecipe(thorium.ItemType("FrostBurntBanner"), thorium.ItemType("BlizzardsEdge"));
            //    AddBannerToItemRecipe(thorium.ItemType("GigaClamBanner"), thorium.ItemType("NanoClamCane"));
            //    AddBannerToItemRecipe(thorium.ItemType("GnomesBanner"), thorium.ItemType("GnomePick"));
            //    AddBannerToItemRecipe(thorium.ItemType("HammerHeadBanner"), thorium.ItemType("CartlidgedCatcher"));
            //    AddBannerToItemRecipe(thorium.ItemType("InfernalHoundBanner"), thorium.ItemType("MoltenCollar"));
            //    AddBannerToItemRecipe(thorium.ItemType("KrakenBanner"), thorium.ItemType("Leviathan"));
            //    AddBannerToItemRecipe(thorium.ItemType("LycanBanner"), thorium.ItemType("MoonlightStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("MoltenMortarBanner"), thorium.ItemType("MortarStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("NecroPotBanner"), thorium.ItemType("GhostlyGrapple"));
            //    AddBannerToItemRecipe(thorium.ItemType("ScissorStalkerBanner"), thorium.ItemType("StalkersSnippers"));
            //    AddBannerToItemRecipe(thorium.ItemType("ShamblerBanner"), thorium.ItemType("BallnChain"));
            //    AddBannerToItemRecipe(thorium.ItemType("SharptoothBanner"), thorium.ItemType("GoldenScale"), 4);
            //    AddBannerToItemRecipe(thorium.ItemType("SnowSingaBanner"), thorium.ItemType("EskimoBanjo"));
            //    AddBannerToItemRecipe(thorium.ItemType("SnowyOwlBanner"), thorium.ItemType("LostMail"));
            //    AddBannerToItemRecipe(thorium.ItemType("SpectrumiteBanner"), thorium.ItemType("PrismiteStaff"));
            //    AddBannerToItemRecipe(thorium.ItemType("StarvedBanner"), thorium.ItemType("DesecratedHeart"));
            //    AddBannerToItemRecipe(thorium.ItemType("TarantulaBanner"), thorium.ItemType("Arthropod"));
            //    AddBannerToItemRecipe(thorium.ItemType("UFOBanner"), thorium.ItemType("DetachedUFOBlaster"));
            //    AddBannerToItemRecipe(thorium.ItemType("UnderworldPotBanner"), thorium.ItemType("HotPot"));
            //    AddBannerToItemRecipe(thorium.ItemType("VampireSquidBanner"), thorium.ItemType("VampireGland"));
            //    AddBannerToItemRecipe(thorium.ItemType("VileSpitterBanner"), thorium.ItemType("VileSpitter"));
            //    AddBannerToItemRecipe(thorium.ItemType("VoltBanner"), thorium.ItemType("VoltHatchet"));
            //    AddBannerToItemRecipe(thorium.ItemType("WindElementalBanner"), thorium.ItemType("Zapper"));

            //    AddBannerToItemRecipe(ItemID.AngryBonesBanner, thorium.ItemType("GraveGoods"));
            //    AddBannerToItemRecipe(ItemID.BoneLeeBanner, thorium.ItemType("TechniqueShadowClone"));
            //    AddBannerToItemRecipe(ItemID.BoneSerpentBanner, thorium.ItemType("SpineBreaker"));
            //    AddBannerToItemRecipe(ItemID.FlyingSnakeBanner, thorium.ItemType("Spearmint"));
            //    AddBannerToItemRecipe(ItemID.FrankensteinBanner, thorium.ItemType("TeslaDefibrillator"));
            //    AddBannerToItemRecipe(ItemID.MartianOfficerBanner, thorium.ItemType("ShieldDroneBeacon"));
            //    AddBannerToItemRecipe(ItemID.MisterStabbyBanner, thorium.ItemType("BackStabber"));
            //    AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, thorium.ItemType("DeadEyePatch"));
            //    AddBannerToItemRecipe(ItemID.RaggedCasterBanner, thorium.ItemType("GatewayGlass"));
            //    AddBannerToItemRecipe(ItemID.RavagerScorpionBanner, thorium.ItemType("EbonyTail"));
            //    AddBannerToItemRecipe(ItemID.RedDevilBanner, thorium.ItemType("DemonTongue"));
            //    AddBannerToItemRecipe(ItemID.SkeletonCommandoBanner, thorium.ItemType("LaunchJumper"));
            //    AddBannerToItemRecipe(ItemID.SnowBallaBanner, thorium.ItemType("HailBomber"));
            //    AddBannerToItemRecipe(ItemID.SnowmanGangstaBanner, thorium.ItemType("TommyGun"));
            //    AddBannerToItemRecipe(ItemID.SquirrelGold, thorium.ItemType("SinisterAcorn"), 10);
            //    AddBannerToItemRecipe(ItemID.SwampThingBanner, thorium.ItemType("SwampSpike"));
            //    AddBannerToItemRecipe(ItemID.WyvernBanner, thorium.ItemType("CloudyChewToy"));

            //    //AddBannerToItemsRecipe(thorium.ItemType("DarksteelKnightBanner"), new int[] { thorium.ItemType("BrokenDarksteelHelmet"), thorium.ItemType("GrayDPaintingItem") });
            //    AddBannerToItemsRecipe(thorium.ItemType("InvaderBanner"), new int[] { thorium.ItemType("VegaPhaser"), thorium.ItemType("BioPod") });
            //    AddBannerToItemsRecipe(thorium.ItemType("NecroticImbuerBanner"), new int[] { thorium.ItemType("NecroticStaff"), thorium.ItemType("TechniqueBloodLotus") });
            //    AddBannerToItemsRecipe(thorium.ItemType("WargBanner"), new int[] { thorium.ItemType("BattleHorn"), thorium.ItemType("BlackCatEars"), thorium.ItemType("Bagpipe"), thorium.ItemType("BloodCellStaff") });
            //    AddBannerToItemsRecipe(ItemID.MimicBanner, new int[] { thorium.ItemType("LargeCoin"), thorium.ItemType("ProofAvarice") });
            //}

            //// Calamity
            //if (Fargowiltas.ModLoaded["CalamityMod"])
            //{
            //    Mod calamity = ModLoader.GetMod("CalamityMod");

            //    AddBannerToItemRecipe(calamity.ItemType("AngryDogBanner"), calamity.ItemType("Cryophobia"), 2);
            //    AddBannerToItemRecipe(calamity.ItemType("ArmoredDiggerBanner"), calamity.ItemType("LeadWizard"));
            //    AddBannerToItemRecipe(calamity.ItemType("CnidrionBanner"), calamity.ItemType("TheTransformer"), 2);
            //    AddBannerToItemRecipe(calamity.ItemType("CrystalCrawlerBanner"), calamity.ItemType("CrystalBlade"));
            //    AddBannerToItemRecipe(calamity.ItemType("CuttlefishBanner"), calamity.ItemType("InkBomb"));
            //    AddBannerToItemRecipe(calamity.ItemType("EidolonWyrmJuvenileBanner"), calamity.ItemType("HalibutCannon"), 200);
            //    AddBannerToItemRecipe(calamity.ItemType("IceClasperBanner"), calamity.ItemType("FrostBarrier"));
            //    AddBannerToItemRecipe(calamity.ItemType("ImpiousImmolatorBanner"), calamity.ItemType("EnergyStaff"));
            //    AddBannerToItemRecipe(calamity.ItemType("IrradiatedSlimeBanner"), calamity.ItemType("LeadCore"));
            //    AddBannerToItemRecipe(calamity.ItemType("TrasherBanner"), calamity.ItemType("TrashmanTrashcan"));

            //    AddBannerToItemRecipe(ItemID.BoneSerpentBanner, calamity.ItemType("OldLordOathsword"));
            //    AddBannerToItemRecipe(ItemID.ClingerBanner, calamity.ItemType("CursedDagger"));
            //    AddBannerToItemRecipe(ItemID.DemonBanner, calamity.ItemType("BladecrestOathsword"));
            //    AddBannerToItemRecipe(ItemID.DesertBasiliskBanner, calamity.ItemType("EvilSmasher"), 4);
            //    AddBannerToItemRecipe(ItemID.DungeonSpiritBanner, calamity.ItemType("PearlGod"), 4);
            //    AddBannerToItemRecipe(ItemID.FlyingAntlionBanner, calamity.ItemType("MandibleBow"));
            //    AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, calamity.ItemType("PlasmaRod"));
            //    AddBannerToItemRecipe(ItemID.GoblinWarriorBanner, calamity.ItemType("Warblade"));
            //    AddBannerToItemRecipe(ItemID.HarpyBanner, calamity.ItemType("SkyGlaze"), 2);
            //    AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("IchorSpear"));
            //    AddBannerToItemRecipe(ItemID.IchorStickerBanner, calamity.ItemType("SpearofDestiny"), 4);
            //    AddBannerToItemRecipe(ItemID.MimicBanner, calamity.ItemType("TheBee"), 2);
            //    AddBannerToItemRecipe(ItemID.NecromancerBanner, calamity.ItemType("WrathoftheAncients"));
            //    AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("Arbalest"), 4);
            //    AddBannerToItemRecipe(ItemID.PirateCrossbowerBanner, calamity.ItemType("RaidersGlory"));
            //    AddBannerToItemRecipe(ItemID.PirateDeadeyeBanner, calamity.ItemType("ProporsePistol"));
            //    AddBannerToItemRecipe(ItemID.PossessedArmorBanner, calamity.ItemType("PsychoticAmulet"), 4);
            //    AddBannerToItemRecipe(ItemID.RuneWizardBanner, calamity.ItemType("EyeofMagnus"));
            //    AddBannerToItemRecipe(ItemID.SandElementalBanner, calamity.ItemType("WifeinaBottlewithBoobs"));
            //    AddBannerToItemRecipe(ItemID.SharkBanner, calamity.ItemType("DepthBlade"));
            //    AddBannerToItemRecipe(ItemID.SkeletonBanner, calamity.ItemType("Waraxe"));
            //    AddBannerToItemRecipe(ItemID.SkeletonMageBanner, calamity.ItemType("AncientShiv"));
            //    AddBannerToItemRecipe(ItemID.TacticalSkeletonBanner, calamity.ItemType("TrueConferenceCall"), 4);
            //    AddBannerToItemRecipe(ItemID.TombCrawlerBanner, calamity.ItemType("BurntSienna"));
            //    AddBannerToItemRecipe(ItemID.TortoiseBanner, calamity.ItemType("FabledTortoiseShell"), 4);
            //    AddBannerToItemRecipe(ItemID.WalkingAntlionBanner, calamity.ItemType("MandibleClaws"));
            //}
        }

        private void AddStatueRecipes()
        {
            void AddStatueRecipe(int statue, int ingredient, int ingredientAmount = 1)
            {
                var recipe = mod.CreateRecipe(statue);

                if (ingredient != -1)
                {
                    recipe.AddIngredient(ingredient, ingredientAmount);
                }
                
                recipe.AddIngredient(ItemID.StoneBlock, 50);
                recipe.AddTile(TileID.HeavyWorkBench);
                recipe.Register();
            }

            //functional
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

            //non functional
            AddStatueRecipe(ItemID.ShieldStatue, -1);
            AddStatueRecipe(ItemID.AnvilStatue,-1);
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

            ////lihzahrd
            //recipe = GetNewRecipe();
            //recipe.AddIngredient(ItemID.LihzahrdBanner);
            //recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            //recipe.AddTile(TileID.HeavyWorkBench);
            //recipe.SetResult(ItemID.LihzahrdGuardianStatue);
            //recipe.AddRecipe();

            //recipe = GetNewRecipe();
            //recipe.AddIngredient(ItemID.LihzahrdBanner);
            //recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            //recipe.AddTile(TileID.HeavyWorkBench);
            //recipe.SetResult(ItemID.LihzahrdStatue);
            //recipe.AddRecipe();

            //recipe = GetNewRecipe();
            //recipe.AddIngredient(ItemID.LihzahrdBanner);
            //recipe.AddIngredient(ItemID.LihzahrdBrick, 50);
            //recipe.AddTile(TileID.HeavyWorkBench);
            //recipe.SetResult(ItemID.LihzahrdWatcherStatue);
            //recipe.AddRecipe();

            //recipe = GetNewRecipe();
            //recipe.AddIngredient(ItemID.Throne);
            //recipe.AddIngredient(ItemID.TeleportationPotion);
            //recipe.AddIngredient(ItemID.StoneBlock, 50);
            //recipe.AddTile(TileID.HeavyWorkBench);
            //recipe.SetResult(ItemID.KingStatue);
            //recipe.AddRecipe();

            //recipe = GetNewRecipe();
            //recipe.AddIngredient(ItemID.Throne);
            //recipe.AddIngredient(ItemID.TeleportationPotion);
            //recipe.AddIngredient(ItemID.StoneBlock, 50);
            //recipe.AddTile(TileID.HeavyWorkBench);
            //recipe.SetResult(ItemID.QueenStatue);
            //recipe.AddRecipe();
        }

        private void AddContainerLootRecipes()
        {
            void KeyToItemRecipe(int key, int result)
            {
                var recipe = mod.CreateRecipe(result);
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
            //Desert key


            // Goodie Bag / Present recipes
            void AddGrabBagItemRecipe(int result, int grabBag = ItemID.Present, int grabBagAmount = 10, int item2type = -1, int item2amount = 1)
            {
                var recipe = mod.CreateRecipe(result);
                recipe.AddIngredient(grabBag, grabBagAmount);
                if (item2type > -1)
                    recipe.AddIngredient(item2type, item2amount);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            AddGrabBagItemRecipe(ItemID.DogWhistle);
            AddGrabBagItemRecipe(ItemID.Toolbox);
            AddGrabBagItemRecipe(ItemID.HandWarmer);
            AddGrabBagItemRecipe(ItemID.RedRyder);
            AddGrabBagItemRecipe(ItemID.CandyCaneSword);
            AddGrabBagItemRecipe(ItemID.CandyCaneHook);
            AddGrabBagItemRecipe(ItemID.FruitcakeChakram);
            AddGrabBagItemRecipe(ItemID.CnadyCanePickaxe);
            AddGrabBagItemRecipe(ItemID.UnluckyYarn, ItemID.GoodieBag);
            AddGrabBagItemRecipe(ItemID.BatHook, ItemID.GoodieBag, 25);

            //herb bags
            void AddHerbBagRecipe(int result)
            {
                var recipe = mod.CreateRecipe(result, 5);
                recipe.AddIngredient(ItemID.HerbBag);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            AddHerbBagRecipe(ItemID.Daybloom);
            AddHerbBagRecipe(ItemID.Moonglow);
            AddHerbBagRecipe(ItemID.Blinkroot);
            AddHerbBagRecipe(ItemID.Waterleaf);
            AddHerbBagRecipe(ItemID.Deathweed);
            AddHerbBagRecipe(ItemID.Fireblossom);
            AddHerbBagRecipe(ItemID.Shiverthorn);
            AddHerbBagRecipe(ItemID.Daybloom);

            void AddCrateRecipe(int result, int crate, int crateAmount, int hardCrate, int hardCrateAmount = 1, int extraItem = -1)
            {
                var recipe = mod.CreateRecipe(result);

                if (crate != -1)
                {
                    recipe.AddIngredient(crate, crateAmount);
                    if (extraItem != -1)
                    {
                        recipe.AddIngredient(extraItem);
                    }
                    recipe.AddTile(TileID.WorkBenches);
                    recipe.Register();
                }
                
                recipe = mod.CreateRecipe(result);
                recipe.AddIngredient(hardCrate, hardCrateAmount);
                if (extraItem != -1)
                {
                    recipe.AddIngredient(extraItem);
                }
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
            }

            //wooden
            AddCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Umbrella, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Spear, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.BabyBirdStaff, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.SunflowerMinecart, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.LadybugMinecart, ItemID.WoodenCrate, 1, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Anchor, -1, 0, ItemID.WoodenCrateHard);

            //iron
            AddCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, 1, ItemID.IronCrateHard);
            AddCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, 1, ItemID.IronCrateHard);
            AddCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, 1, ItemID.IronCrateHard);

            //gold
            AddCrateRecipe(ItemID.HardySaddle, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.Sundial, ItemID.GoldenCrate, 5, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, 5, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.FlareGun, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.CloudinaBottle, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.Mace, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.LuckyHorseshoe, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);

            //jungle
            AddCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.BeeMinecart, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);

            //sky
            AddCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);

            //corrupt
            AddCrateRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, 1, ItemID.CorruptFishingCrateHard);
            AddCrateRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, 1, ItemID.CorruptFishingCrateHard);
            AddCrateRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, 1, ItemID.CorruptFishingCrateHard);
            AddCrateRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, 1, ItemID.CorruptFishingCrateHard);
            AddCrateRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, 1, ItemID.CorruptFishingCrateHard);

            //crimson
            AddCrateRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, 1, ItemID.CrimsonFishingCrateHard);
            AddCrateRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, 1, ItemID.CrimsonFishingCrateHard);
            AddCrateRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, 1, ItemID.CrimsonFishingCrateHard);
            AddCrateRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, 1, ItemID.CrimsonFishingCrateHard);
            AddCrateRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, 1, ItemID.CrimsonFishingCrateHard);

            //dungeon
            AddCrateRecipe(ItemID.WaterBolt, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);

            //frozen crate
            AddCrateRecipe(ItemID.SnowballCannon, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.BlizzardinaBottle, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.IceBlade, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.IceSkates, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.IceMirror, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.FlurryBoots, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.IceBoomerang, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.IceMachine, ItemID.FrozenCrate, 1, ItemID.FrozenCrateHard);
            AddCrateRecipe(ItemID.Fish, ItemID.FrozenCrate, 5, ItemID.FrozenCrateHard);

            //oasis crate
            AddCrateRecipe(ItemID.FlyingCarpet, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.SandstorminaBottle, ItemID.GoldenCrate, 3, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.DesertMinecart, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.EncumberingStone, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);

            //obsidian
            AddCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);

            AddCrateRecipe(ItemID.DarkLance, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.HellwingBow, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.Flamelash, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.Sunfury, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);

            // ocean crate
            AddCrateRecipe(ItemID.Trident, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
        }

        //private static void AddNPCRecipes()
        //{
        //    Fargowiltas mod = ModLoader.GetMod("Fargowiltas") as Fargowiltas;
        //    ModRecipe recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
        //    recipe.AddTile(TileID.MeatGrinder);
        //    recipe.SetResult(ItemID.FleshBlock, 25);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
        //    recipe.AddTile(TileID.DyeVat);
        //    recipe.SetResult(ItemID.DeepRedPaint, 20);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(mod?.GetItem("Truffle"));
        //    recipe.AddTile(TileID.DyeVat);
        //    recipe.SetResult(ItemID.BluePaint, 20);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(mod?.GetItem("Merchant"));
        //    recipe.AddIngredient(ItemID.DynastyWood);
        //    recipe.AddTile(TileID.AlchemyTable);
        //    recipe.SetResult(mod?.GetItem("TravellingMerchant"));
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("Fargowiltas:AnyCaughtNPC");
        //    recipe.AddTile(TileID.DyeVat);
        //    recipe.SetResult(ItemID.GrimDye, 2);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(mod?.GetItem("TravellingMerchant"));
        //    recipe.AddIngredient(ItemID.Bone, 5);
        //    recipe.AddTile(TileID.BoneWelder);
        //    recipe.SetResult(mod?.GetItem("SkeletonMerchant"));
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(mod?.GetItem("SkeletonMerchant"));
        //    recipe.AddTile(TileID.BoneWelder);
        //    recipe.SetResult(ItemID.Bone, 25);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Dryad");
        //    recipe.AddTile(TileID.LivingLoom);
        //    recipe.SetResult(ItemID.LeafWand);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Truffle");
        //    recipe.AddIngredient(ItemID.EnchantedNightcrawler);
        //    recipe.AddTile(TileID.Autohammer);
        //    recipe.SetResult(ItemID.TruffleWorm);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "DyeTrader");
        //    recipe.AddIngredient(ItemID.WoodenSword);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.DyeTradersScimitar);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Tavernkeep");
        //    recipe.AddIngredient(ItemID.Ale, 5);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AleThrowingGlove);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Stylist");
        //    recipe.AddIngredient(ItemID.WoodenSword);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.StylistKilLaKillScissorsIWish);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Painter");
        //    recipe.AddIngredient(ItemID.WoodenBow);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.PainterPaintballGun);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TaxCollector");
        //    recipe.AddIngredient(ItemID.WoodenSword);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.TaxCollectorsStickOfDoom);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Angler");
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.FishermansGuide);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Angler");
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.WeatherRadio);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "Angler");
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Sextant);
        //    recipe.AddRecipe();

        //    //travelling merch recipes 
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Wood, 500);
        //    recipe.AddIngredient(mod?.GetItem("TravellingMerchant"));
        //    recipe.AddTile(TileID.CookingPots);
        //    recipe.SetResult(ItemID.DynastyWood, 500);
        //    recipe.AddRecipe();

        //    //common items - 1 merchant, 2x price
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.IronBar, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Stopwatch);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.IronBar, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.LifeformAnalyzer);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.IronBar, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.DPSMeter);
        //    recipe.AddRecipe();

        //    //uncommon - 1 merchant, 2x price
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.IronBar, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Katana);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.Actuator, 10);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.ActuationAccessory);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.BuilderPotion);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.PortableCementMixer);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.BuilderPotion);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.PaintSprayer);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.BuilderPotion);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.ExtendoGrip);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.BuilderPotion);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.BrickLayer);
        //    recipe.AddRecipe();

        //    //rare - 2 merchant, 2x price
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Code1);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 50);
        //    recipe.AddIngredient(ItemID.Code1);
        //    recipe.AddIngredient(ItemID.HallowedBar, 5); //post mech
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Code2);
        //    recipe.AddRecipe();

        //    //bamboo leaf

        //    //celestial wand

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 4);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Gi);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 7);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.GypsyRobe);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 6);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.MagicHat);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 30);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.AmmoBox);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddIngredient(ItemID.MusketBall, 25); //post evil
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Revolver);
        //    recipe.AddRecipe();

        //    //very rare

        //    //bedazzled nectar

        //    //exotic chew toy

        //    //birdie rattle

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.PlatinumCoin, 10);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.CompanionCube);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.GoldCoin, 70);
        //    recipe.AddIngredient(ItemID.Bone, 10); //post skele
        //    recipe.AddIngredient(ItemID.Duck);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.SittingDucksFishingRod);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.PlatinumCoin, 4);
        //    recipe.AddIngredient(ItemID.Diamond);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.DiamondRing);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.GoldCoin, 30);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.CelestialMagnet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.GoldCoin, 3);
        //    recipe.AddIngredient(ItemID.WaterBucket);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.WaterGun);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.GoldCoin, 90);
        //    recipe.AddIngredient(ItemID.Ectoplasm, 5); //post plant
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.PulseBow);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 3);
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.YellowDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.YellowCounterweight);
        //    recipe.AddRecipe();

        //    //extremely rare
        //    //gray zapinator
        //    //orange zapinator
        //    //sergent united shield

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 4);
        //    recipe.AddIngredient(ItemID.GoldCoin, 70);
        //    recipe.AddIngredient(ItemID.SoulofLight, 2); //hardmode
        //    recipe.AddIngredient(ItemID.SoulofNight, 2);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Gatligator);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 4);
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.BlackDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.BlackCounterweight);
        //    recipe.AddRecipe();

        //    //extraordinarily rare
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "TravellingMerchant", 5);
        //    recipe.AddIngredient(ItemID.GoldCoin, 80);
        //    recipe.AddIngredient(ItemID.GoldBar, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.AngelHalo);
        //    recipe.AddRecipe();

        //    //skeleton merchant recipes
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.BlueDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.BlueCounterweight);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.RedDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.RedCounterweight);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.PurpleDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.PurpleCounterweight);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddIngredient(ItemID.GreenDye);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.GreenCounterweight);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 40);
        //    recipe.AddIngredient(ItemID.SoulofNight, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.Gradient);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant");
        //    recipe.AddIngredient(ItemID.GoldCoin, 40);
        //    recipe.AddIngredient(ItemID.SoulofLight, 5);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.FormatC);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(null, "SkeletonMerchant", 2);
        //    recipe.AddIngredient(ItemID.GoldCoin, 20);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.SetResult(ItemID.MagicLantern);
        //    recipe.AddRecipe();


        //    //engineers combat rench recipe
        //    //engineer plus wrench 
        //}

        //private static void AddTreasureBagRecipes()
        //{
        //    ModRecipe recipe = GetNewRecipe();
        //    //QB
        //    recipe.AddIngredient(ItemID.QueenBeeBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BeesKnees);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.QueenBeeBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BeeGun);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.QueenBeeBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BeeKeeper);
        //    recipe.AddRecipe();

        //    //WOF
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.RangerEmblem);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SorcererEmblem);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SummonerEmblem);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.WarriorEmblem);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ClockworkAssaultRifle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BreakerBlade);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WallOfFleshBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LaserRifle);
        //    recipe.AddRecipe();

        //    //add firecracker here

        //    //plantera
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.GrenadeLauncher);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.PygmyStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.VenusMagnum);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.NettleBurst);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LeafBlower);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Seedler);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.FlowerPow);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PlanteraBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.WaspGun);
        //    recipe.AddRecipe();

        //    //golem
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Stynger);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.PossessedHatchet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SunStone);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.EyeoftheGolem);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Picksaw);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.HeatRay);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.StaffofEarth);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GolemBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.GolemFist);
        //    recipe.AddRecipe();

        //    //duke
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishronBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Flairon);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishronBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Tsunami);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishronBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.RazorbladeTyphoon);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishronBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.TempestStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishronBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BubbleGun);
        //    recipe.AddRecipe();

        //    //empress
        //    //starlight, kalediscope, eventide, nightglow

        //    //moon lord
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Meowmere);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Terrarian);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.StarWrath);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SDMG);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.FireworksLauncher); //CHANGE TO CELEB MK 2
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LastPrism);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LunarFlareBook);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.RainbowCrystalStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MoonLordBossBag);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.MoonlordTurretStaff);
        //    recipe.AddRecipe();

        //    //meowmere minecart here

        //    //dark mage
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyDarkmage);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2PetDragon);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyDarkmage);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2PetGato);
        //    recipe.AddRecipe();

        //    //ogre
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ApprenticeScarf);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SquireShield);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.HuntressBuckler);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.MonkBelt);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2PhoenixBow);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BookStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2SquireDemonSword);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.MonkStaffT1);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.MonkStaffT2);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossTrophyOgre);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2PetGhost);
        //    recipe.AddRecipe();

        //    //besty
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossBagBetsy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BetsyWings);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossBagBetsy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2BetsyBow);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossBagBetsy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DD2SquireBetsySword);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossBagBetsy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ApprenticeStaffT3);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BossBagBetsy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.MonkStaffT3);
        //    recipe.AddRecipe();

        //    //mourning wood
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MourningWoodTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SpookyHook);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MourningWoodTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SpookyTwig);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MourningWoodTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.StakeLauncher);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MourningWoodTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.CursedSapling);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MourningWoodTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.NecromanticScroll);
        //    recipe.AddRecipe();

        //    //pumpking
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.TheHorsemansBlade);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BatScepter);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.RavenStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.CandyCornRifle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.JackOLanternLauncher);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PumpkingTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BlackFairyDust);
        //    recipe.AddRecipe();

        //    //add dark harvest

        //    //everscream
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.EverscreamTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ChristmasTreeSword);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.EverscreamTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ChristmasHook);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.EverscreamTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Razorpine);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.EverscreamTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.FestiveWings);
        //    recipe.AddRecipe();

        //    //santa nk1
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.SantaNK1Trophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.EldMelter);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.SantaNK1Trophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ChainGun);
        //    recipe.AddRecipe();

        //    //ice queen
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceQueenTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BlizzardStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceQueenTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.SnowmanCannon);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceQueenTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.NorthPole);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceQueenTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.BabyGrinchMischiefWhistle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceQueenTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ReindeerBells);
        //    recipe.AddRecipe();

        //    //saucer
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Xenopopper);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.XenoStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LaserMachinegun);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ElectrosphereLauncher);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.InfluxWaver);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.CosmicCarKey);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.AntiGravityHook);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.ChargedBlasterCannon);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.MartianSaucerTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LaserDrill);
        //    recipe.AddRecipe();

        //    //dutchman
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.LuckyCoin);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.DiscountCard);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.CoinGun);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.PirateStaff);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.GoldRing);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FlyingDutchmanTrophy);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.SetResult(ItemID.Cutlass);
        //    recipe.AddRecipe();

        //    //add the dutchman minecart


        //}

        //private static void AddMiscRecipes()
        //{
        //    ModRecipe recipe = GetNewRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IceBlade);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(ItemID.EnchantedSword);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.EnchantedSword, 2);
        //    recipe.AddIngredient(ItemID.SoulofLight, 5);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(ItemID.Arkhalis); //terragrim
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Pumpkin, 500);
        //    recipe.AddTile(TileID.LivingLoom);
        //    recipe.SetResult(ItemID.MagicalPumpkinSeed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.FishingSeaweed, 5);
        //    recipe.AddTile(TileID.LivingLoom);
        //    recipe.SetResult(ItemID.Seaweed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GoodieBag, 2);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.RottenEgg, 25);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.HermesBoots);
        //    recipe.AddIngredient(ItemID.Daybloom);
        //    recipe.AddIngredient(ItemID.Blinkroot);
        //    recipe.AddIngredient(ItemID.Shiverthorn);
        //    recipe.AddIngredient(ItemID.Moonglow);
        //    recipe.AddIngredient(ItemID.Waterleaf);
        //    recipe.AddIngredient(ItemID.Deathweed);
        //    recipe.AddIngredient(ItemID.Fireblossom);
        //    recipe.AddTile(TileID.LivingLoom);
        //    recipe.SetResult(ItemID.FlowerBoots);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Loom);
        //    recipe.AddIngredient(ItemID.Vine, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.LivingLoom);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.NaturesGift);
        //    recipe.AddIngredient(ItemID.RedHusk);
        //    recipe.AddTile(TileID.LivingLoom);
        //    recipe.SetResult(ItemID.JungleRose);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Amber, 15);
        //    recipe.AddIngredient(ItemID.Firefly);
        //    recipe.AddTile(TileID.CookingPots);
        //    recipe.SetResult(ItemID.AmberMosquito);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Moonglow, 15);
        //    recipe.AddIngredient(ItemID.ManaCrystal);
        //    recipe.AddTile(TileID.AlchemyTable);
        //    recipe.SetResult(ItemID.NaturesGift);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.SandBlock, 50);
        //    recipe.AddIngredient(ItemID.Bottle);
        //    recipe.AddTile(TileID.AlchemyTable);
        //    recipe.SetResult(ItemID.SandstorminaBottle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ChlorophyteBar);
        //    recipe.AddIngredient(ItemID.DarkBlueSolution);
        //    recipe.AddTile(TileID.Autohammer);
        //    recipe.SetResult(ItemID.ShroomiteBar);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GrapplingHook);
        //    recipe.AddIngredient(ItemID.WebRopeCoil, 8);
        //    recipe.AddTile(TileID.CookingPots);
        //    recipe.SetResult(ItemID.WebSlinger);
        //    recipe.AddRecipe();

        //}

        //private static void AddFurnitureRecipes()
        //{
        //    //Dungeon furniture pain
        //    ModRecipe recipe = GetNewRecipe();
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueBrickPlatform, 2);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 14);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonBathtub);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 15);
        //    recipe.AddIngredient(ItemID.Silk, 5);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonBed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 20);
        //    recipe.AddIngredient(ItemID.Book, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonBookcase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 5);
        //    recipe.AddIngredient(ItemID.Torch, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonCandelabra);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonCandle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonChair);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch, 4);
        //    recipe.AddIngredient(ItemID.Chain, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonChandelier);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar");
        //    recipe.AddIngredient(ItemID.Glass, 6);
        //    recipe.AddIngredient(ItemID.BlueBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.DungeonClockBlue);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 6);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonDoor);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 16);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonDresser);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddIngredient(ItemID.BlueBrick, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonLamp);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Bone, 4);
        //    recipe.AddIngredient(ItemID.BlueBrick, 15);
        //    recipe.AddIngredient(ItemID.Book);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonPiano);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 5);
        //    recipe.AddIngredient(ItemID.Silk, 2);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonSofa);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 8);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonTable);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonVase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueDungeonWorkBench);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueBrickWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueSlabWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.BlueBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BlueTiledWall, 4);
        //    recipe.AddRecipe();

        //    //green
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenBrickPlatform, 2);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 14);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonBathtub);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 15);
        //    recipe.AddIngredient(ItemID.Silk, 5);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonBed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 20);
        //    recipe.AddIngredient(ItemID.Book, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonBookcase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 5);
        //    recipe.AddIngredient(ItemID.Torch, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonCandelabra);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonCandle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonChair);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch, 4);
        //    recipe.AddIngredient(ItemID.Chain, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonChandelier);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar");
        //    recipe.AddIngredient(ItemID.Glass, 6);
        //    recipe.AddIngredient(ItemID.GreenBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.DungeonClockGreen);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 6);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonDoor);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 16);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonDresser);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddIngredient(ItemID.GreenBrick, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonLamp);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Bone, 4);
        //    recipe.AddIngredient(ItemID.GreenBrick, 15);
        //    recipe.AddIngredient(ItemID.Book);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonPiano);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 5);
        //    recipe.AddIngredient(ItemID.Silk, 2);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonSofa);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 8);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonTable);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonVase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenDungeonWorkBench);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenBrickWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenSlabWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GreenBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.GreenTiledWall, 4);
        //    recipe.AddRecipe();

        //    //pink
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkBrickPlatform, 2);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 14);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonBathtub);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 15);
        //    recipe.AddIngredient(ItemID.Silk, 5);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonBed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 20);
        //    recipe.AddIngredient(ItemID.Book, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonBookcase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 5);
        //    recipe.AddIngredient(ItemID.Torch, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonCandelabra);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonCandle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonChair);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch, 4);
        //    recipe.AddIngredient(ItemID.Chain, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonChandelier);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar");
        //    recipe.AddIngredient(ItemID.Glass, 6);
        //    recipe.AddIngredient(ItemID.PinkBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.DungeonClockPink);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 6);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonDoor);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 16);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonDresser);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddIngredient(ItemID.PinkBrick, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonLamp);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Bone, 4);
        //    recipe.AddIngredient(ItemID.PinkBrick, 15);
        //    recipe.AddIngredient(ItemID.Book);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonPiano);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 5);
        //    recipe.AddIngredient(ItemID.Silk, 2);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonSofa);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 8);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonTable);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonVase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkDungeonWorkBench);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkBrickWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkSlabWall, 4);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.PinkBrick);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.PinkTiledWall, 4);
        //    recipe.AddRecipe();

        //    //obsidian
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 14);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianBathtub);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 15);
        //    recipe.AddIngredient(ItemID.Silk, 5);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianBed);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 20);
        //    recipe.AddIngredient(ItemID.Book, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianBookcase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 5);
        //    recipe.AddIngredient(ItemID.Torch, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianCandelabra);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianCandle);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianChair);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 4);
        //    recipe.AddIngredient(ItemID.Torch, 4);
        //    recipe.AddIngredient(ItemID.Chain, 4);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianChandelier);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar");
        //    recipe.AddIngredient(ItemID.Glass, 6);
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianClock);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 6);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianDoor);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 16);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianDresser);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 3);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianLamp);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Bone, 4);
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 15);
        //    recipe.AddIngredient(ItemID.Book);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianPiano);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 5);
        //    recipe.AddIngredient(ItemID.Silk, 2);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianSofa);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 8);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianTable);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianVase);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.ObsidianBrick, 10);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianWorkBench);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.LihzahrdFurnace);
        //    recipe.AddRecipe();

        //    //lanterns
        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ChainLantern);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BrassLantern);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.CagedLantern);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.CarriageLantern);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.AlchemyLantern);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.DiablostLamp);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddRecipeGroup("IronBar", 6);
        //    recipe.AddIngredient(ItemID.Bone, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.OilRagSconse);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Obsidian, 6);
        //    recipe.AddIngredient(ItemID.Torch);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.ObsidianLantern);
        //    recipe.AddRecipe();

        //    //platforms
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WoodPlatform, 5);
        //    recipe.AddIngredient(ItemID.Bone);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.DungeonShelf, 5);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WoodPlatform, 5);
        //    recipe.AddIngredient(ItemID.Bone);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.WoodShelf, 5);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WoodPlatform, 5);
        //    recipe.AddIngredient(ItemID.Bone);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.MetalShelf, 5);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.WoodPlatform, 5);
        //    recipe.AddIngredient(ItemID.Bone);
        //    recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(ItemID.BrassShelf, 5);
        //    recipe.AddRecipe();

        //    //banners
        //    //dungeon
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.MarchingBonesBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.NecromanticSign);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.RustedCompanyStandard);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.RaggedBrotherhoodSigil);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.MoltenLegionFlag);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Bone, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.DiabolicSigil);
        //    recipe.AddRecipe();

        //    //sky island
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SunplateBlock, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.WorldBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SunplateBlock, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.SunBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SunplateBlock, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.GravityBanner);
        //    recipe.AddRecipe();

        //    //underworld
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.HellboundBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.HellHammerBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.HelltowerBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.LostHopesofManBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.ObsidianWatcherBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.Obsidian, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.LavaEruptsBanner);
        //    recipe.AddRecipe();

        //    //pyramid
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SandstoneBrick, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.AnkhBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SandstoneBrick, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.SnakeBanner);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Silk, 3);
        //    recipe.AddIngredient(ItemID.SandstoneBrick, 10);
        //    recipe.AddTile(TileID.Loom);
        //    recipe.SetResult(ItemID.OmegaBanner);
        //    recipe.AddRecipe();

        //    //ancient armor recipes 
        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.DemoniteBar, 15);
        //    recipe.AddIngredient(ItemID.ShadowScale, 10);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientShadowHelmet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.DemoniteBar, 25);
        //    recipe.AddIngredient(ItemID.ShadowScale, 20);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientShadowScalemail);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.DemoniteBar, 20);
        //    recipe.AddIngredient(ItemID.ShadowScale, 15);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientShadowGreaves);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.IronBar, 15);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientIronHelmet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.GoldBar, 20);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientGoldHelmet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.Bone, 40);
        //    recipe.AddIngredient(ItemID.Cobweb, 40);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientNecroHelmet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.JungleSpores, 8);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientCobaltHelmet);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.JungleSpores, 16);
        //    recipe.AddIngredient(ItemID.Stinger, 10);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientCobaltBreastplate);
        //    recipe.AddRecipe();

        //    recipe = GetNewRecipe();
        //    recipe.AddIngredient(ItemID.JungleSpores, 8);
        //    recipe.AddIngredient(ItemID.Vine, 2);
        //    recipe.AddTile(TileID.DemonAltar);
        //    recipe.SetResult(ItemID.AncientCobaltLeggings);
        //    recipe.AddRecipe();

        //}

        private void AddConvertRecipe(int item, int item2)
        {
            mod.CreateRecipe(item)
               .AddIngredient(item2)
               .AddTile(TileID.DemonAltar)
               .Register();

            mod.CreateRecipe(item2)
               .AddIngredient(item)
               .AddTile(TileID.DemonAltar)
               .Register();
        }

        //private static void AddVanillaRecipeChanges()
        //{
        //    RecipeFinder recipeFinder = new RecipeFinder();
        //    recipeFinder.AddIngredient(ItemID.BeetleHusk);

        //    foreach (Recipe recipe in recipeFinder.SearchRecipes())
        //    {
        //        RecipeEditor editor = new RecipeEditor(recipe);
        //        editor.DeleteIngredient(ItemID.TurtleHelmet);
        //        editor.DeleteIngredient(ItemID.TurtleScaleMail);
        //        editor.DeleteIngredient(ItemID.TurtleLeggings);
        //    }
        //}
    }
}
