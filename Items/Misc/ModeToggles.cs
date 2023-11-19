using Fargowiltas.Projectiles;
using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class ModeToggle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("World Token");
            // Tooltip.SetDefault(@"Cycles difficulty modes");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            //Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 0));
            //ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override string Texture => "Fargowiltas/Items/Misc/ModeToggle_0";
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.buyPrice(1);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.noUseGraphic = true;
            //Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = false;
            Item.shoot = ModContent.ProjectileType<WorldTokenProj>();
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++) //cant use while boss alive
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            string text; ;

            static string DiffText(string difficulty) => Language.GetTextValue($"Mods.Fargowiltas.Items.ModeToggle.{difficulty}");

            switch (Main.GameMode)
            {
                case 0:
                    Main.GameMode = 1;
                    ChangeAllPlayerDifficulty(0);
                    player.difficulty = 0;
                    text = DiffText("Expert");
                    break;

                case 1:
                    Main.GameMode = 2;
                    ChangeAllPlayerDifficulty(0);
                    text = DiffText("Master");
                    break;

                case 2:
                    Main.GameMode = 3;
                    ChangeAllPlayerDifficulty(3);
                    text = DiffText("Journey");
                    break;

                default:
                    Main.GameMode = 0;
                    ChangeAllPlayerDifficulty(0);
                    text = DiffText("Normal");
                    break;
            }
            
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255));
                NetMessage.SendData(7); //sync world
            }

            SoundEngine.PlaySound(SoundID.Roar, player.Center);

            return true;
        }

        private static void ChangeAllPlayerDifficulty(byte diff)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active)
                {
                    player.difficulty = diff;
                }
            }
            
        }

        /*
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            Main.itemAnimations[Item.type].Frame = Main.GameMode + 1;
            base.Update(ref gravity, ref maxFallSpeed);
        }
        public override void UpdateInventory(Player player)
        {
            Main.itemTexture[Item.type] = Main.GameMode + 1;
            base.UpdateInventory(player);
        }
        */
        
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>($"Fargowiltas/Items/Misc/ModeToggle_{Main.GameMode}");
            spriteBatch.Draw(texture, position, frame, drawColor, 0, origin, scale, SpriteEffects.None, 0f);
            return false; 
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>($"Fargowiltas/Items/Misc/ModeToggle_{Main.GameMode}");
            Vector2 position = Item.position - Main.screenPosition + new Vector2(16, 16);
            Rectangle frame = new Rectangle(0, 0, 32, 32);
            spriteBatch.Draw(texture, position, frame, lightColor, rotation, new Vector2(16, 16), scale, SpriteEffects.None, 0f);
            return false;
        }
        
    }
}