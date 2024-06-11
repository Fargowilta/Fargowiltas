using Fargowiltas.Items.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class CraftingTree : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Purple;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CraftingTreeSheet>();
        }
        public override void AddRecipes()
        {
            Recipe.Create(Type, 1)
                .AddIngredient(ItemID.TreeStatue)
                .AddIngredient(ItemID.StoneBlock, 100)
                .AddIngredient(ModContent.ItemType<EnchantedAcorn>(), 10)
                .AddIngredient(ItemID.MeteoriteBar, 5)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
