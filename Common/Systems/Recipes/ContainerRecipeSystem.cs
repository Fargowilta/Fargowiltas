using Fargowiltas.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Common.Systems.Recipes
{
    public class ContainerRecipeSystem : ModSystem
    {
        public override void AddRecipes()
        {
            AddPreHMTreasureBagRecipes();
            AddHMTreasureBagRecipes();
            AddEventTreasureBagRecipes();
            AddGrabBagRecipes();
            AddCrateRecipes();
            AddBiomeKeyRecipes();

            // Treasure magnet I HATE TREASURE MAGNET TEAR OFF ALL OF YOUR FLESH
            CreateTreasureGroupRecipe(ItemID.TreasureMagnet,
                ItemID.DarkLance,
                ItemID.HellwingBow,
                ItemID.Flamelash,
                ItemID.Sunfury
            );
            RecipeHelper.CreateSimpleRecipe(ItemID.TreasureMagnet, ItemID.FlowerofFire, TileID.Solidifier, disableDecraft: true, conditions: Condition.NotRemixWorld);
        }

        private static void AddPreHMTreasureBagRecipes()
        {
            CreateTreasureGroupRecipe(ItemID.KingSlimeTrophy, ItemID.SlimeStaff);
            CreateTreasureGroupRecipe(ItemID.EyeofCthulhuTrophy, ItemID.Binoculars);
            CreateTreasureGroupRecipe(ItemID.EaterofWorldsTrophy, ItemID.EatersBone);
            CreateTreasureGroupRecipe(ItemID.BrainofCthulhuTrophy, ItemID.BoneRattle);
            CreateTreasureGroupRecipe(ItemID.SkeletronTrophy, ItemID.BookofSkulls);

            // Queen Bee
            CreateTreasureGroupRecipe(ItemID.QueenBeeBossBag,
                ItemID.BeesKnees,
                ItemID.BeeGun,
                ItemID.BeeKeeper,
                ItemID.HoneyComb
            );
            CreateTreasureGroupRecipe(ItemID.QueenBeeTrophy,
                ItemID.HoneyedGoggles,
                ItemID.Nectar
            );

            // Deerclops
            CreateTreasureGroupRecipe(ItemID.DeerclopsBossBag,
                ItemID.PewMaticHorn,
                ItemID.WeatherPain,
                ItemID.HoundiusShootius,
                ItemID.LucyTheAxe
            );
            CreateTreasureGroupRecipe(ItemID.DeerclopsTrophy,
                ItemID.ChesterPetItem,
                ItemID.Eyebrella,
                ItemID.DontStarveShaderItem
            );

            // Wall of Flesh
            CreateTreasureGroupRecipe(ItemID.WallOfFleshBossBag,
                ItemID.ClockworkAssaultRifle,
                ItemID.BreakerBlade,
                ItemID.LaserRifle,
                ItemID.FireWhip
            );
        }

        private static void AddHMTreasureBagRecipes()
        {
            // Queen Slime
            CreateTreasureGroupRecipe(ItemID.QueenSlimeBossBag,
                ItemID.Smolstar,
                ItemID.QueenSlimeMountSaddle,
                ItemID.QueenSlimeHook
            );

            // Plantera
            CreateTreasureGroupRecipe(ItemID.PlanteraBossBag,
                ItemID.GrenadeLauncher,
                ItemID.PygmyStaff,
                ItemID.VenusMagnum,
                ItemID.NettleBurst,
                ItemID.LeafBlower,
                ItemID.Seedler,
                ItemID.FlowerPow,
                ItemID.WaspGun
            );
            CreateTreasureGroupRecipe(ItemID.PlanteraTrophy,
                ItemID.TheAxe,
                ItemID.Seedling
            );

            // Golem
            CreateTreasureGroupRecipe(ItemID.GolemBossBag,
                ItemID.Stynger,
                ItemID.PossessedHatchet,
                ItemID.SunStone,
                ItemID.EyeoftheGolem,
                ItemID.Picksaw,
                ItemID.HeatRay,
                ItemID.StaffofEarth,
                ItemID.GolemFist
            );

            // Duke Fishron
            CreateTreasureGroupRecipe(ItemID.FishronBossBag,
                ItemID.Flairon,
                ItemID.Tsunami,
                ItemID.RazorbladeTyphoon,
                ItemID.TempestStaff,
                ItemID.BubbleGun
            );
            CreateTreasureGroupRecipe(ItemID.DukeFishronTrophy, ItemID.FishronWings);

            // Empress of Light
            CreateTreasureGroupRecipe(ItemID.FairyQueenBossBag,
                ItemID.PiercingStarlight,
                ItemID.RainbowWhip,
                ItemID.FairyQueenMagicItem,
                ItemID.FairyQueenRangedItem,
                ItemID.HallowBossDye
            );
            CreateTreasureGroupRecipe(ItemID.FairyQueenTrophy,
                ItemID.SparkleGuitar,
                ItemID.RainbowCursor,
                ItemID.RainbowWings
            );

            // Moon Lord
            CreateTreasureGroupRecipe(ItemID.MoonLordBossBag,
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
            CreateTreasureGroupRecipe(ItemID.MoonLordTrophy, ItemID.MeowmereMinecart);
        }

        private static void AddEventTreasureBagRecipes()
        {
            // Dark Mage
            CreateTreasureGroupRecipe(ItemID.BossTrophyDarkmage,
                ItemID.DD2PetDragon,
                ItemID.DD2PetGato,
                ItemID.SquireShield,
                ItemID.ApprenticeScarf
            );

            // Ogre
            CreateTreasureGroupRecipe(ItemID.BossTrophyOgre,
                ItemID.HuntressBuckler,
                ItemID.MonkBelt,
                ItemID.DD2PhoenixBow,
                ItemID.BookStaff,
                ItemID.DD2SquireDemonSword,
                ItemID.MonkStaffT1,
                ItemID.MonkStaffT2,
                ItemID.DD2PetGhost
            );

            // Betsy
            CreateTreasureGroupRecipe(ItemID.BossBagBetsy,
                ItemID.BetsyWings,
                ItemID.DD2SquireBetsySword,
                ItemID.ApprenticeStaffT3,
                ItemID.MonkStaffT3,
                ItemID.DD2BetsyBow
            );

            // Mourning Wood
            CreateTreasureGroupRecipe(ItemID.MourningWoodTrophy,
                ItemID.SpookyHook,
                ItemID.SpookyTwig,
                ItemID.StakeLauncher,
                ItemID.CursedSapling,
                ItemID.NecromanticScroll
            );

            // Pumpking
            CreateTreasureGroupRecipe(ItemID.PumpkingTrophy,
                ItemID.TheHorsemansBlade,
                ItemID.BatScepter,
                ItemID.RavenStaff,
                ItemID.CandyCornRifle,
                ItemID.JackOLanternLauncher,
                ItemID.BlackFairyDust,
                ItemID.ScytheWhip
            );

            // Everscream
            CreateTreasureGroupRecipe(ItemID.EverscreamTrophy,
                ItemID.ChristmasTreeSword,
                ItemID.ChristmasHook,
                ItemID.Razorpine,
                ItemID.FestiveWings
            );

            // Santa NK1
            CreateTreasureGroupRecipe(ItemID.SantaNK1Trophy,
                ItemID.ElfMelter,
                ItemID.ChainGun
            );

            // Ice Queen
            CreateTreasureGroupRecipe(ItemID.IceQueenTrophy,
                ItemID.BlizzardStaff,
                ItemID.SnowmanCannon,
                ItemID.NorthPole,
                ItemID.BabyGrinchMischiefWhistle,
                ItemID.ReindeerBells
            );

            // Saucer
            CreateTreasureGroupRecipe(ItemID.MartianSaucerTrophy,
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

            // Flying Dutchman
            CreateTreasureGroupRecipe(ItemID.FlyingDutchmanTrophy,
                ItemID.LuckyCoin,
                ItemID.DiscountCard,
                ItemID.CoinGun,
                ItemID.PirateStaff,
                ItemID.GoldRing,
                ItemID.Cutlass,
                ItemID.PirateMinecart
            );
        }

        private static void AddBiomeKeyRecipes()
        {
            RecipeHelper.CreateSimpleRecipe(ItemID.CrimsonKey, ItemID.VampireKnives, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
            RecipeHelper.CreateSimpleRecipe(ItemID.CorruptionKey, ItemID.ScourgeoftheCorruptor, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
            RecipeHelper.CreateSimpleRecipe(ItemID.JungleKey, ItemID.PiranhaGun, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
            RecipeHelper.CreateSimpleRecipe(ItemID.FrozenKey, ItemID.StaffoftheFrostHydra, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
            RecipeHelper.CreateSimpleRecipe(ItemID.HallowedKey, ItemID.RainbowGun, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
            RecipeHelper.CreateSimpleRecipe(ItemID.DungeonDesertKey, ItemID.StormTigerStaff, TileID.MythrilAnvil, disableDecraft: true, conditions: Condition.DownedPlantera);
        }

        private static void AddGrabBagRecipes()
        {
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.DogWhistle, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.Toolbox, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.HandWarmer, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.RedRyder, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneSword, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.CandyCaneHook, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.Present, ItemID.FruitcakeChakram, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            
            RecipeHelper.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.UnluckyYarn, TileID.WorkBenches, ingredientAmount: 10, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.BatHook, TileID.WorkBenches, ingredientAmount: 25, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.GoodieBag, ItemID.RottenEgg, TileID.WorkBenches, ingredientAmount: 2, resultAmount: 25, disableDecraft: true);
            
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Daybloom, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Moonglow, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Blinkroot, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Waterleaf, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Deathweed, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Fireblossom, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(ItemID.HerbBag, ItemID.Shiverthorn, TileID.WorkBenches, resultAmount: 5, disableDecraft: true);
        }

        private static void AddCrateRecipes()
        {
            //wooden
            CreateCrateRecipe(ItemID.SailfishBoots, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.TsunamiInABottle, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Extractinator, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Aglet, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.CordageGuide, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Umbrella, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.ClimbingClaws, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Radar, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.WoodenBoomerang, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.WandofSparking, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard, conditions: Condition.NotRemixWorld);
            CreateCrateRecipe(ItemID.Spear, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Blowpipe, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.PortableStool, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            //CreateCrateRecipe(ItemID.BabyBirdStaff, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.SunflowerMinecart, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.LadybugMinecart, ItemID.WoodenCrate, 5, ItemID.WoodenCrateHard);
            CreateCrateRecipe(ItemID.Anchor, -1, 5, ItemID.WoodenCrateHard);

            //iron
            CreateCrateRecipe(ItemID.FalconBlade, ItemID.IronCrate, 5, ItemID.IronCrateHard);
            CreateCrateRecipe(ItemID.TartarSauce, ItemID.IronCrate, 5, ItemID.IronCrateHard);
            CreateCrateRecipe(ItemID.GingerBeard, ItemID.IronCrate, 5, ItemID.IronCrateHard);
            CreateCrateRecipe(ItemID.CloudinaBottle, ItemID.IronCrate, 3, ItemID.IronCrateHard);


            //gold
            CreateCrateRecipe(ItemID.BandofRegeneration, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.MagicMirror, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.FlareGun, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.HermesBoots, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.ShoeSpikes, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.Mace, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.LifeCrystal, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.HardySaddle, -1, 2, ItemID.GoldenCrateHard);
            CreateCrateRecipe(ItemID.EnchantedSword, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard);

            CreateCrateRecipe(ItemID.Sundial, ItemID.GoldenCrate, 2, ItemID.GoldenCrateHard); //actually should be hm but fuck it

            //jungle
            CreateCrateRecipe(ItemID.AnkletoftheWind, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.Boomstick, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.FeralClaws, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.StaffofRegrowth, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.FiberglassFishingPole, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.BeeMinecart, ItemID.JungleFishingCrate, 3, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.Seaweed, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.FlowerBoots, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);
            CreateCrateRecipe(ItemID.HoneyDispenser, ItemID.JungleFishingCrate, 5, ItemID.JungleFishingCrateHard);

            //sky
            CreateCrateRecipe(ItemID.ShinyRedBalloon, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);
            CreateCrateRecipe(ItemID.Starfury, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);
            CreateCrateRecipe(ItemID.CreativeWings, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);
            CreateCrateRecipe(ItemID.SkyMill, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);
            CreateCrateRecipe(ItemID.LuckyHorseshoe, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);
            CreateCrateRecipe(ItemID.CelestialMagnet, ItemID.FloatingIslandFishingCrate, 3, ItemID.FloatingIslandFishingCrateHard);

            //corrupt
            CreateCrateRecipe(ItemID.BallOHurt, ItemID.CorruptFishingCrate, 3, ItemID.CorruptFishingCrateHard);
            CreateCrateRecipe(ItemID.BandofStarpower, ItemID.CorruptFishingCrate, 3, ItemID.CorruptFishingCrateHard);
            CreateCrateRecipe(ItemID.ShadowOrb, ItemID.CorruptFishingCrate, 3, ItemID.CorruptFishingCrateHard);
            CreateCrateRecipe(ItemID.Musket, ItemID.CorruptFishingCrate, 3, ItemID.CorruptFishingCrateHard);
            CreateCrateRecipe(ItemID.Vilethorn, ItemID.CorruptFishingCrate, 3, ItemID.CorruptFishingCrateHard);

            //crimson
            CreateCrateRecipe(ItemID.TheUndertaker, ItemID.CrimsonFishingCrate, 5, ItemID.CrimsonFishingCrateHard);
            CreateCrateRecipe(ItemID.TheRottedFork, ItemID.CrimsonFishingCrate, 5, ItemID.CrimsonFishingCrateHard);
            CreateCrateRecipe(ItemID.CrimsonRod, ItemID.CrimsonFishingCrate, 5, ItemID.CrimsonFishingCrateHard);
            CreateCrateRecipe(ItemID.PanicNecklace, ItemID.CrimsonFishingCrate, 5, ItemID.CrimsonFishingCrateHard);
            CreateCrateRecipe(ItemID.CrimsonHeart, ItemID.CrimsonFishingCrate, 5, ItemID.CrimsonFishingCrateHard);

            //hallow

            //dungeon
            CreateCrateRecipe(ItemID.WaterBolt, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.Muramasa, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.CobaltShield, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.MagicMissile, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.AquaScepter, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey, conditions: Condition.NotRemixWorld);
            CreateCrateRecipe(ItemID.Valor, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.Handgun, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.ShadowKey, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.BlueMoon, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.BoneWelder, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.AlchemyTable, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);
            CreateCrateRecipe(ItemID.BewitchingTable, ItemID.DungeonFishingCrate, 3, ItemID.DungeonFishingCrateHard, ItemID.GoldenKey);

            //frozen crate
            CreateCrateRecipe(ItemID.SnowballCannon, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard, conditions: Condition.NotRemixWorld);
            CreateCrateRecipe(ItemID.BlizzardinaBottle, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.IceBlade, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.IceSkates, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.IceMirror, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.FlurryBoots, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.IceBoomerang, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.IceMachine, ItemID.FrozenCrate, 3, ItemID.FrozenCrateHard);
            CreateCrateRecipe(ItemID.Fish, ItemID.FrozenCrate, 5, ItemID.FrozenCrateHard);

            //oasis crate
            CreateCrateRecipe(ItemID.SandBoots, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.AncientChisel, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.ThunderSpear, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.ScarabFishingRod, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.ThunderStaff, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.CatBast, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.MagicConch, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.MysticCoilSnake, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.DesertMinecart, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.EncumberingStone, ItemID.OasisCrate, 3, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.FlyingCarpet, ItemID.OasisCrate, 5, ItemID.OasisCrateHard);
            CreateCrateRecipe(ItemID.SandstorminaBottle, ItemID.OasisCrate, 5, ItemID.OasisCrateHard);

            //obsidian
            CreateCrateRecipe(ItemID.DarkLance, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey);
            CreateCrateRecipe(ItemID.HellwingBow, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey);
            CreateCrateRecipe(ItemID.Flamelash, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey);
            CreateCrateRecipe(ItemID.FlowerofFire, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey, conditions: Condition.NotRemixWorld);
            CreateCrateRecipe(ItemID.Sunfury, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey);
            CreateCrateRecipe(ItemID.TreasureMagnet, ItemID.LavaCrate, 3, ItemID.LavaCrateHard, ItemID.ShadowKey);

            CreateCrateRecipe(ItemID.LavaCharm, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.HellCake, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.OrnateShadowKey, ItemID.LavaCrate, 5, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.SuperheatedBlood, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.FlameWakerBoots, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.LavaFishingHook, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.HellMinecart, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.WetBomb, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);
            CreateCrateRecipe(ItemID.DemonConch, ItemID.LavaCrate, 3, ItemID.LavaCrateHard);

            // ocean crate
            CreateCrateRecipe(ItemID.Trident, ItemID.OceanCrate, 3, ItemID.OceanCrateHard);
            CreateCrateRecipe(ItemID.BreathingReed, ItemID.OceanCrate, 3, ItemID.OceanCrateHard);
            CreateCrateRecipe(ItemID.Flipper, ItemID.OceanCrate, 3, ItemID.OceanCrateHard);
            CreateCrateRecipe(ItemID.FloatingTube, ItemID.OceanCrate, 3, ItemID.OceanCrateHard);
            CreateCrateRecipe(ItemID.WaterWalkingBoots, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
            CreateCrateRecipe(ItemID.SharkBait, ItemID.OceanCrate, 5, ItemID.OceanCrateHard);
        }

        private static void CreateCrateRecipe(int result, int crate, int crateAmount, int hardmodeCrate, int extraItem = -1, params Condition[] conditions)
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
                foreach (Condition condition in conditions)
                {
                    recipe.AddCondition(condition);
                }
                recipe.DisableDecraft();
                recipe.Register();
            }

            if (hardmodeCrate != -1)
            {
                var recipe = Recipe.Create(result);
                recipe.AddIngredient(hardmodeCrate, crateAmount);
                if (extraItem != -1)
                {
                    recipe.AddIngredient(extraItem);
                }
                recipe.AddTile(TileID.WorkBenches);
                foreach (Condition condition in conditions)
                {
                    recipe.AddCondition(condition);
                }
                recipe.DisableDecraft();
                recipe.Register();
            }
        }

        private static void CreateTreasureGroupRecipe(int input, params int[] outputs)
        {
            foreach (int output in outputs)
            {
                RecipeHelper.CreateSimpleRecipe(input, output, TileID.Solidifier, disableDecraft: true);
            }
        }
    }
}
