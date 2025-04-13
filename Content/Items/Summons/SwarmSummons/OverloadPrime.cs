using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadPrime : SwarmSummonBase
    {
        public OverloadPrime() : base(NPCID.SkeletronPrime, nameof(OverloadPrime), 25, "MechSkull")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && FargoUtils.ActuallyNight;
        }
    }
}