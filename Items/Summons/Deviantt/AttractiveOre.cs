using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AttractiveOre : BaseSummon
    {
        public override int NPCType => NPCID.UndeadMiner;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Attractive Ore");
            /* Tooltip.SetDefault("Summons Undead Miner" +
                               "\nOnly usable at night or underground"); */
        }

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DeadMansChest)
                .AddIngredient(ItemID.MiningHelmet)
                .AddIngredient(ItemID.SpelunkerPotion)
                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }
    }
}