using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class AutoHouse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("InstaHouse");
            Tooltip.SetDefault("Places an NPC house instantly");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.createTile = ModContent.TileType<AutoHouseTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("Wood", 50)
                .AddIngredient(ItemID.Torch)                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}