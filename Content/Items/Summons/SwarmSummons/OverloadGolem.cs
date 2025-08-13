using Fargowiltas.Content.Items.Summons.VanillaCopy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class OverloadGolem : SwarmSummonBase
    {
        public OverloadGolem() : base(NPCID.Golem, nameof(OverloadGolem), 25, ModContent.ItemType<LihzahrdPowerCell2>())
        {
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.LihzahrdPowerCell]; // 16
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && NPC.downedPlantBoss;
        }
    }
}