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
    public class MechWorm : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_556";

        public override int NPCType => NPCID.TheDestroyer;
        
        public override bool ResetTimeWhenUsed => !NPC.downedMechBoss1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Some Kind of Metallic Worm");
            // Tooltip.SetDefault("Summons the Destroyer");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime && !NPC.AnyNPCs(NPCType);

        public override bool? UseItem(Player player)
        {
            FargoUtils.SpawnBossNetcoded(player, NPCType);
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.MechanicalWorm)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}