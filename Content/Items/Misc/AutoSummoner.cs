using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Fargowiltas.FargoSets;

namespace Fargowiltas.Content.Items.Misc
{
	public class AutoSummoner : ModItem
	{
		public override string Texture => "Fargowiltas/Content/Items/Placeholder";

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 1;
			Item.accessory = true;
            Item.value = Item.sellPrice(0, 1);
            Item.rare = ItemRarityID.Blue;
		}

		public static void PassiveEffect(Player player, Item item)
		{
			player.GetFargoPlayer().AutoSummon = true;
		}

		public override void UpdateInventory(Player player) => PassiveEffect(player, Item);
        public override void UpdateVanity(Player player) => PassiveEffect(player, Item);
        public override void UpdateEquip(Player player) => PassiveEffect(player, Item);

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.ManaCrystal)
                .AddIngredient(ItemID.SummoningPotion, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

		public static void TryAutoSummoner(Player player)
		{
			FargoPlayer fargoPlayer = player.GetFargoPlayer();

			if (!fargoPlayer.AutoSummon) 
				return;

			if (++fargoPlayer.AutoSummonCD < 60)
				return;

			fargoPlayer.AutoSummonCD = 0;

            int weaponsUsed = 0;

            //then go from there and find the next weapon to fire
            for (int i = 0; i < 10; i++) //hotbar
            {
                Item item = player.inventory[i];

                if (i != player.selectedItem && item != null && item.DamageType == DamageClass.Summon
                    && item.damage > 0 && item.shoot > ProjectileID.None && item.ammo <= 0 && !item.channel
                    && ContentSamples.ProjectilesByType[item.shoot].minion
                    && ItemID.Sets.StaffMinionSlotsRequired[item.type] <= player.maxMinions - player.slotsMinions)
                {
                    if (!player.HasAmmo(item) || (item.mana > 0 && player.statMana < item.mana))
                        continue;

                    if (!PlayerLoader.CanUseItem(player, item) || !ItemLoader.CanUseItem(item, player))
                        continue;

                    weaponsUsed++;
                    if (weaponsUsed > 1)
                        break;

                    int damage = player.GetWeaponDamage(item);

                    int itemtime = player.itemTime;
                    int itemtimemax = player.itemTimeMax;
                    FargoPlayer.AutoSummonShootMethod.Invoke(player, [player.whoAmI, item, damage]); // all the OnSpawn stuff already runs here
                    player.itemTime = itemtime;
                    player.itemTimeMax = itemtimemax;

                    SoundEngine.PlaySound(item.UseSound);

                    if (item.mana > 0)
                    {
                        if (player.CheckMana(item.mana / 2, true, false))
                        {
                            player.manaRegenDelay = 300;
                        }
                    }
                    if (item.consumable)
                    {
                        item.stack--;
                    }

                    break;
                }
            }
        }
    }
}
