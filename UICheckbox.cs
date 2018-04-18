using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.GameContent.UI.Chat;
using Terraria;
using Fargowiltas;

namespace Fargowiltas
{
    // TODO, tri-state checkbox.
    class UICheckbox : UIText
    {
        public Color _color;
        public Color olor;
        static Texture2D checkboxTexture = Fargowiltas.instance.GetTexture("checkBox");
        static Texture2D checkmarkTexture = Fargowiltas.instance.GetTexture("checkMark");
        public event EventHandler OnSelectedChanged;

        public float order = 0;
        bool clickable = true;
        string tooltip = "";
        string test;
        private bool selected = true;

        public bool Selected
        {
            get { return selected; }
            set
            {
                if (value != selected)
                {
                    selected = value;
                    if (OnSelectedChanged != null)
                    {
                        OnSelectedChanged(this, EventArgs.Empty);
                    }
                    //OnSelectedChanged?.Invoke();
                }
            }
        }

        public UICheckbox(string text, string tooltip, Color main, Color threed, bool clickable = true, float textScale = 1, bool large = false) : base("", textScale, large)
        {
            this._color = main;
            this.olor = threed;
            this.tooltip = tooltip;
            this.clickable = clickable;
            this.test = "   " + text;
            SetText("   ");
            Recalculate();
        }

        public override void Click(UIMouseEvent evt)
        {
            if (clickable)
            {
                Selected = !Selected;
            }
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            //Vector2 pos = new Vector2(innerDimensions.X - 20, innerDimensions.Y - 5);
            Vector2 pos = new Vector2(innerDimensions.X, innerDimensions.Y - 5);
            Vector2 three = new Vector2(innerDimensions.X + 2, innerDimensions.Y - 3); //the positioning of the 3d part

            spriteBatch.Draw(checkboxTexture, pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            if (Selected)
                spriteBatch.Draw(checkmarkTexture, pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            base.DrawSelf(spriteBatch);
            //Utils.DrawBorderString(spriteBatch, this.test, three, this.olor, 1f, 0f, 0f, -1); the 3d part
            Utils.DrawBorderString(spriteBatch, this.test, pos, this._color, 1f, 0f, 0f, -1);
            if (IsMouseHovering && tooltip.Length > 0)
            {
                Main.HoverItem = new Item();
                Main.hoverItemName = tooltip;
            }
        }

        // public void AddCheck()
        // {
        // spriteBatch.Draw(checkmarkTexture, pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // }

        // public void RemoveCheck()
        // {
        // spriteBatch.Draw("", pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // }

        public override int CompareTo(object obj)
        {
            UICheckbox other = obj as UICheckbox;
            return order.CompareTo(other.order);
        }
    }
}
