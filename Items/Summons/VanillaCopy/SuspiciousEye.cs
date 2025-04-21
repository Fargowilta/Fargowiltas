using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class SuspiciousEye : BaseSummon
    {
       // public override string Texture => "Terraria/Images/Item_43";

        public override int NPCType => NPCID.EyeofCthulhu;
        
        public override bool ResetTimeWhenUsed => !NPC.downedBoss1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Eye That Could Be Seen As Suspicious");
			// Tooltip.SetDefault("Summons the Eye of Cthulhu");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.SuspiciousLookingEye]; // 1
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