using Terraria;
using Terraria.ID;

namespace Fargowiltas.Content.Items.Summons.VanillaCopy
{
    public class MechSkull : BaseSummon
    {

        public override int NPCType => NPCID.SkeletronPrime;
        
        public override bool ResetTimeWhenUsed => !NPC.downedMechBoss3;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight;

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.MechanicalSkull)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}