using Fargowiltas.Items.Tiles;
using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GoldenSlimeCrown : BaseSummon
    {
        public override int NPCType => NPCID.GoldenSlime;

        public override string NPCName => "Golden Slime";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Golden Slime Crown");
            Tooltip.SetDefault("Summons Golden Slime");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<PinkSlimeCrown>())
                .AddIngredient(ItemID.GoldDust, 999)
                .AddTile(ModContent.TileType<GoldenDippingVatSheet>())
                .Register();
        }
    }
}