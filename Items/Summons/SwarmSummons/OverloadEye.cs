using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadEye : SwarmSummonBase
    {
        public OverloadEye() : base(NPCID.EyeofCthulhu, nameof(OverloadEye), 50, "SuspiciousEye")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eyemalgamation");
            // Tooltip.SetDefault("Summons several Eyes of Cthulhu\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}