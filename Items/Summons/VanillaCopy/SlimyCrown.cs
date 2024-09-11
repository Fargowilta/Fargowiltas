using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class SlimyCrown : BaseSummon
    {

        public override int NPCType => NPCID.KingSlime;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Slimy Crown");
            // Tooltip.SetDefault("Summons King Slime");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SlimeCrown)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}