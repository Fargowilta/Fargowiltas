using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class PortableSundial : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Portable Sundial");
            Tooltip.SetDefault("Left click to instantly switch from day to night" +
                "\nRight click to activate the Enchanted Sundial effect" +
                "\nThis will also reset travelling merchant's shops");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.LightRed;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.mana = 50;
            item.UseSound = SoundID.Item4;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player) => !Main.fastForwardTime;

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                Main.sundialCooldown = 0;

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(51, number: Main.myPlayer, number2: 3f);

                    return true;
                }

                Main.fastForwardTime = true;

                NetMessage.SendData(MessageID.WorldData);
                SoundEngine.PlaySound(SoundID.Item4, player.position);
            }
            else
            {
                Main.dayTime = !Main.dayTime;
                Main.time = 0;

                Chest.SetupTravelShop();

                //change moon phases when switching to night
                if (!Main.dayTime && ++Main.moonPhase > 7)
                {
                    Main.moonPhase = 0;
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Sundial)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient(ItemID.SoulofFlight, 10)                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}