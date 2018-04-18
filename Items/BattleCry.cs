using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items
{
    public class BattleCry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle Cry");
            Tooltip.SetDefault("Increase spawn rates by 10x on use\n" +
                                "Use it again to decrease them");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 5;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            modPlayer.npcBoost = !modPlayer.npcBoost;

            if (modPlayer.npcBoost)
            {
                Main.NewText("Spawn rates increased!", 175, 75, 255);
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }
            else
            {
                Main.NewText("Spawn rates decreased!", 175, 75, 255);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.BattlePotion, 15);
            recipe.AddIngredient(ItemID.WaterCandle, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
