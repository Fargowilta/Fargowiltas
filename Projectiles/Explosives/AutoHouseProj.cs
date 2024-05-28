using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class AutoHouseProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.timeLeft = 1;
        }

        public static void PlaceHouse(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);
            Tile tile = Main.tile[xPosition, yPosition];

            // Testing for blocks that should not be destroyed
            if (!FargoGlobalProjectile.OkayToDestroyTileAt(xPosition, yPosition, true))
                return;

            int wallType = WallID.Wood;
            int tileType = TileID.WoodBlock;
            int platformStyle = 0;

            if (player.ZoneDesert && !player.ZoneBeach)
            {
                wallType = WallID.Cactus;
                tileType = TileID.CactusBlock;
                platformStyle = 25;
            }
            else if (player.ZoneSnow)
            {
                wallType = WallID.BorealWood;
                tileType = TileID.BorealWood;
                platformStyle = 19;
            }
            else if (player.ZoneJungle)
            {
                wallType = WallID.RichMaogany;
                tileType = TileID.RichMahogany;
                platformStyle = 2;
            }
            else if (player.ZoneCorrupt)
            {
                wallType = WallID.Ebonwood;
                tileType = TileID.Ebonwood;
                platformStyle = 1;
            }
            else if (player.ZoneCrimson)
            {
                wallType = WallID.Shadewood;
                tileType = TileID.Shadewood;
                platformStyle = 5;
            }
            else if (player.ZoneBeach)
            {
                wallType = WallID.PalmWood;
                tileType = TileID.PalmWood;
                platformStyle = 17;
            }
            else if (player.ZoneHallow)
            {
                wallType = WallID.Pearlwood;
                tileType = TileID.Pearlwood;
                platformStyle = 3;
            }
            else if (player.ZoneGlowshroom)
            {
                wallType = WallID.Mushroom;
                tileType = TileID.MushroomBlock;
                platformStyle = 18;
            }
            else if (player.ZoneSkyHeight)
            {
                wallType = WallID.DiscWall;
                tileType = TileID.Sunplate;
                platformStyle = 22;
            }
            else if (player.ZoneUnderworldHeight)
            {
                wallType = WallID.ObsidianBrick;
                tileType = TileID.ObsidianBrick;
                platformStyle = 13;
            }

            if (x == 10 * side || x == 1 * side)
            {
                //dont act if the right tile already above (but DO replace a corner platform)
                if (y == -5 && tile.TileType == tileType)
                    return;

                //dont act on correct block above/below door, destroying them will break it
                if ((y == -4 || y == 0) && tile.TileType == tileType)
                    return;
                
                if ((y == -1 || y == -2 || y == -3) && (tile.TileType == TileID.ClosedDoor || tile.TileType == TileID.OpenDoor))
                    return;
            }
            else //for blocks besides those on the left/right edges where doors are placed, its okay to have platform as floor
            {
                //dont act if the right blocks already above
                if (y == -5 && (tile.TileType == TileID.Platforms || tile.TileType == tileType))
                    return;

                if (y == 0 && (tile.TileType == TileID.Platforms || tile.TileType == tileType))
                    return;
            }

            //doing it this way so the code still runs to place bg walls behind open door
            if (!((x == 9 * side || x == 2 * side) && (y == -1 || y == -2 || y == -3) && tile.TileType == TileID.OpenDoor))
                FargoGlobalTile.ClearEverything(xPosition, yPosition);

            // Spawn walls
            if (y != -5 && y != 0 && x != (10 * side) && x != (1 * side))
            {
                WorldGen.PlaceWall(xPosition, yPosition, wallType);
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }

            //platforms on top
            if (y == -5 && Math.Abs(x) >= 3 && Math.Abs(x) <= 5)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms, style: platformStyle);
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Platforms, platformStyle);
            }
            // Spawn border
            else if ((y == -5) || (y == 0) || (x == (10 * side)) || (x == (1 * side) && y == -4))
            {
                WorldGen.PlaceTile(xPosition, yPosition, tileType);
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }
        }

        public static void PlaceFurniture(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            Tile tile = Main.tile[xPosition, yPosition];
            // Testing for blocks that should not be destroyed
            if (!FargoGlobalProjectile.OkayToDestroyTileAt(xPosition, yPosition, true))
                return;

            if (y == -1)
            {
                if (Math.Abs(x) == 1)
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 4;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 1;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 10;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 29;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 6;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 9;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 19;
                    }

                    WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor, style: placeStyle);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition - 2, 1, 3);
                }

                if (x == (5 * side))
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 6;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 11;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 29;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 4;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 9;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 10;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 16;
                    }

                    WorldGen.PlaceObject(xPosition, yPosition, TileID.Chairs, direction: side, style: placeStyle);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Chairs, placeStyle);
                }

                if (x == (7 * side))
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 28;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 1;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 8;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 26;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 27;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 7;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 13;
                    }

                    WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables, style: placeStyle);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Tables, placeStyle);
                }
            }

            if (x == (7 * side) && y == -4)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches, style: 5);
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Torches);
            }
        }

        public static void UpdateWall(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            WorldGen.SquareWallFrame(xPosition, yPosition);
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);
            Player player = Main.player[Projectile.owner];

            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            if (player.Center.X < position.X)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 11; x > -1; x--)
                    {
                        if (i != 2 && (x == 11 || x == 0))
                            continue;

                        for (int y = -6; y <= 1; y++)
                        {
                            if (i != 2 && (y == -6 || y == 1))
                                continue;

                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, 1, player);
                            }
                            else if (i == 1)
                            {
                                PlaceFurniture(x, y, position, 1, player);
                            }
                            else
                            {
                                UpdateWall(x, y, position, 1, player);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int x = -11; x < 1; x++)
                    {
                        if (i != 2 && (x == -11 || x == 0))
                            continue;

                        for (int y = -6; y <= 1; y++)
                        {
                            if (i != 2 && (y == -6 || y == 1))
                                continue;

                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, -1, player);
                            }
                            else if (i == 1)
                            {
                                PlaceFurniture(x, y, position, -1, player);
                            }
                        }
                    }
                }
            }
        }
    }
}