using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class ExplosionProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosion");

            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, projectile.position, 14);

            projectile.position = projectile.Center;
            projectile.width = 100;
            projectile.height = 100;
            projectile.Center = projectile.position;

            for (int i = 0; i < 30; i++)
            {
                Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, Alpha: 100, Scale: 1.5f)].velocity *= 1.4f;
            }

            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch, Alpha: 100, Scale: 3.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;

                Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch, Alpha: 100, Scale: 1.5f)].velocity *= 3f;
            }

            for (int i = 0; i < 2; i++)
            {
                float scaleFactor = 0.4f;

                if (i == 1)
                {
                    scaleFactor = 0.8f;
                }

                int gore = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[gore].velocity *= scaleFactor;
                Main.gore[gore].velocity.X += 1f;
                Main.gore[gore].velocity.Y += 1f;

                gore = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[gore].velocity *= scaleFactor;
                Main.gore[gore].velocity.X -= 1f;
                Main.gore[gore].velocity.Y += 1f;

                gore = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[gore].velocity *= scaleFactor;
                Main.gore[gore].velocity.X += 1f;
                Main.gore[gore].velocity.Y -= 1f;

                gore = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[gore].velocity *= scaleFactor;
                Main.gore[gore].velocity.X -= 1f;
                Main.gore[gore].velocity.Y -= 1f;
            }
        }
    }
}