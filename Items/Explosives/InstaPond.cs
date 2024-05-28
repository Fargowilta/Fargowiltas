using Fargowiltas.Common.Systems;
using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class InstaPond : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 48;
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
            Item.shoot = ModContent.ProjectileType<InstaPondProj>();
            Item.shootSpeed = 5f;
        }
        public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 mouse = Main.MouseWorld;
                InstaVisual.DrawOrigin drawOrigin = InstaVisual.DrawOrigin.Top;
                InstaVisual.DrawInstaVisual(player, mouse, new(1000, 5), drawOrigin);
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Dynamite, 25)
                .AddIngredient(ItemID.WetBomb, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}