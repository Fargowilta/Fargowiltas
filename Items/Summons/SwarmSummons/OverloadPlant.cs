using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadPlant : SwarmSummonBase
    {
        public OverloadPlant() : base(NPCID.Plantera, nameof(OverloadPlant), 25, "PlanterasFruit")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heart of the Jungle");
            // Tooltip.SetDefault("Summons several Planteras\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}