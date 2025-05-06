using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class ForbiddenScarab : ModItem
    {
        //private static MethodInfo startSandstormMethod;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Forbidden Scarab");
            // Tooltip.SetDefault("Starts a Sandstorm");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;

			ItemID.Sets.SortingPriorityBossSpawns[Type] = 0; // Places it before any other boss summons
		}

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = Item.sellPrice(0, 0, 2);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Sandstorm.Happening;
        }

        public override bool? UseItem(Player player)
        {
            Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f; //40mph?

            //sets rain time to 12 hours
            int day = 86400;
            int hour = day / 24;
            Main.rainTime = hour * 12;
            Main.raining = true;
            Main.maxRaining = Main.cloudAlpha = 0.9f;

            Sandstorm.StartSandstorm();



            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
                Main.SyncRain();
            }

            FargoUtils.PrintLocalization("MessageInfo.StartSandStorm", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }
    }
}