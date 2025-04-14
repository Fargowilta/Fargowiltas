using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerTwins : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sibling Energizer");
            // Tooltip.SetDefault("Formed after using 10 Omnifocal Lens\n'You wish you had more'");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.Blue;
            Item.value = 1000000;
        }
    }
}