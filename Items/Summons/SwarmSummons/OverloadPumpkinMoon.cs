using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadPumpkinMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Overloaded Pumpkin Moon Medallion");
            // Tooltip.SetDefault("Summons an Overloaded Pumpkin Moon\nUse again to stop the event");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = 1000;
            Item.rare = 1;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 4;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            if (FargoWorld.OverloadPumpkinMoon)
            {
                // cancel it
                Main.pumpkinMoon = false;
                FargoWorld.OverloadPumpkinMoon = false;

                if (Main.netMode == 2)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonStop"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText(Language.GetTextValue("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonStop"), 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode == 2)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonStart"), new Color(50, 255, 130));
                }
                else
                {
                    Main.NewText(Language.GetTextValue("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonStart"), 50, 255, 130);
                }

                Main.pumpkinMoon = true;
                Main.snowMoon = false;
                Main.bloodMoon = false;
                if (Main.netMode != 1)
                {
                    NPC.waveKills = 0f;
                    NPC.waveNumber = 15;

                    if (Main.netMode == 2)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonWave15"), new Color(175, 75, 255));
                    }
                    else
                    {
                        Main.NewText(Language.GetTextValue("Mods.Fargowiltas.MessageInfo.OverloadPumpkinMoonWave15"), 175, 75, 255);
                    }
                }
                else
                {
                    NetMessage.SendData(61, -1, -1, null, player.whoAmI, -4f);
                }

                FargoWorld.OverloadPumpkinMoon = true;
                SoundEngine.PlaySound(SoundID.Roar, player.position);
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PumpkinMoonMedallion)
                .AddIngredient(null, "Overloader", 10)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
