using Terraria;
using Terraria.ID;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadFish : SwarmSummonBase
    {
        public OverloadFish() : base(NPCID.DukeFishron, nameof(OverloadFish), 25, "TruffleWorm2")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}