using Microsoft.Xna.Framework;
using System.Security.Principal;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class ShurikenProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shuriken");
        }

        public override void SetDefaults()
        {
            Projectile.width = 11;
            Projectile.height = 11;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Default;
            Projectile.penetrate = 5;
            Projectile.aiStyle = 2;
            Projectile.timeLeft = 600;
            AIType = 48;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.timeLeft = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.timeLeft = 0;
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<Explosion>(), 0, Projectile.knockBack, Projectile.owner);

            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);
            int radius = 16;     // bigger = boomer

            Player player = Main.player[Projectile.owner];

            NetMessage.SendData(MessageID.KillProjectile, -1, -1, null, Projectile.identity, Projectile.owner);

            AchievementsHelper.CurrentlyMining = true;
            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, yPosition];


                    // Circle
                    if ((x * x + y * y) <= radius)
                    {
                        if (Projectile.owner == Main.myPlayer)
                        {
                            if (tile.IsActuated || FargoGlobalProjectile.TileIsLiterallyAir(tile) || FargoGlobalProjectile.TileBelongsToMagicStorage(tile))
                                continue;

                            if (player.HasEnoughPickPowerToHurtTile(xPosition, yPosition) && WorldGen.CanKillTile(xPosition, yPosition))
                            {
                                WorldGen.KillTile(xPosition, yPosition);
                                if (Main.netMode != NetmodeID.SinglePlayer)
                                {
                                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 20, xPosition, yPosition);
                                }
                            }
                        }

                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);
                    }
                }
            }
            AchievementsHelper.CurrentlyMining = false;
        }
    }
}