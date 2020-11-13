using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class SuperDummy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Dummy");
            Tooltip.SetDefault("Spawns a super dummy at your cursor" +
                "\nSame as regular Target Dummy except minions and projectiles detect and home onto it" +
                "\nOn hit effects get triggered as well" +
                "\nRight click to remove all spawned super dummies");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.Swing;
            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (npc.active && npc.type == ModContent.NPCType<NPCs.SuperDummy>())
                    {
                        npc.life = 0;

                        npc.HitEffect();
                        npc.StrikeNPCNoInteraction(9999, 0, 0, false, false, false);

                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
#pragma warning disable CS0618 // Type or member is obsolete
                            NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, i, 9999, 0, 0, 0, 0, 0);
#pragma warning restore CS0618 // Type or member is obsolete
                        }
                    }
                }
            }
            else if (player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(new Vector2((int)Main.MouseWorld.X - 9, (int)Main.MouseWorld.Y - 20), Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, player.whoAmI, ModContent.NPCType<NPCs.SuperDummy>());
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TargetDummy);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddTile(TileID.CookingPots);            recipe.Register();
        }
    }
}