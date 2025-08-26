using Fargowiltas.Common.Configs;
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

        public override bool OnLeftClick(ref SoundStyle? sound)
        {
            sound = SoundID.Item3;
            return true;
        }

        public override void Load()
        {
            CurrentState = FargoClientConfig.Instance.HideUnlimitedBuffs.ToInt();
        }
        public override bool Draw(SpriteBatch spriteBatch, ref BuilderToggleDrawParams drawParams)
        {
            
            //ech.
            int frame = 0;
            if (CurrentState == 0)
                frame = 0;
            if (CurrentState == 1)
                frame = 1;  

            if (CurrentState == 0)
            {
                FargoClientConfig.Instance.HideUnlimitedBuffs = false;
                FargoClientConfig.Instance.SaveChanges();
            }

            else
            {
                FargoClientConfig.Instance.HideUnlimitedBuffs = true;
                FargoClientConfig.Instance.SaveChanges();
            }

            drawParams.Frame = drawParams.Texture.Frame(4, 2, frame, 0);
            return true;
        }

        public override bool DrawHover(SpriteBatch spriteBatch, ref BuilderToggleDrawParams drawParams)
        {
            int frame = 0;
            drawParams.Frame = drawParams.Texture.Frame(4, 2, frame, 1);
            return true;
        }

        public override void SetStaticDefaults()
        {
            NameText = this.GetLocalization(nameof(NameText));
        }

        public override string DisplayValue()
        {
            string left = "You shouldn't be seeing this.";
            if (CurrentState == 0)
                left = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.LeftOn");
            else
                left = Language.GetTextValue("Mods.Fargowiltas.BuilderToggles.PotionsBuilderToggle.LeftOff");
            return NameText.Format(left);
                
        }
    }
}
