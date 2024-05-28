﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Fargowiltas.Items.Tiles
{
    public class MutantToiletSheet : ModTile
    {
        public const int NextStyleHeight = 40; // Calculated by adding all CoordinateHeights + CoordinatePaddingFix.Y applied to all of them + 2

        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSatOnForNPCs[Type] = true; // Facilitates calling ModifySittingTargetInfo for NPCs
            TileID.Sets.CanBeSatOnForPlayers[Type] = true; // Facilitates calling ModifySittingTargetInfo for Players
            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

            DustType = DustID.LunarOre;
            AdjTiles = [TileID.Chairs, TileID.Toilets]; // Condider adding TileID.Chairs to AdjTiles to mirror "(regular) Toilet" and "Golden Toilet" behavior for crafting stations

            // Names
            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Toilet"));

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            // The following 3 lines are needed if you decide to add more styles and stack them vertically
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1); // Facing right will use the second texture style
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance); // Avoid being able to trigger it from long range
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            // It is very important to know that this is called on both players and NPCs, so do not use Main.LocalPlayer for example, use info.restingEntity
            Tile tile = Framing.GetTileSafely(i, j);

            //info.directionOffset = info.restingEntity is Player ? 6 : 2; // Default to 6 for players, 2 for NPCs
            //info.visualOffset = Vector2.Zero; // Defaults to (0,0)

            info.TargetDirection = -1;

            if (tile.TileFrameX != 0)
            {
                info.TargetDirection = 1; // Facing right if sat down on the right alternate (added through addAlternate in SetStaticDefaults earlier)
            }

            // The anchor represents the bottom-most tile of the chair. This is used to align the entity hitbox
            // Since i and j may be from any coordinate of the chair, we need to adjust the anchor based on that
            info.AnchorTilePosition.X = i; // Our chair is only 1 wide, so nothing special required
            info.AnchorTilePosition.Y = j;

            if (tile.TileFrameY % NextStyleHeight == 0)
            {
                info.AnchorTilePosition.Y++; // Here, since our chair is only 2 tiles high, we can just check if the tile is the top-most one, then move it 1 down
            }

            if (info.RestingEntity is Player player)
            {
                /*player.AddBuff(BuffID.SoulDrain, 2);
                if (Main.rand.NextBool(20))
                {
                    int d = Dust.NewDust(player.position, player.width, player.height, DustID.Vortex, 0f, 0f, 200, default(Color), 0.5f);
                    Main.dust[d].noGravity = true;
                    Main.dust[d].velocity *= 0.75f;
                    Main.dust[d].fadeIn = 1.3f;
                    Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector.Normalize();
                    vector *= Main.rand.Next(50, 100) * 0.04f;
                    Main.dust[d].velocity = vector;
                    vector.Normalize();
                    vector *= 34f;
                    Main.dust[d].position = player.Center - vector;
                }*/

                if (Fargowiltas.ModLoaded["FargowiltasSouls"] && ModContent.TryFind("FargowiltasSouls/MutantPresenceBuff", out ModBuff modBuff))
                {
                    player.AddBuff(modBuff.Type, 2);
                }
            }
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            { // Avoid being able to trigger it from long range
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            { // Match condition in RightClick. Interaction should only show if clicking it does something
                return;
            }

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<MutantToilet>();

            if (Main.tile[i, j].TileFrameX / 18 < 1)
            {
                player.cursorItemIconReversed = true;
            }
        }

        public override void HitWire(int i, int j)
        {
            // Spawn the toilet effect here when triggered by a signal
            Tile tile = Main.tile[i, j];

            int spawnX = i;
            int spawnY = j - (tile.TileFrameY % NextStyleHeight) / 18;

            Wiring.SkipWire(spawnX, spawnY);
            Wiring.SkipWire(spawnX, spawnY + 1);

            if (Wiring.CheckMech(spawnX, spawnY, 60))
            {
                Projectile.NewProjectile(Wiring.GetProjectileSource(spawnX, spawnY), spawnX * 16 + 8, spawnY * 16 + 12, 0f, 0f, ProjectileID.ToiletEffect, 0, 0f, Main.myPlayer);
            }

            if (Main.rand.NextBool(10)
                && Fargowiltas.ModLoaded["FargowiltasSouls"]
                && ModContent.TryFind("FargowiltasSouls/MutantBoss", out ModNPC modNPC)
                && Main.netMode != NetmodeID.MultiplayerClient)
            {
                int p = Player.FindClosest(new Vector2(spawnX * 16 + 8, spawnY * 16 + 12), 0, 0);
                if (p != -1 && !NPC.AnyNPCs(modNPC.Type))
                    NPC.SpawnOnPlayer(p, modNPC.Type);
            }
        }
    }
}