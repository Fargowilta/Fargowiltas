using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadCultist : SwarmSummonBase
    {
        public OverloadCultist() : base(NPCID.CultistBoss, nameof(OverloadCultist), 25, "CultistSummon")
        {
        }

        public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Zealot's Madness");
			// Tooltip.SetDefault("Summons several Lunatic Cultists\nOnly Treasure Bags will be dropped");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 18; // Puts it right before Celestial Sigil
		}

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}