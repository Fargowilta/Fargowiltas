using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
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
            DisplayName.SetDefault("Battle Cry");
            Tooltip.SetDefault("Increase spawn rates by 10x on use" +
                "\nUse it again to decrease them");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Pink;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool UseItem(Player player)
        {
            FargoPlayer modPlayer = player.GetFargoPlayer();
            modPlayer.battleCry = !modPlayer.battleCry;

            string text = "Spawn rates " + (modPlayer.battleCry ? "increased!" : "decreased!");

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
            }

            if (modPlayer.battleCry && !Main.dedServ)
            {
                // TODO: Uncomment when tML adds sound back in.
                //SoundEngine.PlaySound(Mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Horn").WithVolume(1f).WithPitchVariance(.5f), player.position);
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BattlePotion, 15)
                .AddIngredient(ItemID.WaterCandle, 12)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient(ItemID.SoulofLight, 10)                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}