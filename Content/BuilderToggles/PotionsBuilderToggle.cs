using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Content.BuilderToggles
{
    public class PotionsBuilderToggle : BuilderToggle
    {   
        public static LocalizedText NameText { get; private set; }
        public override string HoverTexture => Texture;
        public override Position OrderPosition => new After(TorchBiome);
        public override bool Active() => true;

        //Used to judge whether or not Unlimited Buffs are enabled.
        public override int NumberOfStates => 2;

        //Used to judge whether or not the Buff Tray should be hidden.
        public int RightClickState = 1;

        public override bool OnLeftClick(ref SoundStyle? sound)
        {
            sound = SoundID.Item3;
            return true;
        }

        public override void OnRightClick()
        {
            SoundEngine.PlaySound(SoundID.Unlock);
            RightClickState += 1;
            if (RightClickState > 2)
                RightClickState = 1;
        }

        public override bool Draw(SpriteBatch spriteBatch, ref BuilderToggleDrawParams drawParams)
        {
            
            //ech.
            int frame = 0;
            if (CurrentState == 0 && RightClickState == 1)
                frame = 3;
            if (CurrentState == 1 && RightClickState == 1)
                frame = 2;
            if (CurrentState == 0 && RightClickState == 2)
                frame = 1;
            if (CurrentState == 1 && RightClickState == 2)
                frame = 0;

            if (RightClickState == 1)
                Main.LocalPlayer.GetFargoPlayer().HideBuffTray = true;
            else
                Main.LocalPlayer.GetFargoPlayer().HideBuffTray = false;

            if (CurrentState == 0)
                Main.LocalPlayer.GetFargoPlayer().UnlimitedBuffs = false;
            else
                Main.LocalPlayer.GetFargoPlayer().UnlimitedBuffs = true;




            drawParams.Frame = drawParams.Texture.Frame(4, 2, frame, 0);
            return true;
        }

        public override bool DrawHover(SpriteBatch spriteBatch, ref BuilderToggleDrawParams drawParams)
        {
            int frame = 1;
            if (CurrentState <= 2 && RightClickState == 2)
                frame = 0;
            drawParams.Frame = drawParams.Texture.Frame(4, 2, frame, 1);
            return true;
        }

        public override void SetStaticDefaults()
        {
            NameText = this.GetLocalization(nameof(NameText));
        }

        public override string DisplayValue()
        {
            string right = "You shouldn't be seeing this.";
            string left = "yes";
            if (CurrentState == 0)
                left = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.LeftOff");
            else
                left = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.LeftOn");
            if (RightClickState == 1)
                right = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.RightOff");
            else
                right = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.RightOn");
            return NameText.Format(left, right);
                
        }
    }
}
