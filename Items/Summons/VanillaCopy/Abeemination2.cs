using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class Abeemination2 : BaseSummon
    {

        public override int NPCType => NPCID.QueenBee;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("A Bee In My Nation");
			// Tooltip.SetDefault("Summons Queen Bee in any biome");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.Abeemination]; // 5
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Abeemination)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.ZoneOverworldHeight || player.ZoneSkyHeight)
                return false;
            return base.CanUseItem(player);
        }
    }
}