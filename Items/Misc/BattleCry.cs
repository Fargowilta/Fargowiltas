using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class BattleCry : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Battle Cry");
            /* Tooltip.SetDefault("Left click to toggle 10x increased spawn rates" +
                               "\nRight click to toggle 10x decreased spawn rates"); */
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Pink;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
        }

        public override bool AltFunctionUse(Player player) => true;

        public static void GenerateText(bool isBattle, Player player, bool cry)
        {
            string cryToggled = Language.GetTextValue($"Mods.Fargowiltas.Items.BattleCry.{(isBattle ? "Battle" : "Calming")}");
            string toggle = Language.GetTextValue($"Mods.Fargowiltas.Items.BattleCry.{(cry? "Activated" : "Deactivated")}");
            string punctuation = Language.GetTextValue($"Mods.Fargowiltas.MessageInfo.Common.{(isBattle ? "Exclamation" : "Period")}");

            string text = Language.GetTextValue("Mods.Fargowiltas.Items.BattleCry.CryText", cryToggled, toggle, player.name, punctuation);
            Color color = isBattle ? new Color(255, 0, 0) : new Color(0, 255, 255);

            FargoUtils.PrintText(text, color);
        }

        public static void SyncCry(Player player)
        {
            if (player.whoAmI == Main.myPlayer && Main.netMode == NetmodeID.MultiplayerClient)
            {
                FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

                ModPacket packet = modPlayer.Mod.GetPacket();
                packet.Write((byte)8);
                packet.Write(player.whoAmI);
                packet.Write(modPlayer.BattleCry);
                packet.Write(modPlayer.CalmingCry);
                packet.Send();
            }
        }

        void ToggleCry(bool isBattle, Player player, ref bool cry)
        {
            cry = !cry;

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                GenerateText(isBattle, player, cry);
            }
            else if (Main.netMode == NetmodeID.MultiplayerClient && player.whoAmI == Main.myPlayer)
            {
                var packet = Mod.GetPacket();
                packet.Write((byte)7);
                packet.Write(isBattle);
                packet.Write(player.whoAmI);
                packet.Write(cry);
                packet.Send();

                SyncCry(player);
            }
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                FargoPlayer modPlayer = player.GetFargoPlayer();
                if (player.altFunctionUse == 2)
                {
                    if (modPlayer.BattleCry)
                        ToggleCry(true, player, ref modPlayer.BattleCry);

                    ToggleCry(false, player, ref modPlayer.CalmingCry);
                }
                else
                {
                    if (modPlayer.CalmingCry)
                        ToggleCry(false, player, ref modPlayer.CalmingCry);

                    ToggleCry(true, player, ref modPlayer.BattleCry);
                }
            }

            if (!Main.dedServ)
                SoundEngine.PlaySound(new SoundStyle("Fargowiltas/Assets/Sounds/Horn"), player.Center);

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion, 15)
                .AddIngredient(ItemID.WaterCandle, 5)
                .AddIngredient(ItemID.CalmingPotion, 15)
                .AddIngredient(ItemID.PeaceCandle, 5)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}