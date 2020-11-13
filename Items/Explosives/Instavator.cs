using Fargowiltas.Projectiles.Explosives;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class Instavator : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Creates a hellevator instantly\nDo not use if any important building is below");

        public override void SetDefaults()
        {
            item.damage = 50;
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
            item.shoot = ModContent.ProjectileType<InstaProj>();
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FossilOre, 20)
                .AddIngredient(ItemID.Dynamite, 50)
                .AddIngredient(ItemID.RopeCoil, 10)
                .AddIngredient(ItemID.Torch, 99)                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}