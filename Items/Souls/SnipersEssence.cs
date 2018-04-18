using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class SnipersEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sniper's Essence");
            Tooltip.SetDefault("'This is only the beginning..' \n18% increased ranged damage \n5% increased ranged critical chance \n5% chance to not consume ammo");
            if (Fargowiltas.instance.thoriumLoaded)
            {
                Tooltip.SetDefault("'This is only the beginning..' \n18% increased ranged damage \n5% increased ranged critical chance \n5% chance to not consume ammo /nIncreased armor penetration by 5");
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
            ((FargoPlayer)player.GetModPlayer(mod, "FargoPlayer")).miniRangedEffect = true;

            player.rangedCrit += 5;
            player.rangedDamage += .18f;

            //shark tooth 
            if (!Fargowiltas.instance.thoriumLoaded)
            {
                player.armorPenetration = 5;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe range1 = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //both
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("JadeGauntlet"));
                    range1.AddIngredient(ItemID.RangerEmblem);
                    range1.AddIngredient(ItemID.SlimeGun);
                    range1.AddIngredient(ItemID.Blowpipe);
                    range1.AddIngredient(ItemID.SnowballCannon);
                    range1.AddIngredient(ItemID.Sandgun);
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("FeatherFoe"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MarniteRifleSpear"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StormSurge"));
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Zapper"));
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SharkStorm"));
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("fDarksteelBow"));
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("RangedThorHammer"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Goobow"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("JadeGauntlet"));
                    range1.AddIngredient(ItemID.RangerEmblem);
                    range1.AddIngredient(ItemID.SlimeGun);
                    range1.AddIngredient(ItemID.Blowpipe);
                    range1.AddIngredient(ItemID.SnowballCannon);
                    range1.AddIngredient(ItemID.Sandgun);
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("FeatherFoe"));
                    range1.AddIngredient(ItemID.Harpoon);
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("Zapper"));
                    range1.AddIngredient(ItemID.StarCannon);
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("SharkStorm"));
                    range1.AddIngredient(ItemID.BeesKnees);
                    range1.AddIngredient(ItemID.HellwingBow);
                    range1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("RangedThorHammer"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {

                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    range1.AddIngredient(ItemID.SharkToothNecklace);
                    range1.AddIngredient(ItemID.RangerEmblem);
                    range1.AddIngredient(ItemID.WaterGun);
                    range1.AddIngredient(ItemID.SlimeGun);
                    range1.AddIngredient(ItemID.Blowpipe);
                    range1.AddIngredient(ItemID.SnowballCannon);
                    range1.AddIngredient(ItemID.Sandgun);
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Barinade"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("MarniteRifleSpear"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StormSurge"));
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Pumpler"));
                    range1.AddIngredient(ItemID.Revolver);
                    range1.AddIngredient(ItemID.Blowgun);
                    range1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Goobow"));
                }

                else
                {
                    //no others
                    range1.AddIngredient(ItemID.SharkToothNecklace);
                    range1.AddIngredient(ItemID.RangerEmblem);
                    range1.AddIngredient(ItemID.SlimeGun);
                    range1.AddIngredient(ItemID.Blowpipe);
                    range1.AddIngredient(ItemID.SnowballCannon);
                    range1.AddIngredient(ItemID.Sandgun);
                    range1.AddIngredient(ItemID.RedRyder);
                    range1.AddIngredient(ItemID.Harpoon);
                    range1.AddRecipeGroup("Fargowiltas:AnyEvilGun");
                    range1.AddRecipeGroup("Fargowiltas:AnyEvilBow");
                    range1.AddIngredient(ItemID.Boomstick);
                    range1.AddIngredient(ItemID.StarCannon);
                    range1.AddIngredient(ItemID.BeesKnees);
                    range1.AddIngredient(ItemID.HellwingBow);

                }
            }

            range1.AddTile(TileID.TinkerersWorkbench);
            range1.SetResult(this);
            range1.AddRecipe();
        }
    }
}