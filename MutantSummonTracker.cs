using Fargowiltas.Content.Items.Summons.Mutant;
using Fargowiltas.Content.Items.Summons.VanillaCopy;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas
{
    internal class MutantSummonTracker
    {
        public const float KingSlime = 1f;
        public const float EyeOfCthulhu = 2f;
        public const float EaterOfWorlds = 3f;
        public const float QueenBee = 4f;
        public const float Skeletron = 5f;
        public const float DeerClops = 6f;
        public const float WallOfFlesh = 7f;
        public const float QueenSlime = 8f;
        public const float TheTwins = 9f;
        public const float TheDestroyer = 10f;
        public const float SkeletronPrime = 11f;
        public const float Plantera = 12f;
        public const float Golem = 13f;
        public const float DukeFishron = 14f;
        public const float EmpressOfLight = 15f;
        public const float Betsy = 16f;
        public const float LunaticCultist = 17f;
        public const float Moonlord = 18f;

        internal List<MutantSummonInfo> SortedSummons;
        internal List<MutantSummonInfo> EventSummons;

        internal bool SummonsFinalized = false;

        public MutantSummonTracker()
        {
            Fargowiltas.summonTracker = this;
            InitializeVanillaSummons();
        }

        private void InitializeVanillaSummons()
        {
            SortedSummons = new List<MutantSummonInfo> {
                // Vanilla bosses
                new MutantSummonInfo(KingSlime, ItemID.SlimeCrown, () => NPC.downedSlimeKing, Item.buyPrice(gold: 5)),
                new MutantSummonInfo(EyeOfCthulhu, ItemID.SuspiciousLookingEye, () => NPC.downedBoss1, Item.buyPrice(gold: 8)),
                new MutantSummonInfo(EaterOfWorlds, ItemID.WormFood, () => NPC.downedBoss2, Item.buyPrice(gold: 10)),
                new MutantSummonInfo(EaterOfWorlds, ItemID.BloodySpine, () => NPC.downedBoss2, Item.buyPrice(gold: 10)),
                new MutantSummonInfo(DeerClops, ItemID.DeerThing, () => NPC.downedDeerclops, Item.buyPrice(gold: 12)),
                new MutantSummonInfo(QueenBee, ItemID.Abeemination, () => NPC.downedQueenBee, Item.buyPrice(gold: 15)),
                new MutantSummonInfo(Skeletron, ModContent.ItemType<SuspiciousSkull>(), () => NPC.downedBoss3, Item.buyPrice(gold: 15)),
                new MutantSummonInfo(WallOfFlesh, ModContent.ItemType<FleshyDoll>(), () => Main.hardMode  , Item.buyPrice(gold: 20)),
                new MutantSummonInfo(WallOfFlesh + 0.0001f, ModContent.ItemType<DeathBringerFairy>(), () => Main.hardMode, Item.buyPrice(gold: 50)),
                new MutantSummonInfo(QueenSlime, ItemID.QueenSlimeCrystal, () => NPC.downedQueenSlime, Item.buyPrice(gold: 25)),
                new MutantSummonInfo(TheTwins, ItemID.MechanicalEye, () => NPC.downedMechBoss2, Item.buyPrice(gold: 40)),
                new MutantSummonInfo(TheDestroyer, ItemID.MechanicalWorm, () => NPC.downedMechBoss1, Item.buyPrice(gold: 40)),
                new MutantSummonInfo(SkeletronPrime, ItemID.MechanicalSkull, () => NPC.downedMechBoss3, Item.buyPrice(gold: 40)),
                new MutantSummonInfo(SkeletronPrime + 0.0001f, ModContent.ItemType<MechanicalAmalgam>(), () => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, Item.buyPrice(platinum: 1)),
                new MutantSummonInfo(Plantera, ModContent.ItemType<PlanterasFruit>(), () => NPC.downedPlantBoss, Item.buyPrice(gold: 50)),
                new MutantSummonInfo(Golem, ModContent.ItemType<LihzahrdPowerCell2>(), () => NPC.downedGolemBoss, Item.buyPrice(gold: 60)),
                new MutantSummonInfo(EmpressOfLight, ModContent.ItemType<PrismaticPrimrose>(), () => NPC.downedEmpressOfLight, Item.buyPrice(gold: 60)),
                new MutantSummonInfo(DukeFishron, ModContent.ItemType<TruffleWorm2>(), () => NPC.downedFishron, Item.buyPrice(gold: 60)),
                new MutantSummonInfo(LunaticCultist, ModContent.ItemType<CultistSummon>(), () => NPC.downedAncientCultist, Item.buyPrice(gold: 75)),
                new MutantSummonInfo(Moonlord, ItemID.CelestialSigil, () => NPC.downedMoonlord, Item.buyPrice(platinum: 1)),
                new MutantSummonInfo(Moonlord + 0.0001f, ModContent.ItemType<MutantVoodoo>(), () => NPC.downedMoonlord, Item.buyPrice(platinum: 2))
            };

            EventSummons = new List<MutantSummonInfo>();
        }

        internal void FinalizeSummonData()
        {
            SortedSummons.Sort((x, y) => x.progression.CompareTo(y.progression));
            SummonsFinalized = true;
        }

        internal void AddSummon(float progression, int itemId, Func<bool> downed, int price)
        {
            SortedSummons.Add(new MutantSummonInfo(progression, itemId, downed, price));
        }

        internal void AddEventSummon(float progression, int itemId, Func<bool> downed, int price)
        {
            EventSummons.Add(new MutantSummonInfo(progression, itemId, downed, price));
        }
    }

    internal class MutantSummonInfo
    {
        internal float progression;
        internal string modSource;
        internal int itemId;
        internal Func<bool> downed;
        internal int price;

        internal MutantSummonInfo(float progression, int itemId, Func<bool> downed, int price)
        {
            this.progression = progression;
            this.itemId = itemId;
            this.downed = downed;
            this.price = price;
        }
    }
}