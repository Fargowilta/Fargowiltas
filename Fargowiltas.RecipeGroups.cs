using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas
{
    partial class Fargowiltas
    {
        public override void AddRecipeGroups()
        {
            CreateRecipeGroup("AnyEvilWood", new int[2]
            {
                ItemID.Ebonwood,
                ItemID.Shadewood
            });

            CreateRecipeGroup("AnyAnvil", new int[2]
            {
                ItemID.IronAnvil,
                ItemID.LeadAnvil
            });

            CreateRecipeGroup("AnyHMAnvil", new int[2]
            {
                ItemID.MythrilAnvil,
                ItemID.OrichalcumAnvil
            });

            CreateRecipeGroup("AnyForge", new int[2]
            {
                ItemID.AdamantiteForge,
                ItemID.TitaniumForge
            });

            CreateRecipeGroup("AnyBookcase", new int[31]
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

            CreateRecipeGroup("AnyArmoredBones", new int[3] {
                ItemID.BlueArmoredBonesBanner,
                ItemID.HellArmoredBonesBanner,
                ItemID.RustyArmoredBonesBanner
            });

            CreateRecipeGroup("AnyPirateBanner", new int[4] {
                ItemID.PirateDeadeyeBanner,
                ItemID.PirateCorsairBanner,
                ItemID.PirateCrossbowerBanner,
                ItemID.PirateBanner
            });

            CreateRecipeGroup("AnySlimes", new int[20] {
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
            });

            CreateRecipeGroup("AnyHallows", new int[9] {
                ItemID.PixieBanner,
                ItemID.UnicornBanner,
                ItemID.RainbowSlimeBanner,
                ItemID.GastropodBanner,
                ItemID.LightMummyBanner,
                ItemID.IlluminantBatBanner,
                ItemID.IlluminantSlimeBanner,
                ItemID.ChaosElementalBanner,
                ItemID.EnchantedSwordBanner
            });

            CreateRecipeGroup("AnyCorruptions", new int[9] {
                ItemID.EaterofSoulsBanner,
                ItemID.CorruptorBanner,
                ItemID.CorruptSlimeBanner,
                ItemID.SlimerBanner,
                ItemID.DevourerBanner,
                ItemID.WorldFeederBanner,
                ItemID.DarkMummyBanner,
                ItemID.CursedHammerBanner,
                ItemID.ClingerBanner
            });

            CreateRecipeGroup("AnyCrimsons", new int[11] {
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
                ItemID.FloatyGrossBanner
            });

            CreateRecipeGroup("AnyJungles", new int[15] {
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
                ItemID.MothBanner
            });

            CreateRecipeGroup("AnySnows", new int[13] {
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
            });

            CreateRecipeGroup("AnyDeserts", new int[14] {
                ItemID.SandSlimeBanner,
                ItemID.VultureBanner,
                ItemID.AntlionBanner,
                ItemID.MummyBanner,
                ItemID.WalkingAntlionBanner,
                ItemID.LarvaeAntlionBanner,
                ItemID.FlyingAntlionBanner,
                ItemID.TombCrawlerBanner,
                ItemID.DesertBasiliskBanner,
                ItemID.RavagerScorpionBanner,
                ItemID.DesertLamiaBanner,
                ItemID.DuneSplicerBanner,
                ItemID.DesertGhoulBanner,
                ItemID.DesertDjinnBanner
            });

            CreateRecipeGroup("AnyCaughtNPCs", new int[28] {
                ModContent.ItemType<Guide>(),
                ModContent.ItemType<Angler>(),
                ModContent.ItemType<ArmsDealer>(),
                ModContent.ItemType<Clothier>(),
                ModContent.ItemType<Cyborg>(),
                ModContent.ItemType<Demolitionist>(),
                ModContent.ItemType<Dryad>(),
                ModContent.ItemType<DyeTrader>(),
                ModContent.ItemType<GoblinTinkerer>(),
                ModContent.ItemType<Golfer>(),
                ModContent.ItemType<LumberJack>(),
                ModContent.ItemType<Mechanic>(),
                ModContent.ItemType<Merchant>(),
                ModContent.ItemType<Nurse>(),
                ModContent.ItemType<Painter>(),
                ModContent.ItemType<PartyGirl>(),
                ModContent.ItemType<Pirate>(),
                ModContent.ItemType<Princess>(),
                ModContent.ItemType<SantaClaus>(),
                ModContent.ItemType<SkeletonMerchant>(),
                ModContent.ItemType<Steampunker>(),
                ModContent.ItemType<Stylist>(),
                ModContent.ItemType<Tavernkeep>(),
                ModContent.ItemType<TaxCollector>(),
                ModContent.ItemType<TravellingMerchant>(),
                ModContent.ItemType<WitchDoctor>(),
                ModContent.ItemType<Wizard>(),
                ModContent.ItemType<Zoologist>()
            });

            CreateRecipeGroup("AnyOmnistation", new int[2]
            {
                ModContent.ItemType<Omnistation>(),
                ModContent.ItemType<Omnistation2>()
            });

            CreateRecipeGroup("AnyWoodenCrate", new int[2]
            {
                ItemID.WoodenCrate,
                ItemID.WoodenCrateHard
            });

            CreateRecipeGroup("AnyIronCrate", new int[2]
            {
                ItemID.IronCrate,
                ItemID.IronCrateHard
            });

            CreateRecipeGroup("AnyGoldenCrate", new int[2]
            {
                ItemID.GoldenCrate,
                ItemID.GoldenCrateHard
            });

            CreateRecipeGroup("AnyJungleCrate", new int[2]
            {
                ItemID.JungleFishingCrate,
                ItemID.JungleFishingCrateHard
            });

            CreateRecipeGroup("AnySkyCrate", new int[2]
            {
                ItemID.FloatingIslandFishingCrate,
                ItemID.FloatingIslandFishingCrateHard
            });

            CreateRecipeGroup("AnyCorruptCrate", new int[2]
            {
                ItemID.CorruptFishingCrate,
                ItemID.CorruptFishingCrateHard
            });

            CreateRecipeGroup("AnyCrimsonCrate", new int[2]
            {
                ItemID.CrimsonFishingCrate,
                ItemID.CrimsonFishingCrateHard
            });

            CreateRecipeGroup("AnyHallowCrate", new int[2]
            {
                ItemID.HallowedFishingCrate,
                ItemID.HallowedFishingCrateHard
            });

            CreateRecipeGroup("AnyDungeonCrate", new int[2]
            {
                ItemID.DungeonFishingCrate,
                ItemID.DungeonFishingCrateHard
            });

            CreateRecipeGroup("AnyFrozenCrate", new int[2]
            {
                ItemID.FrozenCrate,
                ItemID.FrozenCrateHard
            });

            CreateRecipeGroup("AnyOasisCrate", new int[2]
            {
                ItemID.OasisCrate,
                ItemID.OasisCrateHard
            });

            CreateRecipeGroup("AnyObsidianCrate", new int[2]
            {
                ItemID.LavaCrate,
                ItemID.LavaCrateHard
            });

            CreateRecipeGroup("AnyOceanCrate", new int[2]
            {
                ItemID.OceanCrate,
                ItemID.OceanCrateHard
            });
        }

        public static RecipeGroup CreateRecipeGroup(string internalName, int[] items, bool autoRegister = true)
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Language.GetTextValue("Mods.Fargowiltas.RecipeGroups" + internalName), items);

            if (autoRegister)
            {
                RecipeGroup.RegisterGroup("Fargowiltas:" + internalName, group);
            }

            return group;
        }
    }
}