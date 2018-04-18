using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System;
using Microsoft.Xna.Framework.Graphics;
using Fargowiltas;

namespace Fargowiltas.Items.Enchantments
{
    public class TerrariaSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Terraria");
            Tooltip.SetDefault("'Welcome back master'\n" +
                                "All effects of material Forces, some upgraded");

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 24));
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 500000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            modPlayer.terrariaSoul = true;
            if (Soulcheck.GetValue("Spore Explosion") == true)
            {
                modPlayer.jungleEnchant = true;
            }
            //miner
            player.pickSpeed -= 0.3f;
            if (Soulcheck.GetValue("Shine Buff") == true)
            {
                Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
            }
            //cobalt
            modPlayer.cobaltEnchant = true;

            //palladium
            player.onHitRegen = true;

            //mythril	
            if (Soulcheck.GetValue("Increase Use Speed"))
            {
                modPlayer.firingSpeed += .5f;
                modPlayer.castingSpeed += .5f;
                modPlayer.throwingSpeed += .5f;
                modPlayer.radiantSpeed += .5f;
                modPlayer.symphonicSpeed += .5f;
                modPlayer.healingSpeed += .5f;
                modPlayer.axeSpeed += .5f;
                modPlayer.hammerSpeed += .5f;
                modPlayer.pickSpeed += .5f;
            }

            //orichalcum
            if (Soulcheck.GetValue("Orichalcum Fireball") == true)
            {
                player.onHitPetal = true;
                modPlayer.oriEnchant = true;
            }
            //titanium
            player.onHitDodge = true;
            player.kbBuff = true;

            if (!(player.FindBuffIndex(59) == -1))
            {
                player.magicDamage += .25f;
                player.meleeDamage += .25f;
                player.rangedDamage += .25f;
                player.minionDamage += .25f;
                player.thrownDamage += .25f;
            }

            //molten
            if (Soulcheck.GetValue("Inferno Buff") == true)
            {
                player.inferno = true;
                Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                int num = 24;
                float num2 = 200f;
                bool flag = player.infernoCounter % 60 == 0;
                int damage = 100;
                if (player.whoAmI == Main.myPlayer)
                {
                    for (int l = 0; l < 200; l++)
                    {
                        NPC nPC = Main.npc[l];
                        if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num] && Vector2.Distance(player.Center, nPC.Center) <= num2)
                        {
                            if (nPC.FindBuffIndex(num) == -1)
                            {
                                nPC.AddBuff(num, 120, false);
                            }
                            if (flag)
                            {
                                player.ApplyDamageToNPC(nPC, damage, 0f, 0, false);
                            }
                        }
                    }
                }
            }
            player.lavaImmune = true;

            //chloro
            if (Soulcheck.GetValue("Leaf Crystal") == true)
            {
                modPlayer.chloroEnchant = true;

                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts[mod.ProjectileType("Chlorofuck")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, mod.ProjectileType("Chlorofuck"), 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            //shroomite
            if (Soulcheck.GetValue("Shroomite Stealth") == true)
            {
                player.shroomiteStealth = true;
                modPlayer.shroomEnchant = true;
            }

            //crimson
            player.crimsonRegen = true;

            //bee + spider 
            player.strongBees = true;
            if (Soulcheck.GetValue("Bees on Hit"))
            {
                modPlayer.beeEnchant = true;
            }
            modPlayer.spiderEnchant = true;

            if (Soulcheck.GetValue("Spelunker Buff") == true)
            {
                player.findTreasure = true;
            }
            if (Soulcheck.GetValue("Hunter Buff") == true)
            {
                player.detectCreature = true;
            }
            if (Soulcheck.GetValue("Dangersense Buff") == true)
            {
                player.dangerSense = true;
            }

            //beetle + turtle
            modPlayer.turtleEnchant = true;
            player.aggro += 50;
            player.thorns = 1f;
            player.turtleThorns = true;
            player.statDefense = (int)(player.statDefense * 1.25);
            if (Soulcheck.GetValue("Beetles") == true)
            {
                player.beetleDefense = true;
                player.beetleCounter += 1f;
                int num5 = 180;
                if (player.beetleCounter >= (float)num5)
                {
                    if (player.beetleOrbs > 0 && player.beetleOrbs < 3)
                    {
                        for (int k = 0; k < 22; k++)
                        {
                            if (player.buffType[k] >= 95 && player.buffType[k] <= 96)
                            {
                                player.DelBuff(k);
                            }
                        }
                    }
                    if (player.beetleOrbs < 3)
                    {
                        player.AddBuff(95 + player.beetleOrbs, 5, false);
                        player.beetleCounter = 0f;
                    }
                    else
                    {
                        player.beetleCounter = (float)num5;
                    }
                }

                if (!player.beetleDefense && !player.beetleOffense)
                {
                    player.beetleCounter = 0f;
                }
                else
                {
                    player.beetleFrameCounter++;
                    if (player.beetleFrameCounter >= 1)
                    {
                        player.beetleFrameCounter = 0;
                        player.beetleFrame++;
                        if (player.beetleFrame > 2)
                        {
                            player.beetleFrame = 0;
                        }
                    }
                    for (int l = player.beetleOrbs; l < 3; l++)
                    {
                        player.beetlePos[l].X = 0f;
                        player.beetlePos[l].Y = 0f;
                    }
                    for (int m = 0; m < player.beetleOrbs; m++)
                    {
                        player.beetlePos[m] += player.beetleVel[m];
                        Vector2[] expr_6EC_cp_0 = player.beetleVel;
                        int expr_6EC_cp_1 = m;
                        expr_6EC_cp_0[expr_6EC_cp_1].X = expr_6EC_cp_0[expr_6EC_cp_1].X + (float)Main.rand.Next(-100, 101) * 0.005f;
                        Vector2[] expr_71A_cp_0 = player.beetleVel;
                        int expr_71A_cp_1 = m;
                        expr_71A_cp_0[expr_71A_cp_1].Y = expr_71A_cp_0[expr_71A_cp_1].Y + (float)Main.rand.Next(-100, 101) * 0.005f;
                        float num6 = player.beetlePos[m].X;
                        float num7 = player.beetlePos[m].Y;
                        float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
                        if (num8 > 100f)
                        {
                            num8 = 20f / num8;
                            num6 *= -num8;
                            num7 *= -num8;
                            int num9 = 10;
                            player.beetleVel[m].X = (player.beetleVel[m].X * (float)(num9 - 1) + num6) / (float)num9;
                            player.beetleVel[m].Y = (player.beetleVel[m].Y * (float)(num9 - 1) + num7) / (float)num9;
                        }
                        else if (num8 > 30f)
                        {
                            num8 = 10f / num8;
                            num6 *= -num8;
                            num7 *= -num8;
                            int num10 = 20;
                            player.beetleVel[m].X = (player.beetleVel[m].X * (float)(num10 - 1) + num6) / (float)num10;
                            player.beetleVel[m].Y = (player.beetleVel[m].Y * (float)(num10 - 1) + num7) / (float)num10;
                        }
                        num6 = player.beetleVel[m].X;
                        num7 = player.beetleVel[m].Y;
                        num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
                        if (num8 > 2f)
                        {
                            player.beetleVel[m] *= 0.9f;
                        }
                        player.beetlePos[m] -= player.velocity * 0.25f;
                    }
                }
            }

            //necro
            //skeletons
            player.npcTypeNoAggro[21] = true;
            player.npcTypeNoAggro[31] = true;
            player.npcTypeNoAggro[32] = true;
            player.npcTypeNoAggro[33] = true;
            player.npcTypeNoAggro[34] = true;
            player.npcTypeNoAggro[44] = true;
            player.npcTypeNoAggro[45] = true;
            player.npcTypeNoAggro[77] = true;
            player.npcTypeNoAggro[110] = true;
            player.npcTypeNoAggro[167] = true;
            player.npcTypeNoAggro[172] = true;
            player.npcTypeNoAggro[197] = true;
            player.npcTypeNoAggro[201] = true;
            player.npcTypeNoAggro[202] = true;
            player.npcTypeNoAggro[203] = true;
            player.npcTypeNoAggro[269] = true;
            player.npcTypeNoAggro[270] = true;
            player.npcTypeNoAggro[271] = true;
            player.npcTypeNoAggro[272] = true;
            player.npcTypeNoAggro[273] = true;
            player.npcTypeNoAggro[274] = true;
            player.npcTypeNoAggro[275] = true;
            player.npcTypeNoAggro[276] = true;
            player.npcTypeNoAggro[277] = true;
            player.npcTypeNoAggro[278] = true;
            player.npcTypeNoAggro[279] = true;
            player.npcTypeNoAggro[280] = true;
            player.npcTypeNoAggro[281] = true;
            player.npcTypeNoAggro[282] = true;
            player.npcTypeNoAggro[283] = true;
            player.npcTypeNoAggro[284] = true;
            player.npcTypeNoAggro[285] = true;
            player.npcTypeNoAggro[286] = true;
            player.npcTypeNoAggro[287] = true;
            player.npcTypeNoAggro[291] = true;
            player.npcTypeNoAggro[292] = true;
            player.npcTypeNoAggro[293] = true;
            player.npcTypeNoAggro[294] = true;
            player.npcTypeNoAggro[295] = true;
            player.npcTypeNoAggro[296] = true;
            player.npcTypeNoAggro[322] = true;
            player.npcTypeNoAggro[323] = true;
            player.npcTypeNoAggro[324] = true;
            player.npcTypeNoAggro[449] = true;
            player.npcTypeNoAggro[450] = true;
            player.npcTypeNoAggro[451] = true;
            player.npcTypeNoAggro[452] = true;

            //forbidden
            player.buffImmune[194] = true;

            if (Soulcheck.GetValue("Forbidden Storm") == true)
            {
                player.setForbidden = true;
                player.UpdateForbiddenSetLock();
                Lighting.AddLight(player.Center, 0.8f, 0.7f, 0.2f);
            }
            //hallowed

            player.noKnockback = true;

            //shield and sword
            if (Soulcheck.GetValue("Hallowed Shield") == true)
            {
                modPlayer.hallowEnchant = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts[mod.ProjectileType("HallowProj")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, mod.ProjectileType("HallowProj"), 80/*dmg*/, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            //spectre
            modPlayer.spectreEnchant = true;

            player.ghostHeal = true;
            player.ghostHurt = true;

            //spooky
            if (Soulcheck.GetValue("Spooky Scythes") == true)
            {
                modPlayer.spookyEnchant = true;
            }
            modPlayer.meteorEnchant = true;

            //solar
            if (Soulcheck.GetValue("Solar Shield") == true)
            {
                player.AddBuff(172, 5, false);
                player.setSolar = true;
                player.solarCounter++;
                int num11 = 240;
                if (player.solarCounter >= num11)
                {
                    if (player.solarShields > 0 && player.solarShields < 3)
                    {
                        for (int num12 = 0; num12 < 22; num12++)
                        {
                            if (player.buffType[num12] >= 170 && player.buffType[num12] <= 171)
                            {
                                player.DelBuff(num12);
                            }
                        }
                    }
                    if (player.solarShields < 3)
                    {
                        player.AddBuff(170 + player.solarShields, 5, false);
                        for (int num13 = 0; num13 < 16; num13++)
                        {
                            Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 100, default(Color), 1f)];
                            dust.noGravity = true;
                            dust.scale = 1.7f;
                            dust.fadeIn = 0.5f;
                            dust.velocity *= 5f;
                        }
                        player.solarCounter = 0;
                    }
                    else
                    {
                        player.solarCounter = num11;
                    }
                }
                for (int num14 = player.solarShields; num14 < 3; num14++)
                {
                    player.solarShieldPos[num14] = Vector2.Zero;
                }
                for (int num15 = 0; num15 < player.solarShields; num15++)
                {
                    player.solarShieldPos[num15] += player.solarShieldVel[num15];
                    Vector2 value = ((float)player.miscCounter / 100f * 6.28318548f + (float)num15 * (6.28318548f / (float)player.solarShields)).ToRotationVector2() * 6f;
                    value.X = (float)(player.direction * 20);
                    player.solarShieldVel[num15] = (value - player.solarShieldPos[num15]) * 0.2f;
                }
                if (player.dashDelay >= 0)
                {
                    player.solarDashing = false;
                    player.solarDashConsumedFlare = false;
                }
                bool flag = player.solarDashing && player.dashDelay < 0;
                if (player.solarShields > 0 || flag)
                {
                    player.dash = 3;
                }
            }
            //vortex
            player.meleeCrit = FargoPlayer.vortexCrit;
            player.rangedCrit = FargoPlayer.vortexCrit;
            player.magicCrit = FargoPlayer.vortexCrit;
            player.thrownCrit = FargoPlayer.vortexCrit;

            //nebula
            if (player.nebulaCD > 0)
            {
                player.nebulaCD--;
            }
            player.setNebula = true;

            //stardust
            if (Soulcheck.GetValue("Stardust Guardian") == true)
            {
                modPlayer.stardustEnchant = true;
                player.setStardust = true;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(187) == -1)
                    {
                        player.AddBuff(187, 3600, true);
                    }
                    if (player.ownedProjectileCounts[623] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, 623, 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            //pets
            if (player.whoAmI == Main.myPlayer)
            {
                if (Soulcheck.GetValue("Baby Face Monster Pet"))
                {
                    modPlayer.crimsonPet = true;

                    if (player.FindBuffIndex(154) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabyFaceMonster] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabyFaceMonster, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.crimsonPet = false;
                }
            }

            if (player.whoAmI == Main.myPlayer)
            {
                if (Soulcheck.GetValue("Turtle Pet"))
                {
                    modPlayer.turtlePet = true;

                    if (player.FindBuffIndex(42) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.Turtle] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Turtle, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.turtlePet = false;
                }

                if (Soulcheck.GetValue("Baby Hornet Pet"))
                {
                    modPlayer.beePet = true;

                    if (player.FindBuffIndex(51) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabyHornet] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabyHornet, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.beePet = false;
                }

                if (Soulcheck.GetValue("Spider Pet"))
                {
                    modPlayer.spiderPet = true;

                    if (player.FindBuffIndex(81) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.Spider] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Spider, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.spiderPet = false;
                }

                if (Soulcheck.GetValue("Baby Dino Pet"))
                {
                    modPlayer.dinoPet = true;

                    if (player.FindBuffIndex(61) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabyDino] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabyDino, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.dinoPet = false;
                }

                if (Soulcheck.GetValue("Baby Eater Pet"))
                {
                    modPlayer.shadowPet = true;

                    if (player.FindBuffIndex(45) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabyEater] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabyEater, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.shadowPet = false;
                }

                if (Soulcheck.GetValue("Cursed Sapling Pet"))
                {
                    modPlayer.saplingPet = true;

                    if (player.FindBuffIndex(85) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.CursedSapling] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.CursedSapling, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.saplingPet = false;
                }

                if (Soulcheck.GetValue("Wisp Pet"))
                {
                    modPlayer.spectrePet = true;

                    if (player.FindBuffIndex(57) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.Wisp] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Wisp, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.spectrePet = false;
                }

                //if(Soulcheck.GetValue("Baby Eater Pet"))
                //{
                modPlayer.shadowPet2 = true;

                if (player.FindBuffIndex(19) == -1)
                {
                    if (player.ownedProjectileCounts[ProjectileID.ShadowOrb] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.ShadowOrb, 0, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
                //}
                //else
                //{
                //		modPlayer.shadowPet2 = false;
                //}

                //if(Soulcheck.GetValue("Baby Eater Pet"))
                //{
                modPlayer.crimsonPet2 = true;

                if (player.FindBuffIndex(155) == -1)
                {
                    if (player.ownedProjectileCounts[ProjectileID.CrimsonHeart] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.CrimsonHeart, 0, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
                //}
                //else
                //{
                //		modPlayer.crimsonPet2 = false;
                //}

                //if(Soulcheck.GetValue("Baby Face Monster Pet"))
                //{
                modPlayer.lanternPet = true;

                if (player.FindBuffIndex(152) == -1)
                {
                    if (player.ownedProjectileCounts[ProjectileID.MagicLantern] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.MagicLantern, 0, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
                //}
                //else
                //{
                //	modPlayer.lanternPet = false;
                //}
            }


        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EarthForce");
            recipe.AddIngredient(null, "NatureForce");
            recipe.AddIngredient(null, "LifeForce");
            recipe.AddIngredient(null, "SpiritForce");
            recipe.AddIngredient(null, "CosmoForce");

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}


