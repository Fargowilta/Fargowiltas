using Fargowiltas.Common.Configs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Projectiles
{
    public class FargoGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        private bool firstTick = true;
        public bool lowRender;

        public static HashSet<int> CannotDestroyTileTypes = new HashSet<int>();
        public static HashSet<int> CannotDestroyWallTypes = new HashSet<int>();
        public static HashSet<Rectangle> CannotDestroyRectangle = new HashSet<Rectangle>();

        public override void SetDefaults(Projectile projectile)
        {
            //if (projectile.CountsAsClass(DamageClass.Summon) || projectile.minion || projectile.sentry || projectile.minionSlots > 0 || ProjectileID.Sets.MinionShot[projectile.type] || ProjectileID.Sets.SentryShot[projectile.type])
            //{
            //    if (!ProjectileID.Sets.IsAWhip[projectile.type])
            //        lowRender = true;
            //}

            //switch (projectile.type)
            //{
            //    case ProjectileID.FlowerPetal:
            //    case ProjectileID.HallowStar:
            //    case ProjectileID.RainbowFront:
            //    case ProjectileID.RainbowBack:
            //        lowRender = true;
            //        break;

            //    default:
            //        break;
            //}

            if (projectile.friendly)
                lowRender = true;
        }

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.bobber && projectile.owner == Main.myPlayer && GetInstance<FargoServerConfig>().ExtraLures && source is EntitySource_ItemUse)
            {
                int split = 1;
                int itemType = Main.player[Main.myPlayer].HeldItem.type;

                //check held item type for fishing rods instead of projectile, since bobber projectiles are overridden by the Bobber items
                switch (itemType)
                {
                    case ItemID.GoldenFishingRod:
                    case ItemID.HotlineFishingHook:
                        split = 5;
                        break;
                    case ItemID.SittingDucksFishingRod:
                    case ItemID.MechanicsRod:
                        split = 3;
                        break;
                    case ItemID.ScarabFishingRod:
                    case ItemID.FiberglassFishingPole:
                    case ItemID.BloodFishingRod:
                    case ItemID.Fleshcatcher:
                    case ItemID.FisherofSouls:
                        split = 2;
                        break;
                    default:
                        split = 1;
                        break;
                }


                if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                    split++;

                if (split > 1)
                    SplitProj(projectile, split);
            }
        }

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.FlyingPiggyBank && GetInstance<FargoServerConfig>().StalkerMoneyTrough)
            {
                Player player = Main.player[projectile.owner];
                float dist = Vector2.Distance(projectile.Center, player.Center);

                if (dist > 3000)
                {
                    projectile.Center = player.Top;
                }
                else if (projectile.Center != player.Center)
                {
                    Vector2 velocity = (player.Center + projectile.DirectionFrom(player.Center) * 3 * 16 - projectile.Center) / (dist < 3f * 16 ? 30f : 60f);
                    projectile.position += velocity;
                }

                if (projectile.timeLeft < 2 && projectile.timeLeft > 0)
                    projectile.timeLeft = 2;
            }

            if (firstTick)
            {
                firstTick = false;

                if (projectile.owner != Main.myPlayer && !projectile.hostile && !projectile.trap && projectile.friendly)
                    lowRender = true;
            }

            if (projectile.bobber && projectile.lavaWet && GetInstance<FargoServerConfig>().FasterLavaFishing)
            {
                if (projectile.ai[0] == 0 && projectile.ai[1] == 0 && projectile.localAI[1] < 600)
                    projectile.localAI[1]++;
            }

            return true;
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (projectile.type == ProjectileID.FlyingPiggyBank && GetInstance<FargoServerConfig>().StalkerMoneyTrough)
            {
                //functionally, this makes money trough toggle the piggy bank on/off
                foreach (Projectile p in Main.projectile.Where(p => p.active && p.type == projectile.type && p.owner == projectile.owner))
                    p.timeLeft = 0;
            }
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;

            double spread = 0.3 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;
                    split = NewProjectileDirectSafe(projectile.GetSource_FromThis(), projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                    {
                        split.friendly = true;
                        split.GetGlobalProjectile<FargoGlobalProjectile>().firstTick = false;
                    }
                }
            }

            if (number % 2 == 0)
            {
                projectile.active = false;
            }
        }

        public static Projectile NewProjectileDirectSafe(IEntitySource source, Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < Main.maxProjectiles) ? Main.projectile[p] : null;
        }
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            float opacityConfig = GetInstance<FargoClientConfig>().TransparentFriendlyProjectiles;
            if (lowRender && !projectile.hostile && opacityConfig < 1)
            {
                Color? color = projectile.ModProjectile?.GetAlpha(lightColor);
                if (color != null)
                {
                    return color.Value * GetInstance<FargoClientConfig>().TransparentFriendlyProjectiles;
                }
                lightColor *= GetInstance<FargoClientConfig>().TransparentFriendlyProjectiles;
            }

            return base.GetAlpha(projectile, lightColor);
        }
        public static bool OkayToDestroyTile(Tile tile)
        {
            if (tile == null)
            {
                return false;
            }
            bool noDungeon = !NPC.downedBoss3 &&
                (tile.TileType == TileID.BlueDungeonBrick || tile.TileType == TileID.GreenDungeonBrick || tile.TileType == TileID.PinkDungeonBrick
                || tile.WallType == WallID.BlueDungeonSlabUnsafe || tile.WallType == WallID.BlueDungeonTileUnsafe || tile.WallType == WallID.BlueDungeonUnsafe
                || tile.WallType == WallID.GreenDungeonSlabUnsafe || tile.WallType == WallID.GreenDungeonTileUnsafe || tile.WallType == WallID.GreenDungeonUnsafe
                || tile.WallType == WallID.PinkDungeonSlabUnsafe || tile.WallType == WallID.PinkDungeonTileUnsafe || tile.WallType == WallID.PinkDungeonUnsafe
            );
            bool noHMOre = (tile.TileType == TileID.Cobalt || tile.TileType == TileID.Palladium || tile.TileType == TileID.Mythril || tile.TileType == TileID.Orichalcum || tile.TileType == TileID.Adamantite || tile.TileType == TileID.Titanium) && !NPC.downedMechBossAny;
            bool noChloro = tile.TileType == TileID.Chlorophyte && !(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3);
            bool noLihzahrd = (tile.TileType == TileID.LihzahrdBrick || tile.WallType == WallID.LihzahrdBrickUnsafe) && !NPC.downedGolemBoss;
            bool noAbyss = false;

            if (ModLoader.TryGetMod("CalamityMod", out Mod calamity))
            {
                calamity.TryFind("AbyssGravel", out ModTile gravel);
                calamity.TryFind("Voidstone", out ModTile voidstone);
                noAbyss = tile.TileType == gravel.Type || tile.TileType == voidstone.Type;
            }
            
            if (noDungeon || noHMOre || noChloro || noLihzahrd || noAbyss || TileBelongsToMagicStorage(tile) ||
                CannotDestroyTileTypes.Contains(tile.TileType) ||
                CannotDestroyWallTypes.Contains(tile.WallType))
                return false;

            return true;
        }
        public static bool OkayToDestroyTileAt(int x, int y) // Testing for blocks that should not be destroyed
        {
            Tile tile = Main.tile[x, y];
            if (tile == null)
            {
                return false;
            }
            foreach (Rectangle rect in CannotDestroyRectangle)
            {
                if (rect.Contains(x * 16, y * 16))
                {
                    return false;
                }
            }
            //TODO: look at this again. would be great if we could check against protected structures
            /*
            if (!GenVars.structures.CanPlace(new(x, y, 1, 1), 0))
            {
                return false;
            }
            */
            return OkayToDestroyTile(tile);
        }

        public static bool TileIsLiterallyAir(Tile tile)
        {
            return tile.TileType == 0 && tile.WallType == 0 && tile.LiquidAmount == 0 /*&& tile.sTileHeader == 0 && tile.bTileHeader == 0 && tile.bTileHeader2 == 0 && tile.bTileHeader3 == 0*/ && tile.TileFrameX == 0 && tile.TileFrameY == 0;
        }

        public static bool TileBelongsToMagicStorage(Tile tile)
        {
            return Fargowiltas.ModLoaded["MagicStorage"] && TileLoader.GetTile(tile.TileType)?.Mod == ModLoader.GetMod("MagicStorage");
        }
    }
}