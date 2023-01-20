using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class Eggplant : BaseSummon
    {
        public override int NPCType => NPCID.DoctorBones;

        public override string NPCName => "Doctor Bones";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Eggplant");
            Tooltip.SetDefault("Summons Doctor Bones" +
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
                void Recipe(int fruit)
                {
                    CreateRecipe()
                        .AddIngredient(fruit)
                        .AddIngredient(ItemID.JungleSpores, 4)
                        .AddIngredient(ItemID.Vine, 2)
                        .AddIngredient(ItemID.JungleGrassSeeds, 2)
                        .AddIngredient(modItem.Type)
                        .AddTile(TileID.Anvils)
                        .Register();
                }

                Recipe(ItemID.Mango);
                Recipe(ItemID.Pineapple);
            }
        }
    }
}