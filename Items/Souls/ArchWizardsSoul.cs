using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Fargowiltas.Items;
using Fargowiltas.NPCs;
using Fargowiltas.Projectiles;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class ArchWizardsSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arch Wizard's Soul");
            Tooltip.SetDefault("'Arcane to the core' \n40% increased magic damage \n20% increased magic critical chance \nIncreases your maximum mana by 100 \nReduces mana usage by 33% \nIncreased pickup range for mana stars \nAutomatically use mana potions when needed");
            if (Fargowiltas.instance.calamityLoaded)
            {
                Tooltip.SetDefault("'Arcane to the core' \n40% increased magic damage \n20% increased magic critical chance \nIncreases your maximum mana by 100 \nReduces mana usage by 33% \nIncreased pickup range for mana stars \nAutomatically use mana potions when needed \nGrants the effects of the Ethereal Talisman");
            }
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

            player.manaCost -= .33f;
            player.magicDamage += .4f;
            player.magicCrit += 20;
            player.statManaMax2 += 100;
            player.magicCuffs = true;
            player.manaMagnet = true;
            player.manaFlower = true;

            if (Fargowiltas.instance.blueMagicLoaded)
            {
                blueMagnet(player);
            }
            if (Fargowiltas.instance.calamityLoaded)
            {
                Talisman(player);
            }
        }

        public void Talisman(Player player)
        {
            player.GetModPlayer<CalamityMod.CalamityPlayer>(ModLoader.GetMod("CalamityMod")).eTalisman = true;
        }

        public void blueMagnet(Player player)
        {
            player.GetModPlayer<Bluemagic.BluemagicPlayer>(ModLoader.GetMod("Bluemagic")).manaMagnet2 = true;
        }

        public override void AddRecipes()
        {
            ModRecipe magic2 = new ModRecipe(mod);

            magic2.AddIngredient(null, "ApprenticesEssence");


            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //all 3
                        magic2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialSeal"));
                    }

                    else
                    {
                        //thorium and calamity
                        magic2.AddIngredient(ItemID.CelestialCuffs);
                    }

                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EtherealTalisman"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SpectrelBlade"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerraStaff"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicRainbow"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumSageStaff"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Effervescence"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AlphaRay"));
                    magic2.AddIngredient(ItemID.LastPrism);
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AlmanacofDespair"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("T1000"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //blue and thorium
                        magic2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialSeal"));
                    }

                    else
                    {
                        //just thorium
                        magic2.AddIngredient(ItemID.CelestialCuffs);
                    }

                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("PrismaticSpray"));
                    magic2.AddIngredient(ItemID.RainbowGun);
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SpectrelBlade"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerraStaff"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("OldGodGrasp"));
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("NuclearFury"));
                    magic2.AddIngredient(ItemID.ApprenticeStaffT3);
                    magic2.AddIngredient(ItemID.BatScepter);
                    magic2.AddIngredient(ItemID.BlizzardStaff);
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("TerrariumSageStaff"));
                    magic2.AddIngredient(ItemID.LastPrism);
                    magic2.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AlmanacofDespair"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {

                if (Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //calamity and blue
                        magic2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialSeal"));
                    }

                    else
                    {
                        //just calamity
                        magic2.AddIngredient(ItemID.CelestialCuffs);
                    }

                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EtherealTalisman"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("InfernalRift"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicRainbow"));
                    magic2.AddIngredient(ItemID.ApprenticeStaffT3);
                    magic2.AddIngredient(ItemID.BatScepter);
                    magic2.AddIngredient(ItemID.BlizzardStaff);
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Effervescence"));
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("AlphaRay"));
                    magic2.AddIngredient(ItemID.LastPrism);
                    magic2.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("T1000"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    if (Fargowiltas.instance.blueMagicLoaded)
                    {
                        //just blue
                        magic2.AddIngredient(ModLoader.GetMod("Bluemagic").ItemType("CelestialSeal"));
                    }

                    else
                    {
                        //no others
                        magic2.AddIngredient(ItemID.CelestialCuffs);
                    }

                    magic2.AddIngredient(ItemID.MeteorStaff);
                    magic2.AddIngredient(ItemID.CrystalStorm);
                    magic2.AddIngredient(ItemID.MagicalHarp);
                    magic2.AddIngredient(ItemID.NettleBurst);
                    magic2.AddIngredient(ItemID.RainbowGun);
                    magic2.AddIngredient(ItemID.InfernoFork);
                    magic2.AddIngredient(ItemID.ApprenticeStaffT3);
                    magic2.AddIngredient(ItemID.RazorbladeTyphoon);
                    magic2.AddIngredient(ItemID.BatScepter);
                    magic2.AddIngredient(ItemID.BlizzardStaff);
                    magic2.AddIngredient(ItemID.LaserMachinegun);
                    magic2.AddIngredient(ItemID.LastPrism);
                }
            }

            magic2.AddTile(null, "CrucibleCosmosSheet");
            magic2.SetResult(this);
            magic2.AddRecipe();
        }

    }
}