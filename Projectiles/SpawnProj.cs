using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class SpawnProj : ModProjectile
    {
        private readonly int[] bosses = new int[]
        {
            NPCID.KingSlime,
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.QueenBee,
            NPCID.SkeletronHead,
            NPCID.TheDestroyer,
            NPCID.SkeletronPrime,
            NPCID.Retinazer,
            NPCID.Spazmatism,
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.DukeFishron,
            NPCID.CultistBoss,
            NPCID.MoonLordCore
        };

        public override void SetStaticDefaults() => DisplayName.SetDefault("Spawn");

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.aiStyle = -1;
            projectile.timeLeft = 1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.hide = true;
        }

        public override bool? CanDamage() => false;

        public override void Kill(int timeLeft)
        {
            if ((int)projectile.ai[0] == NPCID.CultistBoss && NPC.downedAncientCultist)
            {
                // Lunatic Cultist
                Main.npc[NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, (int)projectile.ai[0])].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;
            }
            else if (projectile.ai[1] == 2)
            {
                // Death Fairy (Pre-hardmode bosses)
                for (int i = 0; i < 6; i++)
                {
                    NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, bosses[i]);
                }

                NPC.SpawnWOF(Main.player[projectile.owner].Center);
            }
            else if (projectile.ai[1] == 3)
            {
                // Mutant Voodoo (All bosses)
                foreach (int boss in bosses)
                {
                    if (boss == NPCID.CultistBoss)
                    {
                        Main.npc[NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, boss)].GetGlobalNPC<FargoGlobalNPC>().pillarSpawn = false;
                    }
                }

                NPC.SpawnWOF(Main.player[projectile.owner].Center);
            }
            else
            {
                NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, (int)projectile.ai[0]);
            }
        }
    }
}