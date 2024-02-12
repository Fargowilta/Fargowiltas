using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Fargowiltas;
using Fargowiltas.Projectiles;
using Terraria.Localization;
using Terraria.DataStructures;

namespace Fargowiltas.Items.Misc
{
    public class SuperDummy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Dummy");
            /* Tooltip.SetDefault("Spawns a super dummy at your cursor" +
                               "\nSame as regular Target Dummy except minions and projectiles detect and home onto it" +
                               "\nOn hit effects get triggered as well" +
                               "\nRight click to remove all spawned super dummies" +
                               "\nCan spawn up to 50 super dummies at once"); */

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<NPCs.SuperDummy>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                Main.npc[i].SimpleStrikeNPC(int.MaxValue, 0, false, 0, null, false, 0, true);
                                //Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0, 0, false, false, false);
                            }
                        }
                    }
                    else if (Main.netMode == NetmodeID.MultiplayerClient) //tell server to clear
                    {
                        var netMessage = Mod.GetPacket();
                        netMessage.Write((byte)5);
                        netMessage.Send();
                    }
                }
            }
            else if (NPC.CountNPCS(ModContent.NPCType<NPCs.SuperDummy>()) < 50)// && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 pos = new((int)Main.MouseWorld.X - 9, (int)Main.MouseWorld.Y - 20);
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, player.whoAmI, ModContent.NPCType<NPCs.SuperDummy>());

                //NPC.NewNPC((int)pos.X, (int)pos.Y, ModContent.NPCType<NPCs.SuperDummy>());
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TargetDummy)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.CookingPots)
                .Register();
        }
    }
}
