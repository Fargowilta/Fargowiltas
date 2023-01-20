using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadFrostMoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naughty Present Sack");
            Tooltip.SetDefault("Summons an Overloaded Frost Moon\nUse again to stop the event");
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
            if (FargoWorld.OverloadFrostMoon)
            {
                // cancel it
                Main.snowMoon = false;
                FargoWorld.OverloadFrostMoon = false;

                if (Main.netMode == 2)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Frost Moon fades away!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("The Frost Moon fades away!", 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode == 2)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Frost Moon is rising..."), new Color(50, 255, 130));
                }
                else
                {
                    Main.NewText("The Frost Moon is rising...", 50, 255, 130);
                }

                Main.snowMoon = true;
                Main.pumpkinMoon = false;
                Main.bloodMoon = false;
                if (Main.netMode != 1)
                {
                    NPC.waveKills = 0f;
                    NPC.waveNumber = 20;

                    if (Main.netMode == 2)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Wave: 20: Everything"), new Color(175, 75, 255));
                    }
                    else
                    {
                        Main.NewText("Wave: 20: Everything", 175, 75, 255);
                    }
                }
                else
                {
                    NetMessage.SendData(61, -1, -1, null, player.whoAmI, -5f);
                }

                FargoWorld.OverloadFrostMoon = true;
                SoundEngine.PlaySound(SoundID.Roar, player.position);
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NaughtyPresent)
                .AddIngredient(null, "Overloader", 10)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
