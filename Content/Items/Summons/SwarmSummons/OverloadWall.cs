using Terraria;
using Terraria.ID;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadWall : SwarmSummonBase
    {
        public OverloadWall() : base(NPCID.WallofFlesh, nameof(OverloadWall), 10, "FleshyDoll")
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 5; // Puts it right after Deer Thing and Abeemination, and before Gelatin Crystal
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && player.ZoneUnderworldHeight;
        }
    }
}