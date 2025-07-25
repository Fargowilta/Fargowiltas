using Fargowiltas.Content.Items.Ammos.Bullets;
using Fargowiltas.Content.Items.Tiles;
using Fargowiltas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Common.Systems.Recipes
{
    public class RecipeGroups : ModSystem
    {
        internal static int AnyGoldBar;
        internal static int AnyDemonAltar, AnyAnvil, AnyHMAnvil, AnyForge, AnyBookcase, AnyCookingPot, AnyTombstone, AnyWoodenTable, AnyWoodenChair, AnyWoodenSink;
        internal static int AnyButterfly, AnySquirrel, AnyCommonFish, AnyDragonfly, AnyBird, AnyDuck;
        internal static int AnyFoodT2, AnyFoodT3, AnyGemRobe;
        internal static int AnyWoodCrate, AnyIronCrate, AnyGoldCrate, AnyJungleCrate, AnySkyCrate, AnyCorruptCrate, AnyCrimsonCrate, /*AnyHallowedCrate,*/ AnyDungeonCrate, AnyFrozenCrate, AnySandCrate, AnyLavaCrate, AnyOceanCrate;

        public override void AddRecipeGroups()
        {
            //Silver or Tungsten Pouch (Used in Souls Mod)
            var group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ModContent.ItemType<SilverPouch>()), ModContent.ItemType<SilverPouch>(), ModContent.ItemType<TungstenPouch>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnySilverPouch", group);

            //gold bar
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.GoldBar), ItemID.GoldBar, ItemID.PlatinumBar);
            AnyGoldBar = RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldBar", group);

            //demonite bar
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.DemoniteBar), ItemID.DemoniteBar, ItemID.CrimtaneBar);
            AnyGoldBar = RecipeGroup.RegisterGroup("Fargowiltas:AnyDemoniteBar", group);

            //demon altar
            List<int> demonaltars = new() { ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>() };
            if (ModLoader.HasMod("ImproveGame"))
                demonaltars.AddRange([ModLoader.GetMod("ImproveGame").Find<ModItem>("DemonAltarItem").Type, ModLoader.GetMod("ImproveGame").Find<ModItem>("CrimsonAltarItem").Type]);
            if (ModLoader.HasMod("CalValEX"))
                demonaltars.AddRange([ModLoader.GetMod("CalValEX").Find<ModItem>("MoulderingAltarItem").Type, ModLoader.GetMod("CalValEX").Find<ModItem>("VisceralAltarItem").Type]);
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ModContent.ItemType<DemonAltar>()), demonaltars.ToArray());
            AnyDemonAltar = RecipeGroup.RegisterGroup("Fargowiltas:AnyDemonAltar", group);

            //iron anvil
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.IronAnvil), ItemID.IronAnvil, ItemID.LeadAnvil);
            AnyAnvil = RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //anvil HM
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.MythrilAnvil), ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            AnyHMAnvil = RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            //forge HM
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.AdamantiteForge), ItemID.AdamantiteForge, ItemID.TitaniumForge);
            AnyForge = RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //book cases
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Bookcase),
                ItemID.Bookcase, ItemID.BlueDungeonBookcase, ItemID.BoneBookcase, ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase, ItemID.CrystalBookCase, ItemID.DynastyBookcase, ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase, ItemID.FrozenBookcase, ItemID.GlassBookcase, ItemID.GoldenBookcase,
                ItemID.GothicBookcase, ItemID.GraniteBookcase, ItemID.GreenDungeonBookcase, ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase, ItemID.MarbleBookcase, ItemID.MeteoriteBookcase, ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase, ItemID.PalmWoodBookcase, ItemID.PearlwoodBookcase, ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase, ItemID.RichMahoganyBookcase, ItemID.ShadewoodBookcase, ItemID.SkywareBookcase,
                ItemID.SlimeBookcase, ItemID.SpookyBookcase, ItemID.SteampunkBookcase, ItemID.AshWoodBookcase
            );
            //book cases
            /*
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Bookcase),
                ContentSamples.ItemsByType.Keys.Where(i => (ContentSamples.ItemsByType[i].Name.Contains("Bookcase"))).Cast<int>().ToArray()
            );
            */
            AnyBookcase = RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);

            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.CookingPot), ItemID.CookingPot, ItemID.Cauldron);
            AnyCookingPot = RecipeGroup.RegisterGroup("Fargowiltas:AnyCookingPot", group);

            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("LegacyMisc.87", true),
                ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly,
                ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly,
                ItemID.HellButterfly
            );
            AnyButterfly = RecipeGroup.RegisterGroup("Fargowiltas:AnyButterfly", group);

            //vanilla squirrels
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Squirrel),
                ItemID.Squirrel,
                ItemID.SquirrelRed
            );
            AnySquirrel = RecipeGroup.RegisterGroup("Fargowiltas:AnySquirrel", group);

            //vanilla squirrels
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CommonFish"),
                ItemID.AtlanticCod,
                ItemID.Bass,
                ItemID.Trout,
                ItemID.RedSnapper,
                ItemID.Salmon,
                ItemID.Tuna
            //ItemID.GoldenCarp
            );
            AnyCommonFish = RecipeGroup.RegisterGroup("Fargowiltas:AnyCommonFish", group);

            //vanilla dragonfly
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("LegacyMisc.105", true),
                //ItemID.GoldDragonfly,
                ItemID.BlackDragonfly,
                ItemID.BlueDragonfly,
                ItemID.GreenDragonfly,
                ItemID.OrangeDragonfly,
                ItemID.RedDragonfly,
                ItemID.YellowDragonfly
            );
            AnyDragonfly = RecipeGroup.RegisterGroup("Fargowiltas:AnyDragonfly", group);

            //vanilla birds
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Bird),
                ItemID.Bird,
                //ItemID.GoldBird,
                ItemID.BlueJay,
                ItemID.Cardinal,
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe,
                ItemID.Seagull
            );
            AnyBird = RecipeGroup.RegisterGroup("Fargowiltas:AnyBird", group);

            //vanilla ducks
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Duck),
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe
            );
            AnyDuck = RecipeGroup.RegisterGroup("Fargowiltas:AnyDuck", group);

            //tombstones
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Tombstone),
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
            AnyTombstone = RecipeGroup.RegisterGroup("Fargowiltas:AnyTombstone", group);
           
            //wooden tables
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.WoodenTable),
                ItemID.WoodenTable,
                ItemID.BorealWoodTable,
                ItemID.AshWoodTable,
                ItemID.RichMahoganyTable,
                ItemID.LivingWoodTable,
                ItemID.PearlwoodTable,
                ItemID.SpookyTable,
                ItemID.EbonwoodTable,
                ItemID.ShadewoodTable,
                ItemID.PalmWoodTable,
                ItemID.DynastyTable,
                ItemID.BambooTable
            );
            AnyWoodenTable = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodenTable", group);

            //wooden chairs
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.WoodenChair),
                ItemID.WoodenChair,
                ItemID.BorealWoodChair,
                ItemID.AshWoodChair,
                ItemID.RichMahoganyChair,
                ItemID.LivingWoodChair,
                ItemID.PearlwoodChair,
                ItemID.SpookyChair,
                ItemID.EbonwoodChair,
                ItemID.ShadewoodChair,
                ItemID.PalmWoodChair,
                ItemID.DynastyChair,
                ItemID.BambooChair
            );
            AnyWoodenChair = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodenChair", group);
           
            //wooden sinks
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.WoodenSink),
                ItemID.WoodenSink,
                ItemID.BorealWoodSink,
                ItemID.AshWoodSink,
                ItemID.RichMahoganySink,
                ItemID.LivingWoodSink,
                ItemID.PearlwoodSink,
                ItemID.SpookySink,
                ItemID.EbonwoodSink,
                ItemID.ShadewoodSink,
                ItemID.PalmWoodSink,
                ItemID.DynastySink,
                ItemID.BambooSink
            );
            AnyWoodenSink = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodenSink", group);

            //t2 foods
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("FoodT2"),
                ItemID.BowlofSoup,
                ItemID.CookedShrimp,
                ItemID.PumpkinPie,
                ItemID.Sashimi,
                ItemID.Escargot,
                ItemID.FroggleBunwich,
                ItemID.GrubSoup,
                ItemID.LobsterTail,
                ItemID.MonsterLasagna,
                ItemID.PrismaticPunch,
                ItemID.RoastedDuck,
                ItemID.SeafoodDinner,
                ItemID.BananaSplit,
                ItemID.ChickenNugget,
                ItemID.ChocolateChipCookie,
                ItemID.CreamSoda,
                ItemID.FriedEgg,
                ItemID.Fries,
                ItemID.IceCream,
                ItemID.Nachos,
                ItemID.ShrimpPoBoy,
                ItemID.CoffeeCup
            );
            AnyFoodT2 = RecipeGroup.RegisterGroup("Fargowiltas:AnyFoodT2", group);

            //t3 foods
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("FoodT3"),
                ItemID.GoldenDelight,
                ItemID.GrapeJuice,
                ItemID.Milkshake,
                ItemID.Pizza,
                ItemID.Spaghetti,
                ItemID.Steak,
                ItemID.Hotdog,
                ItemID.ApplePie,
                ItemID.Bacon,
                ItemID.GingerbreadCookie,
                ItemID.BBQRibs,
                ItemID.SugarCookie,
                ItemID.ChristmasPudding
            );
            AnyFoodT3 = RecipeGroup.RegisterGroup("Fargowiltas:AnyFoodT3", group);

            //gem robes
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("GemRobe"),
                ItemID.AmberRobe,
                ItemID.AmethystRobe,
                ItemID.DiamondRobe,
                ItemID.EmeraldRobe,
                ItemID.RubyRobe,
                ItemID.SapphireRobe,
                ItemID.TopazRobe
            );
            AnyGemRobe = RecipeGroup.RegisterGroup("Fargowiltas:AnyGemRobe", group);

            //wooden crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("WoodenCrate"),
                ItemID.WoodenCrate,
                ItemID.WoodenCrateHard
            );
            AnyWoodCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodenCrate", group);

            //iron crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("IronCrate"),
                ItemID.IronCrate,
                ItemID.IronCrateHard
            );
            AnyIronCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyIronCrate", group);

            //gold crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("GoldenCrate"),
                ItemID.GoldenCrate,
                ItemID.GoldenCrateHard
            );
            AnyGoldCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldenCrate", group);

            //jungle crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("JungleCrate"),
                ItemID.JungleFishingCrate,
                ItemID.JungleFishingCrateHard
            );
            AnyJungleCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyJungleCrate", group);

            //sky crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("SkyCrate"),
                ItemID.FloatingIslandFishingCrate,
                ItemID.FloatingIslandFishingCrateHard
            );
            AnySkyCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnySkyCrate", group);

            //corrupt crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CorruptCrate"),
                ItemID.CorruptFishingCrate,
                ItemID.CorruptFishingCrateHard
            );
            AnyCorruptCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyCorruptCrate", group);

            //crimson crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CrimsonCrate"),
                ItemID.CrimsonFishingCrate,
                ItemID.CrimsonFishingCrateHard
            );
            AnyCrimsonCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsonCrate", group);

            /* //hallowed crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("HallowedCrate"),
                ItemID.HallowedFishingCrate,
                ItemID.HallowedFishingCrateHard
            );
            AnyHallowedCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyHallowedCrate", group); */

            //dungeon crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("DungeonCrate"),
                 ItemID.DungeonFishingCrate,
                 ItemID.DungeonFishingCrateHard
             );
            AnyDungeonCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyDungeonCrate", group);

            //frozen crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("FrozenCrate"),
                ItemID.FrozenCrate,
                ItemID.FrozenCrateHard
            );
            AnyFrozenCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyFrozenCrate", group);

            //oasis crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("SandCrate"),
                ItemID.OasisCrate,
                ItemID.OasisCrateHard
            );
            AnySandCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnySandCrate", group);

            //lava crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("LavaCrate"),
                ItemID.LavaCrate,
                ItemID.LavaCrateHard
            );
            AnyLavaCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyLavaCrate", group);

            //ocean crates
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("OceanCrate"),
                ItemID.OceanCrate,
                ItemID.OceanCrateHard
            );
            AnyOceanCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyOceanCrate", group);
        }
    }
}
