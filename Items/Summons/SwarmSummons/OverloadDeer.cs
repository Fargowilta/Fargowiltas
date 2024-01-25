using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadDeer : SwarmSummonBase
    {
        public OverloadDeer() : base(NPCID.Deerclops, nameof(OverloadDeer), 50, "DeerThing2")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Deer Amalgamation");
            // Tooltip.SetDefault("Summons several Deerclops\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}