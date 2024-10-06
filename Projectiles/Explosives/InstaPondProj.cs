using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace Fargowiltas.Projectiles.Explosives
{
    public class InstaPondProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Items/Explosives/InstaPond";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 36;
            Projectile.aiStyle = 16;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;

            return base.TileCollideStyle(ref width, ref height, ref fallThrough, ref hitboxCenterFrac);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item15, Projectile.Center);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            Vector2 position = Projectile.Center;
            int width = 150;
            int height = 50;

            for (int x = -width/2; x <= width/2; x++)
            {
                for (int y = 0; y <= height; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];
                    if (tile == null)
                        continue;

                    if (!FargoGlobalProjectile.OkayToDestroyTileAt(xPosition, yPosition) || FargoGlobalProjectile.TileIsLiterallyAir(tile))
                        continue;

                    FargoGlobalTile.ClearTileAndLiquid(xPosition, yPosition);
                    if (y == height || Math.Abs(x) == width/2)
                    {
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.StoneSlab);
                    }
                    else
                    {
                        WorldGen.PlaceLiquid(xPosition, yPosition, (byte)LiquidID.Water, byte.MaxValue);
                    }
                    
                }
            }

            Main.refreshMap = true;
        }
    }
}