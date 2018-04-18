using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class SlingersEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slinger's Essence");
            Tooltip.SetDefault("'This is only the beginning..' \n18% increased throwing damage \n5% increased throwing critical chance \n5% increased throwing velocity");
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

            player.thrownVelocity += 0.05f;
            player.thrownDamage += 0.18f;
            player.thrownCrit += 5;
        }


        public override void AddRecipes()
        {
            ModRecipe throw1 = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //both
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TopazGauntlet"));
                    throw1.AddIngredient(null, "FruitcakeChakramThrown");
                    throw1.AddIngredient(null, "BloodyMacheteThrown");
                    throw1.AddIngredient(null, "IceBoomerangThrown");
                    throw1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Crystalline"));
                    throw1.AddIngredient(ItemID.MolotovCocktail, 99);
                    throw1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Mycoroot"));
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StarfishSlicer"), 300);
                    throw1.AddIngredient(null, "ThornChakramThrown");
                    throw1.AddIngredient(ItemID.BoneGlove);
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("ChampionsGodHand"));
                    throw1.AddIngredient(null, "FlamarangThrown");
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("GaussKnife"));
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("NinjaEmblem"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TopazGauntlet"));
                    throw1.AddIngredient(null, "FruitcakeChakramThrown");
                    throw1.AddIngredient(null, "BloodyMacheteThrown");
                    throw1.AddIngredient(null, "IceBoomerangThrown");
                    throw1.AddIngredient(ItemID.MolotovCocktail, 99);
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SpikeBomb"), 200);
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StarfishSlicer"), 300);
                    throw1.AddIngredient(null, "ThornChakramThrown");
                    throw1.AddIngredient(ItemID.Beenade, 99);
                    throw1.AddIngredient(ItemID.BoneGlove);
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("ChampionsGodHand"));
                    throw1.AddIngredient(null, "FlamarangThrown");
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("GaussKnife"));
                    throw1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("NinjaEmblem"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    throw1.AddIngredient(null, "WoodenBoomerangThrown");
                    throw1.AddIngredient(null, "FruitcakeChakramThrown");
                    throw1.AddIngredient(null, "BloodyMacheteThrown");
                    throw1.AddIngredient(null, "IceBoomerangThrown");
                    throw1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Crystalline"));
                    throw1.AddIngredient(ItemID.MolotovCocktail, 99);
                    throw1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Mycoroot"));
                    throw1.AddIngredient(ItemID.BoneJavelin, 300);
                    throw1.AddIngredient(null, "ThornChakramThrown");
                    throw1.AddIngredient(ItemID.Beenade, 99);
                    throw1.AddIngredient(ItemID.BoneGlove);
                    throw1.AddIngredient(null, "FlamarangThrown");
                }

                else
                {
                    //no others
                    throw1.AddIngredient(null, "WoodenBoomerangThrown");
                    throw1.AddIngredient(null, "FruitcakeChakramThrown");
                    throw1.AddIngredient(null, "BloodyMacheteThrown");
                    throw1.AddIngredient(null, "IceBoomerangThrown");
                    throw1.AddIngredient(ItemID.SpikyBall, 200);
                    throw1.AddIngredient(ItemID.MolotovCocktail, 99);
                    throw1.AddIngredient(ItemID.BoneJavelin, 300);
                    throw1.AddIngredient(null, "ThornChakramThrown");
                    throw1.AddIngredient(ItemID.Beenade, 99);
                    throw1.AddIngredient(ItemID.BoneGlove);
                    throw1.AddIngredient(null, "FlamarangThrown");
                }
            }

            throw1.AddTile(TileID.TinkerersWorkbench);
            throw1.SetResult(this);
            throw1.AddRecipe();
        }
    }
}