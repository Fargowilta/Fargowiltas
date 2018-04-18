using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class ShadowEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Enchantment");
            Tooltip.SetDefault("'You feel your body slip into the deepest shadows'\n" +
                                "15% increased movement speed \n" +
                                "10% increased melee speed \n" +
                                "Attacks have a chance to inflict cursed flame\n" +
                                "Summons a Baby Eater of Souls and a Shadow Orb");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 20000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);
            modPlayer.shadowEnchant = true;

            player.moveSpeed += 15f;
            player.meleeSpeed += 0.1f;

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
            recipe.AddIngredient(ItemID.ShadowHelmet);
            recipe.AddIngredient(ItemID.ShadowScalemail);
            recipe.AddIngredient(ItemID.ShadowGreaves);
            recipe.AddIngredient(ItemID.LightlessChasms);
            recipe.AddIngredient(ItemID.EatersBone);
            recipe.AddIngredient(ItemID.ShadowOrb);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}







