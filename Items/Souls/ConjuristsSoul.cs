using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using CalamityMod;


namespace Fargowiltas.Items.Souls
{
    public class ConjuristsSoul : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Conjurist's Soul");

            if (Fargowiltas.instance.calamityLoaded)
            {
                Tooltip.SetDefault("'An army at your disposal' \n" +
                                    "Increases your max number of minions by 4 \n" +
                                    "Increases your max number of sentries by 2 \n" +
                                    "40% increased summon damage \n" +
                                    "Increased minion knockback \n" +
                                    "Summons all waifus to protect you, turn off vanity to despawn them");
            }
            else
            {
                Tooltip.SetDefault("'An army at your disposal' \n" +
                                    "Increases your max number of minions by 4 \n" +
                                    "Increases your max number of sentries by 2 \n" +
                                    "40% increased summon damage \n" +
                                    "Increased minion knockback");
            }

        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 750000;
            item.rare = -12;
            item.expert = true;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.maxMinions += 4;
            player.minionDamage += 0.4f;
            player.minionKB += 3f;
            player.maxTurrets += 2;

            //heart of elements
            if (Fargowiltas.instance.calamityLoaded)
            {
                if (!hideVisual)
                {
                    Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, ((float)Main.DiscoR / 255f), ((float)Main.DiscoG / 255f), ((float)Main.DiscoB / 255f));

                    Waifus(player);

                    if (player.whoAmI == Main.myPlayer)
                    {
                        int damage = 300;
                        float damageMult = 2.5f;
                        if (player.FindBuffIndex(ModLoader.GetMod("CalamityMod").BuffType("BrimstoneWaifu")) == -1)
                        {
                            player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("BrimstoneWaifu"), 3600, true);
                        }
                        if (player.ownedProjectileCounts[ModLoader.GetMod("CalamityMod").ProjectileType("BigBustyRose")] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ModLoader.GetMod("CalamityMod").ProjectileType("BigBustyRose"), (int)((float)damage * damageMult), 2f, Main.myPlayer, 0f, 0f);
                        }
                        if (player.FindBuffIndex(ModLoader.GetMod("CalamityMod").BuffType("SirenLure")) == -1)
                        {
                            player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("SirenLure"), 3600, true);
                        }
                        if (player.ownedProjectileCounts[ModLoader.GetMod("CalamityMod").ProjectileType("SirenLure")] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ModLoader.GetMod("CalamityMod").ProjectileType("SirenLure"), 0, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (player.FindBuffIndex(ModLoader.GetMod("CalamityMod").BuffType("DrewsSandyWaifu")) == -1)
                        {
                            player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("DrewsSandyWaifu"), 3600, true);
                        }
                        if (player.ownedProjectileCounts[ModLoader.GetMod("CalamityMod").ProjectileType("DrewsSandyWaifu")] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ModLoader.GetMod("CalamityMod").ProjectileType("DrewsSandyWaifu"), (int)((float)damage * damageMult * 1.5f), 2f, Main.myPlayer, 0f, 0f);
                        }
                        if (player.FindBuffIndex(ModLoader.GetMod("CalamityMod").BuffType("SandyWaifu")) == -1)
                        {
                            player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("SandyWaifu"), 3600, true);
                        }
                        if (player.ownedProjectileCounts[ModLoader.GetMod("CalamityMod").ProjectileType("SandyWaifu")] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ModLoader.GetMod("CalamityMod").ProjectileType("SandyWaifu"), (int)((float)damage * damageMult * 1.5f), 2f, Main.myPlayer, 0f, 0f);
                        }
                        if (player.FindBuffIndex(ModLoader.GetMod("CalamityMod").BuffType("CloudyWaifu")) == -1)
                        {
                            player.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("CloudyWaifu"), 3600, true);
                        }
                        if (player.ownedProjectileCounts[ModLoader.GetMod("CalamityMod").ProjectileType("CloudyWaifu")] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ModLoader.GetMod("CalamityMod").ProjectileType("CloudyWaifu"), (int)((float)damage * damageMult), 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (player.whoAmI == Main.myPlayer && player.velocity.Y == 0f && player.grappling[0] == -1)
                {
                    int num4 = (int)player.Center.X / 16;
                    int num5 = (int)(player.position.Y + (float)player.height - 1f) / 16;
                    if (Main.tile[num4, num5] == null)
                    {
                        Main.tile[num4, num5] = new Tile();
                    }
                    if (!Main.tile[num4, num5].active() && Main.tile[num4, num5].liquid == 0 && Main.tile[num4, num5 + 1] != null && WorldGen.SolidTile(num4, num5 + 1))
                    {
                        Main.tile[num4, num5].frameY = 0;
                        Main.tile[num4, num5].slope(0);
                        Main.tile[num4, num5].halfBrick(false);
                        if (Main.tile[num4, num5 + 1].type == 0)
                        {
                            if (Main.rand.Next(1000) == 0)
                            {
                                Main.tile[num4, num5].active(true);
                                Main.tile[num4, num5].type = 227;
                                Main.tile[num4, num5].frameX = (short)(34 * Main.rand.Next(1, 13));
                                while (Main.tile[num4, num5].frameX == 144)
                                {
                                    Main.tile[num4, num5].frameX = (short)(34 * Main.rand.Next(1, 13));
                                }
                            }
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, num4, num5, 1, TileChangeType.None);
                            }
                        }
                        if (Main.tile[num4, num5 + 1].type == 2)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.tile[num4, num5].active(true);
                                Main.tile[num4, num5].type = 3;
                                Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(6, 11));
                                while (Main.tile[num4, num5].frameX == 144)
                                {
                                    Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(6, 11));
                                }
                            }
                            else
                            {
                                Main.tile[num4, num5].active(true);
                                Main.tile[num4, num5].type = 73;
                                Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(6, 21));
                                while (Main.tile[num4, num5].frameX == 144)
                                {
                                    Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(6, 21));
                                }
                            }
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, num4, num5, 1, TileChangeType.None);
                            }
                        }
                        else if (Main.tile[num4, num5 + 1].type == 109)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.tile[num4, num5].active(true);
                                Main.tile[num4, num5].type = 110;
                                Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(4, 7));
                                while (Main.tile[num4, num5].frameX == 90)
                                {
                                    Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(4, 7));
                                }
                            }
                            else
                            {
                                Main.tile[num4, num5].active(true);
                                Main.tile[num4, num5].type = 113;
                                Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(2, 8));
                                while (Main.tile[num4, num5].frameX == 90)
                                {
                                    Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(2, 8));
                                }
                            }
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, num4, num5, 1, TileChangeType.None);
                            }
                        }
                        else if (Main.tile[num4, num5 + 1].type == 60)
                        {
                            Main.tile[num4, num5].active(true);
                            Main.tile[num4, num5].type = 74;
                            Main.tile[num4, num5].frameX = (short)(18 * Main.rand.Next(9, 17));
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, num4, num5, 1, TileChangeType.None);
                            }
                        }
                    }
                }
            }
        }

        public void Waifus(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).brimstoneWaifu = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).sandBoobWaifu = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).sandWaifu = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).cloudWaifu = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).sirenWaifu = true;
        }

        public override void AddRecipes()
        {
            ModRecipe summon2 = new ModRecipe(mod);
            summon2.AddIngredient(null, "OccultistsEssence");

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //all 3
                        summon2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("InfinityScarab"));
                    }

                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StatisCurse"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HeartoftheElements"));
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("BloodCellStaff"));
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HailBomber"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BlightedEyeStaff"));
                    summon2.AddIngredient(ItemID.StaffoftheFrostHydra);
                    summon2.AddRecipeGroup("Fargowiltas:AnySentry");

                    if (!Fargowiltas.instance.blueMagicLoaded)
                    {
                        //thorium and calamity
                        summon2.AddIngredient(ItemID.TempestStaff);
                    }

                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumSummon"));

                    summon2.AddIngredient(ItemID.MoonlordTurretStaff);
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("EmberStaff"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StaffoftheMechworm"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //blue and thorium
                        summon2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("InfinityScarab"));
                    }

                    else
                    {
                        //just thorium
                        summon2.AddIngredient(ItemID.PapyrusScarab);
                    }

                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MastersLibram"));
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("BloodCellStaff"));
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HailBomber"));
                    summon2.AddIngredient(ItemID.StaffoftheFrostHydra);
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TheIncubator"));
                    summon2.AddRecipeGroup("Fargowiltas:AnySentry");
                    summon2.AddIngredient(ItemID.TempestStaff);
                    summon2.AddIngredient(ItemID.RavenStaff);
                    summon2.AddIngredient(ItemID.XenoStaff);
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumSummon"));
                    summon2.AddIngredient(ItemID.MoonlordTurretStaff);
                    summon2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("EmberStaff"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {

                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //calamity and blue
                        summon2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("InfinityScarab"));
                    }

                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StatisCurse"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HeartoftheElements"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BlightedEyeStaff"));
                    summon2.AddIngredient(ItemID.StaffoftheFrostHydra);

                    if (!Fargowiltas.instance.blueMagicLoaded)
                    {
                        //just calamity

                    }

                    summon2.AddRecipeGroup("Fargowiltas:AnySentry");
                    summon2.AddIngredient(ItemID.TempestStaff);
                    summon2.AddIngredient(ItemID.RavenStaff);
                    summon2.AddIngredient(ItemID.XenoStaff);

                    summon2.AddIngredient(ItemID.MoonlordTurretStaff);
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Cosmilamp"));
                    summon2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StaffoftheMechworm"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //just blue
                        summon2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("InfinityScarab"));
                    }

                    else
                    {
                        //no others
                        summon2.AddIngredient(ItemID.PygmyNecklace);
                        summon2.AddIngredient(ItemID.PapyrusScarab);
                    }

                    summon2.AddIngredient(ItemID.QueenSpiderStaff);
                    summon2.AddIngredient(ItemID.OpticStaff);
                    summon2.AddIngredient(ItemID.TempestStaff);
                    summon2.AddIngredient(ItemID.RavenStaff);
                    summon2.AddIngredient(ItemID.XenoStaff);
                    summon2.AddRecipeGroup("Fargowiltas:AnySentry");
                    summon2.AddRecipeGroup("Fargowiltas:AnySentry");
                    summon2.AddIngredient(ItemID.MoonlordTurretStaff);
                }
            }

            summon2.AddTile(null, "CrucibleCosmosSheet");
            summon2.SetResult(this);
            summon2.AddRecipe();
        }

    }
}