using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class NatureForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Nature");
            Tooltip.SetDefault("'Tapped into every secret of the wilds'\n" +
                                "Taking damage will release a spore explosion\n" +
                                "Provides immunity to lava and some debuffs\n" +
                                "Nearby enemies are ignited with vanity on\n" +
                                "Melee and ranged attacks cause frostburn and emit light\n" +
                                "All attacks inflict poison and venom\n" +
                                "Summons a modified leaf crystal to shoot at nearby enemies\n" +
                                "Not moving puts you in stealth\n" +
                                "Spores spawn on enemies when you attack in stealth mode\n" +
                                "You cheat death, returning with 20 HP\n" +
                                "5 minute cooldown");
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

            //jungle
            if (Soulcheck.GetValue("Spore Explosion") == true)
            {
                modPlayer.jungleEnchant = true;
            }
            //fossil
            modPlayer.fossilEnchant = true;

            //molten
            if (Soulcheck.GetValue("Inferno Buff") == true)
            {
                player.inferno = true;
                Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                int num = 24;
                float num2 = 200f;
                bool flag = player.infernoCounter % 60 == 0;
                int damage = 10;
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

            //frost
            player.frostBurn = true;

            player.buffImmune[46] = true; //chilled
            player.buffImmune[47] = true; //frozen
            player.buffImmune[20] = true; //Poisoned
            player.buffImmune[70] = true; //Venom

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

            //pets
            if (player.whoAmI == Main.myPlayer)
            {
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
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "JungleEnchant");
            recipe.AddIngredient(null, "FossilEnchant");
            recipe.AddIngredient(null, "MoltenEnchant");
            recipe.AddIngredient(null, "FrostEnchant");
            recipe.AddIngredient(null, "ChlorophyteEnchant");
            recipe.AddIngredient(null, "ShroomiteEnchant");

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}


