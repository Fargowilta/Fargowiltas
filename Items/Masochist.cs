using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items
{
    public class Masochist : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Mutant's Gift");
            Tooltip.SetDefault("'Use this to turn on/off Masochist Mode'");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Placeholder";
            }
        }

        public override bool UseItem(Player player)
        {
            FargoWorld.masochistMode = !FargoWorld.masochistMode;

            if (FargoWorld.masochistMode)
            {
                Main.NewText("Masochist Mode initiated!", 175, 75, 255);
            }
            else
            {
                Main.NewText("Masochist Mode deactivated!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}