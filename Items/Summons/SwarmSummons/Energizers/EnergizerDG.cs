using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerDG : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Extra Boney Energizer");
            // Tooltip.SetDefault("Formed after using 10 Skull Chain Necklaces\n'Reminds you of a mean cow'");
        }

        public override string Texture => "Fargowiltas/Items/Summons/SwarmSummons/Energizers/EnergizerSkele";

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