using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class MechEyeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, DustID.Silver, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2f;

                dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, DustID.Silver, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default, .75f);
                Main.dust[dust].velocity *= 2f;
            }
        }
    }
}