using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.VanillaCopy
{
    public class LihzahrdPowerCell2 : BaseSummon
    {
        public override int NPCType => NPCID.Golem;

        public override string NPCName => "Golem";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Lihzahrd Battery Pack");
            Tooltip.SetDefault("Summons the Golem without an altar");
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.downedPlantBoss;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.LihzahrdPowerCell)
               .AddTile(TileID.WorkBenches)
               .Register();
        }
    }
}