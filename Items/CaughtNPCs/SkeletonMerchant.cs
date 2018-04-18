using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class SkeletonMerchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Skeleton Merchant");
            Tooltip.SetDefault("'You would not believe some of the things people throw at me... Wanna buy some of it?'");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = 1;

            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 10;

            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item44;

            item.makeNPC = NPCID.SkeletonMerchant;

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
        }

        public override string Texture
        {
            get
            {
                return "Terraria/NPC_453";
            }
        }
    }
}