using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class GladiatorsSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker's Soul");
            Tooltip.SetDefault("'None shall live to tell the tale' \n30% increased melee damage \n25% increased melee speed \n20% increased melee crit chance \nIncreased melee knockback \nMelee attacks inflict excessive bleeding \nSword swings have a chance to cut an enemy in two \nGrants the effects of the Yoyo Bag");

            if (Fargowiltas.instance.calamityLoaded)
            {
                Tooltip.SetDefault("'None shall live to tell the tale' \n30% increased melee damage \n25% increased melee speed \n20% increased melee crit chance \nIncreased melee knockback \nGrants the effects of the Yoyo Bag and Elemental Gauntlet");
            }

        }
        public override void SetDefaults()
        {
            ;
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.defense = 5;
            item.value = 750000;
            item.rare = -12;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).meleeEffect = true;

            if (Soulcheck.GetValue("Melee Speed") == false)
            {
                player.meleeSpeed += .1f;
            }
            else
            {
                player.meleeSpeed += .25f;
            }

            player.meleeDamage += .3f;
            player.meleeCrit += 20;
            player.kbGlove = true;

            //yoyo bag
            player.counterWeight = 556 + Main.rand.Next(6);
            player.yoyoGlove = true;
            player.yoyoString = true;


            if (Fargowiltas.instance.calamityLoaded)
            {
                Gauntlet(player);
            }

        }

        public void Gauntlet(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).eGauntlet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe melee2 = new ModRecipe(mod);

            melee2.AddIngredient(null, "BarbariansEssence");
            melee2.AddIngredient(ItemID.YoyoBag);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //all 3
                        melee2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("FlamingCrystalGauntlet"));
                    }

                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ElementalGauntlet"));
                    melee2.AddIngredient(ItemID.IceSickle);
                    melee2.AddIngredient(ItemID.DD2SquireBetsySword);
                    melee2.AddIngredient(ItemID.Flairon);
                    melee2.AddIngredient(ItemID.InfluxWaver);
                    melee2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SickThrow"));
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SpatialLance"));
                    melee2.AddIngredient(ItemID.StarWrath);
                    melee2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariansKnife"));

                    if (!Fargowiltas.instance.blueMagicLoaded)
                    {
                        //thorium and calamity
                        melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MirrorBlade"));
                    }
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("DevilsDevastation"));

                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //blue and thorium
                        melee2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("FlamingCrystalGauntlet"));
                    }

                    else
                    {
                        //just thorium
                        melee2.AddIngredient(ItemID.FireGauntlet);
                    }

                    melee2.AddIngredient(ItemID.IceSickle);
                    melee2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("PrimesFury"));
                    melee2.AddIngredient(ItemID.TerraBlade);
                    melee2.AddIngredient(ItemID.DD2SquireBetsySword);
                    melee2.AddIngredient(ItemID.Flairon);
                    melee2.AddIngredient(ItemID.TheHorsemansBlade);
                    melee2.AddIngredient(ItemID.NorthPole);
                    melee2.AddIngredient(ItemID.InfluxWaver);
                    melee2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SickThrow"));
                    melee2.AddIngredient(ItemID.StarWrath);
                    melee2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariansKnife"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {

                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //calamity and blue
                        melee2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("FlamingCrystalGauntlet"));
                    }

                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ElementalGauntlet"));
                    melee2.AddIngredient(ItemID.IceSickle);

                    if (!Fargowiltas.instance.blueMagicLoaded)
                    {
                        //just calamity
                        melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("TrueTyrantYharimsUltisword"));
                    }

                    melee2.AddIngredient(ItemID.DD2SquireBetsySword);
                    melee2.AddIngredient(ItemID.Flairon);
                    melee2.AddIngredient(ItemID.InfluxWaver);
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SpatialLance"));
                    melee2.AddIngredient(ItemID.StarWrath);
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MirrorBlade"));
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("NeptunesBounty"));
                    melee2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("DevilsDevastation"));

                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //just blue
                        melee2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("FlamingCrystalGauntlet"));
                        melee2.AddIngredient(ItemID.IceSickle);
                        melee2.AddIngredient(ItemID.Cutlass);
                        melee2.AddIngredient(ItemID.PsychoKnife);
                        melee2.AddIngredient(ItemID.Kraken);
                        melee2.AddIngredient(ItemID.TerraBlade);
                        melee2.AddIngredient(ItemID.DD2SquireBetsySword);
                        melee2.AddIngredient(ItemID.Flairon);
                        melee2.AddIngredient(ItemID.TheHorsemansBlade);
                        melee2.AddIngredient(ItemID.NorthPole);
                        melee2.AddIngredient(ItemID.InfluxWaver);
                        melee2.AddIngredient(ItemID.StarWrath);
                    }

                    else
                    {
                        //no others
                        melee2.AddIngredient(ItemID.FireGauntlet);
                        melee2.AddIngredient(ItemID.IceSickle);
                        melee2.AddIngredient(ItemID.Cutlass);
                        melee2.AddIngredient(ItemID.PsychoKnife);
                        melee2.AddIngredient(ItemID.Kraken);
                        melee2.AddIngredient(ItemID.TerraBlade);
                        melee2.AddIngredient(ItemID.DD2SquireBetsySword);
                        melee2.AddIngredient(ItemID.Flairon);
                        melee2.AddIngredient(ItemID.TheHorsemansBlade);
                        melee2.AddIngredient(ItemID.NorthPole);
                        melee2.AddIngredient(ItemID.InfluxWaver);
                        melee2.AddIngredient(ItemID.StarWrath);
                    }
                }
            }

            melee2.AddTile(null, "CrucibleCosmosSheet");
            melee2.SetResult(this);
            melee2.AddRecipe();

        }

    }
}