using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class LumberHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("LumberJack Hat");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}