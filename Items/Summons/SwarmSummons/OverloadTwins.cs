using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadTwins : SwarmSummonBase
    {
        public OverloadTwins() : base(NPCID.Retinazer, nameof(OverloadTwins), 25, "MechEye")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omnifocal Lens");
            // Tooltip.SetDefault("Summons several sets of Twins\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}