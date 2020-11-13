using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons
{
    public class LumberJaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lumber Jaxe");
            Tooltip.SetDefault("'The former weapon of a true axe wielding hero'" +
                "\nHit enemies may drop wood when killed");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.DamageType = DamageClass.Melee;
            item.width = 40;
            item.height = 40;
            item.useTime = 30;
            item.useAnimation = 30;
            item.axe = 30;
            item.useStyle = ItemUseStyleID.Swing;
            item.knockBack = 6;
            item.value = 5000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) => target.AddBuff(ModContent.BuffType<Buffs.WoodDrop>(), 600);
    }
}