using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs.Destroyer
{
    public class DestroyerBody : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Destroyer");

            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.TheDestroyerTail);
            npc.aiStyle = -1;
        }

        public override void AI()
        {
            if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }

            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }

            npc.velocity.Length();

            if (Main.npc[(int)npc.ai[1]].alpha < 128)
            {
                if (npc.alpha != 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default, 2f);
                        Main.dust[num].noGravity = true;
                        Main.dust[num].noLight = true;
                    }
                }

                npc.alpha -= 42;

                if (npc.alpha < 0)
                {
                    npc.alpha = 0;
                }
            }

            bool flag = false;

            if (npc.ai[1] <= 0f)
            {
                flag = true;
            }
            else if (Main.npc[(int)npc.ai[1]].life <= 0)
            {
                flag = true;
            }

            if (flag)
            {
                npc.life = 0;

                npc.HitEffect(0, 10.0);
                npc.checkDead();
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.localAI[0] += Main.rand.Next(4);

                if (npc.localAI[0] >= Main.rand.Next(1400, 26000))
                {
                    npc.localAI[0] = 0f;

                    npc.TargetClosest(true);

                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        float num6 = 8f;
                        Vector2 vector = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                        float num7 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector.X + Main.rand.Next(-20, 21);
                        float num8 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5f - vector.Y + Main.rand.Next(-20, 21);
                        float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);

                        num9 = num6 / num9;
                        num7 *= num9;
                        num8 *= num9;
                        num7 += Main.rand.Next(-20, 21) * 0.05f;
                        num8 += Main.rand.Next(-20, 21) * 0.05f;

                        int num10 = 22;

                        if (Main.expertMode)
                        {
                            num10 = 18;
                        }

                        int num11 = 100;

                        vector.X += num7 * 5f;
                        vector.Y += num8 * 5f;

                        int num12 = Projectile.NewProjectile(vector.X, vector.Y, num7, num8, num11, num10, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num12].timeLeft = 300;

                        npc.netUpdate = true;
                    }
                }
            }

            int num13 = (int)(npc.position.X / 16f) - 1;
            int num14 = (int)((npc.position.X + npc.width) / 16f) + 2;
            int num15 = (int)(npc.position.Y / 16f) - 1;
            int num16 = (int)((npc.position.Y + npc.height) / 16f) + 2;

            if (num13 < 0)
            {
                num13 = 0;
            }

            if (num14 > Main.maxTilesX)
            {
                num14 = Main.maxTilesX;
            }

            if (num15 < 0)
            {
                num15 = 0;
            }

            if (num16 > Main.maxTilesY)
            {
                num16 = Main.maxTilesY;
            }

            bool flag2 = false;

            if (!flag2)
            {
                for (int k = num13; k < num14; k++)
                {
                    for (int l = num15; l < num16; l++)
                    {
                        if (Main.tile[k, l] != null && ((Main.tile[k, l].nactive() && (Main.tileSolid[Main.tile[k, l].type] || (Main.tileSolidTop[Main.tile[k, l].type] && Main.tile[k, l].frameY == 0))) || Main.tile[k, l].liquid > 64))
                        {
                            Vector2 vector2;
                            vector2.X = k * 16;
                            vector2.Y = l * 16;

                            if (npc.position.X + npc.width > vector2.X && npc.position.X < vector2.X + 16f && npc.position.Y + npc.height > vector2.Y && npc.position.Y < vector2.Y + 16f)
                            {
                                flag2 = true;

                                break;
                            }
                        }
                    }
                }
            }

            if (!flag2)
            {
                if (npc.ai[2] != 1f)
                {
                    Lighting.AddLight((int)((npc.position.X + npc.width / 2) / 16f), (int)((npc.position.Y + npc.height / 2) / 16f), 0.3f, 0.1f, 0.05f);
                }

                npc.localAI[1] = 1f;
            }
            else
            {
                npc.localAI[1] = 0f;
            }

            float num18 = 16f;

            if (Main.dayTime || Main.player[npc.target].dead)
            {
                flag2 = false;
                npc.velocity.Y = npc.velocity.Y + 1f;

                if (npc.position.Y > Main.worldSurface * 16.0)
                {
                    npc.velocity.Y = npc.velocity.Y + 1f;
                    num18 = 32f;
                }

                if (npc.position.Y > Main.rockLayer * 16.0)
                {
                    for (int n = 0; n < 200; n++)
                    {
                        if (Main.npc[n].aiStyle == npc.aiStyle)
                        {
                            Main.npc[n].active = false;
                        }
                    }
                }
            }

            float num19 = 0.1f;
            float num20 = 0.15f;
            Vector2 vector3 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num21 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            float num22 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;

            num21 = (int)(num21 / 16f) * 16;
            num22 = (int)(num22 / 16f) * 16;
            vector3.X = (int)(vector3.X / 16f) * 16;
            vector3.Y = (int)(vector3.Y / 16f) * 16;
            num21 -= vector3.X;
            num22 -= vector3.Y;

            float num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);

            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector3 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num21 = Main.npc[(int)npc.ai[1]].position.X + (Main.npc[(int)npc.ai[1]].width / 2) - vector3.X;
                    num22 = Main.npc[(int)npc.ai[1]].position.Y + (Main.npc[(int)npc.ai[1]].height / 2) - vector3.Y;
                }
                catch { }
                npc.rotation = (float)Math.Atan2(num22, num21) + 1.57f;
                num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);

                int num24 = (int)(44f * npc.scale);

                num23 = (num23 - num24) / num23;
                num21 *= num23;
                num22 *= num23;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num21;
                npc.position.Y = npc.position.Y + num22;

                return;
            }
            if (!flag2)
            {
                npc.TargetClosest(true);
                npc.velocity.Y = npc.velocity.Y + 0.15f;

                if (npc.velocity.Y > num18)
                {
                    npc.velocity.Y = num18;
                }

                if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num18 * 0.4)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 1.1f;
                    }
                    else
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 1.1f;
                    }
                }
                else if (npc.velocity.Y == num18)
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19;
                    }
                }
                else if (npc.velocity.Y > 4f)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 0.9f;
                    }
                    else
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 0.9f;
                    }
                }
            }
            else
            {
                if (npc.soundDelay == 0)
                {
                    float num25 = num23 / 40f;

                    if (num25 < 10f)
                    {
                        num25 = 10f;
                    }
                    if (num25 > 20f)
                    {
                        num25 = 20f;
                    }

                    npc.soundDelay = (int)num25;

                    SoundEngine.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1, 1f, 0f);
                }

                num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);

                float num26 = Math.Abs(num21);
                float num27 = Math.Abs(num22);
                float num28 = num18 / num23;

                num21 *= num28;
                num22 *= num28;

                if (((npc.velocity.X > 0f && num21 > 0f) || (npc.velocity.X < 0f && num21 < 0f)) && ((npc.velocity.Y > 0f && num22 > 0f) || (npc.velocity.Y < 0f && num22 < 0f)))
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num20;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num20;
                    }

                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num20;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num20;
                    }
                }
                if ((npc.velocity.X > 0f && num21 > 0f) || (npc.velocity.X < 0f && num21 < 0f) || (npc.velocity.Y > 0f && num22 > 0f) || (npc.velocity.Y < 0f && num22 < 0f))
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19;
                    }

                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num19;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num19;
                    }

                    if (Math.Abs(num22) < num18 * 0.2 && ((npc.velocity.X > 0f && num21 < 0f) || (npc.velocity.X < 0f && num21 > 0f)))
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num19 * 2f;
                        }
                        else
                        {
                            npc.velocity.Y = npc.velocity.Y - num19 * 2f;
                        }
                    }

                    if (Math.Abs(num21) < num18 * 0.2 && ((npc.velocity.Y > 0f && num22 < 0f) || (npc.velocity.Y < 0f && num22 > 0f)))
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num19 * 2f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num19 * 2f;
                        }
                    }
                }
                else if (num26 > num27)
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 1.1f;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 1.1f;
                    }

                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num18 * 0.5)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num19;
                        }
                        else
                        {
                            npc.velocity.Y = npc.velocity.Y - num19;
                        }
                    }
                }
                else
                {
                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num19 * 1.1f;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num19 * 1.1f;
                    }

                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num18 * 0.5)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num19;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num19;
                        }
                    }
                }
            }

            npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
        }
    }
}