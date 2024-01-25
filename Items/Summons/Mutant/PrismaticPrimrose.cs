using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class PrismaticPrimrose : BaseSummon
    {
        public override int NPCType => NPCID.HallowBoss;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Prismatic Primrose");
            // Tooltip.SetDefault("Summons the Empress of Light");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.EmpressButterfly)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}