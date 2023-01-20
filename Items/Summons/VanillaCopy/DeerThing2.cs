using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class DeerThing2 : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_5120";

        public override int NPCType => NPCID.Deerclops;

        public override string NPCName => "Deerclops";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Thing Deer");
            Tooltip.SetDefault("Summons Deerclops in any biome");
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