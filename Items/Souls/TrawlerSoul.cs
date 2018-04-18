using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class TrawlerSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trawler Soul");
            Tooltip.SetDefault("'The fish catch themselves' \n" +
                                "Increases fishing skill substantially \n" +
                                "All fishing rods will have 10 extra lures \n" +
                                "Fishing line will never break \n" +
                                "Decreases chance of bait consumption \n" +
                                "Permanent Sonar and Crate Buffs \n" +
                                "Effects of the Frog Legs and Spore Sac \n");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 750000;
            item.rare = -12;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            (player.GetModPlayer<FargoPlayer>(mod)).fishSoul2 = true;

            player.sonarPotion = true;
            player.fishingSkill += 50;
            player.cratePotion = true;
            player.accFishingLine = true;
            player.accTackleBox = true;
            player.accFishFinder = true;

            //fishing in lava??

            //froglegs
            player.autoJump = true;
            player.jumpSpeedBoost += 2.4f;

            if (Soulcheck.GetValue("Spore Sac") == true)
            {
                //spore sac
                player.SporeSac();
                player.sporeSac = true;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe fishing = new ModRecipe(mod);

            fishing.AddIngredient(null, "AnglerEnchantment");
            fishing.AddIngredient(ItemID.AnglerTackleBag);
            fishing.AddIngredient(ItemID.MechanicsRod);
            fishing.AddIngredient(ItemID.SittingDucksFishingRod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                fishing.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AquaticSonarDevice"));
                fishing.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumFisher"));
            }

            else
            {
                fishing.AddIngredient(ItemID.GoldenFishingRod);
            }

            fishing.AddIngredient(ItemID.FrogLeg);
            fishing.AddIngredient(ItemID.BalloonHorseshoeSharkron);
            fishing.AddIngredient(ItemID.FinWings);

            fishing.AddIngredient(ItemID.Toxikarp);
            fishing.AddIngredient(ItemID.Bladetongue);
            fishing.AddIngredient(ItemID.CrystalSerpent);
            fishing.AddIngredient(ItemID.ObsidianSwordfish);

            fishing.AddIngredient(ItemID.SporeSac);

            fishing.AddTile(null, "CrucibleCosmosSheet");
            fishing.SetResult(this);
            fishing.AddRecipe();
        }
    }
}