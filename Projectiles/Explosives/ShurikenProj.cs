using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class ShurikenProj : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Shuriken");

        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 11;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 5;
            projectile.aiStyle = 2;
            projectile.timeLeft = 600;
            aiType = 48;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => projectile.Kill();

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return false;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<ExplosionProj>(), 0, projectile.knockBack, projectile.owner);

            Vector2 position = projectile.Center;

            SoundEngine.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            int radius = 16; // bigger = boomer

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);
                    Tile tile = Main.tile[xPosition, yPosition];
                    Player player = Main.player[projectile.owner];
                    Item bestPickaxe = GetBestPickaxe(player);

                    // Circle
                    if ((x * x + y * y) <= radius)
                    {
                        // Hit the tile 5 times, most tiles that you can break will break in 1-3 hits.
                        for (int i = 0; i < 5; i++)
                        {
                            if (!tile.active())
                            {
                                break;
                            }

                            player.PickTile(xPosition, yPosition, bestPickaxe != null ? bestPickaxe.pick : 35);
                        }

                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);
                    }

                    // NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
            }
        }

        private Item GetBestPickaxe(Player player)
        {
            Item item = null;

            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item invItem = player.inventory[i];

                if (invItem.stack > 0 && invItem.pick > 0 && (item == null || invItem.pick > item.pick))
                {
                    item = invItem;
                }
            }

            return item;
        }
    }
}