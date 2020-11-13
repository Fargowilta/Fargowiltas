using Fargowiltas.Items.Tiles;
using Fargowiltas.NPCs;
using Fargowiltas.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
    public class FargoWorld : ModWorld
    {
        public static int AbomClearCD;
        public static bool MovedLumberjack;
        public static bool OverloadGoblins;
        public static bool OverloadPirates;
        public static bool OverloadPumpkinMoon;
        public static bool OverloadFrostMoon;
        public static bool OverloadMartians;
        public static bool[] CurrentSpawnRateTile;
        public static Dictionary<string, bool> DownedBools = new Dictionary<string, bool>();

        // Do not change the order or name of any of these value names, it will fuck up loading. Any new additions should be added at the end.
        private readonly string[] tags = new string[]
        {
            "lumberjack",
            "betsy",
            "boss",
            "rareEnemy",
            "pinky",
            "undeadMiner",
            "tim",
            "doctorBones",
            "mimic",
            "wyvern",
            "runeWizard",
            "nymph",
            "moth",
            "rainbowSlime",
            "paladin",
            "medusa",
            "clown",
            "iceGolem",
            "sandElemental",
            "mothron",
            "mimicHallow",
            "mimicCorrupt",
            "mimicCrimson",
            "mimicJungle",
            "goblinSummoner",
            "flyingDutchman",
            "dungeonSlime",
            "pirateCaptain",
            "skeletonGun",
            "skeletonMage",
            "boneLee",
            "darkMage",
            "ogre",
            "headlessHorseman",
            "babyGuardian",
            "squirrel"
        };

        public override void Initialize()
        {
            foreach (string tag in tags)
            {
                DownedBools[tag] = false;
            }

            AbomClearCD = 0;
            OverloadGoblins = false;
            OverloadPirates = false;
            OverloadPumpkinMoon = false;
            OverloadFrostMoon = false;
            OverloadMartians = false;
            CurrentSpawnRateTile = new bool[Main.netMode == NetmodeID.Server ? 255 : 1];
        }

        public override TagCompound Save()
        {
            List<string> downed = new List<string>();

            foreach (string tag in tags)
            {
                downed.AddWithCondition(tag, DownedBools[tag]);
            }

            return new TagCompound
            {
                { "downed", downed },
            };
        }

        public override void Load(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");

            foreach (string downedTag in tags)
            {
                DownedBools[downedTag] = downed.Contains(downedTag);
            }
        }

        public override void NetReceive(BinaryReader reader)
        {
            foreach (string tag in tags)
            {
                DownedBools[tag] = reader.ReadBoolean();
            }

            AbomClearCD = reader.ReadInt32();
        }

        public override void NetSend(BinaryWriter writer)
        {
            foreach (string tag in tags)
            {
                writer.Write(DownedBools[tag]);
            }

            writer.Write(AbomClearCD);
        }

        public override void PostUpdate()
        {
            // Seasonals
            Main.halloween = ModContent.GetInstance<FargoConfig>().halloween;
            Main.xMas = ModContent.GetInstance<FargoConfig>().christmas;

            // Resets swarms in-case something goes wrong
            if (Fargowiltas.SwarmActive && NoBosses() && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && !NPC.AnyNPCs(NPCID.DungeonGuardian))
            {
                Fargowiltas.SwarmActive = false;
                FargoGlobalNPC.LastWoFIndex = -1;
                FargoGlobalNPC.WoFDirection = 0;
            }

            if (AbomClearCD > 0)
            {
                AbomClearCD--;
            }

            if (OverloadGoblins && Main.invasionType != InvasionID.GoblinArmy)
            {
                OverloadGoblins = false;
            }

            if (OverloadPirates && Main.invasionType != InvasionID.PirateInvasion)
            {
                OverloadPirates = false;
            }

            if (OverloadPumpkinMoon && !Main.pumpkinMoon)
            {
                OverloadPumpkinMoon = false;
            }

            if (OverloadFrostMoon && !Main.snowMoon)
            {
                OverloadFrostMoon = false;
            }

            if (OverloadMartians && Main.invasionType != InvasionID.MartianMadness)
            {
                OverloadMartians = false;
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            ref bool current = ref CurrentSpawnRateTile[0];
            bool oldSpawnRateTile = current;

            current = tileCounts[ModContent.TileType<RegalStatueTile>()] > 0;

            if (Main.netMode == NetmodeID.MultiplayerClient && current != oldSpawnRateTile)
            {
                ModPacket packet = ModContent.GetInstance<Fargowiltas>().GetPacket();
                packet.Write((byte)1);
                packet.Write(current);
                packet.Send();
            }
        }

        public override void PreUpdate()
        {
            bool rate = false;

            for (int i = 0; i < CurrentSpawnRateTile.Length; i++)
            {
                if (CurrentSpawnRateTile[i])
                {
                    Player player = Main.player[i];

                    if (player.active)
                    {
                        if (!player.dead)
                        {
                            rate = true;
                        }
                    }
                    else
                    {
                        CurrentSpawnRateTile[i] = false;
                    }
                }
            }

            if (rate)
            {
                Main.checkForSpawns += 81;
            }
        }

        public static bool NoBosses() => Main.npc.All(npc => !npc.active || !npc.boss);
    }
}