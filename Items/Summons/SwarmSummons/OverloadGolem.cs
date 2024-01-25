using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadGolem : SwarmSummonBase
    {
        public OverloadGolem() : base(NPCID.Golem, nameof(OverloadGolem), 25, "LihzahrdPowerCell2")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Runic Power Cell");
            // Tooltip.SetDefault("Summons several Golems\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && NPC.downedPlantBoss;
        }
    }
}