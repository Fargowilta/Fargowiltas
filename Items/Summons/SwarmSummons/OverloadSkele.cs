using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadSkele : SwarmSummonBase
    {
        public OverloadSkele() : base(NPCID.SkeletronHead, nameof(OverloadSkele), 40, "SuspiciousSkull")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Skull Chain Necklace");
            /* Tooltip.SetDefault(
@"Summons several Skeletrons during the night
Summons several Dungeon Guardians during the day
Only Treasure Bags will be dropped"); */
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}