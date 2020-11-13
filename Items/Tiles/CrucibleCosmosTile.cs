using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Items.Tiles
{
    public class CrucibleCosmosTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Crucible of the Cosmos");
            AddMapEntry(new Color(200, 200, 200), name);
            // TODO: Uncomment when tML adds this back
            // disableSmartCursor = true;

            //counts as
            adjTiles = new int[] { TileID.WorkBenches, TileID.HeavyWorkBench, TileID.Furnaces, TileID.Anvils, TileID.Bottles, TileID.Sawmill, TileID.Loom, TileID.Tables, TileID.Chairs, TileID.CookingPots, TileID.Sinks, TileID.Kegs, TileID.Hellforge, TileID.AlchemyTable, TileID.TinkerersWorkbench, TileID.ImbuingStation, TileID.DyeVat, TileID.LivingLoom, TileID.GlassKiln, TileID.IceMachine, TileID.HoneyDispenser, TileID.SkyMill, TileID.Solidifier, TileID.BoneWelder, TileID.MythrilAnvil, TileID.AdamantiteForge, TileID.DemonAltar, TileID.Bookcases, TileID.CrystalBall, TileID.Autohammer, TileID.LunarCraftingStation, TileID.FleshCloningVat, TileID.LihzahrdFurnace, TileID.SteampunkBoiler, TileID.Blendomatic, TileID.MeatGrinder };

            if (Fargowiltas.ModLoaded("ThoriumMod"))
            {
                Array.Resize(ref adjTiles, adjTiles.Length + 3);
                adjTiles[adjTiles.Length - 1] = Fargowiltas.LoadedMods["ThoriumMod"].TileType("ThoriumAnvil");
                adjTiles[adjTiles.Length - 2] = Fargowiltas.LoadedMods["ThoriumMod"].TileType("ArcaneArmorFabricator");
                adjTiles[adjTiles.Length - 3] = Fargowiltas.LoadedMods["ThoriumMod"].TileType("SoulForge");
            }

            animationFrameHeight = 54;

            name.AddTranslation((int)GameCulture.CultureName.Chinese, "宇宙坩埚");
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

        public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<CrucibleCosmos>());

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;

            if (frameCounter >= -1) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 8;
            }
        }

        public override void NearbyEffects(int i, int j, bool closer) => Main.player[Main.myPlayer].alchemyTable = true;
    }
}