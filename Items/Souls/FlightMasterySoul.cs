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
    [AutoloadEquip(EquipType.Wings)]
    public class FlightMasterySoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flight Mastery Soul");
            Tooltip.SetDefault("'Ascend' \nActs as wings \nAllows for very long lasting flight \nReleases bees when damaged");
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

            player.ignoreWater = true;
            player.wingTimeMax = 2000;

            //honey
            player.noFallDmg = true;
            player.jumpBoost = true;
            player.bee = true;

        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 18f;
            acceleration *= 3.5f;
        }

        /*public override void WingUpdate(Player player, bool inUse)
    {
    	if (inUse)
    		Dust.NewDust(player.position, player.width, player.height, 107, 0, 0, 0, Color.Green);
    	base.WingUpdate(player, inUse);
    }*/   //add when you have actual wings

        public override void AddRecipes()
        {
            ModRecipe wings = new ModRecipe(mod);

            wings.AddIngredient(ItemID.BalloonHorseshoeHoney);
            wings.AddIngredient(ItemID.HarpyWings);
            wings.AddIngredient(ItemID.BoneWings);
            wings.AddIngredient(ItemID.MothronWings);
            wings.AddIngredient(ItemID.FrozenWings);
            wings.AddIngredient(ItemID.FlameWings);
            wings.AddIngredient(ItemID.TatteredFairyWings);

            wings.AddIngredient(ItemID.FestiveWings);
            wings.AddIngredient(ItemID.BetsyWings);
            wings.AddIngredient(ItemID.FishronWings);
            wings.AddIngredient(ItemID.WingsStardust);
            wings.AddIngredient(ItemID.WingsVortex);
            wings.AddIngredient(ItemID.WingsNebula);
            wings.AddIngredient(ItemID.WingsSolar);

            wings.AddTile(null, "CrucibleCosmosSheet");
            wings.SetResult(this);
            wings.AddRecipe();
        }
    }
}