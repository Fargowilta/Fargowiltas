using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class CosmoForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Cosmos");
            Tooltip.SetDefault("'Been around since the Big Bang' \n" +
                                "20% increased damage\n" +
                                "Solar shield allows you to dash through enemies \n" +
                                "Sets your critical strike chance to 5% \n" +
                                "Every crit will increase it \n" +
                                "Getting hit drops your crit back down \n" +
                                "Hurting enemies has a chance to spawn buff boosters \n" +
                                "Double tap down to direct your guardian");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 300000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            player.meleeDamage += .2f;
            player.rangedDamage += .2f;
            player.magicDamage += .2f;
            player.minionDamage += .2f;
            player.thrownDamage += .2f;

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
            modPlayer.vortexEnchant = true;
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

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteorEnchant");
            recipe.AddIngredient(null, "SolarEnchant");
            recipe.AddIngredient(null, "VortexEnchant");
            recipe.AddIngredient(null, "NebulaEnchant");
            recipe.AddIngredient(null, "StardustEnchant");

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}


