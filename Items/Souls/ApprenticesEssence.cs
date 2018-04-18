using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class ApprenticesEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apprentice's Essence");
            Tooltip.SetDefault("'This is only the beginning..' \n18% increased magic damage \nIncreases your maximum mana by 40 \nReduces mana usage by 5% \nAutomatically use mana potions when needed");
            if (Fargowiltas.instance.calamityLoaded)
            {
                Tooltip.SetDefault("'This is only the beginning..' \n18% increased magic damage \nIncreases your maximum mana by 40 \nReduces mana usage by 5% \nAutomatically use mana potions when needed \nGrants the effects of the Mana Overloader");
            }
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 150000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.manaCost -= .05f;
            player.magicDamage += .18f;
            player.statManaMax2 += 40;
            player.manaFlower = true;

            //mana overloader
            if (Fargowiltas.instance.calamityLoaded)
            {
                if (player.statMana < (player.statManaMax2 * 0.15f))
                {
                    player.ghostHeal = true;
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe magic1 = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //both
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AzureGauntlet"));
                    magic1.AddIngredient(ItemID.WizardHat);
                    magic1.AddIngredient(ItemID.ManaFlower);
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ManaOverloader"));
                    magic1.AddIngredient(ItemID.SorcererEmblem);
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MagikStaffAmber"));
                    magic1.AddRecipeGroup("Fargowiltas:AnySilverStaff");
                    magic1.AddRecipeGroup("Fargowiltas:AnyGoldStaff");
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SkyGlaze"));
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PlasmaRod"));
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DetachedUFOBlaster"));
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MagicConch"));
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("GaussSpark"));
                    magic1.AddIngredient(ItemID.Flamelash);
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AzureGauntlet"));
                    magic1.AddIngredient(ItemID.WizardHat);
                    magic1.AddIngredient(ItemID.ManaFlower);
                    magic1.AddIngredient(ItemID.SorcererEmblem);
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MagikStaffAmber"));
                    magic1.AddRecipeGroup("Fargowiltas:AnySilverStaff");
                    magic1.AddRecipeGroup("Fargowiltas:AnyGoldStaff");
                    magic1.AddIngredient(ItemID.SpaceGun);
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DetachedUFOBlaster"));
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MagicConch"));
                    magic1.AddIngredient(ItemID.BeeGun);
                    magic1.AddIngredient(ItemID.BookofSkulls);
                    magic1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("GaussSpark"));
                    magic1.AddIngredient(ItemID.Flamelash);
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    magic1.AddIngredient(ItemID.WizardHat);
                    magic1.AddIngredient(ItemID.ManaFlower);
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ManaOverloader"));
                    magic1.AddIngredient(ItemID.SorcererEmblem);
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("WintersFury"));
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HarvestStaff"));
                    magic1.AddRecipeGroup("Fargowiltas:AnySilverStaff");
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CoralSpout"));
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StormSpray"));
                    magic1.AddRecipeGroup("Fargowiltas:AnyGoldStaff");
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SkyGlaze"));
                    magic1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PlasmaRod"));
                    magic1.AddIngredient(ItemID.BeeGun);
                    magic1.AddIngredient(ItemID.Flamelash);
                }

                else
                {
                    //no others
                    magic1.AddIngredient(ItemID.WizardHat);
                    magic1.AddIngredient(ItemID.ManaFlower);
                    magic1.AddIngredient(ItemID.SorcererEmblem);
                    magic1.AddIngredient(ItemID.WandofSparking);
                    magic1.AddRecipeGroup("Fargowiltas:AnySilverStaff");
                    magic1.AddRecipeGroup("Fargowiltas:AnyGoldStaff");
                    magic1.AddRecipeGroup("Fargowiltas:AnyEvilMagic");
                    magic1.AddIngredient(ItemID.AmberStaff);
                    magic1.AddIngredient(ItemID.SpaceGun);
                    magic1.AddIngredient(ItemID.WaterBolt);
                    magic1.AddIngredient(ItemID.BeeGun);
                    magic1.AddIngredient(ItemID.BookofSkulls);
                    magic1.AddIngredient(ItemID.MagicMissile);
                    magic1.AddIngredient(ItemID.Flamelash);
                }
            }

            magic1.AddTile(TileID.TinkerersWorkbench);
            magic1.SetResult(this);
            magic1.AddRecipe();
        }

    }
}