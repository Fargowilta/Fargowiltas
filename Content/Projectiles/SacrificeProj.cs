using Fargowiltas.Content.Items.Tiles;
using Fargowiltas.Content.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Fargowiltas.FargoSets;

namespace Fargowiltas.Content.Projectiles
{
    public class SacrificeProj : ModProjectile
    {
        public override string Texture => "Fargowiltas/Content/Projectiles/Explosion";
        public static float MaxTime = 60;
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = (int)MaxTime;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public int SourceItem => (int)Projectile.ai[0];
        public override bool? CanDamage()
        {
            return false;
        }
        public override void AI()
        {
            float progress = 1f - Projectile.timeLeft / MaxTime;

            Projectile.velocity = -Vector2.UnitY * MathHelper.SmoothStep(2, 0, progress);

            for (int i = 0; i < 9; i++)
            {
                float radius = ((60 * (1 - progress)) + 20) * Main.rand.NextFloat(0.2f, 1.2f);
                Vector2 dustPos = Projectile.Center + Main.rand.NextVector2CircularEdge(radius, radius);
                Vector2 dustVel = (Projectile.Center - dustPos) / 15;
                int d = Dust.NewDust(dustPos, 1, 1, DustID.Blood, dustVel.X, dustVel.Y);
                Main.dust[d].noGravity = true;
            }
        }
        public override void OnKill(int timeLeft)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            SoundEngine.PlaySound(SoundID.Shimmer1, Projectile.Center);
            if (SacrificeAltarSheet.EventSacrifice(ContentSamples.ItemsByType[SourceItem], out _, true))
            {
                // actions happen in the EventSacrifice method
            }
            else
            {
                int multiplier = 2;
                if (FargoSets.Items.SacrificeCountDefault[SourceItem] == 1) // things that can only be sacrificed once give increased output
                    multiplier = 6;
                for (int i = 0; i < multiplier; i++)
                {
                    int result = SacrificeAltarSheet.SacrificeResult(out int amount);
                    Item.NewItem(Projectile.InheritSource(Projectile), Projectile.Center, new Item(result, amount));
                }

                for (int i = 0; i < 32; i++)
                {
                    Dust.NewDust(Projectile.Center, 1, 1, DustID.Blood);
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawPosition = Projectile.Center - Main.screenPosition;
            Main.DrawItemIcon(Main.spriteBatch, ContentSamples.ItemsByType[SourceItem], drawPosition, lightColor, 120);
            return false;
        }
    }
}