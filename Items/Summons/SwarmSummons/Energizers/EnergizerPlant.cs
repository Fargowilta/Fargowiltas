using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerPlant : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Leafy Energizer");
            // Tooltip.SetDefault("Formed after using 10 Heart of the Jungles\n'Being a leaf sounds like a good time'");
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