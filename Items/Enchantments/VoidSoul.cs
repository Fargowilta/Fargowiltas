using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class VoidSoul : ModItem
    {
        public int cd = 0;
        public int voidTimer = 600;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of the Void");
            Tooltip.SetDefault("'The depths of the Void have surrendered to your might' \n" +
                                "Rod of Discord effect on grapple key with a 2 second cooldown\n" +
                                "Whenever you teleport, you leave behind a void that sucks in nearby enemies\n" +
                                "Dash into any walls, to teleport through them to the next opening\n" +
                                "Chance for damage to be nullified completely\n" +
                                "Chance to spawn coin portals on enemy hits\n" +
                                "The Mutant's Grab Bags have unlocked their true potential\n" +
                                "Effects of the Cell Phone, set key to go home\n" +
                                "You respawn twice as fast\n" +
                                "Summons several pets from the Void");

        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 500000;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
        }

        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Placeholder";
            }
        }

        public override bool UseItem(Player player)
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
            // var teleportPos = new Vector2();
            // teleportPos.X = Main.mouseX + Main.screenPosition.X;
            // teleportPos.Y = Main.mouseY + Main.screenPosition.Y;

            // if (teleportPos.X > 50 && teleportPos.X < (double) (Main.maxTilesX * 16 - 50) && (teleportPos.Y > 50 && teleportPos.Y < (double) (Main.maxTilesY * 16 - 50)))
            // {
            // Projectile.NewProjectile(teleportPos.X, teleportPos.Y, 0f, 0f, mod.ProjectileType("Void"), 0, 0, Main.myPlayer, 0f, 0f);

            // }

            return true;
        }

        public override void UpdateInventory(Player player)
        {
            player.accWatch = 3;
            player.accDepthMeter = 1;
            player.accCompass = 1;
            player.accFishFinder = true;
            player.accWeatherRadio = true;
            player.accCalendar = true;
            player.accThirdEye = true;
            player.accJarOfSouls = true;
            player.accCritterGuide = true;
            player.accStopwatch = true;
            player.accOreFinder = true;
            player.accDreamCatcher = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            modPlayer.voidSoul = true;

            //2 second cd
            if (player.controlHook && cd <= 0 && Main.myPlayer == player.whoAmI)
            {
                //void spawn
                if (voidTimer <= 0)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Main.projectile[i].type == mod.ProjectileType("Void") && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].active)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType("Void"), 0, 0f, player.whoAmI, 0f, 0f);
                    voidTimer = 600;
                }

                Vector2 vector32;
                vector32.X = (float)Main.mouseX + Main.screenPosition.X;
                if (player.gravDir == 1f)
                {
                    vector32.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)player.height;
                }
                else
                {
                    vector32.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
                }
                vector32.X -= (float)(player.width / 2);
                if (vector32.X > 50f && vector32.X < (float)(Main.maxTilesX * 16 - 50) && vector32.Y > 50f && vector32.Y < (float)(Main.maxTilesY * 16 - 50))
                {
                    int num246 = (int)(vector32.X / 16f);
                    int num247 = (int)(vector32.Y / 16f);
                    if (!Collision.SolidCollision(vector32, player.width, player.height))
                    {
                        player.Teleport(vector32, 1, 0);
                        NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, vector32.X, vector32.Y, 1, 0, 0);
                        cd = 120;
                    }
                }
            }
            cd--;
            voidTimer--;

            player.accWatch = 3;
            player.accDepthMeter = 1;
            player.accCompass = 1;
            player.accFishFinder = true;
            player.accWeatherRadio = true;
            player.accCalendar = true;
            player.accThirdEye = true;
            player.accJarOfSouls = true;
            player.accCritterGuide = true;
            player.accStopwatch = true;
            player.accOreFinder = true;
            player.accDreamCatcher = true;

            //pets
            if (player.whoAmI == Main.myPlayer)
            {
                if (Soulcheck.GetValue("Baby Penguin Pet"))
                {
                    modPlayer.penguinPet = true;

                    if (player.FindBuffIndex(41) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.Penguin] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.Penguin, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.penguinPet = false;
                }

                if (Soulcheck.GetValue("Baby Skeletron Pet"))
                {
                    modPlayer.skullPet = true;

                    if (player.FindBuffIndex(50) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabySkeletronHead] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabySkeletronHead, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.skullPet = false;
                }

                if (Soulcheck.GetValue("Baby Snowman Pet"))
                {
                    modPlayer.snowmanPet = true;

                    if (player.FindBuffIndex(66) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabySnowman] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabySnowman, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.snowmanPet = false;
                }

                if (Soulcheck.GetValue("Zephyr Fish Pet"))
                {
                    modPlayer.fishPet = true;

                    if (player.FindBuffIndex(127) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.ZephyrFish] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.ZephyrFish, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.fishPet = false;
                }

                if (Soulcheck.GetValue("Companion Cube Pet"))
                {
                    modPlayer.cubePet = true;

                    if (player.FindBuffIndex(191) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.CompanionCube] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.CompanionCube, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.cubePet = false;
                }

                if (Soulcheck.GetValue("Baby Grinch Pet"))
                {
                    modPlayer.grinchPet = true;

                    if (player.FindBuffIndex(92) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BabyGrinch] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BabyGrinch, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.grinchPet = false;
                }

                if (Soulcheck.GetValue("Lizard Pet"))
                {
                    modPlayer.lizPet = true;

                    if (player.FindBuffIndex(53) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.PetLizard] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.PetLizard, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.lizPet = false;
                }

                if (Soulcheck.GetValue("Suspicious Looking Eye Pet"))
                {
                    modPlayer.suspiciousEyePet = true;

                    if (player.FindBuffIndex(190) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.SuspiciousTentacle] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.SuspiciousTentacle, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.suspiciousEyePet = false;
                }
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.PortalGun);
            recipe.AddIngredient(ItemID.RodofDiscord);
            recipe.AddIngredient(ItemID.CellPhone);
            recipe.AddIngredient(ItemID.CoinGun);

            recipe.AddIngredient(ItemID.AmberMosquito);
            recipe.AddIngredient(ItemID.Fish);
            recipe.AddIngredient(ItemID.Seaweed);
            recipe.AddIngredient(ItemID.ToySled);
            recipe.AddIngredient(ItemID.ZephyrFish);
            recipe.AddIngredient(ItemID.CompanionCube);
            recipe.AddIngredient(ItemID.LizardEgg);
            recipe.AddIngredient(ItemID.BabyGrinchMischiefWhistle);
            recipe.AddIngredient(ItemID.BoneKey);
            recipe.AddIngredient(ItemID.SuspiciousLookingTentacle);

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

