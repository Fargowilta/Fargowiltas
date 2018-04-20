using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class SpiritForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Spirit");
            Tooltip.SetDefault("'The strength of your spirit amazes even the Mutant'\n" +
                                "Attacks have a chance to inflict shadow flame\n" +
                                "You are immune to all skeletons and knockback\n" +
                                "Double tap down to call an ancient storm to the cursor location\n" +
                                "Summons a shield that can reflect projectiles into enchanted swords \n" +
                                "You also summon enchanted swords to attack enemies\n" +
                                "Magic damage has a chance to spawn damaging orbs\n" +
                                "When you crit, you get a burst of healing orbs on hit instead\n" +
                                "On hit, you release a legion of scythes\n" +
                                "Summons several pets");
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

            //shadow
            modPlayer.shadowEnchant = true;

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
            ForbiddenEnchant.EffectAdd(modPlayer, hideVisual);

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

            if (modPlayer.specHeal)
            {
                player.ghostHeal = true;
            }
            else
            {
                player.ghostHurt = true;
            }

            //spooky
            if (Soulcheck.GetValue("Spooky Scythes") == true)
            {
                modPlayer.spookyEnchant = true;
            }

            //pets
            if (player.whoAmI == Main.myPlayer)
            {
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
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowEnchant");
            recipe.AddIngredient(null, "NecroEnchant");
            recipe.AddIngredient(null, "ForbiddenEnchant");
            recipe.AddIngredient(null, "HallowEnchant");
            recipe.AddIngredient(null, "SpectreEnchant");
            recipe.AddIngredient(null, "SpookyEnchant");

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}


