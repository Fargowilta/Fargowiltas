using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class NecroEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necro Enchantment");
            Tooltip.SetDefault(@"'Welcome to the bone zone' 
25% chance to not consume ammo 
5% increased ranged damage 
You are immune to basic skeletons");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 20000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            player.ammoCost75 = true;
            player.rangedDamage += .05f;


            //skeletons
            player.npcTypeNoAggro[21] = true;
            player.npcTypeNoAggro[31] = true;
            player.npcTypeNoAggro[32] = true;
            player.npcTypeNoAggro[33] = true;
            player.npcTypeNoAggro[34] = true;
            player.npcTypeNoAggro[167] = true;
            player.npcTypeNoAggro[201] = true;
            player.npcTypeNoAggro[202] = true;
            player.npcTypeNoAggro[203] = true;
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
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NecroHelmet);
            recipe.AddIngredient(ItemID.NecroBreastplate);
            recipe.AddIngredient(ItemID.NecroGreaves);
            recipe.AddIngredient(ItemID.BoneSword);
            recipe.AddIngredient(ItemID.PhoenixBlaster);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

