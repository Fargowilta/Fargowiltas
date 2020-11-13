using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class FakeHeartMarkDevianttProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Projectiles/FakeHeartDevianttProj";

        public override void SetStaticDefaults() => DisplayName.SetDefault("Fake Heart");

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 2;
            projectile.aiStyle = -1;
            projectile.hide = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = -3; i < 3; i++)
                {
                    Projectile.NewProjectile(projectile.Center, -projectile.velocity.RotatedBy(Math.PI / 7 * i), ModContent.ProjectileType<FakeHeart2DevianttProj>(), projectile.damage, projectile.knockBack, projectile.owner, -1, 120 + 20 * i);
                }
            }

            projectile.Kill();
        }

        public override bool? CanDamage() => false;
    }
}