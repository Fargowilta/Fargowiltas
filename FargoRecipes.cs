using System.Linq;
using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Summons;
using Fargowiltas.Items.Summons.Mutant;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.Items.Summons.VanillaCopy;
using Fargowiltas.Items.Ammos.Bullets;

namespace Fargowiltas
{
    internal class FargoRecipes
    {
        private Mod mod;

        public FargoRecipes(Mod mod)
        {
            this.mod = mod;
        }

        static string AnyItem(int id) => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemName(id)}";
        static string AnyItem(string fargoLocalizationKey) => $"{Language.GetTextValue("LegacyMisc.37")} {Language.GetTextValue($"Mods.Fargowiltas.RecipeGroups.{fargoLocalizationKey}")}";
        static string AnyBanner(string vanillaKey) => $"{Language.GetTextValue("LegacyMisc.37")} {Language.GetTextValue(vanillaKey)} {Language.GetTextValue("Mods.Fargowiltas.RecipeGroups.Banner")}";

        public static void AddRecipeGroups()
        {
            //Silver or Tungsten Pouch
            RecipeGroup group = new RecipeGroup(() => AnyItem(ModContent.ItemType<SilverPouch>()), ModContent.ItemType<SilverPouch>(), ModContent.ItemType<TungstenPouch>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnySilverPouch", group);

            // Evil Wood
            group = new RecipeGroup(() => AnyItem("EvilWood"),  ItemID.Ebonwood, ItemID.Shadewood );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            //gold bar
            group = new RecipeGroup(() => AnyItem(ItemID.GoldBar), ItemID.GoldBar, ItemID.PlatinumBar );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldBar", group);

            //demon altar
            group = new RecipeGroup(() => AnyItem(ModContent.ItemType<DemonAltar>()), ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>() );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDemonAltar", group);

            //iron anvil
            group = new RecipeGroup(() => AnyItem(ItemID.IronAnvil), ItemID.IronAnvil, ItemID.LeadAnvil);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //anvil HM
            group = new RecipeGroup(() => AnyItem(ItemID.MythrilAnvil), ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            //forge HM
            group = new RecipeGroup(() => AnyItem(ItemID.AdamantiteForge), ItemID.AdamantiteForge, ItemID.TitaniumForge);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //book cases
            group = new RecipeGroup(() => AnyItem(ItemID.Bookcase),
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
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);


            group = new RecipeGroup(() => AnyItem("ArmoredBones"), ItemID.BlueArmoredBonesBanner, ItemID.HellArmoredBonesBanner, ItemID.RustyArmoredBonesBanner);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyArmoredBones", group);

            group = new RecipeGroup(() => AnyItem("PirateBanner"), ItemID.PirateDeadeyeBanner, ItemID.PirateCorsairBanner, ItemID.PirateCrossbowerBanner, ItemID.PirateBanner);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPirateBanner", group);

            // Slimes (excluding ones that don't drop gel)
            group = new RecipeGroup(() => AnyItem(ItemID.SlimeBanner),
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
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnySlimes", group);

            // Any Hallow enemy
            group = new RecipeGroup(() => AnyBanner("RandomWorldName_Adjective.Hallowed"),
                ItemID.PixieBanner,
                ItemID.UnicornBanner,
                ItemID.RainbowSlimeBanner,
                ItemID.GastropodBanner,
                ItemID.LightMummyBanner,
                ItemID.IlluminantBatBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.ChaosElementalBanner,
                ItemID.EnchantedSwordBanner,
                ItemID.BigMimicHallowBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallows", group);

            // Any Corruption enemy
            group = new RecipeGroup(() => AnyBanner("CLI.Corrupt"),
                ItemID.EaterofSoulsBanner,
                ItemID.CorruptorBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.DevourerBanner,
                ItemID.WorldFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CursedHammerBanner,
                ItemID.ClingerBanner,
                ItemID.BigMimicCorruptionBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCorrupts", group);

            // Any Crimson enemy
            group = new RecipeGroup(() => AnyBanner("CLI.Crimson"),
                ItemID.BloodCrawlerBanner,
                ItemID.FaceMonsterBanner,
                ItemID.CrimeraBanner,
                ItemID.HerplingBanner,
                ItemID.CrimslimeBanner,
                ItemID.BloodJellyBanner,
                ItemID.BloodFeederBanner,
                ItemID.BloodMummyBanner,
                ItemID.CrimsonAxeBanner,
                ItemID.IchorStickerBanner,
                ItemID.FloatyGrossBanner,
                ItemID.BigMimicCrimsonBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsons", group);

            // Any Jungle enemy
            group = new RecipeGroup(() => AnyBanner("RandomWorldName_Location.Jungle"),
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
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyJungles", group);

            // Any Snow enemy
            group = new RecipeGroup(() => AnyBanner("RandomWorldName_Noun.Snow"),
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
                ItemID.PigronBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnySnows", group);

            // Any desert enemy
            group = new RecipeGroup(() => AnyBanner("RandomWorldName_Location.Desert"),
                ItemID.VultureBanner,
                ItemID.MummyBanner,
                ItemID.BloodMummyBanner,
                ItemID.DarkMummyBanner,
                ItemID.LightMummyBanner,
                ItemID.FlyingAntlionBanner,
                ItemID.WalkingAntlionBanner,
                ItemID.LarvaeAntlionBanner,
                ItemID.AntlionBanner,
                ItemID.SandSlimeBanner,
                ItemID.TombCrawlerBanner,
                ItemID.DesertBasiliskBanner,
                ItemID.RavagerScorpionBanner,
                ItemID.DesertLamiaBanner,
                ItemID.DesertGhoulBanner,
                ItemID.DesertDjinnBanner,
                ItemID.DuneSplicerBanner,
                ItemID.SandElementalBanner,
                ItemID.SandsharkBanner,
                ItemID.SandsharkCorruptBanner,
                ItemID.SandsharkCrimsonBanner,
                ItemID.SandsharkHallowedBanner,
                ItemID.TumbleweedBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDeserts", group);

            // Any desert enemy
            group = new RecipeGroup(() => AnyBanner("RandomWorldName_Noun.Bats"),
                ItemID.BatBanner,
                ItemID.GiantBatBanner,
                ItemID.GiantFlyingFoxBanner,
                ItemID.IceBatBanner,
                ItemID.IlluminantBatBanner,
                ItemID.JungleBatBanner,
                ItemID.HellbatBanner,
                ItemID.LavaBatBanner,
                ItemID.SporeBatBanner
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBats", group);

            group = new RecipeGroup(() => AnyItem("CaughtNPC"), CaughtNPCItem.CaughtTownies.Values.ToArray());
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);

            group = new RecipeGroup(() => AnyItem(ItemID.CookingPot), ItemID.CookingPot, ItemID.Cauldron);
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCookingPot", group);

            //vanilla butterflies
            group = new RecipeGroup(() => AnyItem("Butterfly"),
                //ItemID.GoldButterfly,
                ItemID.JuliaButterfly,
                ItemID.MonarchButterfly,
                ItemID.PurpleEmperorButterfly,
                ItemID.RedAdmiralButterfly,
                ItemID.SulphurButterfly,
                ItemID.TreeNymphButterfly,
                ItemID.UlyssesButterfly,
                ItemID.ZebraSwallowtailButterfly,
                ItemID.HellButterfly
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyButterfly", group);

            //vanilla squirrels
            group = new RecipeGroup(() => AnyItem(ItemID.Squirrel),
                ItemID.Squirrel,
                ItemID.SquirrelRed
                //ItemID.SquirrelGold,
                //ItemID.GemSquirrelAmber,
                //ItemID.GemSquirrelAmethyst,
                //ItemID.GemSquirrelDiamond,
                //ItemID.GemSquirrelEmerald,
                //ItemID.GemSquirrelRuby,
                //ItemID.GemSquirrelSapphire,
                //ItemID.GemSquirrelTopaz
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnySquirrel", group);

            //vanilla squirrels
            group = new RecipeGroup(() => AnyItem("CommonFish"),
                ItemID.AtlanticCod,
                ItemID.Bass,
                ItemID.Trout,
                ItemID.RedSnapper,
                ItemID.Salmon,
                ItemID.Tuna
                //ItemID.GoldenCarp
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCommonFish", group);

            //vanilla birds
            group = new RecipeGroup(() => AnyItem(ItemID.Bird),
                ItemID.Bird,
                //ItemID.GoldBird,
                ItemID.BlueJay,
                ItemID.Cardinal,
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe,
                ItemID.Seagull
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBird", group);

            //vanilla ducks
            group = new RecipeGroup(() => AnyItem(ItemID.Duck),
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDuck", group);

            //vanilla dragonfly
            group = new RecipeGroup(() => AnyItem("Dragonfly"),
                //ItemID.GoldDragonfly,
                ItemID.BlackDragonfly,
                ItemID.BlueDragonfly,
                ItemID.GreenDragonfly,
                ItemID.OrangeDragonfly,
                ItemID.RedDragonfly,
                ItemID.YellowDragonfly
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDragonfly", group);

            //tombstones
            group = new RecipeGroup(() => AnyItem(ItemID.Tombstone),
                ItemID.Tombstone,
                ItemID.CrossGraveMarker,
                ItemID.Headstone,
                ItemID.GraveMarker,
                ItemID.Gravestone,
                ItemID.Obelisk,
                ItemID.RichGravestone1,
                ItemID.RichGravestone2,
                ItemID.RichGravestone3,
                ItemID.RichGravestone4,
                ItemID.RichGravestone5
            );
            RecipeGroup.RegisterGroup("Fargowiltas:AnyTombstone", group);
        }

        public void AddRecipes()
        {
            AddSummonConversions();
            AddEvilConversions();
            AddMetalConversions();

            if (ModContent.GetInstance<FargoConfig>().BannerRecipes)
            {
                AddBannerToItemRecipes();
            }

            AddStatueRecipes();
            AddContainerLootRecipes();
            AddNPCRecipes();
            AddTreasureBagRecipes();
            //AddFurnitureRecipes();
            AddMiscRecipes();
            AddVanillaRecipes();
        }

        private void AddSummonConversions()
        {
            void AddSummonConversion(int ingredient, int result)
            {
                Recipe.Create(result)
                .AddIngredient(ingredient)
                .AddTile(TileID.WorkBenches)
                .DisableDecraft().Register();
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
            AddSummonConversion(ModContent.ItemType<DeerThing2>(), ItemID.DeerThing);
            AddSummonConversion(ModContent.ItemType<WormyFood>(), ItemID.WormFood);
            AddSummonConversion(ModContent.ItemType<SuspiciousEye>(), ItemID.SuspiciousLookingEye);
            AddSummonConversion(ModContent.ItemType<PrismaticPrimrose>(), ItemID.EmpressButterfly);
            AddSummonConversion(ModContent.ItemType<JellyCrystal>(), ItemID.QueenSlimeCrystal);
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
            AddConvertRecipe(ItemID.BlackCurrant, ItemID.BloodOrange);
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
                var recipe = Recipe.Create(result, resultAmount);

                recipe.AddIngredient(banner, bannerAmount);
                if (item2type > -1)
                    recipe.AddIngredient(item2type, item2amount);
                recipe.AddTile(tile);
                recipe.DisableDecraft(); 
                recipe.Register();
            }

            void AddBannerToItemsRecipe(int banner, int[] results, int bannerAmount = 1, int tile = TileID.Solidifier)
            {
                foreach (int result in results)
                {
                    var recipe = Recipe.Create(result);
                    recipe.AddIngredient(banner, bannerAmount);
                    recipe.AddTile(tile);
                    recipe.DisableDecraft(); 
                    recipe.Register();
                }
            }

            void AddGroupToItemRecipe(string group, int result, int station = TileID.Solidifier, int resultAmount = 1, int groupAmount = 1, int secondaryMaterial = -1, int secondaryAmount = 1)
            {
                var recipe = Recipe.Create(result, resultAmount);
                recipe.AddRecipeGroup(group, groupAmount);
                if (secondaryMaterial != -1)
                    recipe.AddIngredient(secondaryMaterial, secondaryAmount);
                recipe.AddTile(station);
                recipe.DisableDecraft(); 
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
            AddBannerToItemRecipe(ItemID.HornetBanner, ItemID.TatteredBeeWing, tile: TileID.MythrilAnvil, item2type: ItemID.HallowedBar);
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.UnholyTrident, tile: TileID.MythrilAnvil, item2type: ItemID.HallowedBar);
            AddBannerToItemRecipe(ItemID.RedDevilBanner, ItemID.FireFeather, tile: TileID.MythrilAnvil, item2type: ItemID.HallowedBar);
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
            AddBannerToItemRecipe(ItemID.PixieBanner, ItemID.PixieDust, tile: TileID.MythrilAnvil, resultAmount: 100);
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
            AddBannerToItemRecipe(ItemID.SporeBatBanner, ItemID.Shroomerang);
            AddBannerToItemRecipe(ItemID.GiantCursedSkullBanner, ItemID.ShadowJoustingLance);
            AddBannerToItemRecipe(ItemID.DungeonSpiritBanner, ItemID.Ectoplasm, 1, 50);

            AddBannerToItemRecipe(ItemID.EaterofSoulsBanner, ItemID.TentacleSpike, 2);
            AddBannerToItemRecipe(ItemID.CrimeraBanner, ItemID.TentacleSpike, 2);
            AddBannerToItemRecipe(ItemID.PigronBanner, ItemID.HamBat, tile: TileID.MythrilAnvil);

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
            AddBannerToItemsRecipe(ItemID.FloatyGrossBanner, new int[] { ItemID.Vitamins }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.MedusaBanner, new int[] { ItemID.MedusaHead, ItemID.PocketMirror }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.MummyBanner, new int[] { ItemID.MummyMask, ItemID.MummyShirt, ItemID.MummyPants }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.PaladinBanner, new int[] { ItemID.PaladinsHammer, ItemID.PaladinsShield }, tile: TileID.MythrilAnvil);
            AddBannerToItemsRecipe(ItemID.PenguinBanner, new int[] { ItemID.PedguinHat, ItemID.PedguinShirt, ItemID.PedguinPants });
            AddBannerToItemsRecipe(ItemID.PirateBanner, new int[] { ItemID.SailorHat, ItemID.SailorShirt, ItemID.SailorPants }, tile: TileID.MythrilAnvil);
            
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
            AddGroupToItemRecipe("Fargowiltas:AnyDeserts", ItemID.DungeonDesertKey, TileID.MythrilAnvil, 1, 10);

            AddGroupToItemRecipe("Fargowiltas:AnyBats", ItemID.BatBat);

            AddGroupToItemRecipe("Fargowiltas:AnyCorrupts", ItemID.MeatGrinder, TileID.MythrilAnvil, 1, 5);
            AddGroupToItemRecipe("Fargowiltas:AnyCrimsons", ItemID.MeatGrinder, TileID.MythrilAnvil, 1, 5);

            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelAmber, TileID.Solidifier, 1, 1, ItemID.Amber, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelAmethyst, TileID.Solidifier, 1, 1, ItemID.Amethyst, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelDiamond, TileID.Solidifier, 1, 1, ItemID.Diamond, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelEmerald, TileID.Solidifier, 1, 1, ItemID.Emerald, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelRuby, TileID.Solidifier, 1, 1, ItemID.Ruby, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelSapphire, TileID.Solidifier, 1, 1, ItemID.Sapphire, 5);
            AddGroupToItemRecipe("Fargowiltas:AnySquirrel", ItemID.GemSquirrelTopaz, TileID.Solidifier, 1, 1, ItemID.Topaz, 5);

            AddBannerToItemRecipe(ItemID.GemBunnyDiamond, ItemID.Diamond, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnyAmber, ItemID.Amber, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnyRuby, ItemID.Ruby, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnyEmerald, ItemID.Emerald, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnySapphire, ItemID.Sapphire, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnyTopaz, ItemID.Topaz, 1, 5);
            AddBannerToItemRecipe(ItemID.GemBunnyAmethyst, ItemID.Amethyst, 1, 5);

            AddBannerToItemRecipe(ItemID.GemSquirrelDiamond, ItemID.Diamond, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelAmber, ItemID.Amber, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelRuby, ItemID.Ruby, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelEmerald, ItemID.Emerald, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelSapphire, ItemID.Sapphire, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelTopaz, ItemID.Topaz, 1, 5);
            AddBannerToItemRecipe(ItemID.GemSquirrelAmethyst, ItemID.Amethyst, 1, 5);


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
                var recipe = Recipe.Create(statue);

                if (ingredient != -1)
                {
                    recipe.AddIngredient(ingredient, ingredientAmount);
                }
                
                recipe.AddIngredient(ItemID.StoneBlock, 50);
                recipe.AddTile(TileID.HeavyWorkBench);
                recipe.DisableDecraft(); 
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
            Recipe.Create(ItemID.LihzahrdGuardianStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)
                .AddTile(TileID.HeavyWorkBench)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.LihzahrdStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)
                .AddTile(TileID.HeavyWorkBench)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.LihzahrdWatcherStatue)
                .AddIngredient(ItemID.LihzahrdBanner)
                .AddIngredient(ItemID.LihzahrdBrick, 50)
                .AddTile(TileID.HeavyWorkBench)
                .DisableDecraft().Register();


            Recipe.Create(ItemID.KingStatue)
                .AddIngredient(ItemID.Throne)
                .AddIngredient(ItemID.TeleportationPotion)
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddTile(TileID.HeavyWorkBench)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.QueenStatue)
                .AddIngredient(ItemID.Throne)
                .AddIngredient(ItemID.TeleportationPotion)
                .AddIngredient(ItemID.StoneBlock, 50)
                .AddTile(TileID.HeavyWorkBench)
                .DisableDecraft().Register();
        }

        private void AddContainerLootRecipes()
        {
            void KeyToItemRecipe(int key, int result)
            {
                var recipe = Recipe.Create(result);
                recipe.AddIngredient(key);
                recipe.AddIngredient(ItemID.Ectoplasm, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.DisableDecraft(); 
                recipe.Register();
            }

            KeyToItemRecipe(ItemID.CrimsonKey, ItemID.VampireKnives);
            KeyToItemRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor);
            KeyToItemRecipe(ItemID.JungleKey, ItemID.PiranhaGun);
            KeyToItemRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra);
            KeyToItemRecipe(ItemID.HallowedKey, ItemID.RainbowGun);
            KeyToItemRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff);


            // Goodie Bag / Present recipes
            void AddGrabBagItemRecipe(int result, int grabBag = ItemID.Present, int grabBagAmount = 10, int item2type = -1, int item2amount = 1)
            {
                var recipe = Recipe.Create(result);
                recipe.AddIngredient(grabBag, grabBagAmount);
                if (item2type > -1)
                    recipe.AddIngredient(item2type, item2amount);
                recipe.AddTile(TileID.WorkBenches);
                recipe.DisableDecraft(); 
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
                var recipe = Recipe.Create(result, 5);
                recipe.AddIngredient(ItemID.HerbBag);
                recipe.AddTile(TileID.WorkBenches);
                recipe.DisableDecraft(); 
                recipe.Register();
            }

            AddHerbBagRecipe(ItemID.Daybloom);
            AddHerbBagRecipe(ItemID.Moonglow);
            AddHerbBagRecipe(ItemID.Blinkroot);
            AddHerbBagRecipe(ItemID.Waterleaf);
            AddHerbBagRecipe(ItemID.Deathweed);
            AddHerbBagRecipe(ItemID.Fireblossom);
            AddHerbBagRecipe(ItemID.Shiverthorn);

            void AddCrateRecipe(int result, int crate, int crateAmount, int hardCrate, int extraItem = -1)
            {
                if (crate != -1)
                {
                    var recipe = Recipe.Create(result);
                    recipe.AddIngredient(crate, crateAmount);
                    if (extraItem != -1)
                    {
                        recipe.AddIngredient(extraItem);
                    }
                    recipe.AddTile(TileID.WorkBenches);
                    recipe.DisableDecraft(); 
                    recipe.Register();
                }

                if (hardCrate != -1)
                {
                    var recipe = Recipe.Create(result);
                    recipe.AddIngredient(hardCrate, crateAmount);
                    if (extraItem != -1)
                    {
                        recipe.AddIngredient(extraItem);
                    }
                    recipe.AddTile(TileID.WorkBenches);
                    recipe.DisableDecraft(); 
                    recipe.Register();
                }
            }

            //wooden
            AddCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Umbrella, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Spear, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.BabyBirdStaff, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.SunflowerMinecart, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.LadybugMinecart, ItemID.WoodenCrate, 3, ItemID.WoodenCrateHard);
            AddCrateRecipe(ItemID.Anchor, -1, 3, ItemID.WoodenCrateHard);

            //iron
            AddCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, 3, ItemID.IronCrateHard);
            AddCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, 3, ItemID.IronCrateHard);
            AddCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, 3, ItemID.IronCrateHard);
            AddCrateRecipe(ItemID.CloudinaBottle, ItemID.IronCrate, 1, ItemID.IronCrateHard);
            

            //gold
            AddCrateRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.FlareGun, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.Mace, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.LifeCrystal, ItemID.GoldenCrate, 5, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.HardySaddle, -1, 5, ItemID.GoldenCrateHard);
            AddCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, 5, ItemID.GoldenCrateHard);

            AddCrateRecipe(ItemID.Sundial, ItemID.GoldenCrate, 1, ItemID.GoldenCrateHard); //actually should be hm but fuck it

            //jungle
            AddCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.BeeMinecart, ItemID.JungleFishingCrate, 1, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            AddCrateRecipe(ItemID.HoneyDispenser, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);

            //sky
            AddCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);
            AddCrateRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, 1, ItemID.FloatingIslandFishingCrateHard);

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

            //hallow

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
            AddCrateRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            AddCrateRecipe(ItemID.BewitchingTable, ItemID.DungeonFishingCrate, 1, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);

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
            AddCrateRecipe(ItemID.SandBoots, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.DesertMinecart, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.EncumberingStone, ItemID.OasisCrate, 1, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.FlyingCarpet, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            AddCrateRecipe(ItemID.SandstorminaBottle, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);

            //obsidian
            AddCrateRecipe(ItemID.DarkLance, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.HellwingBow, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.Flamelash, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.Sunfury, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);
            AddCrateRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, 1, ItemID.LavaCrateHard, ItemID.ShadowKey);

            AddCrateRecipe(ItemID.LavaCharm, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.WetBomb, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);
            AddCrateRecipe(ItemID.DemonConch, ItemID.LavaCrate, 1, ItemID.LavaCrateHard);

            // ocean crate
            AddCrateRecipe(ItemID.Trident, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, 1, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
            AddCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
        }

        private static void AddNPCRecipes()
        {
            Fargowiltas mod = ModLoader.GetMod("Fargowiltas") as Fargowiltas;

            Recipe.Create(ItemID.FleshBlock, 25)
                .AddRecipeGroup("Fargowiltas:AnyCaughtNPC")
                .AddTile(TileID.MeatGrinder)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.DeepRedPaint, 20).
            AddRecipeGroup("Fargowiltas:AnyCaughtNPC").
            AddTile(TileID.DyeVat).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BluePaint, 20).
            AddIngredient(CaughtNPCItem.CaughtTownies[NPCID.Truffle]).
            AddTile(TileID.DyeVat).
            DisableDecraft().Register();

            Recipe.Create(CaughtNPCItem.CaughtTownies[ModContent.NPCType<NPCs.Squirrel>()]).
            AddRecipeGroup("Fargowiltas:AnySquirrel").
            AddIngredient(ItemID.TopHat).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.TravellingMerchant]).
            AddIngredient(null, "Merchant").
            AddIngredient(ItemID.GoldCoin, 50).
            AddIngredient(ItemID.BlueDye).
            AddTile(TileID.DyeVat).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BloodbathDye, 2).
            AddRecipeGroup("Fargowiltas:AnyCaughtNPC").
            AddTile(TileID.DyeVat).
            DisableDecraft().Register();

            Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.SkeletonMerchant]).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.Bone, 5).
            AddTile(TileID.BoneWelder).
            DisableDecraft().Register();

            Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.TravellingMerchant]).
            AddIngredient(null, "SkeletonMerchant").
            AddTile(TileID.MeatGrinder).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Bone, 25).
            AddIngredient(null, "SkeletonMerchant").
            AddTile(TileID.BoneWelder).
            DisableDecraft().Register();

            Recipe.Create(ItemID.LeafWand).
            AddIngredient(null, "Dryad").
            AddTile(TileID.LivingLoom).
            DisableDecraft().Register();

            Recipe.Create(ItemID.TruffleWorm).
            AddIngredient(null, "Truffle").
            AddIngredient(ItemID.EnchantedNightcrawler).
            AddTile(TileID.Autohammer).
            DisableDecraft().Register();

            Recipe.Create(ItemID.DyeTradersScimitar).
            AddIngredient(null, "DyeTrader").
            AddIngredient(ItemID.WoodenSword).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.AleThrowingGlove).
            AddIngredient(null, "Tavernkeep").
            AddIngredient(ItemID.Ale, 5).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.StylistKilLaKillScissorsIWish).
            AddIngredient(null, "Stylist").
            AddIngredient(ItemID.WoodenSword).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PainterPaintballGun).
            AddIngredient(null, "Painter").
            AddIngredient(ItemID.WoodenBow).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.TaxCollectorsStickOfDoom).
            AddIngredient(null, "TaxCollector").
            AddIngredient(ItemID.WoodenSword).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PrincessWeapon).
            AddIngredient(null, "Princess").
            AddIngredient(ItemID.Ectoplasm).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.CombatWrench).
            AddIngredient(null, "Mechanic").
            AddIngredient(ItemID.WoodenBoomerang).
            AddTile(TileID.DemonAltar).
            DisableDecraft().Register();

            Recipe.Create(ItemID.FishermansGuide).
            AddIngredient(null, "Angler").
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.WeatherRadio).
            AddIngredient(null, "Angler").
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Sextant).
            AddIngredient(null, "Angler").
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //travelling merch recipes 
            Recipe.Create(ItemID.SliceOfCake).
            AddIngredient(ItemID.FoodPlatter).
            AddIngredient(null, "PartyGirl").
            AddTile(TileID.Furnaces).
            DisableDecraft().Register();

            //travelling merch recipes 
            Recipe.Create(ItemID.DynastyWood, 500).
            AddIngredient(ItemID.Wood, 500).
            AddIngredient(null, "TravellingMerchant").
            AddTile(TileID.CookingPots).
            DisableDecraft().Register();

            Recipe.Create(ItemID.UltrabrightTorch, 200).
            AddIngredient(ItemID.Torch, 200).
            AddIngredient(null, "TravellingMerchant").
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //common items - 1 merchant, 2x price
            Recipe.Create(ItemID.Stopwatch).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddRecipeGroup("IronBar", 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.LifeformAnalyzer).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddRecipeGroup("IronBar", 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.DPSMeter).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddRecipeGroup("IronBar", 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //uncommon - 1 merchant, 2x price
            Recipe.Create(ItemID.Katana).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddRecipeGroup("IronBar", 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.ActuationAccessory).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.Actuator, 10).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PortableCementMixer).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.BuilderPotion).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PaintSprayer).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.BuilderPotion).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.ExtendoGrip).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.BuilderPotion).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BrickLayer).
            AddIngredient(null, "TravellingMerchant").
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.BuilderPotion).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //rare - 2 merchant, 2x price
            Recipe.Create(ItemID.Code1).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 10).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Code2).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 50).
            AddIngredient(ItemID.Code1).
            AddIngredient(ItemID.HallowedBar, 5). //post mech
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BambooLeaf).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.PlatinumCoin, 2).
            AddIngredient(ItemID.BambooBlock, 25).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.CelestialWand).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.PlatinumCoin, 2).
            AddIngredient(ItemID.ManaCrystal).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Gi).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 4).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.GypsyRobe).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 7).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.MagicHat).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 6).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.AmmoBox).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 30).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Revolver).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 20).
            AddIngredient(ItemID.MusketBall, 25). //post evil
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //very rare
            Recipe.Create(ItemID.BedazzledNectar).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.PlatinumCoin, 2).
            AddIngredient(ItemID.TreeNymphButterfly).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.ExoticEasternChewToy).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.PlatinumCoin, 2).
            AddIngredient(ItemID.Cactus, 50).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BirdieRattle).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.PlatinumCoin, 2).
            AddIngredient(ItemID.Feather, 10).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.CompanionCube).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.PlatinumCoin, 10).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.SittingDucksFishingRod).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.GoldCoin, 70).
            AddIngredient(ItemID.Bone, 10). //post skele
            AddRecipeGroup("Fargowiltas:AnyDuck").
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.DiamondRing).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.PlatinumCoin, 4).
            AddIngredient(ItemID.Diamond).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.CelestialMagnet).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.GoldCoin, 30).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.WaterGun).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.GoldCoin, 3).
            AddIngredient(ItemID.WaterBucket).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PulseBow).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.GoldCoin, 90).
            AddIngredient(ItemID.Ectoplasm, 5). //post plant
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.YellowCounterweight).
            AddIngredient(null, "TravellingMerchant", 3).
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.YellowDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //extremely rare
            Recipe.Create(ItemID.ZapinatorGray).
            AddIngredient(null, "TravellingMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 34).
            AddIngredient(ItemID.SpaceGun).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

           Recipe.Create(ItemID.ZapinatorOrange).
           AddIngredient(null, "TravellingMerchant", 2).
           AddIngredient(ItemID.PlatinumCoin).
           AddIngredient(ItemID.ZapinatorGray).
           AddIngredient(ItemID.SoulofLight). //hm
           AddTile(TileID.TinkerersWorkbench).
           DisableDecraft().Register();

           Recipe.Create(ItemID.BouncingShield).
           AddIngredient(null, "TravellingMerchant", 2).
           AddIngredient(ItemID.GoldCoin, 70).
           AddIngredient(ItemID.SoulofLight). //hm
           AddTile(TileID.TinkerersWorkbench).
           DisableDecraft().Register();

            Recipe.Create(ItemID.Gatligator).
            AddIngredient(null, "TravellingMerchant", 4).
            AddIngredient(ItemID.GoldCoin, 70).
            AddIngredient(ItemID.SoulofLight, 2). //hardmode
            AddIngredient(ItemID.SoulofNight, 2).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.BlackCounterweight).
            AddIngredient(null, "TravellingMerchant", 4).
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.BlackDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //extraordinarily rare
            Recipe.Create(ItemID.AngelHalo).
            AddIngredient(null, "TravellingMerchant", 5).
            AddIngredient(ItemID.GoldCoin, 80).
            AddIngredient(ItemID.GoldBar, 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            //skeleton merchant recipes
            Recipe.Create(ItemID.BlueCounterweight).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.BlueDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.RedCounterweight).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.RedDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.PurpleCounterweight).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.PurpleDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.GreenCounterweight).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 10).
            AddIngredient(ItemID.GreenDye).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.Gradient).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 40).
            AddIngredient(ItemID.SoulofNight, 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.FormatC).
            AddIngredient(null, "SkeletonMerchant").
            AddIngredient(ItemID.GoldCoin, 40).
            AddIngredient(ItemID.SoulofLight, 5).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();

            Recipe.Create(ItemID.MagicLantern).
            AddIngredient(null, "SkeletonMerchant", 2).
            AddIngredient(ItemID.GoldCoin, 20).
            AddTile(TileID.TinkerersWorkbench).
            DisableDecraft().Register();
        }

        private void AddTreasureBagRecipes()
        {
            void CreateTreasureBagRecipes(int input, params int[] outputs)
            {
                foreach (int output in outputs)
                {
                    Recipe.Create(output)
                        .AddIngredient(input)
                        .AddTile(TileID.Solidifier)
                        .DisableDecraft().Register();
                }
            }

            CreateTreasureBagRecipes(ItemID.KingSlimeTrophy, ItemID.SlimeStaff);
            
            CreateTreasureBagRecipes(ItemID.EyeofCthulhuTrophy, ItemID.Binoculars);
            
            CreateTreasureBagRecipes(ItemID.EaterofWorldsTrophy, ItemID.EatersBone);
            
            CreateTreasureBagRecipes(ItemID.BrainofCthulhuTrophy, ItemID.BoneRattle);
            
            CreateTreasureBagRecipes(ItemID.SkeletronTrophy, ItemID.BookofSkulls);

            //QB
            CreateTreasureBagRecipes(ItemID.QueenBeeBossBag,
                ItemID.BeesKnees,
                ItemID.BeeGun,
                ItemID.BeeKeeper
            );
            CreateTreasureBagRecipes(ItemID.QueenBeeTrophy,
                ItemID.HoneyedGoggles,
                ItemID.Nectar
            );

            //deerclops
            CreateTreasureBagRecipes(ItemID.DeerclopsBossBag,
                ItemID.PewMaticHorn,
                ItemID.WeatherPain,
                ItemID.HoundiusShootius,
                ItemID.LucyTheAxe
            );
            CreateTreasureBagRecipes(ItemID.DeerclopsTrophy,
                ItemID.ChesterPetItem,
                ItemID.Eyebrella,
                ItemID.DontStarveShaderItem
            );

            //WOF
            CreateTreasureBagRecipes(ItemID.WallOfFleshBossBag,
                ItemID.RangerEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                ItemID.WarriorEmblem,
                ItemID.ClockworkAssaultRifle,
                ItemID.BreakerBlade,
                ItemID.LaserRifle,
                ItemID.FireWhip
            );

            //queen slime
            CreateTreasureBagRecipes(ItemID.QueenSlimeBossBag,
                ItemID.Smolstar,
                ItemID.QueenSlimeMountSaddle,
                ItemID.QueenSlimeHook
            );

            //plantera
            CreateTreasureBagRecipes(ItemID.PlanteraBossBag,
                ItemID.GrenadeLauncher,
                ItemID.PygmyStaff,
                ItemID.VenusMagnum,
                ItemID.NettleBurst,
                ItemID.LeafBlower,
                ItemID.Seedler,
                ItemID.FlowerPow,
                ItemID.WaspGun
            );
            CreateTreasureBagRecipes(ItemID.PlanteraTrophy,
                ItemID.TheAxe,
                ItemID.Seedling
            );

            //golem
            CreateTreasureBagRecipes(ItemID.GolemBossBag,
                ItemID.Stynger,
                ItemID.PossessedHatchet,
                ItemID.SunStone,
                ItemID.EyeoftheGolem,
                ItemID.Picksaw,
                ItemID.HeatRay,
                ItemID.StaffofEarth,
                ItemID.GolemFist
            );

            //duke
            CreateTreasureBagRecipes(ItemID.FishronBossBag,
                ItemID.Flairon,
                ItemID.Tsunami,
                ItemID.RazorbladeTyphoon,
                ItemID.TempestStaff,
                ItemID.BubbleGun
            );
            CreateTreasureBagRecipes(ItemID.DukeFishronTrophy, ItemID.FishronWings);

            //empress
            CreateTreasureBagRecipes(ItemID.FairyQueenBossBag,
                ItemID.PiercingStarlight,
                ItemID.RainbowWhip,
                ItemID.FairyQueenMagicItem,
                ItemID.FairyQueenRangedItem,
                ItemID.HallowBossDye
            );
            CreateTreasureBagRecipes(ItemID.FairyQueenTrophy,
                ItemID.SparkleGuitar,
                ItemID.RainbowCursor,
                ItemID.RainbowWings
            );

            //moon lord
            CreateTreasureBagRecipes(ItemID.MoonLordBossBag,
                ItemID.Meowmere,
                ItemID.Terrarian,
                ItemID.StarWrath,
                ItemID.SDMG,
                ItemID.Celeb2,
                ItemID.LastPrism,
                ItemID.LunarFlareBook,
                ItemID.RainbowCrystalStaff,
                ItemID.MoonlordTurretStaff
            );
            CreateTreasureBagRecipes(ItemID.MoonLordTrophy, ItemID.MeowmereMinecart);

            //dark mage
            CreateTreasureBagRecipes(ItemID.BossTrophyDarkmage,
                ItemID.DD2PetDragon,
                ItemID.DD2PetGato
            );

            //ogre
            CreateTreasureBagRecipes(ItemID.BossTrophyOgre,
                ItemID.ApprenticeScarf,
                ItemID.SquireShield,
                ItemID.HuntressBuckler,
                ItemID.MonkBelt,
                ItemID.DD2PhoenixBow,
                ItemID.BookStaff,
                ItemID.DD2SquireDemonSword,
                ItemID.MonkStaffT1,
                ItemID.MonkStaffT2,
                ItemID.DD2PetGhost
            );

            //besty
            CreateTreasureBagRecipes(ItemID.BossBagBetsy,
                ItemID.BetsyWings,
                ItemID.DD2SquireBetsySword,
                ItemID.ApprenticeStaffT3,
                ItemID.MonkStaffT3,
                ItemID.DD2BetsyBow
            );

            //mourning wood
            CreateTreasureBagRecipes(ItemID.MourningWoodTrophy,
                ItemID.SpookyHook,
                ItemID.SpookyTwig,
                ItemID.StakeLauncher,
                ItemID.CursedSapling,
                ItemID.NecromanticScroll
            );

            //pumpking
            CreateTreasureBagRecipes(ItemID.PumpkingTrophy,
                ItemID.TheHorsemansBlade,
                ItemID.BatScepter,
                ItemID.RavenStaff,
                ItemID.CandyCornRifle,
                ItemID.JackOLanternLauncher,
                ItemID.BlackFairyDust,
                ItemID.ScytheWhip
            );

            //everscream
            CreateTreasureBagRecipes(ItemID.EverscreamTrophy,
                ItemID.ChristmasTreeSword,
                ItemID.ChristmasHook,
                ItemID.Razorpine,
                ItemID.FestiveWings
            );

            //santa nk1
            CreateTreasureBagRecipes(ItemID.SantaNK1Trophy,
                ItemID.ElfMelter,
                ItemID.ChainGun
            );

            //ice queen
            CreateTreasureBagRecipes(ItemID.IceQueenTrophy,
                ItemID.BlizzardStaff,
                ItemID.SnowmanCannon,
                ItemID.NorthPole,
                ItemID.BabyGrinchMischiefWhistle,
                ItemID.ReindeerBells
            );

            //saucer
            CreateTreasureBagRecipes(ItemID.MartianSaucerTrophy,
                ItemID.Xenopopper,
                ItemID.XenoStaff,
                ItemID.LaserMachinegun,
                ItemID.ElectrosphereLauncher,
                ItemID.InfluxWaver,
                ItemID.CosmicCarKey,
                ItemID.AntiGravityHook,
                ItemID.ChargedBlasterCannon,
                ItemID.LaserDrill
            );

            //dutchman
            CreateTreasureBagRecipes(ItemID.FlyingDutchmanTrophy,
                ItemID.LuckyCoin,
                ItemID.DiscountCard,
                ItemID.CoinGun,
                ItemID.PirateStaff,
                ItemID.GoldRing,
                ItemID.Cutlass,
                ItemID.PirateMinecart
            );

            //treasure magnet I HATE TREASURE MAGNET TEAR OFF ALL OF YOUR FLESH
            CreateTreasureBagRecipes(ItemID.TreasureMagnet,
                ItemID.DarkLance,
                ItemID.HellwingBow,
                ItemID.Flamelash,
                ItemID.FlowerofFire,
                ItemID.Sunfury
            );
        }

        private void AddMiscRecipes()
        {
            Recipe.Create(ItemID.EnchantedSword)
                .AddIngredient(ItemID.IceBlade)
                .AddTile(TileID.CrystalBall)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.Terragrim)
                .AddIngredient(ItemID.EnchantedSword, 2)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.CrystalBall)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.MagicalPumpkinSeed)
                .AddIngredient(ItemID.Pumpkin, 500)
                .AddTile(TileID.LivingLoom)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.Seaweed)
                .AddIngredient(ItemID.FishingSeaweed, 5)
                .AddTile(TileID.LivingLoom)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.RottenEgg, 25)
                .AddIngredient(ItemID.GoodieBag, 2)
                .AddTile(TileID.WorkBenches)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.FlowerBoots)
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Daybloom)
                .AddIngredient(ItemID.Blinkroot)
                .AddIngredient(ItemID.Shiverthorn)
                .AddIngredient(ItemID.Moonglow)
                .AddIngredient(ItemID.Waterleaf)
                .AddIngredient(ItemID.Deathweed)
                .AddIngredient(ItemID.Fireblossom)
                .AddTile(TileID.LivingLoom)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.LivingLoom)
                .AddIngredient(ItemID.Loom)
                .AddIngredient(ItemID.Vine, 10)
                .AddTile(TileID.WorkBenches)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.JungleRose)
                .AddIngredient(ItemID.NaturesGift)
                .AddIngredient(ItemID.RedHusk)
                .AddTile(TileID.LivingLoom)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.NaturesGift)
                .AddIngredient(ItemID.JungleRose)
                .AddIngredient(ItemID.CyanHusk)
                .AddTile(TileID.LivingLoom)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AmberMosquito)
                .AddIngredient(ItemID.Amber, 15)
                .AddIngredient(ItemID.Firefly)
                .AddTile(TileID.CookingPots)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.NaturesGift)
                .AddIngredient(ItemID.Moonglow, 15)
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.AlchemyTable)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.SandstorminaBottle)
                .AddIngredient(ItemID.SandBlock, 50)
                .AddIngredient(ItemID.Bottle)
                .AddTile(TileID.AlchemyTable)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.ShroomiteBar)
                .AddIngredient(ItemID.ChlorophyteBar)
                .AddIngredient(ItemID.DarkBlueSolution)
                .AddTile(TileID.Autohammer)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.WebSlinger)
                .AddIngredient(ItemID.GrapplingHook)
                .AddIngredient(ItemID.WebRopeCoil, 8)
                .AddTile(TileID.CookingPots)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AbigailsFlower)
               .AddIngredient(ItemID.Deathweed, 5)
               .AddTile(TileID.Tombstones)
               .AddCondition(Condition.InGraveyard)
               .DisableDecraft().Register();

            Recipe.Create(ItemID.SandstorminaBottle)
               .AddIngredient(ItemID.PharaohsMask)
               .AddIngredient(ItemID.PharaohsRobe)
               .AddIngredient(ItemID.GoldCoin, 10)
               .AddTile(TileID.TinkerersWorkbench)
               .DisableDecraft().Register();

            Recipe.Create(ItemID.FlyingCarpet)
               .AddIngredient(ItemID.PharaohsMask)
               .AddIngredient(ItemID.PharaohsRobe)
               .AddIngredient(ItemID.GoldCoin, 10)
               .AddTile(TileID.TinkerersWorkbench)
               .DisableDecraft().Register();

            Recipe.Create(ItemID.FartInABalloon)
               .AddIngredient(ItemID.CloudinaBalloon)
               .AddIngredient(ItemID.WhoopieCushion)
               .AddTile(TileID.TinkerersWorkbench)
               .DisableDecraft().Register();

            Recipe.Create(ItemID.BalloonHorseshoeFart)
               .AddIngredient(ItemID.BlueHorseshoeBalloon)
               .AddIngredient(ItemID.WhoopieCushion)
               .AddTile(TileID.TinkerersWorkbench)
               .DisableDecraft().Register();
        }

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

        //}

        private void AddConvertRecipe(int item, int item2)
        {
            Recipe.Create(item)
               .AddIngredient(item2)
               .AddTile(TileID.DemonAltar)
               .DisableDecraft().Register();

            Recipe.Create(item2)
               .AddIngredient(item)
               .AddTile(TileID.DemonAltar)
               .DisableDecraft().Register();
        }

        private void AddVanillaRecipes()
        {
            foreach (Recipe recipe in Main.recipe.Where(recipe => recipe.HasIngredient(ItemID.BeetleHusk)))
            {
                if (recipe.TryGetIngredient(ItemID.TurtleHelmet, out Item head))
                {
                    recipe.RemoveIngredient(head);
                    recipe.AddIngredient(ItemID.ChlorophyteMask);
                }
                if (recipe.TryGetIngredient(ItemID.TurtleScaleMail, out Item body))
                {
                    recipe.RemoveIngredient(body);
                    recipe.AddIngredient(ItemID.ChlorophytePlateMail);
                }
                if (recipe.TryGetIngredient(ItemID.TurtleLeggings, out Item legs))
                {
                    recipe.RemoveIngredient(legs);
                    recipe.AddIngredient(ItemID.ChlorophyteGreaves);
                }
            }

            //ancient armor recipes
            Recipe.Create(ItemID.AncientShadowHelmet)
                .AddIngredient(ItemID.DemoniteBar, 15)
                .AddIngredient(ItemID.ShadowScale, 10)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientShadowScalemail)
                .AddIngredient(ItemID.DemoniteBar, 25)
                .AddIngredient(ItemID.ShadowScale, 20)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientShadowGreaves)
                .AddIngredient(ItemID.DemoniteBar, 20)
                .AddIngredient(ItemID.ShadowScale, 15)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientIronHelmet)
                .AddIngredient(ItemID.IronBar, 15)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientGoldHelmet)
                .AddIngredient(ItemID.GoldBar, 20)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientNecroHelmet)
                .AddIngredient(ItemID.Bone, 20)
                .AddIngredient(ItemID.Cobweb, 40)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientCobaltHelmet)
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientCobaltBreastplate)
                .AddIngredient(ItemID.JungleSpores, 16)
                .AddIngredient(ItemID.Stinger, 10)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.AncientCobaltLeggings)
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddIngredient(ItemID.Vine, 2)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();

            Recipe.Create(ItemID.TeleportationPylonVictory)
                .AddIngredient(ItemID.TeleportationPylonDesert)
                .AddIngredient(ItemID.TeleportationPylonHallow)
                .AddIngredient(ItemID.TeleportationPylonJungle)
                .AddIngredient(ItemID.TeleportationPylonMushroom)
                .AddIngredient(ItemID.TeleportationPylonOcean)
                .AddIngredient(ItemID.TeleportationPylonPurity)
                .AddIngredient(ItemID.TeleportationPylonSnow)
                .AddIngredient(ItemID.TeleportationPylonUnderground)
                .AddIngredient(ItemID.PlatinumCoin)
                .AddTile(TileID.DemonAltar)
                .DisableDecraft().Register();
        }
    }
}
