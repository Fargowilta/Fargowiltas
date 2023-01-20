using Fargowiltas.Items.Misc;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Fargowiltas.UI
{
    public class StatSheetUI : UIState
    {
        public const int BackWidth = 600;
        public const int BackHeight = 25 * HowManyPerColumn + 26 + 4; //row height * stat rows + search bar + padding
        public const int HowManyPerColumn = 14;
        public const int HowManyColumns = 2;

        public int LineCounter;
        public int ColumnCounter;

        public UISearchBar SearchBar;
        public UIDragablePanel BackPanel;
        public UIPanel InnerPanel;

        public override void OnInitialize()
        {
            Vector2 offset = new Vector2(Main.screenWidth / 2 - BackWidth * 0.75f, Main.screenHeight / 2 - BackHeight * 0.75f);

            BackPanel = new UIDragablePanel();
            BackPanel.Left.Set(offset.X, 0f);
            BackPanel.Top.Set(offset.Y, 0f);
            BackPanel.Width.Set(BackWidth, 0f);
            BackPanel.Height.Set(BackHeight, 0f);
            BackPanel.PaddingLeft = BackPanel.PaddingRight = BackPanel.PaddingTop = BackPanel.PaddingBottom = 0;
            BackPanel.BackgroundColor = new Color(29, 33, 70) * 0.7f;
            Append(BackPanel);

            SearchBar = new UISearchBar(BackWidth - 8, 26);
            SearchBar.Left.Set(4, 0f);
            SearchBar.Top.Set(6, 0f); // 6 so padding lines up
            BackPanel.Append(SearchBar);

            InnerPanel = new UIPanel();
            InnerPanel.Left.Set(6, 0f);
            InnerPanel.Top.Set(6 + 28, 0f); // 28 for search bar
            InnerPanel.Width.Set(BackWidth - 12, 0f);
            InnerPanel.Height.Set(BackHeight - 12 - 28, 0);
            InnerPanel.PaddingLeft = InnerPanel.PaddingRight = InnerPanel.PaddingTop = InnerPanel.PaddingBottom = 0;
            InnerPanel.BackgroundColor = new Color(73, 94, 171) * 0.9f;
            BackPanel.Append(InnerPanel);

            base.OnInitialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Main.GameUpdateCount % (!SearchBar.IsEmpty ? 2 : 4) == 0) // 15 times a second, or 30 times a second if searchbar has text
            {
                RebuildStatList();
            }
        }

        public void RebuildStatList()
        {
            Player player = Main.LocalPlayer;
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();

            InnerPanel.RemoveAllChildren();
            ColumnCounter = LineCounter = 0;

            double Damage(DamageClass damageClass) => Math.Round(player.GetTotalDamage(damageClass).Additive * player.GetTotalDamage(damageClass).Multiplicative * 100 - 100);
            int Crit(DamageClass damageClass) => (int)player.GetTotalCritChance(damageClass);

            AddStat($"Melee Damage: {Damage(DamageClass.Melee)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Critical: {Crit(DamageClass.Melee)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Speed: {(int)(1f / player.GetAttackSpeed(DamageClass.Melee) * 100)}%", ItemID.CopperBroadsword);
            AddStat($"Ranged Damage: {Damage(DamageClass.Ranged)}%", ItemID.CopperBow);
            AddStat($"Ranged Critical: {Crit(DamageClass.Ranged)}%", ItemID.CopperBow);
            AddStat($"Magic Damage: {Damage(DamageClass.Magic)}%", ItemID.WandofSparking);
            AddStat($"Magic Critical: {Crit(DamageClass.Magic)}%", ItemID.WandofSparking);
            AddStat($"Mana Cost Reduction: {Math.Round((1.0 - player.manaCost) * 100)}%", ItemID.WandofSparking);
            AddStat($"Summon Damage: {Damage(DamageClass.Summon)}%", ItemID.SlimeStaff);
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                AddStat($"Summon Critical: {(int)ModLoader.GetMod("FargowiltasSouls").Call("GetSummonCrit")}%", ItemID.SlimeStaff);
            else
                AddStat("");
            AddStat($"Max Minions: {player.maxMinions}", ItemID.SlimeStaff);
            AddStat($"Max Sentries: {player.maxTurrets}", ItemID.SlimeStaff);

            AddStat($"Armor Penetration: {player.GetArmorPenetration(DamageClass.Generic)}", ItemID.SharkToothNecklace);
            AddStat($"Aggro: {player.aggro}", ItemID.FleshKnuckles);


            AddStat($"Life: {player.statLifeMax2}", ItemID.LifeCrystal);
            AddStat($"Life Regen: {player.lifeRegen / 2}/sec", ItemID.BandofRegeneration);
            AddStat($"Mana: {player.statManaMax2}", ItemID.ManaCrystal);
            AddStat($"Mana Regen: {player.manaRegen / 2}/sec", ItemID.ManaCrystal);
            AddStat($"Defense: {player.statDefense}", ItemID.CobaltShield);
            AddStat($"Damage Reduction: {Math.Round(player.endurance * 100)}%", ItemID.WormScarf);
            AddStat($"Luck: {Math.Round(player.luck, 2)}", ItemID.Torch);
            AddStat($"Fishing Quests: {player.anglerQuestsFinished}", ItemID.AnglerEarring);
            AddStat($"Battle Cry: {(modPlayer.BattleCry ? "[c/ff0000:Battle]" : (modPlayer.CalmingCry ? "[c/00ffff:Calming]" : "None"))}", ModContent.ItemType<BattleCry>());
            AddStat($"Max Speed: {(int)((player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6)} mph", ItemID.HermesBoots);

            string RenderWingStat(double stat) => stat <= 0 ? "???" : stat.ToString();
            AddStat(player.wingTimeMax / 60 > 60 || player.empressBrooch ? "Wing Time: Yes" : $"Wing Time: {RenderWingStat(Math.Round(player.wingTimeMax / 60.0, 2))} sec", ItemID.AngelWings);
            AddStat($"Wing Max Speed: {RenderWingStat(Math.Round(modPlayer.StatSheetWingSpeed * 32 / 6.25))} mph", ItemID.AngelWings);
            AddStat($"Wing Ascent Modifier: {RenderWingStat(Math.Round(modPlayer.StatSheetMaxAscentMultiplier * 100))}%", ItemID.AngelWings);
            AddStat($"Wing Can Hover: {(modPlayer.CanHover == null ? "???" : modPlayer.CanHover)}", ItemID.AngelWings);
        }

        public void AddStat(string text, int item = -1)
        {
            int left = 8 + ColumnCounter * ((BackWidth - 8) / HowManyColumns);
            int top = 8 + LineCounter * (23); // I don't know why but 23 works perfectly
            if (++LineCounter == HowManyPerColumn)
            {
                ColumnCounter++;
                LineCounter = 0;
            }

            UIText ui = new UIText(item > -1 ? $"[i:{item}] {text}" : text);
            ui.Left.Set(left, 0f);
            ui.Top.Set(top, 0f);

            string[] words = text.Split(' ');
            if (!SearchBar.IsEmpty)
            {
                if (words.Any(s => s.StartsWith(SearchBar.Input, StringComparison.OrdinalIgnoreCase)))
                {
                    float fade = MathHelper.Lerp(0.1f, 0.9f, (float)(Math.Sin(Main.GameUpdateCount / 10f) + 1f) / 2f);
                    Color color = Color.Lerp(Color.Yellow, Color.Goldenrod, fade);
                    ui.TextColor = color;
                }
                else
                    // Gray out text when filtered by search
                    ui.TextColor = Color.Gray * 1.5f;
            }

            InnerPanel.Append(ui);
        }

        /*public void SetPositionToPoint(Point point)
        {
            BackPanel.Left.Set(point.X, 0f);
            BackPanel.Top.Set(point.Y, 0f);
        }

        public Point GetPositinAsPoint() => new Point((int)BackPanel.Left.Pixels, (int)BackPanel.Top.Pixels);*/
    }
}