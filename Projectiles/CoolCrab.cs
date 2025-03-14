using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class CoolCrab : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Turtle);
            AIType = ProjectileID.Turtle;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.turtle = false; // Relic from AIType
            return true;
        }
        public int FrameCounter = 0;
        public int Frame = 0;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            
            var modPlayer = player.GetModPlayer<FargoPlayer>();
            if (player.dead)
            {
                modPlayer.CoolCrab = false;
            }
            if (modPlayer.CoolCrab)
            {
                Projectile.timeLeft = 2;
            }
            int startFrame;
            int endFrame;
            int animFrames = 5;

            if (Projectile.ai[0] == 1)
            {
                startFrame = endFrame = Main.projFrames[Type] - 1;
            }
            else
            {
                startFrame = 0;
                endFrame = Main.projFrames[Type] - 2;
                if (Projectile.velocity.X == 0)
                    endFrame = 0;
            }
            if (Frame < startFrame || Frame > endFrame)
            {
                Frame = startFrame;
            }
            if (++FrameCounter > animFrames)
            {
                FrameCounter = 0;
                if (++Frame > endFrame)
                    Frame = startFrame;
            }

            Projectile.direction = Projectile.spriteDirection = MathF.Sign(player.Center.X - Projectile.Center.X);

            int num113 = Dust.NewDust(new Vector2(Projectile.Center.X - Projectile.direction * (Projectile.width / 2), Projectile.Center.Y + Projectile.height / 2), Projectile.width, 6, DustID.Snow, 0f, 0f, 0, default, 1f);
            Main.dust[num113].noGravity = true;
            Main.dust[num113].velocity *= 0.3f;
            Main.dust[num113].noLight = true;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;

            int num156 = texture2D13.Height / 8; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Vector2 drawOffset = Vector2.UnitY * 0 * Projectile.scale;

            SpriteEffects effects = Projectile.spriteDirection > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Main.EntitySpriteDraw(texture2D13, Projectile.Center + drawOffset - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, effects, 0);
            return false;
        }
    }
}