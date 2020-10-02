﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.AA
{
    [Autoload(false)]
    public class Clawbomination : ModItem
    {
        private readonly Mod AAMod = Fargowiltas.FargosGetMod("AAMod");

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons several Grips of Chaos");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.SwarmActive = true;
            Fargowiltas.SwarmTotal = 10 * player.inventory[player.selectedItem].stack;
            Fargowiltas.SwarmKills = 0;

            // Kill whole stack
            player.inventory[player.selectedItem].stack = 0;

            if (Fargowiltas.SwarmTotal <= 20)
            {
                Fargowiltas.SwarmSpawned = Fargowiltas.SwarmTotal;
            }
            else if (Fargowiltas.SwarmTotal <= 100)
            {
                Fargowiltas.SwarmSpawned = 20;
            }
            else if (Fargowiltas.SwarmTotal != 1000)
            {
                Fargowiltas.SwarmSpawned = 50;
            }
            else
            {
                Fargowiltas.SwarmSpawned = 60;
            }

            Fargowiltas.SwarmTotal *= 2;

            for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
            {
                // TODO: AA Crossmod
                //int boss = NPC.NewNPC((int)player.position.X + 1000, (int)player.position.Y + Main.rand.Next(-1000, -400), AAMod.NPCType("GripOfChaosBlue"));
                //Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
                //int grip = NPC.NewNPC((int)player.position.X - 1000, (int)player.position.Y + Main.rand.Next(-1000, -400), AAMod.NPCType("GripOfChaosRed"));
                //Main.npc[grip].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("You'd better get a grip!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("You'd better get a grip!", 175, 75, 255);
            }

            SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(AAMod, "InterestingClaw")
            .AddIngredient(null, "Overloader")
            .AddTile(TileID.DemonAltar)
            .Register();

            CreateRecipe()
            .AddIngredient(AAMod, "CuriousClaw")
            .AddIngredient(null, "Overloader")
            .AddTile(TileID.DemonAltar)
            .Register();
        }
    }
}