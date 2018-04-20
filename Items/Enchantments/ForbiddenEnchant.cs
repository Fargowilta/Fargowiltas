using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fargowiltas.Items.Enchantments
{
    public class ForbiddenEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Enchantment");
            Tooltip.SetDefault("'Walk like an Egyptian' \n" +
                                "10% increased magic and minion damage \n" +
                                "Increases your max number of minions by 1 \n" +
                                "You are immune to the Mighty Wind debuff \n" +
                                "Double tap down to call an ancient storm to the cursor location");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>(mod);

            player.maxMinions += 1;
            player.minionDamage += 0.1f;
            player.magicDamage += 0.1f;

            EffectAdd(player, hideVisual, mod);

        }

        public static void EffectAdd(Player player, bool hideVisual, Mod mod)
        {
            player.buffImmune[194] = true; //mighty wind

            if (Soulcheck.GetValue("Forbidden Storm") == true)
            {
                player.setForbidden = true;
                player.UpdateForbiddenSetLock();
                Lighting.AddLight(player.Center, 0.8f, 0.7f, 0.2f);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AncientBattleArmorHat);
            recipe.AddIngredient(ItemID.AncientBattleArmorShirt);
            recipe.AddIngredient(ItemID.AncientBattleArmorPants);
            recipe.AddIngredient(ItemID.SpiritFlame);
            recipe.AddIngredient(ItemID.ShadowFlameHexDoll);
            recipe.AddIngredient(ItemID.DeadlySphereStaff);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}







