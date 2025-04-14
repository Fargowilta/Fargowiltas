using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.VanillaCopy
{
    public class SuspiciousEye : BaseSummon
    {

        public override int NPCType => NPCID.EyeofCthulhu;
        
        public override bool ResetTimeWhenUsed => !NPC.downedBoss1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SuspiciousLookingEye)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}