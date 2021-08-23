using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public sealed class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.Fargowiltas.Mutant")]
        [DefaultValue(true)]
        public bool Mutant;

        [Label("$Mods.Fargowiltas.Abom")]
        [DefaultValue(true)]
        public bool Abom;

        [Label("$Mods.Fargowiltas.Devi")]
        [DefaultValue(true)]
        public bool Devi;

        [Label("$Mods.Fargowiltas.Lumber")]
        [DefaultValue(true)]
        public bool Lumber;

        [Label("[i:1774] Halloween Season Active")]
        [DefaultValue(false)]
        public bool Halloween;

        [Label("[i:1869] Christmas Season Active")]
        [DefaultValue(false)]
        public bool Christmas;

        [Label("[i:771] Unlimited Ammo in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedAmmo;
        
        [Label("     [i:3104] Ammo stack size")]
		[Range(3996, 9999)]
		[DefaultValue(3996)]
		public int AmmoStackSize;

        [Label("[i:42] Unlimited Consumable Weapons in Hardmode")]
        [DefaultValue(true)]
        public bool UnlimitedConsumableWeapons;
        
        [Label("     [i:168] Weapon stack size")]
		[Range(3996, 9999)]
		[DefaultValue(3996)]
		public int WeaponStackSize;
        
        [Label("[i:4479] Unlimited Potion/Class Station Buffs")]
        [DefaultValue(true)]
        public bool UnlimitedPotionBuffsOn120;
        
        [Label("     [i:296] Potion stack size")]
		[Range(30, 9999)]
		[DefaultValue(30)]
		public int PotionStackSize;
        
        [Label("     [i:3198] Station stack size")]
		[Range(15, 9999)]
		[DefaultValue(15)]
		public int StationStackSize;
        
        [Label("[i:2374] Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool AnglerQuestInstantReset;

        [Label("[i:2294] Extra Lures on Fishing Rods")]
        [DefaultValue(true)]
        public bool ExtraLures;

        [Label("[i:3213] Stalker Money Trough")]
        [DefaultValue(true)]
        public bool StalkerMoneyTrough;

        [Label("[i:267] Catch Town NPCs")]
        [DefaultValue(true)]
        public bool CatchNPCs;

        [Label("[i:267] Extra Town NPC sales")]
        [DefaultValue(true)]
        public bool NPCSales;

        [Label("[i:1809] Powerful Rotten Eggs")]
        [DefaultValue(true)]
        public bool RottenEggs;

        [Label("[i:1683] Banner Recipes")]
        [DefaultValue(true)]
        public bool BannerRecipes;
        
        [Label("[i:2334] Crate Recipes")]
        [DefaultValue(true)]
        public bool CrateRecipes;
        
        [Label("[i:476] Statue Recipes")]
        [DefaultValue(true)]
        public bool StatueRecipes;
        
        [Label("[i:43] Summon Conversion")]
        [DefaultValue(true)]
        public bool SummonConversion;
        
        [Label("[i:880] Evil Conversion")]
        [DefaultValue(true)]
        public bool EvilConversion;
        
        [Label("[i:57] Metal Conversion")]
        [DefaultValue(true)]
        public bool MetalConversion;

        [Label("[i:2] Increased Max Stacks")]
        [DefaultValue(true)]
        public bool IncreaseMaxStack;

        [Label("[i:997] Increased Extractinator Speed")]
        [DefaultValue(true)]
        public bool ExtractSpeed;

        [Label("[i:909] Fountains Cause Biomes")]
        [DefaultValue(true)]
        public bool Fountains;

        [Label("[i:3117] No enemies spawn during boss fights")]
        [DefaultValue(true)]
        public bool BossZen;

        [Label("[i:87] Informational and Construction Accessories work in Piggy Bank")]
        [DefaultValue(true)]
        public bool PiggyBankAcc;

        [Label("[i:1612] Debuffs render above player")]
        [DefaultValue(false)]
        public bool DebuffDisplay;

        [Label("[i:1612] Debuff Display Opacity")]
        [DefaultValue(1f)] [Slider]
        public float DebuffOpacity;

        [Label("[i:1309] Transparent Minions & Support Attacks")]
        [DefaultValue(false)]
        public bool TransparentMinions;
    }
}
