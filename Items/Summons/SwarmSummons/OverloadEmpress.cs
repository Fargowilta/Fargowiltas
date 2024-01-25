using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadEmpress : SwarmSummonBase
    {
        public OverloadEmpress() : base(NPCID.HallowBoss, nameof(OverloadEmpress), 25, "PrismaticPrimrose")
        {
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jar of Lacewings");
            // Tooltip.SetDefault("Summons several Empresses of Light\nOnly Treasure Bags will be dropped");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}