using Fargowiltas.Content.Buffs;
using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    public class CrabSizedGlasses : ModItem
    {

        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ShadowOrb);
            Item.rare = ItemRarityID.Green;
            Item.width = 20;
            Item.height = 40;
            Item.shoot = ModContent.ProjectileType<CoolCrab>();
            Item.buffType = ModContent.BuffType<CoolCrabBuff>();
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }

        public override void UseStyle(Player player, Rectangle
            heldItemFrame)
        {
            base.UseStyle(player, heldItemFrame);

            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600);
            }
        }
    }
}