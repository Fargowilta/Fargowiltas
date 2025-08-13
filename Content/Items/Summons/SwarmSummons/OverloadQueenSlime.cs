﻿using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadQueenSlime : SwarmSummonBase
    {
        public OverloadQueenSlime() : base(NPCID.QueenSlimeBoss, nameof(OverloadQueenSlime), 25, ItemID.QueenSlimeCrystal)
        {
        }

        public override void SetStaticDefaults()
        {
             ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.QueenSlimeCrystal]; // 6
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}