using System;
using System.Linq;
using System.Collections.Generic;
using Fargowiltas.Buffs;
using Fargowiltas.Items.Summons.SwarmSummons.Energizers;
using Fargowiltas.Items.Tiles;
////using Fargowiltas.Items.Vanity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Items.Explosives;
using Fargowiltas.Items.Summons.Abom;
using Fargowiltas.Common.Configs;
using Fargowiltas.Items.Summons.Deviantt;

namespace Fargowiltas.NPCs
{
    public class EnergizedGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool SwarmActive(NPC npc) => npc.GetGlobalNPC<FargoGlobalNPC>().SwarmActive;

        internal static int[] Bosses = [ 
            NPCID.KingSlime,
            NPCID.EyeofCthulhu,
            //NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.QueenBee,
            NPCID.SkeletronHead,
            NPCID.QueenSlimeBoss,
            NPCID.TheDestroyer,
            NPCID.SkeletronPrime,
            NPCID.Retinazer,
            NPCID.Spazmatism,
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.DukeFishron,
            NPCID.HallowBoss,
            NPCID.CultistBoss,
            NPCID.MoonLordCore,
            NPCID.MartianSaucerCore,
            NPCID.Pumpking,
            NPCID.IceQueen,
            NPCID.DD2Betsy,
            NPCID.DD2OgreT3,
            NPCID.IceGolem,
            NPCID.SandElemental,
            NPCID.Paladin,
            NPCID.Everscream,
            NPCID.MourningWood,
            NPCID.SantaNK1,
            NPCID.HeadlessHorseman,
            NPCID.PirateShip 
        ];

        public override void SetDefaults(NPC npc)
        {
            if (Fargowiltas.SwarmSetDefaults)
            {
                bool validBoss = true;
                const int thousand = 1000;
                const int million = thousand * thousand;
                int baseHealth = 40 * thousand;
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.EyeofCthulhu:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.EaterofWorldsHead:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.BrainofCthulhu:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.DD2DarkMageT1:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.Deerclops:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.QueenBee:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.SkeletronHead:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.WallofFlesh:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.QueenSlimeBoss:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.TheDestroyer:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.Retinazer:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.Spazmatism:
                        npc.lifeMax = baseHealth;
                        break;

                    case NPCID.SkeletronPrime:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.Plantera:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.Golem:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.DD2Betsy:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.DukeFishron:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.HallowBoss:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.CultistBoss:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.MoonLordCore:
                        npc.lifeMax = baseHealth * 2;
                        break;

                    case NPCID.DungeonGuardian:
                        //npc.lifeMax = baseHealth;
                        break;

                    default:
                        validBoss = false;
                        break;
                }
                if (validBoss && Fargowiltas.SwarmItemsUsed > 1)
                {
                    npc.lifeMax *= Fargowiltas.SwarmItemsUsed;
                }
                int minDamage = Fargowiltas.SwarmMinDamage * 2;
                if (!npc.townNPC && npc.lifeMax > 10 && npc.damage < minDamage)
                    npc.damage = minDamage;

            }
        }
        private int go = 1;

        public override bool PreAI(NPC npc)
        {
            if (SwarmActive(npc) && go < 2)
            {
                go++;
                npc.AI();
                float speedToAdd = 0.5f;
                Vector2 newPos = npc.position + npc.velocity * speedToAdd;
                if (!Collision.SolidCollision(newPos, npc.width, npc.height))
                {
                    npc.position = newPos;
                }
            }
            return true;
        }

        public override void PostAI(NPC npc)
        {
            if (go == 2)
            {
                go = 1;
            }
        }
    }
}