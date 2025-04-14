using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadWall : SwarmSummonBase
    {
        public OverloadWall() : base(NPCID.WallofFlesh, nameof(OverloadWall), 10, "FleshyDoll")
        {
        }

        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Bundle of Dolls");
			// Tooltip.SetDefault("Summons several Walls of Flesh\nOnly Treasure Bags will be dropped");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 5; // Puts it right after Deer Thing and Abeemination, and before Gelatin Crystal
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && player.ZoneUnderworldHeight;
        }
    }
}