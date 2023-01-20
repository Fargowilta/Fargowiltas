using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HeartChocolate : BaseSummon
    {
        public override int NPCType => NPCID.Nymph;

        public override string NPCName => "Nymph";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Heart Chocolate");
            Tooltip.SetDefault("Summons Nymph" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes()
        {
            if (ModContent.TryFind("Fargowiltas/Deviantt", out ModItem modItem))
            {
                CreateRecipe()
                  .AddIngredient(ItemID.LifeCrystal)
                  .AddIngredient(ItemID.GoldCoin, 10)
                  .AddIngredient(modItem.Type)
                  .AddTile(TileID.CookingPots)
                  .Register();
            }
        }
    }
}