using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class PhantasmalEyeProj : ModProjectile
    {
        public float HomingCooldown
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 50;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 240, true);
            target.AddBuff(BuffID.CursedInferno, 240, true);
            target.AddBuff(BuffID.Confused, 120, true);
            target.AddBuff(BuffID.Venom, 240, true);
            target.AddBuff(BuffID.ShadowFlame, 240, true);
            target.AddBuff(BuffID.OnFire, 240, true);
            target.AddBuff(BuffID.Frostburn, 240, true);
        }

        public override void AI()
        {
            const int homingDelay = 10;
            const float flySpeed = 60; // Fly speed in pixels per frame
            const int lerpFrameAmount = 20; // Minimum of 1

            HomingCooldown++;

            if (HomingCooldown > homingDelay)
            {
                HomingCooldown = homingDelay; // cap this value

                int foundTarget = HomeOnTarget();

                if (foundTarget != -1)
                {
                    NPC npc = Main.npc[foundTarget];
                    Vector2 desiredVelocity = projectile.DirectionTo(npc.Center) * flySpeed;
                    projectile.velocity = Vector2.Lerp(projectile.velocity, desiredVelocity, 1f / lerpFrameAmount);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, DustID.BlueCrystalShard, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2f;

                dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, DustID.BlueCrystalShard, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, default, .75f);
                Main.dust[dust].velocity *= 2f;
            }
        }

        private int HomeOnTarget()
        {
            const bool HOMING_CAN_AIM_AT_WET_ENEMIES = true;
            const float HOMING_MAXIMUM_RANGE_IN_PIXELS = 1000;

            int selectedTarget = -1;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy(projectile) && (!npc.wet || HOMING_CAN_AIM_AT_WET_ENEMIES))
                {
                    float distance = projectile.Distance(npc.Center);

                    if (distance <= HOMING_MAXIMUM_RANGE_IN_PIXELS && (selectedTarget == -1 || projectile.Distance(Main.npc[selectedTarget].Center) > distance))
                    {
                        selectedTarget = i;
                    }
                }
            }

            return selectedTarget;
        }
    }
}