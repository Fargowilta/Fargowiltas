using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Utilities;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Common.Systems.Recipes
{
    public class NPCRecipeSystem : ModSystem
    {
        internal static int AnyCaughtNPC;
        internal static int AnyCaughtSlime;
        public override void AddRecipeGroups()
        {
            int[] townies = CaughtNPCItem.CaughtTownies.Values.ToArray();
            int[] slimes = [ModContent.Find<ModItem>("Fargowiltas", "NerdySlime").Type, ModContent.Find<ModItem>("Fargowiltas", "CoolSlime").Type,
            ModContent.Find<ModItem>("Fargowiltas", "ElderSlime").Type, ModContent.Find<ModItem>("Fargowiltas", "ClumsySlime").Type,
            ModContent.Find<ModItem>("Fargowiltas", "DivaSlime").Type, ModContent.Find<ModItem>("Fargowiltas", "MysticSlime").Type,
            ModContent.Find<ModItem>("Fargowiltas", "SurlySlime").Type, ModContent.Find<ModItem>("Fargowiltas", "SquireSlime").Type];

            for (int i = 0; i < slimes.Length; i++)
            {
                List<int> temp = townies.ToList();
                temp.Remove(slimes[i]);
                townies = temp.ToArray();
            }
            var group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CaughtNPC"), townies);
            AnyCaughtNPC = RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtNPC", group);

            var groupSlimes = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CaughtSlime"), slimes);
            AnyCaughtSlime = RecipeGroup.RegisterGroup("Fargowiltas:AnyCaughtSlime", groupSlimes);
        }

        public override void AddRecipes()
        {
            AddNPCRecipes();
            AddSkeletonMerchantNPCRecipes();
            AddTravellingMerchantNPCRecipes();
        }

        private static void AddNPCRecipes()
        {
            var recipe = Recipe.Create(ItemID.FleshBlock, 25);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.MeatGrinder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.DeepRedPaint, 20);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.DyeVat);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BloodbathDye, 2);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.DyeVat);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.WallSkeleton);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.BoneWelder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.HangingSkeleton);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.BoneWelder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Catacomb);
            recipe.AddRecipeGroup(AnyCaughtNPC);
            recipe.AddTile(TileID.BoneWelder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BluePaint, 20);
            recipe.AddIngredient(CaughtNPCItem.CaughtTownies[NPCID.Truffle]);
            recipe.AddTile(TileID.DyeVat);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(CaughtNPCItem.CaughtTownies[ModContent.NPCType<NPCs.Squirrel>()]);
            recipe.AddRecipeGroup(RecipeGroups.AnySquirrel);
            recipe.AddIngredient(ItemID.TopHat);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.TravellingMerchant]);
            recipe.AddIngredient(null, "Merchant");
            recipe.AddIngredient(ItemID.GoldCoin, 50);
            recipe.AddIngredient(ItemID.BlueDye);
            recipe.AddTile(TileID.DyeVat);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.LeafWand);
            recipe.AddIngredient(null, "Dryad");
            recipe.AddTile(TileID.LivingLoom);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.TruffleWorm);
            recipe.AddIngredient(null, "Truffle");
            recipe.AddIngredient(ItemID.EnchantedNightcrawler);
            recipe.AddTile(TileID.Autohammer);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.DyeTradersScimitar);
            recipe.AddIngredient(null, "DyeTrader");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.AleThrowingGlove);
            recipe.AddIngredient(null, "Tavernkeep");
            recipe.AddIngredient(ItemID.Ale, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.StylistKilLaKillScissorsIWish);
            recipe.AddIngredient(null, "Stylist");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PainterPaintballGun);
            recipe.AddIngredient(null, "Painter");
            recipe.AddIngredient(ItemID.WoodenBow);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.TaxCollectorsStickOfDoom);
            recipe.AddIngredient(null, "TaxCollector");
            recipe.AddIngredient(ItemID.WoodenSword);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PrincessWeapon);
            recipe.AddIngredient(null, "Princess");
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.CombatWrench);
            recipe.AddIngredient(null, "Mechanic");
            recipe.AddIngredient(ItemID.WoodenBoomerang);
            recipe.AddTile(TileID.DemonAltar);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.FishermansGuide);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.WeatherRadio);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Sextant);
            recipe.AddIngredient(null, "Angler");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.SliceOfCake);
            recipe.AddIngredient(ItemID.FoodPlatter);
            recipe.AddIngredient(null, "PartyGirl");
            recipe.AddTile(TileID.Furnaces);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Gel, 10);
            recipe.AddRecipeGroup(AnyCaughtSlime);
            recipe.AddTile(TileID.Solidifier);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PinkGel, 5);
            recipe.AddIngredient(null, "SurlySlime");
            recipe.AddTile(TileID.Solidifier);
            recipe.DisableDecraft();
            recipe.Register();
        }

        private static void AddSkeletonMerchantNPCRecipes()
        {
            var recipe = Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.TravellingMerchant]);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddTile(TileID.MeatGrinder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Bone, 25);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddTile(TileID.BoneWelder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlueCounterweight);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.BlueDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.RedCounterweight);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.RedDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PurpleCounterweight);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.PurpleDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.GreenCounterweight);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.GreenDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Gradient);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 40);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.FormatC);
            recipe.AddIngredient(null, "SkeletonMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 40);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.MagicLantern);
            recipe.AddIngredient(null, "SkeletonMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();
        }

        private static void AddTravellingMerchantNPCRecipes()
        {
            var recipe = Recipe.Create(CaughtNPCItem.CaughtTownies[NPCID.SkeletonMerchant]);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(TileID.BoneWelder);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.DynastyWood, 500);
            recipe.AddIngredient(ItemID.Wood, 500);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddTile(TileID.CookingPots);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.UltrabrightTorch, 200);
            recipe.AddIngredient(ItemID.Torch, 200);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            // Common items - 1 merchant, 2x price
            recipe = Recipe.Create(ItemID.Stopwatch);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.LifeformAnalyzer);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.DPSMeter);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            // Uncommon - 1 merchant, 2x price
            recipe = Recipe.Create(ItemID.Katana);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.NotRemixWorld);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.ActuationAccessory);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.Actuator, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PortableCementMixer);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.BuilderPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PaintSprayer);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.BuilderPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.ExtendoGrip);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.BuilderPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BrickLayer);
            recipe.AddIngredient(null, "TravellingMerchant");
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(ItemID.BuilderPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            // Rare - 2 merchant, 2x price
            recipe = Recipe.Create(ItemID.Code1);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.DownedEyeOfCthulhu);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Code2);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 50);
            recipe.AddIngredient(ItemID.Code1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.DownedMechBossAny);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.ZapinatorGray);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 34);
            recipe.AddIngredient(ItemID.SpaceGun);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.ZapinatorOrange);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin);
            recipe.AddIngredient(ItemID.ZapinatorGray);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.CelestialWand);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 2);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Gi);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 4);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.GypsyRobe);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.MagicHat);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 6);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Revolver);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.SmashedShadowOrb);
            recipe.DisableDecraft();
            recipe.Register();

            // Very rare - 2 merchant, 2x price
            recipe = Recipe.Create(ItemID.BambooLeaf);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 2);
            recipe.AddIngredient(ItemID.BambooBlock, 25);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BedazzledNectar);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 2);
            recipe.AddIngredient(ItemID.TreeNymphButterfly);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.ExoticEasternChewToy);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 2);
            recipe.AddIngredient(ItemID.Cactus, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BirdieRattle);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 2);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.CompanionCube);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.SittingDucksFishingRod);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 70);
            recipe.AddRecipeGroup(RecipeGroups.AnyDuck);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.DownedSkeletron);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.DiamondRing);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.PlatinumCoin, 4);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.WaterGun);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 3);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.PulseBow);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 90);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.DownedMechBossAll);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.YellowCounterweight);
            recipe.AddIngredient(null, "TravellingMerchant", 2);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.YellowDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            // Extremely rare - 4 merchant, 2x price
            recipe = Recipe.Create(ItemID.BouncingShield);
            recipe.AddIngredient(null, "TravellingMerchant", 4);
            recipe.AddIngredient(ItemID.GoldCoin, 70);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.Gatligator);
            recipe.AddIngredient(null, "TravellingMerchant", 4);
            recipe.AddIngredient(ItemID.GoldCoin, 70);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemID.BlackCounterweight);
            recipe.AddIngredient(null, "TravellingMerchant", 4);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.BlackDye);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();

            // Extraordinarily rare - 5 merchant, 2x price
            recipe = Recipe.Create(ItemID.AngelHalo);
            recipe.AddIngredient(null, "TravellingMerchant", 5);
            recipe.AddIngredient(ItemID.GoldCoin, 80);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.DisableDecraft();
            recipe.Register();
        }
    }
}
