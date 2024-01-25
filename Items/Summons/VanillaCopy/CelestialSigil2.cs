using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class CelestialSigil2 : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_3601";

        public override int NPCType => NPCID.MoonLordCore;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Celestially Sigil");
            // Tooltip.SetDefault("Summons the Moon Lord instantly");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.CelestialSigil)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}