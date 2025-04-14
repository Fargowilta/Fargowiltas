using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class SuspiciousLookingChest : BaseSummon
    {
        public override int NPCType => Main.LocalPlayer.ZoneSnow ? NPCID.IceMimic : NPCID.Mimic;
        
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			// DisplayName.SetDefault("Suspicious Looking Chest");
			/* Tooltip.SetDefault("Summons Mimic"
            + "\nSummons Ice Mimic when in snow biome"); */

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 6; // Places it right after Gelatin Crystal
		}
        public override bool CanUseItem(Player player)
        {
            if (!Main.hardMode && !FargoUtils.EternityMode) 
                return false;
            return base.CanUseItem(player);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (!FargoUtils.EternityMode)
                tooltips.Insert(4, new TooltipLine(Mod, "HardmodeLock", Language.GetTextValue($"Mods.Fargowiltas.Items.SuspiciousLookingChest.HardmodeLock")));

        }
        public override void AddRecipes()
        {
            CreateRecipe()
                    .AddRecipeGroup("Fargowiltas:AnyDemoniteBar", 10)
                    .AddIngredient(ItemID.GoldCoin, 10)
                    .AddIngredient(ItemID.Chest, 1)
                    .AddTile(TileID.DemonAltar)
                    .Register();
        }
    }
}
