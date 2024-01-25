using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadBetsy : SwarmSummonBase
    {
        public OverloadBetsy() : base(NPCID.DD2Betsy, nameof(OverloadBetsy), 25, "BetsyEgg")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dragon Egg Tray");
            // Tooltip.SetDefault("Summons several Betsys\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}