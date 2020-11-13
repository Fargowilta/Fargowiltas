using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class RenewalBaseProj : ModProjectile
    {
        private readonly string _name;
        private readonly int _projType;
        private readonly int _convertType;
        private readonly bool _isSupreme;

        protected RenewalBaseProj(string name, int projType, int convertType, bool isSupreme)
        {
            _name = name;
            _projType = projType;
            _convertType = convertType;
            _isSupreme = isSupreme;
        }

        public override string Texture => "Fargowiltas/Items/Renewals/" + _name;

        public override void SetStaticDefaults() => DisplayName.SetDefault(_name);

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, projectile.Center);

            int radius = 150;
            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], _projType, 0, 0, Main.myPlayer);
            }

            if (_isSupreme)
            {
                for (int x = -Main.maxTilesX; x < Main.maxTilesX; x++)
                {
                    for (int y = -Main.maxTilesY; y < Main.maxTilesY; y++)
                    {
                        WorldGen.Convert((int)(x + projectile.Center.X / 16.0f), (int)(y + projectile.Center.Y / 16.0f), _convertType, 1);
                    }
                }
            }
            else
            {
                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        // Circle
                        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                        {
                            WorldGen.Convert((int)(x + projectile.Center.X / 16.0f), (int)(y + projectile.Center.Y / 16.0f), _convertType, 1);
                        }
                    }
                }
            }
        }
    }
}