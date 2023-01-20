using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AttractiveOre : BaseSummon
    {
        public override int NPCType => NPCID.UndeadMiner;

        public override string NPCName => "Undead Miner";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Attractive Ore");
            Tooltip.SetDefault("Summons Undead Miner" +
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
                    .AddIngredient(ItemID.DeadMansChest)
					.AddIngredient(ItemID.MiningHelmet)
                    .AddIngredient(ItemID.SpelunkerPotion)
                    .AddIngredient(ItemID.GoldCoin, 3)
                    .AddIngredient(modItem.Type)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
        }
    }
}