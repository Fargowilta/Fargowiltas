using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wally Energizer");
            // Tooltip.SetDefault("Formed after using 10 Bundle of Dolls\n'You feel claustrophobic'");
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