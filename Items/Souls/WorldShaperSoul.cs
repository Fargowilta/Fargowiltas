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
    public class WorldShaperSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("World Shaper Soul");
            Tooltip.SetDefault(@"'Limitless possibilities'
Near infinite block placement and mining reach
Increased block and wall placement speed by 25% 
Mining speed doubled 
Auto paint and actuator effect 
Provides light 
Toggle vanity to enable Builder Mode:
Anything that creates a tile will not be consumed 
No enemies can spawn
");
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
            ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).builderEffect = true;

            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;

            //toolbox
            Player.tileRangeX += 50;
            Player.tileRangeY += 50;

            //gizmo pack
            player.autoPaint = true;

            //pick axe stuff
            player.pickSpeed -= 0.50f;

            //mining helmet
            if (Soulcheck.GetValue("Shine Buff") == false)
            {
                Lighting.AddLight(player.Center, 0.8f, 0.8f, 0f);
            }
            //presserator
            player.autoActuator = true;

            if (!hideVisual)
            {
                /*player.magicDamage*= 0f;
                player.meleeDamage*= 0f;
                player.rangedDamage*= 0f;
                player.minionDamage*= 0f;
                player.thrownDamage*= 0f;*/

                ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).builderMode = true;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe build = new ModRecipe(mod);

            build.AddIngredient(ItemID.Toolbelt);
            build.AddIngredient(ItemID.Toolbox);
            build.AddIngredient(ItemID.ArchitectGizmoPack);
            build.AddIngredient(ItemID.ActuationAccessory);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //thorium and calamity
                    build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AncientFossil"));
                    build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrystalineCharm"));
                    build.AddRecipeGroup("Fargowiltas:AnyDrax");
                    build.AddIngredient(ItemID.ShroomiteDiggingClaw);
                    build.AddIngredient(ItemID.Picksaw);
                    build.AddIngredient(ItemID.LaserDrill);
                    build.AddIngredient(ItemID.DrillContainmentUnit);
                    build.AddIngredient(ItemID.PeaceCandle, 10);
                    build.AddIngredient(ItemID.RoyalGel);
                    build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("OceanCrest"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    build.AddIngredient(ItemID.MiningHelmet);
                    build.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrystalineCharm"));
                    build.AddRecipeGroup("Fargowiltas:AnyDrax");
                    build.AddIngredient(ItemID.ShroomiteDiggingClaw);
                    build.AddIngredient(ItemID.Picksaw);
                    build.AddIngredient(ItemID.LaserDrill);
                    build.AddIngredient(ItemID.DrillContainmentUnit);
                    build.AddIngredient(ItemID.Sunflower, 50);
                    build.AddIngredient(ItemID.PeaceCandle, 10);
                    build.AddIngredient(ItemID.RoyalGel);
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AncientFossil"));
                    build.AddRecipeGroup("Fargowiltas:AnyDrax");
                    build.AddIngredient(ItemID.ShroomiteDiggingClaw);
                    build.AddIngredient(ItemID.MoltenPickaxe);
                    build.AddIngredient(ItemID.Picksaw);
                    build.AddIngredient(ItemID.LaserDrill);
                    build.AddIngredient(ItemID.DrillContainmentUnit);
                    build.AddIngredient(ItemID.PeaceCandle, 10);
                    build.AddIngredient(ItemID.RoyalGel);
                    build.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("OceanCrest"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //no others
                    build.AddRecipeGroup("Fargowiltas:AnyDrax");
                    build.AddIngredient(ItemID.ShroomiteDiggingClaw);
                    build.AddIngredient(ItemID.MoltenPickaxe);
                    build.AddIngredient(ItemID.Picksaw);
                    build.AddIngredient(ItemID.LaserDrill);
                    build.AddIngredient(ItemID.DrillContainmentUnit);
                    build.AddIngredient(ItemID.Sunflower, 50);
                    build.AddIngredient(ItemID.PeaceCandle, 10);
                    build.AddIngredient(ItemID.RoyalGel);
                }
            }

            build.AddTile(null, "CrucibleCosmosSheet");
            build.SetResult(this);
            build.AddRecipe();
        }
    }
}