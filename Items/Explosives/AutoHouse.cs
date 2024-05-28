using Fargowiltas.Common.Systems;
using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class AutoHouse : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("InstaHouse");
            // Tooltip.SetDefault("Places an NPC house instantly");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 32;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.buyPrice(0, 0, 3);
            Item.createTile = ModContent.TileType<AutoHouseTile>();
        }

        public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 mouse = Main.MouseWorld - Vector2.UnitY * 16;
                InstaVisual.DrawOrigin origin = mouse.X - player.Center.X > 0 ? InstaVisual.DrawOrigin.Left : InstaVisual.DrawOrigin.Right;
                InstaVisual.DrawInstaVisual(player, mouse, new(10, 6), origin);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("Wood", 50)
                .AddIngredient(ItemID.Torch)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}