using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class JungleChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicJungle;

        public override string NPCName => "Jungle Mimic";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Jungle Chest");
            Tooltip.SetDefault("Summons Jungle Mimic");
        }

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
    }
}