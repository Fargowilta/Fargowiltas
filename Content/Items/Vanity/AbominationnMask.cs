using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class AbominationnMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Abominationn Mask");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BallaHat)
                .AddIngredient(ItemID.JackOLanternMask)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}