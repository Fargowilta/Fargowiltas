using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadFish : SwarmSummonBase
    {
        public OverloadFish() : base(NPCID.DukeFishron, nameof(OverloadFish), 25, "TruffleWorm2")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Truffle Worm Clump");
            // Tooltip.SetDefault("Summons several Duke Fishrons\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}