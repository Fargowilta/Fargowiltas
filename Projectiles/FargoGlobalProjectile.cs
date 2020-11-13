using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FargoGlobalProjectile : GlobalProjectile
    {
        public bool firstTick = true;

        public override bool InstancePerEntity => true;

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer)
            {
                if (firstTick)
                {
                    if (ModContent.GetInstance<FargoConfig>().extraLures && projectile.bobber)
                    {
                        int split = 1;

                        switch (projectile.type)
                        {
                            case ProjectileID.BobberFiberglass:
                            case ProjectileID.BobberFisherOfSouls:
                            case ProjectileID.BobberFleshcatcher:
                                split = 2;
                                break;

                            case ProjectileID.BobberMechanics:
                            case ProjectileID.BobbersittingDuck:
                                split = 3;
                                break;

                            case ProjectileID.BobberHotline:
                            case ProjectileID.BobberGolden:
                                split = 5;
                                break;
                        }

                        if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                        {
                            split++;
                        }

                        if (split > 1)
                        {
                            SplitProj(projectile, split);
                        }
                    }
                }
            }

            if (projectile.type == ProjectileID.FlyingPiggyBank && ModContent.GetInstance<FargoConfig>().stalkerMoneyTrough)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 2000)
                {
                    projectile.Kill();
                }
                else if (dist > 100)
                {
                    projectile.position += Vector2.Normalize(player.Center - projectile.Center) * 3;
                }
            }

            if (firstTick)
            {
                firstTick = false;
            }

            return true;
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;
            double spread = 0.6 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;

                    split = NewProjectileDirectSafe(projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                    {
                        split.friendly = true;

                        split.GetGlobalProjectile<FargoGlobalProjectile>().firstTick = false;
                    }
                }
            }

            if (number % 2 == 0)
            {
                projectile.active = false;
            }
        }

        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int proj = Projectile.NewProjectile(pos, vel, type, damage, knockback, owner, ai0, ai1);

            return (proj < 1000) ? Main.projectile[proj] : null;
        }
    }
}