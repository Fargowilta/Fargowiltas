﻿using Terraria;
using Terraria.ID;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadDarkMage : SwarmSummonBase
    {
        public OverloadDarkMage() : base(NPCID.DD2DarkMageT1, nameof(OverloadDarkMage), 50, "ForbiddenTome")
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 4; // Puts it right after Goblin Battle Standard
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}
