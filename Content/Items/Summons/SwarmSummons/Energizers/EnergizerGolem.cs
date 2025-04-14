using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lihzahrd Energizer");
            // Tooltip.SetDefault("Formed after using 10 Runic Power Cells\n'You wish it was spelled \"lizard\"");
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