using Fargowiltas.Projectiles.Explosives;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class BoomShuriken : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Rapid firing explosives");

        public override void SetDefaults()
        {
            item.width = 11;
            item.height = 11;
            item.damage = 16;
            item.DamageType = DamageClass.Ranged;
            item.noMelee = true;
            item.consumable = true;
            item.noUseGraphic = true;
            item.scale = 0.75f;
            item.crit = 5;
            item.useStyle = ItemUseStyleID.Swing;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.maxStack = 999;
            item.rare = ItemRarityID.Blue;
            item.shoot = ModContent.ProjectileType<ShurikenProj>();
            item.shootSpeed = 11f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Shuriken, 20)
                .AddIngredient(ItemID.Dynamite, 5)                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}