using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
    public class WormyFood : BaseSummon
    {
        public override string Texture => "Terraria/Images/Item_70";

        public override int NPCType => NPCID.EaterofWorldsHead;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Wormy Food");
            // Tooltip.SetDefault("Summons the Eater of Worlds in any biome");
        }

        public override bool CanUseItem(Player player) => !NPC.AnyNPCs(NPCType);

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
               .AddIngredient(ItemID.WormFood)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}