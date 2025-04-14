using Fargowiltas.Content.Items.Summons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Items.Summons.VanillaCopy
{
    public class TruffleWorm2 : BaseSummon
    {

        public override int NPCType => NPCID.DukeFishron;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Truffly Worm");
            // Tooltip.SetDefault("Summons Duke Fishron without fishing");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.TruffleWorm)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}