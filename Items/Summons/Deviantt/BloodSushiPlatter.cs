using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class BloodSushiPlatter : BaseSummon
    {
        public override int NPCType => NPCID.BloodNautilus;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Blood Sushi Platter");
            /* Tooltip.SetDefault("Summons Dreadnautilus" +
                               "\nOnly usable during Blood Moon"); */
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
                  .AddIngredient(ItemID.GoldCoin, 20)
                  .AddIngredient(modItem.Type)
                  .AddTile(TileID.MythrilAnvil)
                  .Register();
            }
        }
    }
}