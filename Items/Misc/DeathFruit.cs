using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class DeathFruit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Fruit");
            Tooltip.SetDefault("Permanently decreases maximum life by 20" +
                "\nEffects may not be reversible for characters that have used modded life-increasing items");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 99;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.useAnimation = 30;
            item.useTime = 30;
            item.consumable = true;
            item.UseSound = SoundID.Item27;
        }

        public override bool ConsumeItem(Player player)
        {
            if (player.statLifeMax <= 20)
            {
                return false;
            }

            return true;
        }

        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.statLifeMax > 20 && player.itemTime == 0)
            {
                player.statLifeMax -= 20;
                player.statLifeMax2 -= 20;
                player.statLife -= 20;

                if (Main.myPlayer == player.whoAmI)
                {
                    player.HealEffect(-20, true);
                }
            }

            return true;
        }
    }
}