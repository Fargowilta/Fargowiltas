using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class LumberjackBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lumberjack Body");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.vanity = true;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
