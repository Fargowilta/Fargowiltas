using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HolyGrail : BaseSummon
    {
        public override int NPCType => NPCID.Tim;

        public override string NPCName => "Tim";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Holy Grail");
            Tooltip.SetDefault("Summons Tim" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes()
        {
			void Recipe(int bar)
			{
				CreateRecipe()
					.AddIngredient(bar, 3)
					.AddIngredient(ItemID.SummoningPotion, 7)
					.AddIngredient(ItemID.MudBlock)
					.AddIngredient(ItemID.ManaCrystal)
					.AddTile(TileID.DemonAltar)
					.Register();
			}
			
			Recipe(ItemID.DemoniteBar);
            Recipe(ItemID.CrimtaneBar);
        }
    }
}