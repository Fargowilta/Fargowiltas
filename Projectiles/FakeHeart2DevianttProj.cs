using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FakeHeart2DevianttProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Projectiles/FakeHeartDevianttProj";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fake Heart");

            ProjectileID.Sets.TrailCacheLength[projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.aiStyle = -1;
            projectile.penetrate = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            float rand = Main.rand.Next(90, 111) * 0.01f * (Main.essScale * 0.5f);

            Lighting.AddLight(projectile.Center, 0.5f * rand, 0.1f * rand, 0.1f * rand);

            if (++projectile.localAI[0] == 30)
            {
                projectile.localAI[1] = projectile.velocity.ToRotation();
                projectile.velocity = Vector2.Zero;
            }

            if (--projectile.ai[1] == 0)
            {
                projectile.velocity = projectile.localAI[1].ToRotationVector2() * -12.5f;
            }
            else if (projectile.ai[1] < 0)
            {
                if (projectile.ai[0] >= 0 && projectile.ai[0] < 200)
                {
                    int ai0 = (int)projectile.ai[0];

                    if (Main.npc[ai0].CanBeChasedBy())
                    {
                        double veloRotation = (Main.npc[ai0].Center - projectile.Center).ToRotation() - projectile.velocity.ToRotation();

                        if (veloRotation > Math.PI)
                        {
                            veloRotation -= 2.0 * Math.PI;
                        }

                        if (veloRotation < -1.0 * Math.PI)
                        {
                            veloRotation += 2.0 * Math.PI;
                        }

                        projectile.velocity = projectile.velocity.RotatedBy(veloRotation * (projectile.Distance(Main.npc[ai0].Center) > 100 ? 0.6f : 0.2f));
                    }
                    else
                    {
                        projectile.ai[0] = -1f;
                        projectile.netUpdate = true;
                    }
                }
                else
                {
                    if (++projectile.localAI[1] > 12f)
                    {
                        projectile.localAI[1] = 0f;

                        float maxDistance = 700f;
                        int possibleTarget = -1;

                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            NPC npc = Main.npc[i];

                            if (npc.CanBeChasedBy())
                            {
                                float npcDistance = projectile.Distance(npc.Center);

                                if (npcDistance < maxDistance)
                                {
                                    maxDistance = npcDistance;
                                    possibleTarget = i;
                                }
                            }
                        }

                        projectile.ai[0] = possibleTarget;
                        projectile.netUpdate = true;
                    }
                }
            }

            if (projectile.velocity != Vector2.Zero)
            {
                projectile.rotation = projectile.velocity.ToRotation();
            }

            projectile.rotation -= (float)Math.PI / 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => target.AddBuff(BuffID.Lovestruck, 600);

        public override Color? GetAlpha(Color lightColor) => new Color(255, lightColor.G, lightColor.B, lightColor.A);

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Asset<Texture2D> texture = TextureAssets.Projectile[projectile.type];
            int height = texture.Height() / Main.projFrames[projectile.type]; // Y-pos of lower right corner of sprite to draw
            Rectangle rec = new Rectangle(0, height * projectile.frame, texture.Width(), height);
            Vector2 origin = rec.Size() / 2f;
            Color color = lightColor;

            color = projectile.GetAlpha(color);

            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[projectile.type]; i++)
            {
                Main.spriteBatch.Draw(texture.Value, projectile.oldPos[i] + projectile.Size / 2f - Main.screenPosition + new Vector2(0, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), color * ((float)(ProjectileID.Sets.TrailCacheLength[projectile.type] - i) / ProjectileID.Sets.TrailCacheLength[projectile.type]), projectile.oldRot[i], origin, projectile.scale, SpriteEffects.None, 0f);
            }

            Main.spriteBatch.Draw(texture.Value, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), projectile.GetAlpha(lightColor), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}