using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadDestroyer : SwarmSummonBase
    {
        public OverloadDestroyer() : base(NPCID.TheDestroyer, nameof(OverloadDestroyer), 10, "MechWorm")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Seismic Actuator");
            // Tooltip.SetDefault("Summons several Destroyers\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}