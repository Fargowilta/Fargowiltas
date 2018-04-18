using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System;

namespace Fargowiltas.Items.Souls
{
    [AutoloadEquip(EquipType.Wings)]
    public class DimensionSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Dimensions");



            Tooltip.SetDefault("'The dimensions of Terraria are at your fingertips'"
                + "\nDoes various things");
            //33% chance to instantly heal back 75% of any damage taken
            /* + "\nActs as wings \nAllows for infinite flight"
             + "\n30% damage reduction \nIncreases life regeneration by 15 \nIncreases HP by 500 \nReflect 100% of damage back to attackers \nEffects of the Star Veil, Paladin's Shield, and Frozen Turtle Shell \nGrants immunity to even more debuffs"
             + "\n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nAllows the player to dash into the enemy"
             + "\nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 50% \nMining speed tripled and Auto paint effect \nSeveral common enemies are harmless"
             + "\nIncreases fishing skill massively \nPermanent Sonar and Crate Buffs \nAll other effects of material souls");*/
            /* if(Fargowiltas.instance.thoriumLoaded)
             {
                 Tooltip.SetDefault("'The dimensions of Terraria are at your fingertips'"
                 + "\nActs as wings \nAllows for infinite flight"
                 + "\n30% damage reduction \nIncreases life regeneration by 15 \nIncreases HP by 500 \nReflect 100% of damage back to attackers \nEffects of the Star Veil and Terrarium Defender \nAllows you to detect enemies and hazards around you \nGrants immunity to even more debuffs"
                 + "\n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nAllows the player to dash into the enemy"
                 + "\nNear infinite block placement and mining reach \nIncreased block and wall placement speed by 50% \nMining speed tripled and Auto paint effect \nSeveral common enemies are harmless"
                 + "*/

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 18));

        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.defense = 12;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.value = 1500000;
            item.rare = -12;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            (player.GetModPlayer<FargoPlayer>(mod)).dimensionSoul = true;

            //tank
            player.endurance += 0.30f;
            player.lifeRegen += 15;
            player.thorns += 1f;
            player.aggro += 100;
            player.statLifeMax2 += 500;
            player.statDefense = (int)(player.statDefense * 1.25);

            //ankh shield
            player.buffImmune[46] = true; //chilled
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true; //weak
            player.buffImmune[36] = true; //broken armor
            player.buffImmune[30] = true; //bleeding
            player.buffImmune[20] = true; //Poisoned
            player.buffImmune[32] = true; //slow
            player.buffImmune[31] = true; //Confused
            player.buffImmune[35] = true; //silenced
            player.buffImmune[23] = true; //cursed
            player.buffImmune[22] = true; //darkness

            player.buffImmune[44] = true; //Frostburn
            player.buffImmune[47] = true; //Frozen
            player.buffImmune[24] = true; //Fire
            player.buffImmune[69] = true; //Ichor
            player.buffImmune[70] = true; //Venom
            player.buffImmune[80] = true; //Black Out
            player.buffImmune[156] = true; //Stoned

            player.buffImmune[88] = true; //chaos state
            player.buffImmune[37] = true; //horrified
            player.buffImmune[39] = true; //cursed inferno
            player.buffImmune[68] = true; //suffocation

            // sweet vengeance or star veil
            if (Fargowiltas.instance.thoriumLoaded)
            {
                player.panic = true;
                player.starCloak = true;
                player.longInvince = true;
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                player.starCloak = true;
                player.longInvince = true;
            }

            // shiny stone
            player.shinyStone = true;

            //charm of myths
            player.pStone = true;

            //paladin
            if (player.statLife > player.statLifeMax2 * .20)
            {
                player.AddBuff(BuffID.PaladinsShield, 30, true);
            }

            //frozenshell
            if (player.statLife < player.statLifeMax2 * .6)
            {
                player.AddBuff(BuffID.IceBarrier, 30, true);
            }

            //celestial shell
            player.accMerman = true;
            player.wolfAcc = true;
            if (hideVisual)
            {
                player.hideMerman = true;
                player.hideWolf = true;
            }

            //wings
            player.ignoreWater = true;

            player.wingTimeMax = 99999;

            //speed

            //arctic diving gear
            player.arcticDivingGear = true;
            player.accFlipper = true;
            player.accDivingHelm = true;
            player.iceSkate = true;
            player.ignoreWater = true;


            //frostspark
            if (Soulcheck.GetValue("Super Speed") == true)
            {
                (player.GetModPlayer<FargoPlayer>(mod)).speedEffect = true;
                player.accRunSpeed = 2.00f;
                player.moveSpeed += 5f;
            }
            else
            {
                player.accRunSpeed = 35.00f;
                player.moveSpeed += 0.25f;
            }
            player.rocketBoots = 3;
            player.iceSkate = true;

            //lava waders
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;


            //balloons
            player.noFallDmg = true;
            player.jumpBoost = true;

            //honey
            player.bee = true;

            //shield of cthulu
            if (!Fargowiltas.instance.calamityLoaded)
            {
                player.dash = 2;
            }


            //slime mount
            player.maxFallSpeed += 6f;
            player.autoJump = true;

            //builder

            player.tileSpeed += 0.5f;
            player.wallSpeed += 0.5f;


            //toolbox
            Player.tileRangeX += 50;//WORKS
            Player.tileRangeY += 50;

            //gizmo pack
            player.autoPaint = true;

            //pick axe stuff
            player.pickSpeed -= 0.66f;

            if (!hideVisual)
            {
                /*player.magicDamage*= 0f;
                player.meleeDamage*= 0f;
                player.rangedDamage*= 0f;
                player.minionDamage*= 0f;
                player.thrownDamage*= 0f;*/

                (player.GetModPlayer<FargoPlayer>(mod)).builderMode = true;
            }


            //mining helmet
            if (Soulcheck.GetValue("Shine Buff") == true)
            {
                Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
            }
            //fishing
            player.sonarPotion = true;
            player.fishingSkill += 50;
            player.cratePotion = true;
            player.accFishingLine = true;
            player.accTackleBox = true;
            player.accFishFinder = true;

            //froglegs
            player.autoJump = true;
            player.jumpSpeedBoost += 2.5f;

            if (Soulcheck.GetValue("Spore Sac") == true)
            {
                //spore sac
                player.SporeSac();
                player.sporeSac = true;
            }

        (player.GetModPlayer<FargoPlayer>(mod)).fishSoul2 = true;

            //dread eye
            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Soulcheck.GetValue("Dangersense Buff") == true)
                {
                    player.dangerSense = true;
                }
                if (Soulcheck.GetValue("Hunter Buff") == true)
                {
                    player.detectCreature = true;
                }
            }

            if (Fargowiltas.instance.calamityLoaded)
            {
                player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("BrimstoneFlames")] = true;
                player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("HolyLight")] = true;
                player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("GlacialState")] = true;

                CalamityTank(player);

                CalamityBoots(player);
            }

            if (Fargowiltas.instance.blueMagicLoaded)
            {
                BlueTank(player);
            }
        }

        public void CalamityTank(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianAegis = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).dashMod = 4;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).aSpark = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).gShell = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).fCarapace = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).absorber = true;
        }

        public void CalamityBoots(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).IBoots = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianFire = true;
        }

        public void BlueTank(Player player)
        {
            player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).lifeMagnet2 = true;
            player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).crystalCloak = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.25f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 18f;
            acceleration *= 3.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "ColossusSoul");
            recipe.AddIngredient(null, "SupersonicSoul");
            recipe.AddIngredient(null, "FlightMasterySoul");
            recipe.AddIngredient(null, "WorldShaperSoul");
            recipe.AddIngredient(null, "TrawlerSoul");

            recipe.AddTile(null, "CrucibleCosmosSheet");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

}