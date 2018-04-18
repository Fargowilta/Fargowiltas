using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;


namespace Fargowiltas.Items.Souls
{
    public class SupersonicSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supersonic Soul");
            Tooltip.SetDefault("'Sound barriers forever broken' \n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nProvides lava immunity and permanent light \nGrants the ability to swim and greatly extends underwater breathing \nIncreases jump height, allows auto jump, and negates fall damage \nAllows the player to dash into the enemy");
            if (Fargowiltas.instance.thoriumLoaded)
            {
                Tooltip.SetDefault("'Sound barriers forever broken' \n25% increased movement speed \nAllows supersonic fast running, and extra mobility on ice \nProvides lava immunity and permanent light \nGrants the ability to swim and greatly extends underwater breathing \nIncreases jump height, allows auto jump, and negates fall damage \nAllows the player to dash into the enemy \nReflects 35% of damage back to attackers");
            }
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.defense = 4;
            item.accessory = true;
            item.value = 750000;
            item.expert = true;
            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            //arctic diving gear
            player.arcticDivingGear = true;
            player.accFlipper = true;
            player.accDivingHelm = true;
            player.iceSkate = true;
            player.ignoreWater = true;

            if (player.wet)
                Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);

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

            //spiked stompers
            if (Fargowiltas.instance.thoriumLoaded)
            {
                player.thorns += 0.35f;
            }

            //slime mount
            player.maxFallSpeed += 5f;
            player.autoJump = true;

            //elysian tracers
            if (Fargowiltas.instance.calamityLoaded && !hideVisual)
            {
                CalamityBoots(player);
            }

            //shield of cthulu
            player.dash = 2;

        }

        public void CalamityBoots(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).IBoots = true;
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).elysianFire = true;
        }


        public override void AddRecipes()
        {
            ModRecipe speed = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //thorium and calamity
                    speed.AddIngredient(ItemID.EoCShield);
                    speed.AddIngredient(ItemID.BundleofBalloons);
                    speed.AddIngredient(ItemID.ArcticDivingGear);
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SpikedStompers"));
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumBoots"));
                    speed.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ElysianTracers"));
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("WarpCore"));
                    speed.AddIngredient(ItemID.SlimySaddle);
                    speed.AddIngredient(ItemID.FuzzyCarrot);
                    speed.AddIngredient(ItemID.BlessedApple);
                    speed.AddIngredient(ItemID.AncientHorn);
                    speed.AddIngredient(ItemID.ShrimpyTruffle);
                    speed.AddIngredient(ItemID.ReindeerBells);
                    speed.AddIngredient(ItemID.BrainScrambler);
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    speed.AddIngredient(ItemID.EoCShield);
                    speed.AddIngredient(ItemID.BundleofBalloons);
                    speed.AddIngredient(ItemID.ArcticDivingGear);
                    speed.AddIngredient(ItemID.FlowerBoots);
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SpikedStompers"));
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumBoots"));
                    speed.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("WarpCore"));
                    speed.AddIngredient(ItemID.SlimySaddle);
                    speed.AddIngredient(ItemID.FuzzyCarrot);
                    speed.AddIngredient(ItemID.BlessedApple);
                    speed.AddIngredient(ItemID.AncientHorn);
                    speed.AddIngredient(ItemID.ShrimpyTruffle);
                    speed.AddIngredient(ItemID.ReindeerBells);
                    speed.AddIngredient(ItemID.BrainScrambler);
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    speed.AddIngredient(ItemID.EoCShield);
                    speed.AddIngredient(ItemID.FlyingCarpet);
                    speed.AddIngredient(ItemID.BundleofBalloons);
                    speed.AddIngredient(ItemID.ArcticDivingGear);
                    speed.AddIngredient(ItemID.FlowerBoots);
                    speed.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ElysianTracers"));
                    speed.AddIngredient(ItemID.SlimySaddle);
                    speed.AddIngredient(ItemID.FuzzyCarrot);
                    speed.AddIngredient(ItemID.BlessedApple);
                    speed.AddIngredient(ItemID.AncientHorn);
                    speed.AddIngredient(ItemID.ShrimpyTruffle);
                    speed.AddIngredient(ItemID.ReindeerBells);
                    speed.AddIngredient(ItemID.BrainScrambler);
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //no others
                    speed.AddIngredient(ItemID.EoCShield);
                    speed.AddIngredient(ItemID.FlyingCarpet);
                    speed.AddIngredient(ItemID.BundleofBalloons);
                    speed.AddIngredient(ItemID.ArcticDivingGear);
                    speed.AddIngredient(ItemID.FlowerBoots);
                    speed.AddIngredient(ItemID.FrostsparkBoots);
                    speed.AddIngredient(ItemID.LavaWaders);
                    speed.AddIngredient(ItemID.SlimySaddle);
                    speed.AddIngredient(ItemID.FuzzyCarrot);
                    speed.AddIngredient(ItemID.BlessedApple);
                    speed.AddIngredient(ItemID.AncientHorn);
                    speed.AddIngredient(ItemID.ShrimpyTruffle);
                    speed.AddIngredient(ItemID.ReindeerBells);
                    speed.AddIngredient(ItemID.BrainScrambler);
                }
            }

            speed.AddTile(null, "CrucibleCosmosSheet");
            speed.SetResult(this);
            speed.AddRecipe();

        }
    }
}