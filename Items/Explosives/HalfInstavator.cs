using Fargowiltas.Common.Systems;
using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class HalfInstavator : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Half Instavator");
            // Tooltip.SetDefault("Drops a bomb that creates half a hellevator instantly\nWill not dig below a certain depth\nDo not use if any important building is below");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            //Item.value = Item.buyPrice(0, 0, 3);
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<HalfInstaProj>();
            Item.shootSpeed = 5f;
        }
        public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 mouse = Main.MouseWorld;
                mouse += Vector2.UnitY * 16;
                InstaVisual.DrawOrigin drawOrigin = InstaVisual.DrawOrigin.Top;
                InstaVisual.DrawInstaVisual(player, mouse, new(5, 1000), drawOrigin);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mouse = Main.MouseWorld;

            Projectile.NewProjectile(player.GetSource_ItemUse(source.Item), mouse, Vector2.Zero, type, 0, 0, player.whoAmI);

            return false;
        }

        /*public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Dynamite, 10)
                .AddIngredient(ItemID.Torch, 25)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.Anvils)
                .Register();
        }*/
    }
}