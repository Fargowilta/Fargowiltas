using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Fargowiltas;

namespace Terraria.GameContent.UI.Elements
{
    public class UIPageSelect : UIImageButton
    {
        private Texture2D _normal;
        private Texture2D _nope;
        internal string hoverText;
        private int pag;
        private static bool math;
        private int max;

        public UIPageSelect(Texture2D normal, Texture2D nope, string hoverText) : base(normal)
        {
            this._normal = normal;
            this._nope = nope;
            this.Width.Set((float)this._normal.Width, 0f);
            this.Height.Set((float)this._normal.Height, 0f);
            this.hoverText = hoverText;
        }

        public static void ClickMe(UIMouseEvent evt, UIElement listeningElement, ref int page, bool add, int limit)
        {
            if (add == true)
            {
                if (page < limit)
                {
                    page++;
                }
            }
            else
            {
                if (page > limit)
                {
                    page--;
                }
            }
            if (page == limit)
            {
                math = false;
            }
            else
            {
                math = true;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = base.GetDimensions();
            spriteBatch.Draw(this._normal, dimensions.Position(), Color.White);

        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            Main.PlaySound(12, -1, -1, 1, 1f, 0f);
        }
    }
}