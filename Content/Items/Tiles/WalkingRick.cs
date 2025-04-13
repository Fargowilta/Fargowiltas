using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Fargowiltas.Content.Items.Tiles
{
    public class WalkingRick : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Walking Rick");
            // Tooltip.SetDefault("'Kien R. Oco'");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<WalkingRickSheet>();
        }
    }
}