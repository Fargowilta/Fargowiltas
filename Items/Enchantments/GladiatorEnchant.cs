using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class GladiatorEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gladiator Enchantment");
            Tooltip.SetDefault("'Are you not entertained?' \n" +
                                "5% increased throwing damage\n" +
                                "Throwing weapons will speed up drastically\n" +
                                "Summons a pet Minotaur");
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

            modPlayer.gladEnchant = true;

            player.thrownDamage += 0.05f;

            //pets
            if (player.whoAmI == Main.myPlayer)
            {
                if (Soulcheck.GetValue("Mini Minotaur Pet"))
                {
                    modPlayer.minotaurPet = true;

                    if (player.FindBuffIndex(136) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.MiniMinotaur] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.MiniMinotaur, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.minotaurPet = false;
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.GladiatorHelmet);
            recipe.AddIngredient(ItemID.GladiatorBreastplate);
            recipe.AddIngredient(ItemID.GladiatorLeggings);
            recipe.AddIngredient(ItemID.Javelin, 200);
            recipe.AddIngredient(ItemID.TartarSauce);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

