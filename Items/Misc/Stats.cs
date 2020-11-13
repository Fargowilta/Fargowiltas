using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

////using ThoriumMod;

namespace Fargowiltas.Items.Misc
{
    public class Stats : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Stat Sheet");

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // item.owner was either replaced with something else (no idea what) or was deleted. Main.LocalPlayer should work fine, seeing as tooltips are client side, right?
            Player player = Main.LocalPlayer;

            tooltips.Add(new TooltipLine(Mod, "info", $"Melee Damage: {player.GetDamage(DamageClass.Melee) * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Melee Speed: {player.meleeSpeed * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Melee Crit: {player.GetCrit(DamageClass.Melee)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Ranged Damage: {player.GetDamage(DamageClass.Ranged) * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Ranged Crit: {player.GetCrit(DamageClass.Ranged)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Magic Damage: {player.GetDamage(DamageClass.Magic) * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Magic Crit: {player.GetCrit(DamageClass.Magic)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Summon Damage: {player.GetDamage(DamageClass.Summon) * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Max Minions: {player.maxMinions}"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Max Sentries: {player.maxTurrets}"));

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                ThoriumStats(tooltips, player);
            }

            tooltips.Add(new TooltipLine(Mod, "info", $"Damage Reduction: {player.endurance * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Life Regen: {player.lifeRegen} HP/second"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Armor Pen: {player.armorPenetration}"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Max Speed: {(player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6} mph"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Wing Time: {player.wingTimeMax / 60} seconds"));
        }

        private void ThoriumStats(List<TooltipLine> tooltips, Player player)
        {
            // TODO: ThoriumPlayer
            /*ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            tooltips.Add(new TooltipLine(Mod, "info", $"Symphonic Damage: {thoriumPlayer.symphonicDamage * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Symphonic Speed: {(thoriumPlayer.symphonicSpeed * 100)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Symphonic Crit: {thoriumPlayer.symphonicCrit}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Inspiration Regen: {thoriumPlayer.inspirationRegenBonus * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Empowerment Duration: {thoriumPlayer.bardBuffDuration / 60} seconds"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Radiant Damage: {thoriumPlayer.radiantBoost * 100}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Radiant Speed: {(thoriumPlayer.radiantSpeed * 100)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Healing Speed: {(thoriumPlayer.healingSpeed * 100)}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Radiant Crit: {thoriumPlayer.radiantCrit}%"));
            tooltips.Add(new TooltipLine(Mod, "info", $"Bonus Healing: {thoriumPlayer.healBonus}"));*/
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sign)
                .AddIngredient(ItemID.CopperAxe)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}