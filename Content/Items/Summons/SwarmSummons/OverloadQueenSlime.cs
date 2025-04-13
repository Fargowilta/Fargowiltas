using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadQueenSlime : SwarmSummonBase
    {
        public OverloadQueenSlime() : base(NPCID.QueenSlimeBoss, nameof(OverloadQueenSlime), 25, "JellyCrystal")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}