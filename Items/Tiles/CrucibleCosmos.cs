using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class CrucibleCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crucible of the Cosmos");
            Tooltip.SetDefault("'It seems to be hiding magnificent power'" +
                "\nFunctions as every crafting station");

            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宇宙坩埚");
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "'它似乎隐藏着巨大的力量'" +
                "\n包含几乎所有制作环境");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.rare = ItemRarityID.Red;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.createTile = ModContent.TileType<CrucibleCosmosTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MultitaskCenter>())
                .AddIngredient(ModContent.ItemType<ElementalAssembler>())
                .AddRecipeGroup("Fargowiltas:AnyForge")
                .AddRecipeGroup("Fargowiltas:AnyHMAnvil")
                .AddRecipeGroup("Fargowiltas:AnyBookcase")
                .AddIngredient(ItemID.CrystalBall)
                .AddIngredient(ItemID.Autohammer)
                .AddIngredient(ItemID.BlendOMatic)
                .AddIngredient(ItemID.MeatGrinder)
                .AddIngredient(ItemID.SteampunkBoiler)
                .AddIngredient(ItemID.FleshCloningVaat)
                .AddIngredient(ItemID.LihzahrdFurnace)
                .AddIngredient(ItemID.LunarCraftingStation)
                .AddIngredient(ItemID.LunarBar, 25)                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}