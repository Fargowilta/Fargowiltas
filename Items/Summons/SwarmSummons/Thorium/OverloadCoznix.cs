﻿using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.SwarmSummons.Thorium
{
    [Autoload(false)]
    public class OverloadCoznix : ModItem
    {
        private readonly Mod thorium = Fargowiltas.FargosGetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Lens 2.0");
            Tooltip.SetDefault("Summons several Fallen Beholders");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
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
            else
            {
                Fargowiltas.SwarmSpawned = 40;
            }

            for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
            {
                // TODO: Crossmod
                //int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), thorium.NPCType("FallenDeathBeholder"));
                //Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The gates of hell have opened wide!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("The gates of hell have opened wide!", 175, 75, 255);
            }

            SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(thorium, "VoidLens");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            
            recipe.Register();
        }
    }
}