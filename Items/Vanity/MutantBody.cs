using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class MutantBody : ModItem
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
                .AddIngredient(ItemID.SkeletronMask)
                .AddIngredient(ItemID.DestroyerMask)
                .AddIngredient(ItemID.SkeletronPrimeMask)
                .AddIngredient(ItemID.TwinMask)
                .AddIngredient(ItemID.GolemMask)
                .AddIngredient(ItemID.FairyQueenMask)
                .AddIngredient(ItemID.BossMaskMoonlord)                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}