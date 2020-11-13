using Fargowiltas.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Renewals
{
    public class BaseRenewalItem : ModItem
    {
        private readonly string name;
        private readonly string tooltip;
        private readonly string projType;
        private readonly int material;
        private readonly bool supreme;
        private readonly string supremeMaterial;

        protected BaseRenewalItem(string name, string tooltip, string projType, int material, bool supreme = false, string supremeMaterial = "")
        {
            this.name = name;
            this.tooltip = tooltip;
            this.projType = projType;
            this.material = material;
            this.supreme = supreme;
            this.supremeMaterial = supremeMaterial;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = Mod.ProjectileType(projType);
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            if (supreme)
            {
                recipe.AddIngredient(Mod.ItemType(supremeMaterial), 10);
                recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
                recipe.AddTile(TileID.AlchemyTable);
            }
            else
            {
                recipe.AddIngredient(ItemID.Bottle);
                recipe.AddIngredient(material, 100);
                recipe.AddTile(TileID.Bottles);
            }

            recipe.Register();
        }
    }
}