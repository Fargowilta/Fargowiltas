using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HemoclawCrab : BaseSummon
    {
        public override int NPCType => NPCID.GoblinShark;

        public override string NPCName => "Hemogoblin Shark";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hemoclaw Crab");
            Tooltip.SetDefault("Summons Hemogoblin Shark" +
                               "\nOnly usable during Blood Moon");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && Main.bloodMoon;
        }

        public override void AddRecipes()
        {
            if (ModContent.TryFind("Fargowiltas/Deviantt", out ModItem modItem))
            {
                CreateRecipe()
                  .AddIngredient(ItemID.ChumBucket)
                  .AddIngredient(ItemID.GoldCoin, 10)
                  .AddIngredient(modItem.Type)
                  .AddTile(TileID.MythrilAnvil)
                  .Register();
            }
        }
    }
}