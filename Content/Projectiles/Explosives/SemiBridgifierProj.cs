﻿using Fargowiltas.Content.Items.Tiles;
using Terraria.ModLoader;

namespace Fargowiltas.Content.Projectiles.Explosives
{
    public class SemiBridgifierProj : OmniBridgifierProj
    {
        protected override int TileHeight => 3;
        protected override int Placeable => ModContent.TileType<SemistationSheet>();
        protected override bool Replaceable(int TileType) => TileType == Placeable;
    }
}