using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Fargowiltas.Items;
using Fargowiltas.NPCs;
using Fargowiltas.Projectiles;
using System.Linq;
using System.Collections.Generic;

// why
using Terraria.IO;
using System.IO;

namespace Fargowiltas
{
    class Fargowiltas : Mod
    {
        internal static ModHotKey CheckListKey;
        internal static ModHotKey HomeKey;
        internal Soulcheck SoulCheck;
        public UserInterface customResources;

        //loaded
        internal bool blueMagicLoaded;
        internal bool calamityLoaded;
        internal bool cookieLoaded;
        internal bool crystiliumLoaded;
        internal bool ersionLoaded;
        internal bool gabeLoaded;
        internal bool grealmLoaded;
        internal bool joostLoaded;
        internal bool nightmaresLoaded;
        internal bool pumpkingLoaded;
        internal bool sacredToolsLoaded;
        internal bool shroomsLoaded;
        internal bool spiritLoaded;
        internal bool terraCompLoaded;
        internal bool thoriumLoaded;
        internal bool tremorLoaded;
        internal bool xervosLoaded;
        internal bool w1kLoaded;
        internal bool waterBiomeLoaded;
        internal bool ancientsLoaded;
        internal bool btfaLoaded;
        internal bool FKTModSettingsLoaded;

        //multi summon
        internal bool multiSlime;
        internal static int slimeKills;
        internal static int slimeNum;
        internal static int slimeSpawned;

        internal bool multiEye;
        internal static int eyeKills;
        internal static int eyeNum;
        internal static int eyeSpawned;

        internal bool multiWorm;
        internal static int wormKills;
        internal static int wormNum;
        internal static int wormSpawned;

        internal bool multiBrain;
        internal static int brainKills;
        internal static int brainNum;
        internal static int brainSpawned;

        internal bool multiSkele;
        internal static int skeleKills;
        internal static int skeleNum;
        internal static int skeleSpawned;

        internal bool multiBee;
        internal static int beeKills;
        internal static int beeNum;
        internal static int beeSpawned;

        internal bool multiTwins;
        internal static int retKills;
        internal static int spazKills;
        internal static int twinsNum;
        internal static int twinsSpawned;

        internal bool multiPrime;
        internal static int primeKills;
        internal static int primeNum;
        internal static int primeSpawned;

        internal bool multiDestroy;
        internal static int destroyKills;
        internal static int destroyNum;
        internal static int destroySpawned;

        internal bool multiPlant;
        internal static int plantKills;
        internal static int plantNum;
        internal static int plantSpawned;

        internal bool multiGolem;
        internal static int golemKills;
        internal static int golemNum;
        internal static int golemSpawned;

        internal bool multiFish;
        internal static int fishKills;
        internal static int fishNum;
        internal static int fishSpawned;

        internal bool multiMoon;
        internal static int moonKills;
        internal static int moonNum;
        internal static int moonSpawned;

        internal bool multiDG;
        internal static int DGNum;
        internal static int DGKills;
        internal static int DGSpawned;

        //stoned (ID 156) is placeholder for modded debuffs
        //add more 156s after the currently existing ones (not at the actual end of array) and then overwrite them in PostSetupContent when adding buffs
        internal int[] debuffIDs =
        {156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156, 156
        , 20, 21, 22, 23, 24, 30, 31, 32, 33, 35, 36, 37, 39, 44, 46, 67, 68, 69, 70, 80, 94, 103, 120, 137, 144, 145, 148, 153, 156, 160, 163, 164, 195, 196, 197
        };

        internal static Fargowiltas instance;

        public Fargowiltas()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

        }

