using System;
using System.Collections.Generic;
using Terraria;

namespace Fargowiltas.Utilities
{
    public static class MutantSummonTracker
    {
        public const float KingSlime = 1f;
        public const float EyeOfCthulhu = 2f;
        public const float EaterOfWorlds = 3f;
        public const float QueenBee = 4f;
        public const float Skeletron = 5f;
        public const float WallOfFlesh = 6f;
        public const float TheTwins = 7f;
        public const float TheDestroyer = 8f;
        public const float SkeletronPrime = 9f;
        public const float Plantera = 10f;
        public const float Golem = 11f;
        public const float DukeFishron = 12f;
        public const float LunaticCultist = 13f;
        public const float Moonlord = 14f;

        public static List<MutantSummonInfo> SortedSummons;
        public static List<MutantSummonInfo> EventSummons;
        public static bool SummonsFinalized = false;

        internal static void InitializeVanillaSummons()
        {
            SortedSummons = new List<MutantSummonInfo> {
                // Vanilla bosses
                new MutantSummonInfo(KingSlime, "Fargowiltas", "SlimyCrown", () => NPC.downedSlimeKing, 50000),
                new MutantSummonInfo(EyeOfCthulhu, "Fargowiltas", "SuspiciousEye", () => NPC.downedBoss1, 80000),
                new MutantSummonInfo(EaterOfWorlds, "Fargowiltas", "WormyFood", () => NPC.downedBoss2, 100000),
                new MutantSummonInfo(EaterOfWorlds, "Fargowiltas", "GoreySpine", () => NPC.downedBoss2, 100000),
                new MutantSummonInfo(QueenBee, "Fargowiltas", "Abeemination2", () => NPC.downedQueenBee, 150000),
                new MutantSummonInfo(Skeletron, "Fargowiltas", "SuspiciousSkull", () => NPC.downedBoss3, 150000),
                new MutantSummonInfo(WallOfFlesh, "Fargowiltas", "FleshyDoll", () => Main.hardMode  , 200000),
                new MutantSummonInfo(WallOfFlesh + 0.01f, "Fargowiltas", "DeathBringerFairy", () => Main.hardMode  , 500000),
                new MutantSummonInfo(TheTwins, "Fargowiltas", "MechEye", () => NPC.downedMechBoss2, 400000),
                new MutantSummonInfo(TheDestroyer, "Fargowiltas", "MechWorm", () => NPC.downedMechBoss1, 400000),
                new MutantSummonInfo(SkeletronPrime, "Fargowiltas", "MechSkull", () => NPC.downedMechBoss3, 400000),
                new MutantSummonInfo(SkeletronPrime + 0.01f, "Fargowiltas", "MechanicalAmalgam", () => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, 1000000),
                new MutantSummonInfo(Plantera, "Fargowiltas", "PlanterasFruit", () => NPC.downedPlantBoss, 500000),
                new MutantSummonInfo(Golem, "Fargowiltas", "LihzahrdPowerCell2", () => NPC.downedGolemBoss, 600000),
                new MutantSummonInfo(DukeFishron, "Fargowiltas", "TruffleWorm2", () => NPC.downedFishron, 600000),
                new MutantSummonInfo(LunaticCultist, "Fargowiltas", "CultistSummon", () => NPC.downedAncientCultist, 750000),
                new MutantSummonInfo(Moonlord, "Fargowiltas", "CelestialSigil2", () => NPC.downedMoonlord, 1000000),
                new MutantSummonInfo(Moonlord + 0.01f, "Fargowiltas", "MutantVoodoo", () => NPC.downedMoonlord, 2000000)
            };

            EventSummons = new List<MutantSummonInfo>();
        }

        public static void FinalizeSummonData()
        {
            SortedSummons.Sort((x, y) => x.progression.CompareTo(y.progression));
            SummonsFinalized = true;
        }

        public static void AddSummon(float progression, string modSource, string itemName, Func<bool> downed, int price) => SortedSummons.Add(new MutantSummonInfo(progression, modSource, itemName, downed, price));

        public static void AddEventSummon(float progression, string modSource, string itemName, Func<bool> downed, int price) => EventSummons.Add(new MutantSummonInfo(progression, modSource, itemName, downed, price));
    }

    public class MutantSummonInfo
    {
        internal float progression;
        internal string modSource;
        internal string itemName;
        internal Func<bool> downed;
        internal int price;

        public MutantSummonInfo(float progression, string modSource, string itemName, Func<bool> downed, int price)
        {
            this.progression = progression;
            this.modSource = modSource;
            this.itemName = itemName;
            this.downed = downed;
            this.price = price;
        }
    }
}