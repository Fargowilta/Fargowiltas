using Fargowiltas.Content.Items.Summons;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class JungleChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicJungle;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Jungle Chest");
			// Tooltip.SetDefault("Summons Jungle Mimic");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
        /*
        public override void AddRecipes()
        {
            if (ModContent.TryFind("Fargowiltas/Deviantt", out ModItem modItem))
            {
                CreateRecipe()
                  .AddIngredient(ItemID.SoulofLight, 7)
                  .AddIngredient(ItemID.SoulofNight, 7)
                  .AddIngredient(ItemID.GoldCoin, 30)
                  .AddIngredient(modItem.Type)
                  .AddTile(TileID.MythrilAnvil)
                  .Register();
            }
        }
        */
    }
}