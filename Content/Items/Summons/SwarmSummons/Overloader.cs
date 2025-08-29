using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.SwarmSummons
{
    public class Overloader : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Overloader");
            /* Tooltip.SetDefault("Used to craft swarm summons\n" +
                               "When used, all summons in the stack will be consumed\n" +
                               "The more consumed, the more bosses will spawn\n" +
                               "A Trophy will drop every 10 kills\n" +
                               "An Energizer will drop every 100 kills"); */
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 0;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
        }
    }
}