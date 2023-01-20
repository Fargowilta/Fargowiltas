using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class GoreySpine : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_1331";

        public override int NPCType => NPCID.BrainofCthulhu;

        public override string NPCName => "Brain of Cthulhu";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Red Stained Spine");
            Tooltip.SetDefault("Summons the Brain of Cthulhu in any biome");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.BloodySpine)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}