using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBetsy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Draco Energizer");
            // Tooltip.SetDefault("Formed after using 10 Dragon Egg Trays\n'You feel like you've waited three thousand years'");
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