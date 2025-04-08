using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Fargowiltas.Common.Configs
{
    public sealed class FargoClientConfig : ModConfig
    {
        public static FargoClientConfig Instance;
        public override void OnLoaded()
        {
            Instance = this;
        }
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool ExpandedTooltips;

        [DefaultValue(true)]
        public bool ExactTooltips;

        [DefaultValue(false)]
        public bool HideUnlimitedBuffs;

        [DefaultValue(false)]
        public bool DoubleTapDashDisabled;

        [DefaultValue(false)]
        public bool DoubleTapSetBonusDisabled;

        [DefaultValue(true)]
        public bool MultiplayerDeathSpectate;

        [DefaultValue(1f)]
        [Slider]
        public float TransparentFriendlyProjectiles;

        [DefaultValue(0.75f)]
        [Slider]
        public float DebuffOpacity;

        [DefaultValue(0.75f)]
        [Slider]
        public float DebuffFaderRatio;

        [ReloadRequired]
        [DefaultValue(true)]
        public bool EnableShopExpanderSupport;
        

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            TransparentFriendlyProjectiles = Utils.Clamp(TransparentFriendlyProjectiles, 0f, 1f);
        }
    }
}
