using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fishy Energizer");
            // Tooltip.SetDefault("Formed after using 10 Truffle Worm Clumps\n'You feel content'");
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