using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class DoubleObsidianInstabridge : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Creates 2 bridges of obsidian platforms across the whole world" +
                "\nAlso clears the area between and above the platforms" +
                "\nDo not use if any important building is nearby");

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<DoubleObsInstaBridgeProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(Main.MouseWorld, Vector2.Zero, type, 0, 0, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ObsidianInstaBridge>(), 2)                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}