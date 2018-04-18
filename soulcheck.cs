using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using System;
using System.Reflection;
using System.Linq;
using Terraria.ModLoader;
using System.Collections.Generic;


namespace Fargowiltas
{
    class Soulcheck : UIState
    {
        public UIPanel checklistPanel;
        public static bool visible = false;

        public static Dictionary<String, bool> toggleDict = new Dictionary<String, bool>();

        public static bool GetValue(string buff)
        {
            bool returnVar;
            toggleDict.TryGetValue(buff, out returnVar);
            ErrorLogger.Log(buff + ": " + returnVar.ToString());
            return returnVar;
        }

        private Color WTF = new Color(173, 94, 171);
        private float Left;
        private float Top = 20f;
        public void CreateCheckbox(String name, Color color)
        {
            toggleDict.Add(name, true);

            var temp = new UICheckbox(name, "", color, WTF, true);
            temp.Left.Set(Left, 0f);
            temp.Top.Set(Top, 0f);
            temp.OnSelectedChanged += (object o, EventArgs e) =>
            {
                toggleDict[name] = !toggleDict[name];
            };
            checklistPanel.Append(temp);

            Top += 25f;
            if (Top >= 540)
            {
                Top = 20f;
                Left = 190f;
            }
        }

        public override void OnInitialize()
        {
            // Is initialize called? (Yes it is called on reload) I want to reset nicely with new character or new loaded mods: visible = false;

            checklistPanel = new UIPanel();
            checklistPanel.SetPadding(10);
            checklistPanel.Width.Set(450f, 0f);
            checklistPanel.Height.Set(600f, 0f);
            checklistPanel.Left.Set(1000f, 0f);
            checklistPanel.Top.Set(450f, 0f);
            checklistPanel.BackgroundColor = new Color(73, 94, 171);
            checklistPanel.OnMouseDown += new UIElement.MouseEvent(DragOn);
            checklistPanel.OnMouseUp += new UIElement.MouseEvent(DragOff);
            base.Append(checklistPanel);

            CreateCheckbox("Inferno Buff", new Color(244, 121, 13));
            CreateCheckbox("Hallowed Shield", new Color(224, 221, 44));
            CreateCheckbox("Split Enemies", new Color(242, 201, 21));
            CreateCheckbox("Seasonal Enemies", new Color(114, 74, 25));
            CreateCheckbox("Beetles", new Color(88, 89, 153));
            CreateCheckbox("Leaf Crystal", new Color(47, 224, 67));
            CreateCheckbox("Spore Explosion", new Color(12, 183, 32));
            CreateCheckbox("Forbidden Storm", new Color(221, 186, 171));
            CreateCheckbox("Stardust guardian", new Color(11, 221, 196));
            CreateCheckbox("Solar Shield", new Color(229, 124, 11));
            CreateCheckbox("Shroomite Stealth", new Color(11, 42, 196));
            CreateCheckbox("Orichalcum Fireball", new Color(211, 99, 192));
            CreateCheckbox("Spooky Scythes", new Color(37, 41, 68));
            CreateCheckbox("Hunter Buff", new Color(219, 143, 37));
            CreateCheckbox("Spelunker Buff", new Color(246, 255, 2));
            CreateCheckbox("Dangersense Buff", new Color(209, 75, 27));
            CreateCheckbox("Shine Buff", new Color(247, 255, 48));
            CreateCheckbox("Spore Sac", new Color(93, 255, 0));
            CreateCheckbox("Super Speed", new Color(255, 25, 52));
            CreateCheckbox("Melee Speed", new Color(255, 178, 0));
            CreateCheckbox("Splitting Projectiles", new Color(224, 58, 58));
            CreateCheckbox("Increase Use Speed", new Color(81, 181, 113));
            CreateCheckbox("Bees on Hit", new Color(81, 181, 113));
            CreateCheckbox("Baby Dino Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Penguin Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Skeletron Pet", new Color(81, 181, 113));
            CreateCheckbox("Turtle Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Snowman Pet", new Color(81, 181, 113));
            CreateCheckbox("Zephyr Fish Pet", new Color(81, 181, 113));
            CreateCheckbox("Companion Cube Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Grinch Pet", new Color(81, 181, 113));
            CreateCheckbox("Lizard Pet", new Color(81, 181, 113));
            CreateCheckbox("Suspicious Looking Eye Pet", new Color(81, 181, 113));
            CreateCheckbox("Mini Minotaur Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Eater Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Face Monster Pet", new Color(81, 181, 113));
            CreateCheckbox("Spider Pet", new Color(81, 181, 113));
            CreateCheckbox("Baby Hornet Pet", new Color(81, 181, 113));
            CreateCheckbox("Wisp Pet", new Color(81, 181, 113));
            CreateCheckbox("Cursed Sapling Pet", new Color(81, 181, 113));
            CreateCheckbox("Black Cat Pet", new Color(81, 181, 113));
        }

        internal void UpdateNeeded()
        {
            updateneeded = true;
        }
        private bool updateneeded;

        private Vector2 offset;
        public bool dragging = false;

        private void DragOn(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - checklistPanel.Left.Pixels, evt.MousePosition.Y - checklistPanel.Top.Pixels);

            dragging = true;
        }

        private void DragOff(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            checklistPanel.Left.Set(end.X - offset.X, 0f);
            checklistPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (checklistPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                checklistPanel.Left.Set(MousePosition.X - offset.X, 0f);
                checklistPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}