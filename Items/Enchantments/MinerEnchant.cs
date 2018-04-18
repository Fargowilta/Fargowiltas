using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class MinerEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner Enchantment");
            Tooltip.SetDefault("'The planet trembles with each swing of your pick' \n" +
                                "30% increased mining speed \n" +
                                "Shows the location of enemies, traps, and treasures \n" +
                                "You emit an aura of light\n" +
                                "Summons a magic lantern");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 10000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            player.pickSpeed -= 0.3f;
            if (Soulcheck.GetValue("Shine Buff") == true)
            {
                Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
            }
            if (Soulcheck.GetValue("Spelunker Buff") == true)
            {
                player.findTreasure = true;
            }
            if (Soulcheck.GetValue("Hunter Buff") == true)
            {
                player.detectCreature = true;
            }
            if (Soulcheck.GetValue("Dangersense Buff") == true)
            {
                player.dangerSense = true;
            }

            if (player.whoAmI == Main.myPlayer)
            {
                //if(Soulcheck.GetValue("Baby Face Monster Pet"))
                //{
                modPlayer.lanternPet = true;

                if (player.FindBuffIndex(152) == -1)
                {
                    if (player.ownedProjectileCounts[ProjectileID.MagicLantern] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, ProjectileID.MagicLantern, 0, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
                //}
                //else
                //{
                //	modPlayer.lanternPet = false;
                //}
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MiningHelmet);
            recipe.AddIngredient(ItemID.MiningShirt);
            recipe.AddIngredient(ItemID.MiningPants);
            recipe.AddIngredient(ItemID.CactusPickaxe);
            recipe.AddIngredient(ItemID.MagicLantern);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}


