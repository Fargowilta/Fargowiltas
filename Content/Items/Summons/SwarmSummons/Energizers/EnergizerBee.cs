using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBee : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Buzzy Energizer");
            // Tooltip.SetDefault("Formed after using 10 Overstuffed Larva\n'Smells like it tastes like honey'");
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