using Fargowiltas.Content.Items.CaughtNPCs;
using Fargowiltas.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Utilities;
using static Fargowiltas.FargoSets;

namespace Fargowiltas.Content.Items.Tiles
{
    public class SacrificeAltarSheet : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = [16, 16];
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Demon Altar");
            AddMapEntry(new Color(200, 200, 200), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            //counts as
            //AdjTiles = [TileID.DemonAltar];
        }

        //public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        //{
        //    r = 0.93f;
        //    g = 0.11f;
        //    b = 0.9f;
        //}

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool RightClick(int i, int j) => SacrificeThing(i, j);
        public override void MouseOver(int i, int j) => HoverItemIcon();
        public override void MouseOverFar(int i, int j) => HoverItemIcon();

        public static void HoverItemIcon()
        {
            if (Main.LocalPlayer.HeldItem != null && FargoSets.Items.SacrificeCount[Main.LocalPlayer.HeldItem.type] > 0)
            {
                Main.LocalPlayer.cursorItemIconID = Main.LocalPlayer.HeldItem.type;
                Main.LocalPlayer.noThrow = 2;
                Main.LocalPlayer.cursorItemIconEnabled = true;
            }
        }
        public static bool SacrificeThing(int i, int j)
        {
            if (Main.LocalPlayer.HeldItem == null)
                return false;
            int itemType = Main.LocalPlayer.HeldItem.type;
            if (EventSacrifice(Main.LocalPlayer.HeldItem, out int consumeCount, false) || FargoSets.Items.SacrificeCount[itemType] > 0) // item sacrificable; do the sacrifice thing
            {
                if (Main.LocalPlayer.CountItem(itemType, consumeCount + 1) >= consumeCount)
                {
                    for (int consume = 0; consume < consumeCount; consume++)
                        Main.LocalPlayer.ConsumeItem(itemType, includeVoidBag: true);

                    if (FargoSets.Items.SacrificeCount[itemType] > 0)
                        FargoSets.Items.SacrificeCount[itemType]--;

                    Vector2 spawnPos = Main.MouseWorld;
                    //SoundEngine.PlaySound(a, spawnPos);
                    Projectile.NewProjectile(new EntitySource_WorldEvent(), spawnPos, Vector2.Zero, ModContent.ProjectileType<SacrificeProj>(), 0, 0f, Main.myPlayer, itemType);
                return true;
                }
            }
            return false;
        }

