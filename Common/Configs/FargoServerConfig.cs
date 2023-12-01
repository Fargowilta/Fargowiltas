using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace Fargowiltas.Common.Configs
{
    public sealed class FargoServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) => false;

        [Header("$Mods.Fargowiltas.Configs.FargoServerConfig.Headers.TownNPCs")]
        [DefaultValue(true)]
        public bool Mutant;

        [DefaultValue(true)]
        public bool Abom;

        [DefaultValue(true)]
        public bool Devi;

        [DefaultValue(true)]
        public bool Lumber;

        [DefaultValue(true)]
        public bool Squirrel;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool CatchNPCs;

        [DefaultValue(true)]
        public bool NPCSales;

        [DefaultValue(true)]
        public bool SaferBoundNPCs;

        [Header("$Mods.Fargowiltas.Configs.FargoServerConfig.Headers.Seasons")]
        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections Halloween;

        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections Christmas;

        [Header("$Mods.Fargowiltas.Configs.FargoServerConfig.Headers.Seeds")]
        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections DrunkWorld;

        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections BeeWorld;

        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections WorthyWorld;

        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections CelebrationWorld;

        [DefaultValue(0)]
        [DrawTicks]
        public SeasonSelections ConstantWorld;

        [Header("$Mods.Fargowiltas.Configs.FargoServerConfig.Headers.Unlimited")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo;

        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons;

        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120;

        private const uint maxExtraBuffSlots = 99;
        [Header("$Mods.Fargowiltas.Configs.FargoServerConfig.Headers.Misc")]
        [Range(0, maxExtraBuffSlots)]
        [DefaultValue(22)]
        [ReloadRequired]
        public uint ExtraBuffSlots;

        [DefaultValue(true)]
        public bool AnglerQuestInstantReset;

        [DefaultValue(true)]
        public bool ExtraLures;

        [DefaultValue(true)]
        public bool StalkerMoneyTrough;

        [DefaultValue(true)]
        public bool RottenEggs;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool BannerRecipes;

        [DefaultValue(true)]
        public bool IncreaseMaxStack;

        [DefaultValue(true)]
        public bool ExtractSpeed;

        [DefaultValue(true)]
        public bool Fountains;

        [DefaultValue(true)]
        public bool BossZen;

        [DefaultValue(true)]
        public bool PiggyBankAcc;

        [DefaultValue(true)]
        public bool FasterLavaFishing;

        [DefaultValue(true)]
        public bool TorchGodEX;

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            ExtraBuffSlots = Utils.Clamp<uint>(ExtraBuffSlots, 0, maxExtraBuffSlots);
        }
    }
}
