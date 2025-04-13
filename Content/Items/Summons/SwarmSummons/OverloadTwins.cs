using Terraria;
using Terraria.ID;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadTwins : SwarmSummonBase
    {
        public OverloadTwins() : base(NPCID.Retinazer, nameof(OverloadTwins), 25, "MechEye")
        {
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && FargoUtils.ActuallyNight;
        }
    }
}