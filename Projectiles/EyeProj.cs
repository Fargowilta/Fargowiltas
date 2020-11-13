using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class EyeProj : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Eye");

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 13;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, Scale: 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2f;

                dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, Scale: 1f);
                Main.dust[dust].velocity *= 2f;
            }
        }
    }
}