        public static int[] SetDefaultSacrificeCount(SetFactory itemFactory)
        {
            return itemFactory.CreateIntSet(0,
                // king slime
                ItemID.NinjaHood, 1,
                ItemID.NinjaShirt, 1,
                ItemID.NinjaPants, 1,

                // queen bee
                ItemID.BeeGun, 1,
                ItemID.BeeKeeper, 1,
                ItemID.BeesKnees, 1,
                ItemID.HiveWand, 1,

                // demonite/crimson
                ItemID.DemonBow, 1,
                ItemID.TendonBow, 1,
                ItemID.LightsBane, 1,
                ItemID.BloodButcherer, 1,
                ItemID.FisherofSouls, 1,
                ItemID.Fleshcatcher, 1,
                
                ItemID.NightmarePickaxe, 1,
                ItemID.DeathbringerPickaxe, 1,
                ItemID.TheBreaker, 1,
                ItemID.FleshGrinder, 1,
                ItemID.WarAxeoftheNight, 1,
                ItemID.BloodLustCluster, 1,

                // deerclops
                ItemID.PewMaticHorn, 1,
                ItemID.WeatherPain, 1,
                ItemID.HoundiusShootius, 1,
                ItemID.LucyTheAxe, 1,

                // skeletron
                ItemID.BookofSkulls, 1,
                ItemID.SkeletronHand, 1,

                // enemy drop materials
                ItemID.TatteredCloth, 3,
                ItemID.WormTooth, 3,
                ItemID.SharkFin, 3,
                ItemID.Hook, 3,
                ItemID.BlackLens, 1,

                // event drops
                ItemID.SlimeStaff, 1,

                ItemID.Harpoon, 1,

                ItemID.BloodRainBow, 1,
                ItemID.VampireFrogStaff, 1,
                ItemID.BloodFishingRod, 1,

                // shadow orb drops
                ItemID.Musket, 1,
                ItemID.ShadowOrb, 1,
                ItemID.Vilethorn, 1,
                ItemID.BallOHurt, 1,
                ItemID.BandofStarpower, 1,

                ItemID.TheUndertaker, 1,
                ItemID.CrimsonHeart, 1,
                ItemID.CrimsonRod, 1,
                ItemID.TheRottedFork, 1,
                ItemID.PanicNecklace, 1,
                // enemy weapon drops
                ItemID.BatBat, 1,
                ItemID.ChainKnife, 1,
                ItemID.BoneSword, 1,
                ItemID.BonePickaxe, 1,
                ItemID.AntlionClaw, 1, // mandible blade
                ItemID.TentacleSpike, 1,
                ItemID.DemonScythe, 1,
                ItemID.BloodyMachete, 1,
                ItemID.BladedGlove, 1,

                // event summons
                CaughtNPCItem.CaughtTownies[NPCID.Dryad], 1,
                ItemID.PinkGel, 1,
                ItemID.TissueSample, 1,
                ItemID.ShadowScale, 1,
                ModContent.ItemType<WiresPainting>(), 1
                );
        }
        public readonly struct Result(int type, int amount)
        {
            public readonly int Type = type;
            public readonly int Amount = amount;
        }
        // some common values to help modded entries
        public static int OreCount = 80;
        public static double OreWeight = 0.5;

        public static int FishCount = 10;
        public static double FishWeight = 0.75;

        public static int CrateCount = 3;
        public static double CrateWeight = 0.5;
        public static int SacrificeResult(out int amount)
        {
            WeightedRandom<Result> result = new(Main.rand.Next(int.MaxValue));

            // misc materials
            result.Add(new(ItemID.Lens, 6), 0.5);
            result.Add(new(ItemID.RottenChunk, 6), 0.5);
            result.Add(new(ItemID.Vertebrae, 6), 0.5);
            result.Add(new(ItemID.Mushroom, 50), 1);
            result.Add(new(ItemID.Gel, 200), 0.5);
            result.Add(new(ItemID.Feather, 15), 0.25);
            result.Add(new(ItemID.FallenStar, 6), 0.2);

            // ores
            result.Add(new(ItemID.CopperOre, OreCount), OreWeight);
            result.Add(new(ItemID.TinOre, OreCount), OreWeight);
            result.Add(new(ItemID.LeadOre, OreCount), OreWeight);
            result.Add(new(ItemID.IronOre, OreCount), OreWeight);
            result.Add(new(ItemID.TungstenOre, OreCount), OreWeight);
            result.Add(new(ItemID.SilverOre, OreCount), OreWeight);
            result.Add(new(ItemID.GoldOre, OreCount), OreWeight);
            result.Add(new(ItemID.PlatinumOre, OreCount), OreWeight);

            // lootboxes
            result.Add(new(ItemID.DesertFossil, 100), 0.25);

            result.Add(new(ItemID.HerbBag, 5), 2);
            result.Add(new(ItemID.Geode, 5), 0.5);
            result.Add(new(ItemID.Oyster, 3), 0.2);

            result.Add(new(ItemID.WoodenCrate, CrateCount), 1);
            result.Add(new(ItemID.IronCrate, CrateCount), 0.25);
            result.Add(new(ItemID.GoldenCrate, CrateCount), 0.05);

            result.Add(new(ItemID.JungleFishingCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.FloatingIslandFishingCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.CorruptFishingCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.CrimsonFishingCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.FrozenCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.OceanCrate, CrateCount), CrateWeight);
            result.Add(new(ItemID.OasisCrate, CrateCount), CrateWeight);

            // fishe
            result.Add(new(ItemID.ArmoredCavefish, FishCount), FishWeight);
            result.Add(new(ItemID.CrimsonTigerfish, FishCount), FishWeight);
            result.Add(new(ItemID.Damselfish, FishCount), FishWeight);
            result.Add(new(ItemID.DoubleCod, FishCount), FishWeight);
            result.Add(new(ItemID.Ebonkoi, FishCount), FishWeight);
            result.Add(new(ItemID.FrostMinnow, FishCount), FishWeight);
            result.Add(new(ItemID.Hemopiranha, FishCount), FishWeight);
            result.Add(new(ItemID.SpecularFish, FishCount), FishWeight);
            result.Add(new(ItemID.VariegatedLardfish, FishCount), FishWeight);

            // misc
            result.Add(new(ItemID.Torch, 500), 0.25);

            // rare
            result.Add(new(ItemID.LifeCrystal, 1), 0.1);
            result.Add(new(ItemID.PlatinumCoin, 1), 0.001); // lol

            Result real = result.Get();
            result.Clear();
            amount = real.Amount;
            return real.Type;
            
        }

