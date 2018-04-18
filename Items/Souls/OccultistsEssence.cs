using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items.Souls
{
    public class OccultistsEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Occultist's Essence");
            Tooltip.SetDefault("'This is only the beginning..' \n12% increased summon damage \nIncreases your max number of minions by 1 \nIncreases your max number of sentries by 1");
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

            player.maxMinions += 1;
            player.maxTurrets += 1;
            player.minionDamage += 0.12f;
        }

        public override void AddRecipes()
        {
            ModRecipe summon1 = new ModRecipe(mod);

            if (Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //both
                    summon1.AddIngredient(ItemID.SummonerEmblem);
                    summon1.AddIngredient(ItemID.SlimeStaff);
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaboundStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MeteorStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AmberMinion"));
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("DankStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodClotStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HiveMind"));
                    summon1.AddIngredient(ItemID.HornetStaff);
                    summon1.AddIngredient(ItemID.ImpStaff);
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StrangeSkull"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DistressCaller"));
                }

                if (!Fargowiltas.instance.calamityLoaded)
                {
                    //just thorium
                    summon1.AddIngredient(ItemID.SummonerEmblem);
                    summon1.AddIngredient(ItemID.SlimeStaff);
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StarfishWand"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HatchlingStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("MeteorStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("AmberMinion"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("HiveMind"));
                    summon1.AddIngredient(ItemID.HornetStaff);
                    summon1.AddIngredient(ItemID.ImpStaff);
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("StrangeSkull"));
                    summon1.AddIngredient(ModLoader.GetMod("ThoriumMod").ItemType("DistressCaller"));
                }
            }

            if (!Fargowiltas.instance.thoriumLoaded)
            {
                if (Fargowiltas.instance.calamityLoaded)
                {
                    //just calamity
                    summon1.AddIngredient(ItemID.SummonerEmblem);
                    summon1.AddIngredient(ItemID.SlimeStaff);
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaboundStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("DankStaff"));
                    summon1.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BloodClotStaff"));
                    summon1.AddIngredient(ItemID.HornetStaff);
                    summon1.AddIngredient(ItemID.ImpStaff);
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                }

                else
                {
                    //no others
                    summon1.AddIngredient(ItemID.SummonerEmblem);
                    summon1.AddIngredient(ItemID.SlimeStaff);
                    summon1.AddIngredient(ItemID.HornetStaff);
                    summon1.AddIngredient(ItemID.ImpStaff);
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                    summon1.AddRecipeGroup("Fargowiltas:AnySentry1");
                }
            }

            summon1.AddTile(TileID.TinkerersWorkbench);
            summon1.SetResult(this);
            summon1.AddRecipe();
        }

    }
}