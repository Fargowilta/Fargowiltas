using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using CalamityMod;

namespace Fargowiltas.Items.Souls
{
    public class OlympiansSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Olympian's Soul");
            Tooltip.SetDefault("'Strike with deadly precision'\n" +
                                "40% increased throwing damage\n" +
                                "33% chance not to consume thrown item\n" +
                                "20% increased throwing critical chance and velocity\n" +
                                "Throwing weapons will split in 3 after a short distance");
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
            (player.GetModPlayer<FargoPlayer>(mod)).throwSoul = true;

            player.thrownVelocity += 0.2f;
            player.thrownDamage += 0.4f;
            player.thrownCrit += 20;
            player.thrownCost33 = true;

        }

        public override void AddRecipes()
        {
            ModRecipe throw2 = new ModRecipe(mod);

            throw2.AddIngredient(null, "SlingersEssence");

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //thorium and calamity
                    //throw2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StatisNinjaBelt"));
                    throw2.AddIngredient(null, "BananarangThrown", 5);
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HotPot"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("VoltTomahawk"));
                    throw2.AddIngredient(null, "ShadowflameKnifeThrown");
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CryoFang"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SparkTaser"));
                    throw2.AddRecipeGroup("Fargowiltas:AnyEvilChest");
                    throw2.AddIngredient(null, "DaybreakThrown");
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumKnife"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Trefork"));
                    throw2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicKunai"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    //throw2.AddIngredient(ItemID.MasterNinjaGear);   
                    throw2.AddIngredient(null, "BananarangThrown", 5);
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HotPot"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("VoltTomahawk"));
                    throw2.AddIngredient(null, "ShadowflameKnifeThrown");
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CryoFang"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SparkTaser"));
                    throw2.AddIngredient(null, "PaladinsHammerThrown");
                    throw2.AddIngredient(null, "ToxicFlaskThrown");
                    throw2.AddRecipeGroup("Fargowiltas:AnyEvilChest");
                    throw2.AddIngredient(null, "DaybreakThrown");
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumKnife"));
                    throw2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Trefork"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    //throw2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StatisNinjaBelt"));
                    throw2.AddIngredient(null, "BananarangThrown", 5);
                    throw2.AddIngredient(null, "MagicDaggerThrown");
                    throw2.AddIngredient(null, "ShadowflameKnifeThrown");
                    throw2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Brimblade"));
                    throw2.AddIngredient(null, "LightDiscThrown", 5);
                    throw2.AddIngredient(null, "ToxicFlaskThrown");
                    throw2.AddRecipeGroup("Fargowiltas:AnyEvilChest");
                    throw2.AddIngredient(null, "PossessedHatchetThrown");
                    throw2.AddIngredient(null, "DaybreakThrown");

                    throw2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicKunai"));


                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //no others
                    //throw2.AddIngredient(ItemID.MasterNinjaGear);   
                    throw2.AddIngredient(null, "BananarangThrown", 5);
                    throw2.AddIngredient(null, "MagicDaggerThrown");
                    throw2.AddIngredient(null, "ShadowflameKnifeThrown");
                    throw2.AddIngredient(null, "LightDiscThrown", 5);
                    throw2.AddIngredient(null, "ToxicFlaskThrown");
                    throw2.AddIngredient(null, "PaladinsHammerThrown");
                    throw2.AddRecipeGroup("Fargowiltas:AnyEvilChest");
                    throw2.AddIngredient(null, "PossessedHatchetThrown");
                    throw2.AddIngredient(null, "DaybreakThrown");
                }
            }

            throw2.AddTile(null, "CrucibleCosmosSheet");
            throw2.SetResult(this);
            throw2.AddRecipe();
        }

    }
}