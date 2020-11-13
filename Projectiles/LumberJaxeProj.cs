using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class LumberJaxeProj : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("LumberJaxe");

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 150;
            aiType = ProjectileID.CrystalBullet;
        }

        public override void AI() => projectile.rotation += 0.3f;

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => projectile.Kill();

        public override void Kill(int timeLeft) => Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 0, projectile.velocity.Y * 0, ModContent.ProjectileType<ExplosionProj>(), (int)(projectile.damage * 1f), projectile.knockBack, projectile.owner);
    }
}