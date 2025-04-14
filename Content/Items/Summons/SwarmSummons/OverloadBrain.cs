using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadBrain : SwarmSummonBase
    {
        public OverloadBrain() : base(NPCID.BrainofCthulhu, nameof(OverloadBrain), 25, "GoreySpine")
        {
        }


        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}