        public override void Load()
        {
            instance = this;
            CheckListKey = RegisterHotKey("Soul Toggles", "L");
            HomeKey = RegisterHotKey("Teleport Home", "+");

            if (!Main.dedServ)
            {

                customResources = new UserInterface();
                SoulCheck = new Soulcheck();
                Soulcheck.visible = false;
                customResources.SetState(SoulCheck);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
            "CustomBars: Custom Resource Bar",
            delegate
            {
                if (Soulcheck.visible)
                {
                    //Update CustomBars
                    customResources.Update(Main._drawInterfaceGameTime);
                    SoulCheck.Draw(Main.spriteBatch);
                }
                return true;
            },
            InterfaceScaleType.UI)
            );
        }

        //bool sheet
        public override void PostSetupContent()
        {
            try
            {
                blueMagicLoaded = ModLoader.GetMod("Bluemagic") != null;
                calamityLoaded = ModLoader.GetMod("CalamityMod") != null;
                cookieLoaded = ModLoader.GetMod("CookieMod") != null;
                crystiliumLoaded = ModLoader.GetMod("CrystiliumMod") != null;
                ersionLoaded = ModLoader.GetMod("Ersion") != null;
                gabeLoaded = ModLoader.GetMod("GabeHasWonsMod") != null;
                grealmLoaded = ModLoader.GetMod("GRealm") != null;
                joostLoaded = ModLoader.GetMod("JoostMod") != null;
                nightmaresLoaded = ModLoader.GetMod("TrueEater") != null;
                pumpkingLoaded = ModLoader.GetMod("Pumpking") != null;
                sacredToolsLoaded = ModLoader.GetMod("SacredTools") != null;
                shroomsLoaded = ModLoader.GetMod("Shrooms") != null;
                spiritLoaded = ModLoader.GetMod("SpiritMod") != null;
                terraCompLoaded = ModLoader.GetMod("TerraCompilation") != null;
                thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
                tremorLoaded = ModLoader.GetMod("Tremor") != null;
                xervosLoaded = ModLoader.GetMod("XervosMod") != null;
                w1kLoaded = ModLoader.GetMod("W1KModRedux") != null;
                waterBiomeLoaded = ModLoader.GetMod("WaterBiomeMod") != null;
                ancientsLoaded = ModLoader.GetMod("EchoesoftheAncients") != null;
                btfaLoaded = ModLoader.GetMod("ForgottenMemories") != null;

                FKTModSettingsLoaded = ModLoader.GetMod("FKTModSettings") != null;

                //multi summons
                multiSlime = false;
                slimeNum = 0;
                slimeKills = 0;
                slimeSpawned = 0;

                multiEye = false;
                eyeNum = 0;
                eyeKills = 0;
                eyeSpawned = 0;

                multiWorm = false;
                wormNum = 0;
                wormKills = 0;
                wormSpawned = 0;

                multiBrain = false;
                brainNum = 0;
                brainKills = 0;
                brainSpawned = 0;

                multiSkele = false;
                skeleNum = 0;
                skeleKills = 0;
                skeleSpawned = 0;

                multiBee = false;
                beeNum = 0;
                beeKills = 0;
                beeSpawned = 0;

                multiTwins = false;
                retKills = 0;
                spazKills = 0;
                twinsNum = 0;
                twinsSpawned = 0;

                multiPrime = false;
                primeNum = 0;
                primeKills = 0;
                primeSpawned = 0;

                multiDestroy = false;
                destroyNum = 0;
                destroyKills = 0;
                destroySpawned = 0;

                multiPlant = false;
                plantNum = 0;
                plantKills = 0;
                plantSpawned = 0;

                multiGolem = false;
                golemNum = 0;
                golemKills = 0;
                golemSpawned = 0;

                multiFish = false;
                fishNum = 0;
                fishKills = 0;
                fishSpawned = 0;

                multiMoon = false;
                moonNum = 0;
                moonKills = 0;
                moonSpawned = 0;

                multiDG = false;
                DGNum = 0;
                DGKills = 0;
                DGSpawned = 0;

                debuffIDs[0] = this.BuffType("GodEater");
                debuffIDs[1] = this.BuffType("FlamesoftheUniverse");
                debuffIDs[2] = this.BuffType("MutantNibble");
                debuffIDs[3] = this.BuffType("Asocial");
                debuffIDs[4] = this.BuffType("Bloodthirsty"); //bloodthirsty currently does nothing fyi :v
                debuffIDs[5] = this.BuffType("ClippedWings");
                debuffIDs[6] = this.BuffType("Kneecapped");
                debuffIDs[7] = this.BuffType("Defenseless");
                debuffIDs[8] = this.BuffType("Lethargic");
                debuffIDs[9] = this.BuffType("Purified");
                debuffIDs[10] = this.BuffType("Berserked");
                debuffIDs[11] = this.BuffType("Infested");
                debuffIDs[12] = this.BuffType("MarkedforDeath");
                debuffIDs[13] = this.BuffType("LivingWasteland");
                debuffIDs[14] = this.BuffType("Rotting");
                debuffIDs[15] = this.BuffType("LightningRod");
                debuffIDs[16] = this.BuffType("SqueakyToy");

            }
            catch (Exception e)
            {
                ErrorLogger.Log("Fargowiltas PostSetupContent Error: " + e.StackTrace + e.Message);
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "BananarangThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Bananarang);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "BloodyMacheteThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BloodyMachete);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "DaybreakThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.DayBreak);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "EnchantedBoomerangThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.EnchantedBoomerang);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "FlamarangThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Flamarang);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "FruitcakeChakramThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.FruitcakeChakram);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "IceBoomerangThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.IceBoomerang);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "LightDiscThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.LightDisc);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MagicDaggerThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MagicDagger);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "PaladinsHammerThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PaladinsHammer);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "PossessedHatchetThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.PossessedHatchet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "ShadowflameKnifeThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.ShadowFlameKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "ThornChakramThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.ThornChakram);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "VampireKnivesThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "WoodenBoomerangThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WoodenBoomerang);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "ToxicFlaskThrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.ToxicFlask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "FleshyDoll");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.GuideVoodooDoll);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "LihzahrdPowerCell2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.LihzahrdPowerCell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "TruffleWorm2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "CelestialSigil2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CelestialSigil);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechEye");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalEye);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechWorm");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalWorm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "MechSkull");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.MechanicalSkull);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "GoreySpine");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.BloodySpine);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "SlimyCrown");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeCrown);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "Abeemination2");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Abeemination);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "WormyFood");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WormFood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(null, "SuspiciousEye");
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SuspiciousLookingEye);
            recipe.AddRecipe();


            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CopperPickaxe);
            recipe.AddIngredient(ItemID.WoodenHammer);
            recipe.AddIngredient(ItemID.Wrench);
            recipe.AddIngredient(ItemID.WireCutter);
            recipe.AddIngredient(ItemID.EmptyBucket);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Toolbox);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bubble);
            recipe.AddIngredient(ItemID.RedHusk);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(ItemID.ShinyRedBalloon);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceBlade);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(ItemID.EnchantedSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Pumpkin, 500);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(ItemID.MagicalPumpkinSeed);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bladetongue);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Toxikarp);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Toxikarp);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.Bladetongue);
            recipe.AddRecipe();

            //BANNER recipes
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryBonesBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TallyCounter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AnomuraFungusBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GlowingMushroom, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AntlionBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AntlionMandible, 40);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WalkingAntlionBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AntlionClaw);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FlyingAntlionBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AntlionMandible, 80);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GreenSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 50);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 150);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PurpleSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.YellowSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BlackSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MotherSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 400);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PinkyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PinkGel, 999);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UmbrellaSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.UmbrellaHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 120);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SpikedIceSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 300);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 120);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SpikedJungleSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 300);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SandSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 120);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DungeonSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GoldenKey, 100);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LavaSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Cascade);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ToxicSludgeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Bezoar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Blindfold);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 300);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimslimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 300);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GastropodBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 500);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IlluminantSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 300);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RainbowSlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Gel, 5000);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BloodCrawlerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vertebrae, 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JellyfishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Glowstick, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PinkJellyfishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.JellyfishNecklace);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GreenJellyfishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Megaphone);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ChainKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DepthMeter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrawdadBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimeraBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vertebrae, 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CursedSkullBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Nazar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonMageBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Bone, 500);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DemonScythe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DevourerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.WormTooth, 500);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ZombieArm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RaincoatZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RainHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ZombieEskimoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.EskimoHood);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BloodZombieBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SharkToothNecklace);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EaterofSoulsBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RottenChunk, 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FaceMonsterBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vertebrae, 25);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FireImpBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ObsidianRose);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GiantShellyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WormBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.WhoopieCushion);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GraniteFlyerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NightVisionHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HarpyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GiantHarpyFeather);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HellbatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MagmaStone);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GreekSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.GladiatorHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemonEyeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BlackLens);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HornetBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TatteredBeeWing);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DepthMeter);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PiranhaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.RobotHat);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SalamanderBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Rally);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SharkBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DivingHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BoneSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SnowFlinxBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Compass);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadMinerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BonePickaxe);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadVikingBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.VikingHelmet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AnglerFishBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AdhesiveBandage);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryTrapperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Uzi);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ArmorPolish);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredSkeletonBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BeamSword);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ArmoredVikingBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.IceSickle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertBasiliskBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.AncientHorn);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BlackRecluseBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PoisonStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptorBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vitamins);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.FloatyGrossBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Vitamins);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DesertDjinnBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DjinnLamp);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GiantBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.TrifoldMap);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MummyMask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WerewolfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoonCharm);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.VampireBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BrokenBatWing);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DiablolistBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.InfernoFork);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.NecromancerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ShadowbeamStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RaggedCasterBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.SpectreStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WraithBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FastClock);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DarkMummyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Blindfold);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DungeonSpiritBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Ectoplasm, 200);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TortoiseBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Seaweed);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IcyMermanBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FrostStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceTortoiseBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FrozenTurtleShell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LihzahrdBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.LizardEgg);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MedusaBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MedusaHead);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MagicQuiver);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Marrow);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UnicornBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BlessedApple);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AngryNimbusBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NimbusRod);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ClownBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Bananarang, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DripplerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MoneyTrough);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoblinArcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Harpoon);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ButcherBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ButchersChainsaw);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CreatureFromTheDeepBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.NeptunesShell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DeadlySphereBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DeadlySphereStaff);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DrManFlyBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.ToxicFlask);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MothronBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.MothronWings);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PsychoBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.PsychoKnife);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ReaperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.DeathSickle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MartianScutlixGunnerBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.BrainScrambler);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedDevilBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.UnholyTrident);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.RedDevilBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FireFeather);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LavaBatBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.HelFire);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WolfBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Amarok);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JungleCreeperBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Yelets);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IceElementalBanner);
            recipe.AddIngredient(ItemID.GoldenKey, 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.FrozenKey);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DerplingBanner);
            recipe.AddIngredient(ItemID.GoldenKey, 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.JungleKey);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimsonAxeBanner);
            recipe.AddIngredient(ItemID.GoldenKey, 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.CrimsonKey);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CursedHammerBanner);
            recipe.AddIngredient(ItemID.GoldenKey, 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.CorruptionKey);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EnchantedSwordBanner);
            recipe.AddIngredient(ItemID.GoldenKey, 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.HallowedKey);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CorruptPenguinBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(ItemID.Fish);
            recipe.AddRecipe();



            //statues
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BatBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BatStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MimicBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.ChestStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrabBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.CrabStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.JellyfishBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.JellyfishStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PiranhaBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.PiranhaStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SharkBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SharkStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SkeletonBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SkeletonStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.SlimeStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SpiderBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.WallCreeperStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UnicornBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.UnicornStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DripplerBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.DripplerStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WraithBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.WraithStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.UndeadVikingBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.UndeadVikingStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MedusaBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.MedusaStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HarpyBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HarpyStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PigronBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.PigronStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GreekSkeletonBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HopliteStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GraniteGolemBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.GraniteGolemStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BloodZombieBanner);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BloodZombieStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Bomb, 99);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.BombStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.LifeCrystal, 6);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.HeartStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ManaCrystal, 6);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.StarStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.KingStatue);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Throne);
            recipe.AddIngredient(ItemID.TeleportationPotion);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(ItemID.QueenStatue);
            recipe.AddRecipe();


            //conversion
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CopperBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TinBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CopperBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SilverBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TungstenBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TungstenBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.SilverBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoldBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PlatinumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PlatinumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.GoldBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CobaltBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.PalladiumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PalladiumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CobaltBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.OrichalcumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.MythrilBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TitaniumBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.AdamantiteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemoniteBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.CrimtaneBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimtaneBar);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.DemoniteBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.TissueSample);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TissueSample);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(ItemID.ShadowScale);
            recipe.AddRecipe();
        }

        public override void AddRecipeGroups()
        {
            //drax
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Drax", new int[]
            {
                ItemID.Drax,
                ItemID.PickaxeAxe,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyDrax", group);

            if (Fargowiltas.instance.terraCompLoaded)
            {
                //cobalt
                group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Repeater", new int[]
                {
                ItemID.CobaltRepeater,
                ItemID.PalladiumRepeater,
                ModLoader.GetMod("TerraCompilation").ItemType("CobaltComp"),
                ModLoader.GetMod("TerraCompilation").ItemType("PaladiumComp"),

                });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltRepeater", group);

                //mythril
                group = new RecipeGroup(() => Lang.misc[37] + " Mythril Repeater", new int[]
                {
                ItemID.MythrilRepeater,
                ItemID.OrichalcumRepeater,
                ModLoader.GetMod("TerraCompilation").ItemType("MythrilComp"),
                ModLoader.GetMod("TerraCompilation").ItemType("OrichalcumComp"),
                });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilRepeater", group);

                //adamantite
                group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Repeater", new int[]
                {
                ItemID.AdamantiteRepeater,
                ItemID.TitaniumRepeater,
                ModLoader.GetMod("TerraCompilation").ItemType("AdamantiteComp"),
                ModLoader.GetMod("TerraCompilation").ItemType("TitaniumComp"),

                });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantiteRepeater", group);
            }

            else
            {

                //cobalt
                group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Repeater", new int[]
                {
                ItemID.CobaltRepeater,
                ItemID.PalladiumRepeater,
                });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltRepeater", group);

                //mythril
                group = new RecipeGroup(() => Lang.misc[37] + " Mythril Repeater", new int[]
                {
                ItemID.MythrilRepeater,
                ItemID.OrichalcumRepeater,
               });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilRepeater", group);

                //adamantite
                group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Repeater", new int[]
                {
                ItemID.AdamantiteRepeater,
                ItemID.TitaniumRepeater,
                });
                RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantiteRepeater", group);
            }

            //evil chest
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Chest", new int[]
            {
                ItemID.VampireKnives,
                ItemType("VampireKnivesThrown"),
                ItemID.ScourgeoftheCorruptor,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilChest", group);

            //evil wood
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Wood", new int[]
            {
                ItemID.Ebonwood,
                ItemID.Shadewood,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilWood", group);

            //evilbow
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Bow", new int[]
            {
                ItemID.DemonBow,
                ItemID.TendonBow,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilBow", group);

            //evilgun
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Gun", new int[]
            {
                ItemID.Musket,
                ItemID.TheUndertaker,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilGun", group);

            //silverstaff
            group = new RecipeGroup(() => Lang.misc[37] + " Silver Staff", new int[]
            {
                ItemID.SapphireStaff,
                ItemID.EmeraldStaff,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySilverStaff", group);

            //goldstaff
            group = new RecipeGroup(() => Lang.misc[37] + " Gold Staff", new int[]
            {
                ItemID.RubyStaff,
                ItemID.DiamondStaff,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldStaff", group);

            //evilmagic
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Magic Weapon", new int[]
            {
                ItemID.Vilethorn,
                ItemID.CrimsonRod,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilMagic", group);

            //expertevil
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Expert Drop", new int[]
            {
                ItemID.WormScarf,
                ItemID.BrainOfConfusion,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilExpert", group);

            //evilmimic acc
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Mimic Accessory", new int[]
            {
                ItemID.FleshKnuckles,
                ItemID.PutridScent,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyEvilMimic", group);

            //tier 1 sentry
            group = new RecipeGroup(() => Lang.misc[37] + " Tier 1 Sentry", new int[]
            {
                ItemID.DD2LightningAuraT1Popper,
                ItemID.DD2FlameburstTowerT1Popper,
                ItemID.DD2ExplosiveTrapT1Popper,
                ItemID.DD2BallistraTowerT1Popper,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySentry1", group);

            //tier 3 sentry
            group = new RecipeGroup(() => Lang.misc[37] + " Tier 3 Sentry", new int[]
            {
                ItemID.DD2LightningAuraT3Popper,
                ItemID.DD2FlameburstTowerT3Popper,
                ItemID.DD2ExplosiveTrapT3Popper,
                ItemID.DD2BallistraTowerT3Popper,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySentry", group);

            //anvil HM
            group = new RecipeGroup(() => Lang.misc[37] + " Mythril Anvil", new int[]
            {
                ItemID.MythrilAnvil,
                ItemID.OrichalcumAnvil,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //forge HM
            group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Forge", new int[]
            {
                ItemID.AdamantiteForge,
                ItemID.TitaniumForge,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //any adamantite
            group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Bar", new int[]
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamantite", group);

            //shroomite head
            group = new RecipeGroup(() => Lang.misc[37] + " Shroomite Head Piece", new int[]
            {
                ItemID.ShroomiteHeadgear,
                ItemID.ShroomiteMask,
                ItemID.ShroomiteHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyShroomHead", group);

            //orichalcum head
            group = new RecipeGroup(() => Lang.misc[37] + " Orichalcum Head Piece", new int[]
            {
                ItemID.OrichalcumHeadgear,
                ItemID.OrichalcumMask,
                ItemID.OrichalcumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyOriHead", group);

            //palladium head
            group = new RecipeGroup(() => Lang.misc[37] + " Palladium Head Piece", new int[]
            {
                ItemID.PalladiumHeadgear,
                ItemID.PalladiumMask,
                ItemID.PalladiumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPallaHead", group);

            //cobalt head
            group = new RecipeGroup(() => Lang.misc[37] + " Cobalt Head Piece", new int[]
            {
                ItemID.CobaltHelmet,
                ItemID.CobaltHat,
                ItemID.CobaltMask,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyCobaltHead", group);

            //mythril head
            group = new RecipeGroup(() => Lang.misc[37] + " Mythril Head Piece", new int[]
            {
                ItemID.MythrilHat,
                ItemID.MythrilHelmet,
                ItemID.MythrilHood,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyMythrilHead", group);

            //titanium head
            group = new RecipeGroup(() => Lang.misc[37] + " Titanium Head Piece", new int[]
            {
                ItemID.TitaniumHeadgear,
                ItemID.TitaniumMask,
                ItemID.TitaniumHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyTitaHead", group);

            //hallowed head
            group = new RecipeGroup(() => Lang.misc[37] + " Hallowed Head Piece", new int[]
            {
                ItemID.HallowedMask,
                ItemID.HallowedHeadgear,
                ItemID.HallowedHelmet,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyHallowHead", group);

            //adamantite head
            group = new RecipeGroup(() => Lang.misc[37] + " Adamantite Head Piece", new int[]
            {
                ItemID.AdamantiteHelmet,
                ItemID.AdamantiteMask,
                ItemID.AdamantiteHeadgear,

            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyAdamHead", group);

            //chloro head
            group = new RecipeGroup(() => Lang.misc[37] + " Chlorophyte Head Piece", new int[]
            {
                ItemID.ChlorophyteMask,
                ItemID.ChlorophyteHelmet,
                ItemID.ChlorophyteHeadgear,

            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyChloroHead", group);

            //spectre head
            group = new RecipeGroup(() => Lang.misc[37] + " Spectre Head Piece", new int[]
            {
                ItemID.SpectreHood,
                ItemID.SpectreMask,

            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnySpectreHead", group);

            //book cases
            group = new RecipeGroup(() => Lang.misc[37] + " Wooden Bookcase", new int[]
            {
                ItemID.Bookcase,
                ItemID.EbonwoodBookcase,
                ItemID.RichMahoganyBookcase,
                ItemID.LivingWoodBookcase,
                ItemID.ShadewoodBookcase,
                ItemID.PalmWoodBookcase,
                ItemID.BorealWoodBookcase,
            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);

            //beetle body
            group = new RecipeGroup(() => Lang.misc[37] + " Beetle Body", new int[]
            {
                ItemID.BeetleShell,
                ItemID.BeetleScaleMail,

            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyBeetle", group);

            //phasesabers
            group = new RecipeGroup(() => Lang.misc[37] + " Phasesaber", new int[]
            {
                ItemID.RedPhasesaber,
                ItemID.BluePhasesaber,
                ItemID.GreenPhasesaber,
                ItemID.PurplePhasesaber,
                ItemID.WhitePhasesaber,
                ItemID.YellowPhasesaber,

            });
            RecipeGroup.RegisterGroup("Fargowiltas:AnyPhasesaber", group);

        }

        public static bool NoInvasion(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
        }

        public static bool NoBiome(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }

        public static bool NoZone(NPCSpawnInfo spawnInfo)
        {
            return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
        }

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
        }

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
        }

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
        }

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
        {
            return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
        }

    }
}
