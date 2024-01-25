using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadWorm : SwarmSummonBase
    {
        public OverloadWorm() : base(NPCID.EaterofWorldsHead, nameof(OverloadWorm), 25, "WormyFood")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Worm Chicken");
            // Tooltip.SetDefault("Summons several Eater of Worlds\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}