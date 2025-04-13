using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class AbominationnBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Abominationn Body");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.vanity = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PirateShirt)
                .AddIngredient(ItemID.ChargedBlasterCannon)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
