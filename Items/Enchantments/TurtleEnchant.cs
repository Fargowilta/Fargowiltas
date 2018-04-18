using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class TurtleEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Enchantment");
            Tooltip.SetDefault("'You suddenly have the urge to hide in a shell' \n" +
                                "When standing still, you 'hide in your shell' and may dodge projectiles\n" +
                                "100% of damage taken by melee attacks is reflected \n" +
                                "Enemies are more likely to target you\n" +
                                "Summons a pet Turtle");
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
            modPlayer.turtleEnchant = true;

            player.aggro += 50;
            player.thorns = 1f;
            player.turtleThorns = true;

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
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.Yelets);
            recipe.AddIngredient(ItemID.Seedler);
            recipe.AddIngredient(ItemID.ButchersChainsaw);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

