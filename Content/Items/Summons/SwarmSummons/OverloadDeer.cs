using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadDeer : SwarmSummonBase
    {
        public OverloadDeer() : base(NPCID.Deerclops, nameof(OverloadDeer), 50, "DeerThing2")
        {
        }
        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}