using Fargowiltas.Content.Items.Summons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.Deviantt
{
    public class Eggplant : BaseSummon
    {
        public override int NPCType => NPCID.DoctorBones;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Eggplant");
			/* Tooltip.SetDefault("Summons Doctor Bones" +
                               "\nOnly usable at night or underground"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 0; // Places it before any other bosses
		}

        public override bool CanUseItem(Player player)
        {
            return FargoUtils.ActuallyNight || player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }

        public override void AddRecipes()
        {
            void Recipe(int fruit)
            {
                CreateRecipe()
                    .AddIngredient(fruit)
                    .AddIngredient(ItemID.JungleSpores, 4)
                    .AddIngredient(ItemID.Vine, 2)
                    .AddIngredient(ItemID.JungleGrassSeeds, 2)
                    .AddTile(TileID.Anvils)
                    .Register();
            }

            Recipe(ItemID.Mango);
            Recipe(ItemID.Pineapple);
        }
    }
}