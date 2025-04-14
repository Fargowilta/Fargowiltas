using Fargowiltas.Content.Items.Summons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.VanillaCopy
{
    public class DeerThing2 : BaseSummon
    {
        public override int NPCType => NPCID.Deerclops;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Thing Deer");
            // Tooltip.SetDefault("Summons Deerclops in any biome");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DeerThing)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}