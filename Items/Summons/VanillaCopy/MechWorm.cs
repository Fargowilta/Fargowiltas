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
    public class MechWorm : BaseSummon
    {

        public override int NPCType => NPCID.TheDestroyer;
        
        public override bool ResetTimeWhenUsed => !NPC.downedMechBoss1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Some Kind of Metallic Worm");
			// Tooltip.SetDefault("Summons the Destroyer");

			ItemID.Sets.SortingPriorityBossSpawns[Type] = ItemID.Sets.SortingPriorityBossSpawns[ItemID.MechanicalWorm]; // 9
		}

        public override bool CanUseItem(Player player) => FargoUtils.ActuallyNight && !NPC.AnyNPCs(NPCType);

        public override bool? UseItem(Player player)
        {
            FargoUtils.SpawnBossNetcoded(player, NPCType);
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Main.time = 0;

            if (Main.netMode == NetmodeID.Server) //sync time
                NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
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