using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadBrain : SwarmSummonBase
    {
        public OverloadBrain() : base(NPCID.BrainofCthulhu, nameof(OverloadBrain), 25, "GoreySpine")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brain Storm");
            // Tooltip.SetDefault("Summons several Brains of Cthulhu\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}