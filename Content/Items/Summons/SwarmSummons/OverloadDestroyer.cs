using Terraria;
using Terraria.ID;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadDestroyer : SwarmSummonBase
    {
        public OverloadDestroyer() : base(NPCID.TheDestroyer, nameof(OverloadDestroyer), 10, "MechWorm")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && FargoUtils.ActuallyNight;
        }
    }
}