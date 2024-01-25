using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadPrime : SwarmSummonBase
    {
        public OverloadPrime() : base(NPCID.SkeletronPrime, nameof(OverloadPrime), 25, "MechSkull")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primal Control Chip");
            // Tooltip.SetDefault("Summons several Skeletron Primes\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}