        public static bool EventSacrifice(Item item, out int consumeCount, bool action = true)
        {
            consumeCount = 1;
            if (!action && FargoSets.Items.SacrificeCount[item.type] <= 0)
                return false;

            // spawn blood moon
            if (item.type == CaughtNPCItem.CaughtTownies[NPCID.Dryad])
            {
                if (action)
                {
                    FargoSets.Items.SacrificeCount[item.type]--;
                    SoundEngine.PlaySound(SoundID.Roar);

                    // turn it to night
                    Main.dayTime = false;
                    Main.time = 0;
                    NetMessage.SendData(MessageID.WorldData);

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        AchievementsHelper.NotifyProgressionEvent(4);
                        Main.bloodMoon = true;
                        if (Main.GetMoonPhase() == MoonPhase.Empty)
                        {
                            Main.moonPhase = 5;
                        }
                        Main.NewText(Lang.misc[8].Value, 50, byte.MaxValue, 130);
                    }
                    else
                    {
                        NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, Main.LocalPlayer.whoAmI, -10f);
                    }
                }
                return true;
            }

            // spawn slime rain
            if (item.type == ItemID.PinkGel)
            {
                consumeCount = 10;
                if (action)
                {
                    FargoSets.Items.SacrificeCount[item.type]--;
                    if (!Main.slimeRain)
                    {
                        Main.StartSlimeRain();
                        Main.slimeWarningDelay = 1;
                        Main.slimeWarningTime = 1;
                        SoundEngine.PlaySound(SoundID.Roar);
                    }
                }
                return true;
            }

            // drop a meteor
            if (item.type == ItemID.ShadowScale || item.type == ItemID.TissueSample)
            {
                consumeCount = 10;
                if (action)
                {
                    FargoSets.Items.SacrificeCount[ItemID.ShadowScale]--;
                    FargoSets.Items.SacrificeCount[ItemID.TissueSample]--;

                    if (Main.netMode == NetmodeID.SinglePlayer)
                        WorldGen.dropMeteor();
                    else
                    {
                        var netMessage = Fargowiltas.Instance.GetPacket();
                        netMessage.Write((byte)10); // "drop a meteor" tag
                        netMessage.Send();
                    }
                }
                return true;
            }

            // wires painting; spawns 20 cats :)
            if (item.type == ModContent.ItemType<WiresPainting>())
            {
                if (action)
                {
                    FargoSets.Items.SacrificeCount[ModContent.ItemType<WiresPainting>()]--;
                    for (int i = 0; i < 20; i++)
                    {
                        NPC.NewNPC(new EntitySource_WorldEvent(), (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, NPCID.TownCat);
                    }
                }
                return true;
            }
            return false;
        }
        /*
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<DemonAltar>());
        }
        */
    }
}