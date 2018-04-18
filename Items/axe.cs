using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items
{
    public class axe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lumber Jaxe");
            Tooltip.SetDefault("'The axe of a true axe wielding hero' \nHit enemies may drop wood when killed");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 30;
            item.useAnimation = 30;
            item.axe = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 5000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("WoodDrop"), 600);
        }

    }
}