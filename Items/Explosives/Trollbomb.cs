using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class Trollbomb : ModItem
    {
        public override void SetStaticDefaults() => Tooltip.SetDefault("Summon a random bomb");

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.consumable = false;
            item.useStyle = ItemUseStyleID.Shoot;
            item.mana = 10;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(19))
            {
                case 0:
                    type = ProjectileID.Bomb;
                    break;

                case 1:
                    type = ProjectileID.BouncyBomb;
                    break;

                case 2:
                    type = ProjectileID.StickyBomb;
                    break;

                case 3:
                    type = ProjectileID.SmokeBomb;
                    break;

                case 4:
                    type = ProjectileID.Dynamite;
                    break;

                case 5:
                    type = ProjectileID.StickyDynamite;
                    break;

                case 6:
                    type = ProjectileID.BouncyDynamite;
                    break;

                case 7:
                    type = ProjectileID.Grenade;
                    break;

                case 8:
                    type = ProjectileID.StickyGrenade;
                    break;

                case 9:
                    type = ProjectileID.BouncyGrenade;
                    break;

                case 10:
                    type = ProjectileID.DirtBomb;
                    break;

                case 11:
                    type = ProjectileID.DirtStickyBomb;
                    break;

                case 12:
                    type = ProjectileID.DryBomb;
                    break;

                case 13:
                    type = ProjectileID.WetBomb;
                    break;

                case 14:
                    type = ProjectileID.HoneyBomb;
                    break;

                case 15:
                    type = ProjectileID.LavaBomb;
                    break;

                case 16:
                    type = ProjectileID.ScarabBomb;
                    break;

                case 17:
                    type = ProjectileID.Beenade;
                    break;

                case 18:
                    type = ProjectileID.PartyGirlGrenade;
                    break;
            }

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Bomb, 10)
                .AddIngredient(ItemID.StickyBomb, 10)
                .AddIngredient(ItemID.BouncyBomb, 10)
                .AddIngredient(ItemID.Dynamite, 10)
                .AddIngredient(ItemID.ManaCrystal)                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}