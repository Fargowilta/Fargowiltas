using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class MechSkull : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_557";

        public override int NPCType => NPCID.SkeletronPrime;
        
        public override bool ResetTimeWhenUsed => !NPC.downedMechBoss3;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Some Kind of Metallic Skull");
            // Tooltip.SetDefault("Summons Skeletron Prime");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.MechanicalSkull)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}