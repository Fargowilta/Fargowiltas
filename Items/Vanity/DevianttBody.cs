using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class DevianttBody : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Robe)
                .AddIngredient(ItemID.PinkGel)
                .AddIngredient(ItemID.AncientBattleArmorMaterial)                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}