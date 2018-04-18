using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using Fargowiltas;
using System.Linq;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        //for convenience
        public bool isStandingStill = false;

        public bool wood = false;
        public bool eater = false;
        public bool queenStinger = false;
        public bool infinity = false;
        public bool npcBoost = false;

        //shoot speed
        public float firingSpeed = 0f;
        public float castingSpeed = 0f;
        public float throwingSpeed = 0f;
        public float radiantSpeed = 0f;
        public float symphonicSpeed = 0f;
        public float healingSpeed = 0f;
        public float axeSpeed = 0f;
        public float hammerSpeed = 0f;
        public float pickSpeed = 0f;

        //minions
        public bool brainMinion = false;
        public bool eaterMinion = false;

        //enchantments
        public bool shadowEnchant = false;
        public bool crimsonEnchant = false;
        public bool spectreEnchant = false;
        public bool specHeal = false;
        public int healTown = 0;
        public bool beeEnchant = false;
        public bool spiderEnchant = false;
        public bool stardustEnchant = false;
        public bool mythrilEnchant = false;
        public bool fossilEnchant = false;
        public bool jungleEnchant = false;
        public bool elementEnchant = false;
        public bool shroomEnchant = false;
        public bool cobaltEnchant = false;
        public bool spookyEnchant = false;
        public bool hallowEnchant = false;
        public bool chloroEnchant = false;
        public bool vortexEnchant = false;
        public static int vortexCrit = 4;
        public bool vortexStealth = false;
        public bool adamantiteEnchant = false;
        public bool frostEnchant = false;
        public bool palladEnchant = false;
        public bool oriEnchant = false;
        public bool meteorEnchant = false;
        private int meteorTimer = 120;
        private int meteorCD = 0;
        public bool moltenEnchant = false;


        public bool copperEnchant = false;
        public bool ninjaEnchant = false;
        public bool firstStrike = false;
        public bool ironEnchant = false;
        public bool turtleEnchant = false;
        public bool leadEnchant = false;
        public bool gladEnchant = false;
        public bool goldEnchant = false;

        //pets
        public bool flickerPet = false;
        public bool moonEye = false;
        public bool dinoPet = false;
        public bool seedPet = false;
        public bool dogPet = false;
        public bool catPet = false;
        public bool pumpkinPet = false;
        public bool skullPet = false;
        public bool saplingPet = false;
        public bool turtlePet = false;
        public bool lizPet = false;
        public bool eyePet = false;
        public bool minotaurPet = false;
        public bool dragPet = false;
        public bool shadowPet = false;
        public bool shadowPet2 = false;
        public bool crimsonPet = false;
        public bool crimsonPet2 = false;
        public bool spectrePet = false;
        public bool penguinPet = false;
        public bool snowmanPet = false;
        public bool fishPet = false;
        public bool cubePet = false;
        public bool grinchPet = false;
        public bool suspiciousEyePet = false;
        public bool beePet = false;
        public bool spiderPet = false;
        public bool lanternPet = false;

        //soul effects
        public bool meleeEffect = false;
        public bool throwSoul = false;
        public bool rangedEffect = false;
        public bool miniRangedEffect = false;
        public bool builderEffect = false;
        public bool builderMode = false;
        public bool universeEffect = false;
        public bool speedEffect = false;
        public bool tankEffect = false;
        public bool fishSoul1 = false;
        public bool fishSoul2 = false;
        public bool dimensionSoul = false;
        public bool terrariaSoul = false;
        public int healTimer = 0;
        public bool voidSoul = false;

        //debuffs
        public bool hexed = false;
        public bool unstable = false;
        private int unstableCD = 0;
        public bool fused = false;
        public bool shadowflame = false;

        public bool godEater = false;               //defense removed, endurance removed, colossal DOT
        public bool flamesoftheUniverse = false;    //activates various vanilla debuffs
        public bool mutantNibble = false;           //disables potions, moon bite effect, feral bite effect, disables lifesteal
        public int statLifePrevious = -1;           //used for mutantNibble
        public bool asocial = false;                //disables minions, disables pets
        public bool wasAsocial = false;
        public bool hidePetToggle0 = true;
        public bool hidePetToggle1 = true;
        public bool kneecapped = false;             //disables running :v
        public bool defenseless = false;            //-30 defense, no damage reduction, cross necklace and knockback prevention effects disabled
        public bool lethargic = false;              //all item speed reduced to 75%
        public bool purified = false;               //purges all other buffs
        public bool infested = false;               //weak DOT that grows exponentially stronger
        public int maxInfestTime;
        public bool firstInfection = true;
        public float infestedDust;
        public bool rotting = false;                //inflicts DOT and almost every stat reduced
        public bool squeakyToy = false;             //all attacks do one damage and make squeaky noises
        public bool bloodthirst = false;
        public bool atrophied = false;              //melee speed and damage reduced. maybe player cannot fire melee projectiles?
        public bool jammed = false;                 //ranged damage and speed reduced, all non-custom ammo set to baseline ammos
        public bool slimed = false;



        public override TagCompound Save()
        {
            TagCompound tagCompound = new TagCompound();
            foreach (KeyValuePair<String, Boolean> entry in Soulcheck.toggleDict)
            {
                tagCompound.Add(entry.Key, entry.Value);
            }
            return tagCompound;
            // return base.Save();
        }
        public override void Load(TagCompound tag)
        {
            foreach (KeyValuePair<String, Object> entry in tag)
            {
                try
                {
                    if (Soulcheck.toggleDict.ContainsKey(entry.Key))
                    {
                        Soulcheck.toggleDict[entry.Key] = (bool)entry.Value;
                    }
                    else
                    {
                        Soulcheck.toggleDict.Add(entry.Key, (bool)entry.Value);
                    }
                }
                catch (Exception e) { }
            }
            base.Load(tag);
        }


        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Fargowiltas.CheckListKey.JustPressed)
            {
                if (Soulcheck.visible == false)
                {
                    Soulcheck.visible = true;
                }
                else
                {
                    Soulcheck.visible = false;
                }
            }

            //may need cooldown?
            if (voidSoul && Fargowiltas.HomeKey.JustPressed)
            {
                if (Main.rand.Next(2) == 0)
                    Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.1f);

                for (int index = 0; index < 70; ++index)
                    Dust.NewDust(player.position, player.width, player.height, 15, (float)(player.velocity.X * 0.5), (float)(player.velocity.Y * 0.5), 150, Color.White, 1.5f);
                player.grappling[0] = -1;
                player.grapCount = 0;
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
                        Main.projectile[index].Kill();
                }
                player.Spawn();
                for (int index = 0; index < 70; ++index)
                    Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.White, 1.5f);
            }
        }
        public override void ResetEffects()
        {

            wood = false;
            eater = false;

            queenStinger = false;
            infinity = false;
            //npcBoost = false;

            firingSpeed = 0f;
            castingSpeed = 0f;
            throwingSpeed = 0f;
            radiantSpeed = 0f;
            symphonicSpeed = 0f;
            healingSpeed = 0f;
            axeSpeed = 0f;
            hammerSpeed = 0f;
            pickSpeed = 0f;


            brainMinion = false;
            eaterMinion = false;

            //enchantments
            shadowEnchant = false;
            crimsonEnchant = false;
            spectreEnchant = false;
            beeEnchant = false;
            spiderEnchant = false;
            stardustEnchant = false;
            mythrilEnchant = false;
            fossilEnchant = false;
            jungleEnchant = false;
            elementEnchant = false;
            shroomEnchant = false;
            cobaltEnchant = false;
            spookyEnchant = false;
            hallowEnchant = false;
            chloroEnchant = false;
            vortexEnchant = false;
            vortexStealth = false;
            adamantiteEnchant = false;
            frostEnchant = false;
            palladEnchant = false;
            oriEnchant = false;
            meteorEnchant = false;
            moltenEnchant = false;
            copperEnchant = false;
            ninjaEnchant = false;
            firstStrike = false;
            ironEnchant = false;
            turtleEnchant = false;
            leadEnchant = false;
            gladEnchant = false;
            goldEnchant = false;

            //pets
            flickerPet = false;
            moonEye = false;
            dinoPet = false;
            seedPet = false;
            dogPet = false;
            catPet = false;
            pumpkinPet = false;
            skullPet = false;
            saplingPet = false;
            turtlePet = false;
            lizPet = false;
            eyePet = false;
            minotaurPet = false;
            dragPet = false;
            shadowPet = false;
            shadowPet2 = false;
            crimsonPet = false;
            crimsonPet2 = false;
            spectrePet = false;
            penguinPet = false;
            snowmanPet = false;
            fishPet = false;
            cubePet = false;
            grinchPet = false;
            suspiciousEyePet = false;
            beePet = false;
            spiderPet = false;
            lanternPet = false;

            //add to kill pets!

            //souls
            meleeEffect = false;
            throwSoul = false;
            rangedEffect = false;
            miniRangedEffect = false;
            builderEffect = false;
            builderMode = false;
            universeEffect = false;
            speedEffect = false;
            tankEffect = false;
            fishSoul1 = false;
            fishSoul2 = false;
            dimensionSoul = false;
            terrariaSoul = false;
            healTimer = 0;
            voidSoul = false;

            //debuffs
            hexed = false;
            unstable = false;
            fused = false;
            shadowflame = false;
            slimed = false;

            godEater = false;
            flamesoftheUniverse = false;
            mutantNibble = false;
            asocial = false;
            kneecapped = false;
            defenseless = false;
            lethargic = false;
            purified = false;
            infested = false;
            rotting = false;
            squeakyToy = false;
            bloodthirst = false;
            atrophied = false;
            jammed = false;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (moltenEnchant)
            {
                Projectile boom = Projectile.NewProjectileDirect(player.Center, new Vector2(0, 0), mod.ProjectileType("Explosion"), (int)(50 * player.meleeDamage), 0f, Main.myPlayer);
                //boom.width *= 5;
                //boom.height *= 5;
            }

            if (voidSoul)
            {
                player.respawnTimer = (int)(player.respawnTimer * .5);
            }
        }

        public override void UpdateDead()
        {
            //debuffs
            hexed = false;
            unstable = false;
            fused = false;
            shadowflame = false;
            slimed = false;

            godEater = false;
            flamesoftheUniverse = false;
            mutantNibble = false;
            asocial = false;
            kneecapped = false;
            defenseless = false;
            lethargic = false;
            purified = false;
            infested = false;
            rotting = false;
            squeakyToy = false;
            bloodthirst = false;
            atrophied = false;
            jammed = false;
        }

        public override void PreUpdate()
        {
            isStandingStill = (double)Math.Abs(player.velocity.X) < 0.05 && (double)Math.Abs(player.velocity.Y) < 0.05;

            if (FargoWorld.masochistMode)
            {
                if (Main.bloodMoon)
                {
                    player.buffImmune[BuffID.Bleeding] = false;
                    player.AddBuff(BuffID.Bleeding, 2);
                }
            }

            if (!infested && !firstInfection)
            {
                firstInfection = true;
            }

            //ninja smoke bomb nonsense
            Projectile nearestProj = null;
            float distance = 5 * 16;

            Main.projectile.Where(x => x.type == ProjectileID.SmokeBomb && x.active).ToList().ForEach(x =>
            {
                if (nearestProj == null && Vector2.Distance(x.position, player.position) <= distance)
                {
                    nearestProj = x;
                    distance = Vector2.Distance(x.position, player.position);
                }
                else if (nearestProj != null && Vector2.Distance(nearestProj.position, player.position) <= distance)
                {
                    nearestProj = x;
                    distance = Vector2.Distance(nearestProj.position, player.position);
                }
            });

            if (nearestProj != null)
            {
                player.endurance += 0.20f;
                firstStrike = true;
            }

            //meteor shower nonsense
            if (meteorEnchant && player.statMana <= 5 && meteorCD == 0)
            {
                if (meteorTimer % 2 == 0)
                {
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(-1000, 1000), player.Center.Y - 1000, (float)Main.rand.Next(-2, 2), 0f + Main.rand.Next(8, 12), Main.rand.Next(424, 427), (int)(50 * player.magicDamage), 0f, Main.myPlayer, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
                }

                meteorTimer--;

                if (meteorTimer == 0)
                {
                    meteorCD = 600;
                    meteorTimer = 120;
                }
            }
            if (meteorCD > 0)
            {
                meteorCD--;
            }

            //tele through wall until open space on dash into wall
            if (voidSoul && player.dashDelay > 0 && player.velocity.X == 0)
            {
                var teleportPos = new Vector2();
                int direction = player.direction;

                teleportPos.X = player.position.X + direction;
                teleportPos.Y = player.position.Y;

                while (Collision.SolidCollision(teleportPos, player.width, player.height))
                {
                    if (direction == 1)
                    {
                        teleportPos.X++;
                    }
                    else
                    {
                        teleportPos.X--;
                    }
                }
                if (teleportPos.X > 50 && teleportPos.X < (double)(Main.maxTilesX * 16 - 50) && teleportPos.Y > 50 && teleportPos.Y < (double)(Main.maxTilesY * 16 - 50))
                {
                    player.Teleport(teleportPos, 1);
                    NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, teleportPos.X, teleportPos.Y, 1);
                }
            }


            if (unstable)
            {
                if (unstableCD >= 60)
                {
                    Vector2 pos = Main.screenPosition;

                    int x = Main.rand.Next((int)pos.X, (int)pos.X + Main.screenWidth);
                    int y = Main.rand.Next((int)pos.Y, (int)pos.Y + Main.screenHeight);
                    Vector2 teleportPos = new Vector2(x, y);

                    while (Collision.SolidCollision(teleportPos, player.width, player.height) && teleportPos.X > 50 && teleportPos.X < (double)(Main.maxTilesX * 16 - 50) && teleportPos.Y > 50 && teleportPos.Y < (double)(Main.maxTilesY * 16 - 50))
                    {
                        x = Main.rand.Next((int)pos.X, (int)pos.X + Main.screenWidth);
                        y = Main.rand.Next((int)pos.Y, (int)pos.Y + Main.screenHeight);
                        teleportPos = new Vector2(x, y);
                    }

                    player.Teleport(teleportPos, 1);
                    NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, teleportPos.X, teleportPos.Y, 1);

                    unstableCD = 0;
                }
                unstableCD++;
            }
        }

        public override void PostUpdate()
        {

        }

        public override void PostUpdateMiscEffects()
        {
            if (slimed)
            {
                //slowed effect
                player.moveSpeed /= 2f;
                player.jump /= 2;
            }

            if (godEater)
            {
                player.statDefense = 0;
                player.endurance = 0;
            }

            if (mutantNibble)
            {
                //disables lifesteal, mostly
                if (player.statLife > statLifePrevious)
                    player.statLife = statLifePrevious;
                else
                    statLifePrevious = player.statLife;
            }
            else
            {
                statLifePrevious = player.statLife;
            }

            if (defenseless)
            {
                player.statDefense -= 30;
                player.endurance = 0;
                player.longInvince = false;
                player.noKnockback = false;
            }

            if (purified)
            {
                KillPets();

                //removes all buffs/debuffs, but it interacts really weirdly with luiafk infinite potions.
                int purifiedID = mod.BuffType("Purified");
                for (int i = 0; i < 22; i++)
                {
                    if (player.buffType[i] > 0 && player.buffTime[i] > 0 && player.buffType[i] != purifiedID)
                        player.DelBuff(i);
                }
            }
            else if (asocial)
            {
                KillPets();
                player.maxMinions = 0;
                player.minionDamage -= .5f;
            }
            else if (wasAsocial) //should only occur when above debuffs end
            {
                player.hideMisc[0] = hidePetToggle0;
                player.hideMisc[1] = hidePetToggle1;

                wasAsocial = false;
            }

            if (rotting)
            {
                player.moveSpeed *= 0.75f;
            }

            if (kneecapped)
            {
                player.accRunSpeed = player.maxRunSpeed;
            }

            if (atrophied)
            {
                player.meleeSpeed = 0f; //melee silence
                player.thrownVelocity = 0f;
                //just in case
                player.meleeDamage = 0.01f;
                player.meleeCrit = 0;
            }
        }

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Masochist"));
            items.Add(item);
        }

        public override float UseTimeMultiplier(Item item)
        {
            if (lethargic)
            {
                return 0.5f;
            }

            if (rotting)
            {
                return 0.75f;
            }

            return 1f;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {

        }

        public override void OnHitAnything(float x, float y, Entity victim)
        {

        }

        public override void PostUpdateRunSpeeds()
        {
            if (speedEffect)
            {
                player.maxRunSpeed = 1000;
                player.accRunSpeed = 2;
                player.runAcceleration = 5;
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (shadowflame)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 10;

            }

            if (godEater)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;

                player.lifeRegenTime = 0;
                player.lifeRegen -= 90;
            }

            if (mutantNibble)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;

                if (player.lifeRegenCount > 0)
                    player.lifeRegenCount = 0;

                player.lifeRegenTime = 0;
            }

            if (infested)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;

                player.lifeRegenTime = 0;

                player.lifeRegen -= InfestedExtraDOT();
            }

            if (rotting)
            {
                if (player.lifeRegen > 0)
                    player.lifeRegen = 0;

                if (player.lifeRegenCount > 0)
                    player.lifeRegenCount = 0;

                player.lifeRegenTime = 0;

                player.lifeRegen -= 12;
            }


        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {

            if (shadowflame)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width, player.height, DustID.Shadowflame, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);

                    fullBright = true;
                }
            }

            if (infested)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width, player.height, DustID.Shadowflame, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), infestedDust);
                    Main.dust[dust].noGravity = true;
                    //Main.dust[dust].velocity *= 1.8f;
                    // Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);

                    fullBright = true;
                }
            }

            if (godEater) //plague dust code but its pink
            {
                if (Main.rand.Next(3) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 86, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.2f;
                    Main.dust[dust].velocity.Y -= 0.15f;
                    Main.playerDrawDust.Add(dust);
                }
                //plague -> proportions HEX DEC newcolor
                r *= 0.15f; //0.07f -> 0.50 FF 255 0.15f
                g *= 0.03f; //0.15f -> 1.00 33 051 0.03f
                b *= 0.09f; //0.01f -> ?.?? 99 153 0.09f
                fullBright = true;
            }

            if (flamesoftheUniverse)
            {
                drawInfo.drawPlayer.onFire = true;
                drawInfo.drawPlayer.onFire2 = true;
                drawInfo.drawPlayer.onFrostBurn = true;
                drawInfo.drawPlayer.ichor = true;
                drawInfo.drawPlayer.burned = true;

                //shadowflame
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width, player.height, DustID.Shadowflame, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);

                    fullBright = true;
                }

            }
        }


        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (hexed)
            {
                target.life += damage;
                target.HealEffect(damage, true);

                if (target.life > target.lifeMax)
                {
                    target.life = target.lifeMax;
                }

                damage = 0;
                knockback = 0;
                crit = false;

                return;

            }

            if (squeakyToy)
            {
                damage = 1;
                Squeak(target.Center);
                return;
            }

            if (proj.type == ProjectileID.Kraken || proj.type == ProjectileID.Trident || proj.type == ProjectileID.Flairon || proj.type == ProjectileID.FlaironBubble || proj.type == ProjectileID.WaterStream || proj.type == ProjectileID.WaterBolt || proj.type == ProjectileID.RainNimbus || proj.type == ProjectileID.Bubble)
            {
                target.AddBuff(BuffID.Wet, 180, true);
            }

            if (terrariaSoul)
            {
                target.AddBuff(BuffID.Venom, 240, true);
            }

            if (queenStinger)
            {
                target.AddBuff(BuffID.Poisoned, 120, true);
            }

            if (spiderEnchant && proj.minion)
            {
                target.AddBuff(BuffID.Venom, 120, true);
            }

            /*if (meleeEffect)
            {
               if(proj.melee)
			   {
				  target.AddBuff(BuffID.CursedInferno, 240, true);
			   }  
			}   */

            if (rangedEffect)
            {
                if (proj.ranged)
                {
                    target.AddBuff(BuffID.ShadowFlame, 240, true);
                }
            }

            if (universeEffect)
            {
                target.AddBuff(mod.BuffType("FlamesoftheUniverse"), 240, true);
            }

            if (shadowEnchant && Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 120, true);
            }
            if (crimsonEnchant && Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Ichor, 120, true);
            }



            if (chloroEnchant)
            {
                target.AddBuff(BuffID.Poisoned, 240, true);
                target.AddBuff(BuffID.Venom, 240, true);
            }

            if (cobaltEnchant)
            {
                target.AddBuff(BuffID.Confused, 120, true);
            }

            if (copperEnchant && proj.type != mod.ProjectileType("Shock"))
            {
                knockback = 0f;
                target.AddBuff(mod.BuffType("Shock"), 60, true);
                //Projectile.NewProjectile(target.Center.X, target.Center.Y, target.velocity.X, target.velocity.Y, mod.ProjectileType("Shock"), 20, 0, Main.myPlayer, 0f, 0f);
            }

            if (goldEnchant)
            {
                target.AddBuff(BuffID.Midas, 120, true);
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (hexed)
            {
                target.life += damage;
                target.HealEffect(damage, true);

                if (target.life > target.lifeMax)
                {
                    target.life = target.lifeMax;
                }

                damage = 0;
                knockback = 0;
                crit = false;

                return;

            }

            if (squeakyToy)
            {
                damage = 1;
                Squeak(target.Center);
                return;
            }

            if (voidSoul && Main.rand.Next(25) == 0 && target.type != NPCID.TargetDummy)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y - 10, 0f, 0f, 518, 0, 0f, Main.myPlayer, 0f, 0f);
            }

            if (terrariaSoul)
            {
                target.AddBuff(BuffID.Venom, 240, true);
            }

            if (queenStinger)
            {
                target.AddBuff(BuffID.Poisoned, 120, true);
            }

            if (spiderEnchant && item.summon)
            {
                target.AddBuff(BuffID.Venom, 120, true);
            }

            if (meleeEffect)
            {
                if (item.melee)
                {
                    // target.AddBuff(BuffID.CursedInferno, 240, true);
                    target.AddBuff(mod.BuffType("SuperBleed"), 240, true);

                }
            }

            if (rangedEffect)
            {
                if (item.ranged)
                {
                    target.AddBuff(BuffID.ShadowFlame, 240, true);
                }

            }

            if (universeEffect)
            {
                target.AddBuff(mod.BuffType("FlamesoftheUniverse"), 240, true);
            }

            if (shadowEnchant && Main.rand.Next(4) == 0)
            {
                target.AddBuff(BuffID.ShadowFlame, 120, true);
            }

            if (chloroEnchant)
            {
                target.AddBuff(BuffID.Poisoned, 240, true);
                target.AddBuff(BuffID.Venom, 240, true);
            }

            if (cobaltEnchant && Main.rand.Next(3) == 0)
            {
                target.AddBuff(BuffID.Confused, 120, true);
            }

            if (goldEnchant)
            {
                target.AddBuff(BuffID.Midas, 120, true);
            }
        }

        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
        {
            if (squeakyToy)
            {
                damage = 1;
                Squeak(target.Center);
            }
        }

        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
        {
            if (squeakyToy)
            {
                damage = 1;
                Squeak(target.Center);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (infinity && (player.HeldItem.ranged || player.HeldItem.magic || player.HeldItem.thrown))
            {
                player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " self destructed."), player.HeldItem.damage / 33, 0);
                player.immune = false;
            }

            //no heal on dummy!!!
            if (target.type == NPCID.TargetDummy)
            {
                return;
            }

            if (spectreEnchant && proj.magic)
            {
                if (crit)
                {
                    specHeal = true;
                    healTown++;
                }
                else
                {
                    if (healTown != 0 && healTown <= 6)
                    {
                        healTown++;
                    }
                    else
                    {
                        specHeal = false;
                        healTown = 0;
                    }
                }
            }

            if (vortexEnchant && proj.ranged)
            {
                if (crit && (vortexCrit < 100))
                {
                    vortexCrit += 4;
                }
            }

            if (terrariaSoul)
            {
                if (crit && (vortexCrit < 100))
                {
                    vortexCrit += 4;
                }
                else if (vortexCrit >= 100 && proj.type != ProjectileID.CrystalLeafShot && proj.type != mod.ProjectileType("HallowSword"))
                {
                    if (healTimer == 0)
                    {
                        player.statLife += (damage / 25);
                        player.HealEffect(damage / 25);
                        healTimer = 10;
                    }
                    else
                    {
                        healTimer--;
                    }
                }
            }

            if (palladEnchant && Main.rand.Next(50) == 0)
            {
                player.statLife += (damage / 3);
                player.HealEffect(damage / 3);
            }

        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {

            /*if(terrariaSoul && Main.rand.Next(10) == 0)
			{
				player.statLife += (damage);
				player.HealEffect(damage);
			}*/
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            // if(turtleEnchant)
            // {
            //when standing still
            // if ((double)Math.Abs(player.velocity.X) < 0.05 && (double)Math.Abs(player.velocity.Y) < 0.05 && player.itemAnimation == 0)
            // {
            // if(Main.expertMode)
            // {
            // damage = damage - (int)(player.statDefense * 0.75);
            // }
            // else
            // {
            // damage = damage - (int)(player.statDefense * 0.5);
            // }
            // player.statLife -= damage;

            // damage = 0;
            // }
            // }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {

        }

        public override bool CanBeHitByProjectile(Projectile proj)
        {
            if (queenStinger)
            {
                if (proj.type == ProjectileID.Stinger)
                {
                    return false;
                }
            }

            //ninja?
            /*if(tankEffect/* && Main.rand.Next(10) == 0)
			{
				return false;
			}*/
            return true;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            bool returnValue = true;

            if (FargoWorld.masochistMode)
            {
                //no work
                //lava
                if (damageSource == PlayerDeathReason.ByOther(2))
                {
                    //player.KillMe(PlayerDeathReason.ByOther(2), 999, 1);
                    player.Hurt(PlayerDeathReason.ByOther(2), 999, 1);
                }
            }

            if (voidSoul && Main.rand.Next(10) == 0)
            {
                returnValue = false; ;
            }
            return returnValue;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

            if (jungleEnchant)
            {
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 62);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);

                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SporeBoom"), 30, 5, Main.myPlayer, 0f, 0f);
            }

            if (terrariaSoul && jungleEnchant)
            {
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 62);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -2.5f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -2.5f, 0f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.75f, -0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -0.75f, 0.75f, mod.ProjectileType("SporeBoom"), 0, 0, Main.myPlayer, 0f, 0f);

                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SporeBoom"), 120, 5, Main.myPlayer, 0f, 0f);
            }

            if (spookyEnchant && player.FindBuffIndex(mod.BuffType("SpookyCD")) == -1)
            {
                Main.PlaySound(2/**/, (int)player.position.X, (int)player.position.Y, 62);

                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 5f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 5f, 0f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -5f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -5f, 0f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, 4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, -4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4f, -4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4f, 4f, mod.ProjectileType("SpookyScythe"), 80, 2, Main.myPlayer, 0f, 0f);

                player.AddBuff(mod.BuffType("SpookyCD"), 240);

            }

            if ((vortexEnchant || terrariaSoul) && vortexCrit > 4)
            {
                vortexCrit /= 2;
            }

            if (tankEffect && Main.rand.Next(5) == 0)
            {
                player.statLife += (Convert.ToInt32(damage * .5));
                player.HealEffect(Convert.ToInt32(damage * .5));
            }

            if (dimensionSoul && Main.rand.Next(3) == 0)
            {
                player.statLife += (Convert.ToInt32(damage * .75));
                player.HealEffect(Convert.ToInt32(damage * .75));
            }

        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            //add rando debuff thing
            //insert check for masomode here
            // int rng = Main.rand.Next(FargoDebuffs.instance.debuffIDs.Length);
            //int debuff = FargoDebuffs.instance.debuffIDs[rng];
            //player.AddBuff(debuff, 300);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (fossilEnchant && player.FindBuffIndex(mod.BuffType("Revived")) == -1)
            {
                player.statLife = 20;
                player.HealEffect(20);
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                Main.NewText("You've been revived!", 175, 75, 255);
                player.AddBuff(mod.BuffType("Revived"), 18000);
                return false;
            }
            if (terrariaSoul && player.FindBuffIndex(mod.BuffType("Revived")) == -1)
            {
                player.statLife = 200;
                player.HealEffect(200);
                player.immune = true;
                player.immuneTime = player.longInvince ? 180 : 120;
                Main.NewText("You've been revived!", 175, 75, 255);
                player.AddBuff(mod.BuffType("Revived"), 14400);
                return false;
            }

            //add more tbh
            if (infested && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " could not handle the infection.");
            }

            if (rotting && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " rotted away.");
            }

            if ((godEater || flamesoftheUniverse) && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8)
            {
                damageSource = PlayerDeathReason.ByCustomReason(player.name + " was annihilated by divine wrath.");
            }

            return true;
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            if (infinity)
            {
                return false;
            }

            if (universeEffect)
            {
                if (Main.rand.Next(100) < 50)
                {
                    return false;
                }
            }

            if (rangedEffect)
            {
                if (Main.rand.Next(100) < 32)
                {
                    return false;
                }
            }

            if (miniRangedEffect)
            {
                if (Main.rand.Next(100) < 4)
                {
                    return false;
                }
            }

            if (throwSoul)
            {
                if (Main.rand.Next(100) < 32)
                {
                    return false;
                }

            }
            return true;


        }

        /*public override void SetControls ()
		{
			vortexStealth = player.vortexStealthActive;
		}
		
		public override void PostUpdateEquips ()
		{
			if(vortexEnchant)
			{
				player.setVortex = true;
				player.vortexStealthActive = vortexStealth;
			}
		}*/

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (meteorEnchant)
            {
                if (item.type == ItemID.SpaceGun || item.type == ItemID.LaserRifle || item.type == ItemID.HeatRay || item.type == ItemID.LaserMachinegun)
                {
                    player.statMana += item.mana;
                }
            }

            if (fishSoul2 && item.fishingPole > 0)
            {
                float spread = 45f * 0.0174f;
                float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
                double deltaAngle = spread / 20f;
                double offsetAngle;
                int i;
                for (i = 0; i < 10; i++)
                {
                    offsetAngle = startAngle + deltaAngle * i;
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
                }

                return true;
            }

            if (fishSoul1 && item.fishingPole > 0)
            {
                float spread = 45f * 0.0174f;
                float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
                double deltaAngle = spread / 20f;
                double offsetAngle;
                int i;

                for (i = 0; i < 4; i++)
                {
                    offsetAngle = startAngle + deltaAngle * i;
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
                }

                return true;

            }

            if (terrariaSoul && Main.rand.Next(2) == 0 && Soulcheck.GetValue("Splitting Projectiles") && !item.summon)
            {
                float spread = 2f * 0.1250f;
                float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                double baseAngle = Math.Atan2(speedX, speedY);
                double offsetAngle;

                for (float i = -1f; i <= 1f; i++)
                {
                    offsetAngle = baseAngle + i * spread;
                    Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
                }

                return false;
            }

            if (adamantiteEnchant && item.magic)
            {

                if (Main.rand.Next(5) == 0)
                {
                    float spread = 2f * 0.1250f;
                    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                    double baseAngle = Math.Atan2(speedX, speedY);
                    double offsetAngle;

                    for (float i = -1f; i <= 1f; i++)
                    {
                        offsetAngle = baseAngle + i * spread;
                        Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI, 0f, 0f);
                    }

                    return false;
                }
                else if (Main.rand.Next(20) == 0)
                {
                    float spread = 45f * 0.0174f;
                    double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
                    double deltaAngle = spread / 8f;
                    double offsetAngle;
                    int i;
                    int j = Main.rand.Next(3);

                    int r = 0;

                    do
                    {
                        r = Main.rand.Next(714);
                    } while (r != 15 && r != 20 && r != 27 && r != 45 && r != 88 && r != 95 && r != 114 && r != 253 && r != 261 && r != 280 && r != 316 && r != 409 && r != 459 && r != 504 && r != 510 && r != 521 && r != 634 && r != 635 && r != 660 && r != 711 && r != 704 && !((r >= 76) && (r <= 78)) && !((r >= 121) && (r <= 126)) && !((r >= 294) && (r <= 295)));

                    for (i = 0; i < 1; i++)
                    {
                        offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, r, damage, knockBack, player.whoAmI, 0f, 0f);
                    }

                    return false;
                }
            }

            return true;
        }

        private void KillPets()
        {
            int petID = player.miscEquips[0].buffType;
            int lightPetID = player.miscEquips[1].buffType;

            player.buffImmune[petID] = true;
            player.buffImmune[lightPetID] = true;

            player.ClearBuff(petID);
            player.ClearBuff(lightPetID);

            beePet = false;
            catPet = false;
            crimsonPet = false;
            crimsonPet2 = false;
            cubePet = false;
            dinoPet = false;
            dogPet = false;
            dragPet = false;
            eyePet = false;
            fishPet = false;
            grinchPet = false;
            lanternPet = false;
            lizPet = false;
            minotaurPet = false;
            penguinPet = false;
            pumpkinPet = false;
            saplingPet = false;
            seedPet = false;
            shadowPet = false;
            shadowPet2 = false;
            skullPet = false;
            snowmanPet = false;
            spectrePet = false;
            spiderPet = false;
            suspiciousEyePet = false;
            turtlePet = false;

            //memorizes player selections
            if (!wasAsocial)
            {
                hidePetToggle0 = player.hideMisc[0];
                hidePetToggle1 = player.hideMisc[1];

                wasAsocial = true;
            }

            //disables pet and light pet too!
            if (!player.hideMisc[0])
            {
                player.TogglePet();
            }

            if (!player.hideMisc[1])
            {
                player.ToggleLight();
            }

            player.hideMisc[0] = true;
            player.hideMisc[1] = true;
        }

        private void Squeak(Vector2 center)
        {
            int rng = Main.rand.Next(6);

            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/SqueakyToy/squeak" + (rng + 1)).WithVolume(1f).WithPitchVariance(.5f), center);

        }

        private int InfestedExtraDOT()
        {
            int buffIndex = player.FindBuffIndex(mod.BuffType("Infested"));

            if (buffIndex == -1)
                return 0;

            int timeLeft = player.buffTime[buffIndex];

            float baseVal = (float)(maxInfestTime - timeLeft) / (120);
            //change the denominator to adjust max power of DOT
            int modifier = (int)(baseVal * baseVal + 8);

            infestedDust = (baseVal / 10) + 1f;

            if (infestedDust > 5f)
            {
                infestedDust = 5f;
            }

            return modifier;
        }

    }
}
