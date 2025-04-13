using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadBee : SwarmSummonBase
    {
        public OverloadBee() : base(NPCID.QueenBee, nameof(OverloadBee), 50, "Abeemination2")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}