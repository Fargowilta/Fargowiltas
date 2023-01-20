using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class AncientSeal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Seal");
            Tooltip.SetDefault("Summons ALL the bosses modded included" +
                               "\n'Use at your own risk'");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = ItemRarityID.Purple;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return Main.dayTime != true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            // Vanilla
            Projectile.NewProjectile(player.GetSource_ItemUse(source.Item), pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, 1, 3);

            // Modded
            for (int i = Main.maxNPCTypes; i < NPCLoader.NPCCount; i++)
            {
                NPC npc = new NPC();
                npc.SetDefaults(i);

                if (npc.boss)
                {
                    SpawnBoss(player, i, npc.TypeName);
                }
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Every boss has awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Every boss has awoken!", new Color(175, 75, 255));
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return false;
        }

        public static int SpawnBoss(Player player, int npcID, string name)
        {
            Main.NewText($"{name} has awoken!", new Color(175, 75, 255));
            return NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), npcID);
        }
    }
}