using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;

namespace Fargowiltas.Items.Souls
{
    public class BardSoul : ModItem
    {
        string tooltip = null;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhapsodist's Soul");

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                Tooltip.SetDefault("'Every note you produce births a new world'\n" +
                                    "40% increased symphonic damage\n" +
                                    "25% increased symphonic playing speed\n" +
                                    "20% increased symphonic critical strike chance\n" +
                                    "Your symphonic damage empowers all nearby allies with: Cold Shoulder, Spider Bite, Abomination's Blood, Vile Flames and Terrarian\n" +
                                    "Damage done against frostburnt, envenomed, ichor'd, and cursed flamed enemies is increased by 10%\n" +
                                    "Doubles the range of your empowerments effect radius\n" +
                                    "Percussion critical strikes will deal 10% more damage\n" +
                                    "Percussion critical strikes will briefly stun enemies\n" +
                                    "Your wind instrument attacks now attempt to quickly home in on enemies\n" +
                                    "If the attack already homes onto enemies, it does so far more quickly\n" +
                                    "String weapon projectiles bounce five additional times\n" +
                                    "Critical strikes caused by brass instrument attacks release a spread of energy");

                //at a later date
                // Increases inspiration regeneration by 10%
                // Increases maximum inspiration by 4					
            }
            else
            {
                Tooltip.SetDefault("'Every note you produce births a new world'\n" +
                                   "-Enable Thorium for this soul to do anything-");
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 750000;
            item.expert = true;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Fargowiltas.instance.thoriumLoaded)
            {
                Bard(player);
            }
        }

        public void Bard(Player player)
        {
            //general
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicDamage += 0.4f; //symphonic damage
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicCrit += 20;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).symphonicSpeed += .25f;

            //woofers
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).subwooferFrost = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).subwooferVenom = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).subwooferIchor = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).subwooferCursed = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).subwooferTerrarium = true;

            //type buffs
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).bardHomingBool = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).bardHomingBonus = 5f;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).bardMute2 = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).tuner2 = true;
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).bardBounceBonus = 5;
        }

        public override void AddRecipes()
        {
            if (Fargowiltas.instance.thoriumLoaded)
            {
                ModRecipe recipe = new ModRecipe(mod);

                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("VenomSubwoofer"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("FrostSubwoofer"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CorruptSubwoofer"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrimsonSubwoofer"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumSubwoofer"));

                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DigitalVibrationTuner"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("EpicMouthpiece"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StraightMute"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("GuitarPickClaw"));

                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Triangle"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Ocarina"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Saxophone"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("RockstarsDoubleBassBlastGuitar"));

                recipe.AddTile(null, "CrucibleCosmosSheet");
                recipe.SetResult(this);
                recipe.AddRecipe();
            }

            else
            {
                return;
            }
        }
    }
}
