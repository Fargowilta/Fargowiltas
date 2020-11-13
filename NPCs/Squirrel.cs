using Fargowiltas.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [Autoload(false)]
    [AutoloadHead]
    public class Squirrel : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squirrel");

            Main.npcFrameCount[npc.type] = 6;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 50;
            npc.height = 32;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = .25f;
            animationType = NPCID.Squirrel;
            npc.aiStyle = 7;

            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)Fargowiltas.LoadedMods["FargowiltasSouls"].ItemType("TophatSquirrel");
            }
        }

        public override void AI() => npc.dontTakeDamage = Main.bloodMoon;

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];

                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == Fargowiltas.LoadedMods["FargowiltasSouls"].ItemType("TophatSquirrel"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override string TownNPCName() => Language.GetTextValue("Mods.Fargoawiltas.NPC_Names_Squirrel." + WorldGen.genRand.Next(3));

        public override string GetChat()
        {
            if (Main.bloodMoon)
            {
                return Language.GetTextValue("Mods.Fargoawiltas.NPC_Dialogu_Squirrel.Suffer");
            }

            switch (Main.rand.Next(3))
            {
                case 0:
                    return Language.GetTextValue("Mods.Fargoawiltas.NPC_Dialogu_Squirrel.Squeak");

                case 1:
                    return Language.GetTextValue("Mods.Fargoawiltas.NPC_Dialogu_Squirrel.Chitter");

                default:
                    return Language.GetTextValue("Mods.Fargoawiltas.NPC_Dialogu_Squirrel.Crunch");
            }
        }

        public override void SetChatButtons(ref string button, ref string button2) => button = Language.GetTextValue("LegacyInterface.28");

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        private void TryAddItem(Item item, Chest shop, ref int nextSlot)
        {
            const int maxShop = 40;

            if (item.modItem == null || !item.modItem.Mod.Name.Equals("FargowiltasSouls") || nextSlot >= maxShop)
            {
                return;
            }

            bool duplicateItem = false;

            if (item.Name.EndsWith("Enchantment"))
            {
                foreach (Item shopItem in shop.item)
                {
                    if (shopItem.type == item.type)
                    {
                        duplicateItem = true;

                        break;
                    }
                }

                if (!duplicateItem && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.Contains("Force"))
            {
                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    Recipe recipe = Main.recipe[i];

                    if (recipe.HasResult(item.type))
                    {
                        foreach (Item requiredItem in recipe.requiredItem)
                        {
                            foreach (Item shopItem in shop.item)
                            {
                                if (requiredItem.type == shopItem.type)
                                {
                                    duplicateItem = true;

                                    break;
                                }
                            }

                            if (!duplicateItem && nextSlot < maxShop)
                            {
                                if (requiredItem.Name.Contains("Enchantment"))
                                {
                                    shop.item[nextSlot++].SetDefaults(requiredItem.type);
                                }
                            }
                        }
                    }
                }
            }
            else if (item.Name.StartsWith("Soul"))
            {
                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    Recipe recipe = Main.recipe[i];

                    if (recipe.HasResult(item.type))
                    {
                        foreach (Item requiredItem in recipe.requiredItem)
                        {
                            foreach (Item shopItem in shop.item)
                            {
                                if (requiredItem.type == shopItem.type)
                                {
                                    duplicateItem = true;

                                    break;
                                }
                            }

                            if (!duplicateItem && nextSlot < maxShop)
                            {
                                if (requiredItem.Name.Contains("Force") || requiredItem.Name.Contains("Soul"))
                                {
                                    shop.item[nextSlot++].SetDefaults(requiredItem.type);
                                }
                            }
                        }
                    }
                }
            }
            else if (item.Name.EndsWith("Essence"))
            {
                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    foreach (Item shopItem in shop.item)
                    {
                        if (shopItem.type == item.type)
                        {
                            duplicateItem = true;

                            break;
                        }
                    }

                    if (!duplicateItem && nextSlot < maxShop)
                    {
                        shop.item[nextSlot++].SetDefaults(item.type);
                    }
                }
            }
            else if (item.Name.EndsWith("Soul"))
            {
                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    Recipe recipe = Main.recipe[i];

                    if (recipe.HasResult(item.type))
                    {
                        foreach (Item requiredItem in recipe.requiredItem)
                        {
                            foreach (Item shopItem in shop.item)
                            {
                                if (requiredItem.type == shopItem.type)
                                {
                                    duplicateItem = true;

                                    break;
                                }
                            }

                            if (!duplicateItem && nextSlot < maxShop)
                            {
                                if (requiredItem.Name.Contains("Essence"))
                                {
                                    shop.item[nextSlot++].SetDefaults(requiredItem.type);
                                }
                            }
                        }
                    }
                }
            }
            else if (item.type == Fargowiltas.LoadedMods["FargowiltasSouls"].ItemType("AeolusBoots"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == ItemID.FrostsparkBoots || item2.type == ItemID.BalloonHorseshoeFart)
                    {
                        duplicateItem = true;

                        break;
                    }
                }

                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot++].SetDefaults(ItemID.FrostsparkBoots);
                }

                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot++].SetDefaults(ItemID.BalloonHorseshoeFart);
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Fargowiltas.ModLoaded("FargowiltasSouls"))
            {
                shop.item[nextSlot].SetDefaults(Fargowiltas.LoadedMods["FargowiltasSouls"].ItemType("TophatSquirrel"));
                shop.item[nextSlot++].shopCustomPrice = 100000;
            }

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];

                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    TryAddItem(item, shop, ref nextSlot);
                }

                foreach (Item item in player.armor)
                {
                    TryAddItem(item, shop, ref nextSlot);
                }
            }
        }

        public override void /*OnKill*/ NPCLoot() => FargoWorld.DownedBools["squirrel"] = true;

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Asset<Texture2D> texture = TextureAssets.Npc[npc.type];
            Rectangle rec = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin = rec.Size() / 2f;
            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (Main.bloodMoon)
            {
                Main.spriteBatch.Draw(ModContent.GetTexture("Fargowiltas/NPCs/Squirrel_Glow").Value, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), Color.White * npc.Opacity, npc.rotation, origin, (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f, effects, 0f);
            }

            Main.spriteBatch.Draw(texture.Value, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), npc.GetAlpha(lightColor), npc.rotation, origin, npc.scale, effects, 0f);

            if (Main.bloodMoon)
            {
                Main.spriteBatch.Draw(ModContent.GetTexture("Fargowiltas/NPCs/Squirrel_Eyes").Value, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rec), Color.White * npc.Opacity, npc.rotation, origin, npc.scale, effects, 0f);
            }

            return false;
        }
    }
}