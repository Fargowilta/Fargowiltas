using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadPlant : SwarmSummonBase
    {
        public OverloadPlant() : base(NPCID.Plantera, nameof(OverloadPlant), 25, "PlanterasFruit")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}