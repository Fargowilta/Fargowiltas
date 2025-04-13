using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.DataStructures;

namespace Fargowiltas.Content.Items.Tiles
{
    public class CrucibleCosmosSheet : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 4;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Crucible of the Cosmos");
            AddMapEntry(new Color(200, 200, 200), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            //counts as
            AdjTiles = [TileID.WorkBenches, TileID.HeavyWorkBench, TileID.Furnaces,  TileID.Anvils,  TileID.Bottles, TileID.Sawmill, TileID.Loom, TileID.Tables, TileID.Chairs, TileID.CookingPots, TileID.Sinks, TileID.Kegs, TileID.Hellforge, TileID.AlchemyTable, TileID.TinkerersWorkbench, TileID.ImbuingStation, TileID.DyeVat, TileID.LivingLoom, TileID.GlassKiln, TileID.IceMachine, TileID.HoneyDispenser, TileID.SkyMill, TileID.Solidifier, TileID.BoneWelder, TileID.MythrilAnvil, TileID.AdamantiteForge, TileID.DemonAltar, TileID.Bookcases, TileID.CrystalBall, TileID.Autohammer,  TileID.LunarCraftingStation, TileID.LesionStation, TileID.FleshCloningVat, TileID.LihzahrdFurnace, TileID.SteampunkBoiler, TileID.Blendomatic, TileID.MeatGrinder, TileID.Tombstones, ModContent.TileType<GoldenDippingVatSheet>()];

            TileID.Sets.CountsAsHoneySource[Type] = true;
            TileID.Sets.CountsAsLavaSource[Type] = true;
            TileID.Sets.CountsAsWaterSource[Type] = true;

            //if (ModLoader.GetMod("ThoriumMod") != null)
            //{
            //    Array.Resize(ref AdjTiles, AdjTiles.Length + 3);
            //    AdjTiles[AdjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil");
            //    AdjTiles[AdjTiles.Length - 2] = ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator");
            //    AdjTiles[AdjTiles.Length - 3] = ModLoader.GetMod("ThoriumMod").TileType("SoulForge");
            //}

            AnimationFrameHeight = 54;
            
            //name.AddTranslation(GameCulture.Chinese, "宇宙坩埚");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        /*
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<CrucibleCosmos>());
        }
        */
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 5) //replace with duration of frame in ticks
            {
                frameCounter = 0;
                frame++;
                frame %= 8;
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.LocalPlayer.Distance(new Vector2(i * 16 + 8, j * 16 + 8)) < 16 * 5)
            {
                Main.LocalPlayer.GetModPlayer<FargoPlayer>().ElementalAssemblerNearby = 6;
            }
        }
    }
}