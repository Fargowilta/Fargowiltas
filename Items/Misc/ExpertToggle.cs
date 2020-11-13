using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class ExpertToggle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Expert's Token");
            Tooltip.SetDefault("Toggles Expert mode");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.buyPrice(1);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++) //cant use while boss alive
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return false;
                }
            }

            return true;
        }

        public override bool UseItem(Player player)
        {
            FieldInfo currentGameModeInfoField = typeof(Main).Assembly.GetType("Terraria.Main").GetField("_currentGameModeInfo", BindingFlags.Static | BindingFlags.NonPublic);
            GameModeData currentGameModeInfo = (GameModeData)currentGameModeInfoField.GetValue(null);
            currentGameModeInfo = currentGameModeInfo == GameModeData.ExpertMode ? GameModeData.NormalMode : GameModeData.ExpertMode;
            currentGameModeInfoField.SetValue(null, currentGameModeInfo);
            // Seems to work. - Stevie

            string text = Main.expertMode ? "Expert mode is now enabled!" : "Expert mode is now disabled!";

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
                NetMessage.SendData(MessageID.WorldData); //sync world
            }

            SoundEngine.PlaySound(15, player.Center, 0);

            return true;
        }
    }
}