using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class WormyFood : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_70";

        public override int NPCType => NPCID.EaterofWorldsHead;

        public override string NPCName => "Eater of Worlds";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Wormy Food");
            Tooltip.SetDefault("Summons the Eater of Worlds in any biome");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.WormFood)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}