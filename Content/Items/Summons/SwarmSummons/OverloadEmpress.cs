using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadEmpress : SwarmSummonBase
    {
        public OverloadEmpress() : base(NPCID.HallowBoss, nameof(OverloadEmpress), 25, "PrismaticPrimrose")
        {
        }
        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}