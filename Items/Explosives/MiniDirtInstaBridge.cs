﻿using Fargowiltas.Common.Systems;
using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class MiniDirtInstaBridge : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mini Instabridge");
            /* Tooltip.SetDefault("Creates a long bridge of platforms at your cursor" +
                               "\nWill not break any blocks"); */
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 32;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.buyPrice(0, 0, 3);
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<MiniDirtInstabridgeProj>();
        }

        public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 mouse = Main.MouseWorld;
                int side = Math.Sign(mouse.X - player.Center.X);
                InstaVisual.DrawOrigin origin = side > 0 ? InstaVisual.DrawOrigin.Left : InstaVisual.DrawOrigin.Right;
                if (side == -1)
                    mouse.X += side * 16;
                InstaVisual.DrawInstaVisual(player, mouse, new(150, 1), origin);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mouse = Main.MouseWorld;

            Projectile.NewProjectile(player.GetSource_ItemUse(source.Item), mouse, Vector2.Zero, type, 0, 0, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Dynamite)
                .AddIngredient(ItemID.DirtBlock, 100)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}