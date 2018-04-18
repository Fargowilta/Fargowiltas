using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class NinjaEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninja Enchantment");
            Tooltip.SetDefault("'They are already dead' \n" +
                                "Throw a smoke bomb to teleport to it\n" +
                                "Standing nearby smoke makes you take 20% less damage and you always crit when you attack a full health enemy \n" +
                                "Effects of the Master Ninja Gear\n" +
                                "Summons a pet Black cat");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            modPlayer.ninjaEnchant = true;

            //ninja gear
            player.blackBelt = true;
            player.spikedBoots = 2;
            player.dash = 1;

            //pet
            if (player.whoAmI == Main.myPlayer)
            {
                if (Soulcheck.GetValue("Black Cat Pet"))
                {
                    modPlayer.catPet = true;

                    if (player.FindBuffIndex(84) == -1)
                    {
                        if (player.ownedProjectileCounts[ProjectileID.BlackCat] < 1)
                        {
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.BlackCat, 0, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                else
                {
                    modPlayer.catPet = false;
                }
            }


        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.NinjaHood);
            recipe.AddIngredient(ItemID.NinjaShirt);
            recipe.AddIngredient(ItemID.NinjaPants);
            recipe.AddIngredient(ItemID.MasterNinjaGear);
            recipe.AddIngredient(ItemID.SmokeBomb, 50);
            recipe.AddIngredient(ItemID.UnluckyYarn);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

