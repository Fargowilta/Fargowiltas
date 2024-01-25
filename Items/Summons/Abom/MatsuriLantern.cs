using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class MatsuriLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Matsuri Lantern");
            // Tooltip.SetDefault("Makes every night a Lantern Night when possible");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true; //visually indicate it as consumable
        }

        public override bool ConsumeItem(Player player) => false;

        public override bool CanUseItem(Player player) => !FargoWorld.Matsuri;

        public override bool? UseItem(Player player)
        {
            FargoWorld.Matsuri = true;
            FargoUtils.PrintLocalization("MessageInfo.StartLanternNight", new Color(175, 75, 255));
            
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Roar, player.position);

            Item.SetDefaults(ModContent.ItemType<SpentLantern>());

            return true;
        }
    }
}