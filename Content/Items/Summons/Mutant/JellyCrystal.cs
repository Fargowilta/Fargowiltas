using Fargowiltas.Content.Items.Summons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.Mutant
{
    public class JellyCrystal : BaseSummon
    {

        public override int NPCType => NPCID.QueenSlimeBoss;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Jelly Crystal");
            // Tooltip.SetDefault("Summons Queen Slime");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.QueenSlimeCrystal)
               .AddTile(TileID.WorkBenches)
               .Register();

            CreateRecipe()
               .AddIngredient(ItemID.CrystalShard, 5)
               .AddIngredient(ItemID.SoulofLight, 3)
               .AddTile(TileID.MythrilAnvil)
               .Register();
        }
    }
}