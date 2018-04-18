using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class BarbariansEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barbarian's Essence");
            Tooltip.SetDefault("'This is only the beginning..' \n18% increased melee damage \n10% increased melee speed \n5% increased melee crit chance");
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

            player.meleeSpeed += .1f;
            player.meleeDamage += .18f;
            player.meleeCrit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe melee1 = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //both
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrimsonGauntlet"));
                    melee1.AddIngredient(ItemID.WarriorEmblem);
                    melee1.AddIngredient(ItemID.Spear);
                    melee1.AddIngredient(ItemID.ZombieArm);
                    melee1.AddIngredient(ItemID.AntlionClaw);
                    melee1.AddIngredient(ItemID.Trident);
                    melee1.AddIngredient(ItemID.ChainKnife);
                    melee1.AddIngredient(ItemID.IceBlade);
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("PearlPike"));
                    melee1.AddIngredient(ItemID.BeeKeeper);
                    melee1.AddIngredient(ItemID.BlueMoon);
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Sanguine")); //
                    melee1.AddIngredient(ItemID.DarkLance);
                    melee1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("TheGodsGambit"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("CrimsonGauntlet"));
                    melee1.AddIngredient(ItemID.WarriorEmblem);
                    melee1.AddIngredient(ItemID.Spear);
                    melee1.AddIngredient(ItemID.ZombieArm);
                    melee1.AddIngredient(ItemID.AntlionClaw);
                    melee1.AddIngredient(ItemID.ChainKnife);
                    melee1.AddIngredient(ItemID.IceBlade);
                    melee1.AddIngredient(ItemID.Starfury);
                    melee1.AddIngredient(ItemID.EnchantedSword);
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("PearlPike"));
                    melee1.AddIngredient(ItemID.BeeKeeper);
                    melee1.AddIngredient(ItemID.BlueMoon);
                    melee1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Sanguine")); //
                    melee1.AddIngredient(ItemID.DarkLance);
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    melee1.AddIngredient(ItemID.WarriorEmblem);
                    melee1.AddIngredient(ItemID.Spear);
                    melee1.AddIngredient(ItemID.ZombieArm);
                    melee1.AddIngredient(ItemID.AntlionClaw);
                    melee1.AddIngredient(ItemID.Trident);
                    melee1.AddIngredient(ItemID.ChainKnife);
                    melee1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MycelialClaws"));
                    melee1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MarniteSpear"));
                    melee1.AddIngredient(ItemID.Rally);
                    melee1.AddIngredient(ItemID.IceBlade);
                    melee1.AddIngredient(ItemID.JungleYoyo);
                    melee1.AddIngredient(ItemID.BeeKeeper);
                    melee1.AddIngredient(ItemID.BlueMoon);
                    melee1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("TheGodsGambit"));
                }

                else
                {
                    //no others
                    melee1.AddIngredient(ItemID.WarriorEmblem);
                    melee1.AddIngredient(ItemID.Spear);
                    melee1.AddIngredient(ItemID.ZombieArm);
                    melee1.AddIngredient(ItemID.AntlionClaw);
                    melee1.AddIngredient(ItemID.Trident);
                    melee1.AddIngredient(ItemID.ChainKnife);

                    melee1.AddIngredient(ItemID.Rally);
                    melee1.AddIngredient(ItemID.IceBlade);
                    melee1.AddIngredient(ItemID.Starfury);
                    melee1.AddIngredient(ItemID.EnchantedSword);
                    melee1.AddIngredient(ItemID.JungleYoyo);
                    melee1.AddIngredient(ItemID.BeeKeeper);
                    melee1.AddIngredient(ItemID.BlueMoon);
                    melee1.AddIngredient(ItemID.DarkLance);
                }
            }

            melee1.AddTile(TileID.TinkerersWorkbench);
            melee1.SetResult(this);
            melee1.AddRecipe();
        }

    }
}