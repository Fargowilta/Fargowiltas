using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
	public class InstantResearch : ModItem
	{
		public override string Texture => "Fargowiltas/Items/Placeholder";

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Instant Research");
			// Tooltip.SetDefault("DEBUG ITEM\nResearches everything");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
		}

		public override bool? UseItem(Player player)
		{
			if (player.itemAnimation > 0 && player.itemTime == 0)
			{
				int count = 0;

				for (int i = 0; i < ContentSamples.ItemsByType.Count; i++)
				{
					if (CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(i, out int amountNeeded))
					{
						int diff = amountNeeded - player.creativeTracker.ItemSacrifices.GetSacrificeCount(i);
						if (diff > 0)
						{
							player.creativeTracker.ItemSacrifices.RegisterItemSacrifice(i, diff);
							count++;
						}
					}
				}

				FargoUtils.PrintLocalization("Items.InstantResearch.ResearchText", count);
			}

			return true;
		}
	}
}
