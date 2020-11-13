using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class DeathScythe : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.DeathSickle;

        public override Color? GetAlpha(Color lightColor) => Color.White;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abominationn Scythe");

            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.penetrate = 50;
            projectile.scale = 1f;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0)
            {
                projectile.localAI[0] = 1;
                projectile.ai[0] = -1;

                SoundEngine.PlaySound(SoundID.Item71, projectile.Center);
            }

            projectile.rotation += 1f;

            const int aislotHomingCooldown = 1;
            const int homingDelay = 30;
            const float desiredFlySpeedInPixelsPerFrame = 70;
            const float amountOfFramesToLerpBy = 10; // Minimum of 1, please keep in full numbers even though it's a float!

            projectile.ai[aislotHomingCooldown]++;

            if (projectile.ai[aislotHomingCooldown] > homingDelay)
            {
                projectile.ai[aislotHomingCooldown] = homingDelay; // Cap this value
                projectile.ai[0] = HomeOnTarget();

                if (projectile.ai[0] > -1 && projectile.ai[0] < 200)
                {
                    NPC npc = Main.npc[(int)projectile.ai[0]];

                    if (npc.active && npc.CanBeChasedBy())
                    {
                        Vector2 desiredVelocity = projectile.DirectionTo(npc.Center) * desiredFlySpeedInPixelsPerFrame;

                        projectile.velocity = Vector2.Lerp(projectile.velocity, desiredVelocity, 1f / amountOfFramesToLerpBy);
                    }
                }
                else
                {
                    projectile.ai[0] = -1;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => target.AddBuff(BuffID.ShadowFlame, 600);

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Asset<Texture2D> texture = TextureAssets.Projectile[projectile.type];
            int height = TextureAssets.Projectile[projectile.type].Height() / Main.projFrames[projectile.type]; // Y-pos of lower right corner of sprite to draw
            Rectangle rec = new Rectangle(0, height * projectile.frame, texture.Width(), height);
            Vector2 origin = rec.Size() / 2f;
            SpriteEffects effects = projectile.spriteDirection > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Color color = lightColor;
            color = projectile.GetAlpha(color);

            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[projectile.type]; i++)
            {
                Color newColor = color * 0.5f;

                newColor *= (float)(ProjectileID.Sets.TrailCacheLength[projectile.type] - i) / ProjectileID.Sets.TrailCacheLength[projectile.type];

                Main.spriteBatch.Draw(texture.Value, projectile.oldPos[i] + projectile.Size / 2f - Main.screenPosition + new Vector2(0, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), newColor, projectile.oldRot[i], origin, projectile.scale, effects, 0f);
            }

            Main.spriteBatch.Draw(texture.Value, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), projectile.GetAlpha(lightColor), projectile.rotation, origin, projectile.scale, effects, 0f);

            return false;
        }

        private int HomeOnTarget()
        {
            const bool homingCanAimAtWetEnemies = true;
            const float homingMaximumRangeInPixels = 1000;
            int selectedTarget = -1;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (npc.CanBeChasedBy(projectile) && (!npc.wet || homingCanAimAtWetEnemies))
                {
                    float distance = projectile.Distance(npc.Center);

                    if (distance <= homingMaximumRangeInPixels && (selectedTarget == -1 || projectile.Distance(Main.npc[selectedTarget].Center) > distance))
                    {
                        selectedTarget = i;
                    }
                }
            }

            return selectedTarget;
        }
    }
}