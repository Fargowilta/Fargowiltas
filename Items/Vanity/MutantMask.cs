using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MutantMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Blue;
            item.vanity = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EyeMask)
                .AddIngredient(ItemID.BrainMask)
                .AddIngredient(ItemID.EaterMask)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}