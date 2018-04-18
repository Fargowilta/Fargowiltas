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
    public class GuardianAngelsSoul : ModItem
    {
        string tooltip = null;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Angel's Soul");

            if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
            {
                Tooltip.SetDefault("'Divine Intervention' \n" +
                                    "40% increased radiant damage\n" +
                                    "25% increased healing and radiant casting speed\n" +
                                    "20% increased radiant critical strike chance\n" +
                                    "Healing spells will heal an additional 5 life\n" +
                                    "Healing an ally will increase your movement speed and increase their life regen and defense\n" +
                                    "Upon drinking a healing potion, all allies will recover 25 life and 40 mana\n" +
                                    "You and nearby allies will take 8% reduced damage\n" +
                                    "Taking fatal damage unleashes your inner spirit");
            }
            else
            {
                Tooltip.SetDefault("'Divine Intervention' \n" +
                                   "Enemies are less likely to target you\n" +
                                   "You and nearby allies will take 10% reduced damage\n" +
                                   "-Enable Thorium for this soul's full potential-");
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
                //Turn undead
                player.aggro -= 50;
                player.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("AegisAura"), 30, false);
                for (int k = 0; k < 255; k++)
                {
                    Player target = Main.player[k];

                    if (target.active && target != player && Vector2.Distance(target.Center, player.Center) < 275)
                    {
                        target.AddBuff(ModLoader.GetMod("ThoriumMod").BuffType("AegisAura"), 30, false);
                    }
                }

                //the rest
                Healer(player);
            }

            else
            {
                player.aggro -= 50;
                player.endurance += 0.1f;
            }
        }

        public void Healer(Player player)
        {
            //general
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantBoost += 0.4f; //radiant damage
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantSpeed -= 0.25f; //radiant casting speed
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).healingSpeed += 0.25f; //healing spell casting speed
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).radiantCrit += 20;

            //archdemon's curse
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).darkAura = true; //Dark intent purple coloring effect

            //support stash
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).quickBelt = true; //bonus movement from healing
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).apothLife = true; //drinking health potion recovers life
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).apothMana = true; //drinking health potion recovers mana

            //ascension statuette
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).ascension = true; //turn into healing thing on death

            //wynebg..........
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).Wynebgwrthucher = true; //heals on healing ally

            //archangels heart
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).healBonus += 5; //Bonus healing

            //saving grace
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).crossHeal = true; //bonus defense in heal
            player.GetModPlayer<ThoriumMod.ThoriumPlayer>(ModLoader.GetMod("ThoriumMod")).healBloom = true; //bonus life regen on heal
        }

        public override void AddRecipes()
        {
            if (Fargowiltas.instance.thoriumLoaded)
            {
                ModRecipe recipe = new ModRecipe(mod);

                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("ArchDemonCurse"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SupportSash"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TurnUndead"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AscensionStatuette"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Wynebgwrthucher"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("ArchangelHeart"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SavingGrace"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("BoneBaton"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerraScythe"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("ChristmasCheer"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumHolyScythe"));
                recipe.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("RealitySlasher"));

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
