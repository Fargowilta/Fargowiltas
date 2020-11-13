using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public class FargoConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$Mods.Fargowiltas.Mutant")]
        [DefaultValue(true)]
        public bool mutant;

        [Label("$Mods.Fargowiltas.Abom")]
        [DefaultValue(true)]
        public bool abom;

        [Label("$Mods.Fargowiltas.Devi")]
        [DefaultValue(true)]
        public bool devi;

        [Label("$Mods.Fargowiltas.Lumber")]
        [DefaultValue(true)]
        public bool lumber;

        [Label("[i:1774] Halloween Season Active")]
        [DefaultValue(false)]
        public bool halloween;

        [Label("[i:1869] Christmas Season Active")]
        [DefaultValue(false)]
        public bool christmas;

        [Label("[i:771] Unlimited Ammo at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool unlimitedAmmo;

        [Label("[i:42] Unlimited Consumable Weapons at 3996+ in Hardmode")]
        [DefaultValue(true)]
        public bool unlimitedConsumableWeapons;

        [Label("[i:292] Unlimited Potion Buffs for 60+ Potions")]
        [DefaultValue(true)]
        public bool unlimitedPotionBuffsOn120;

        [Label("[i:2374] Angler Quest Instant Reset")]
        [DefaultValue(true)]
        public bool anglerQuestInstantReset;

        [Label("[i:2294] Extra Lures on Fishing Rods")]
        [DefaultValue(true)]
        public bool extraLures;

        [Label("[i:3213] Stalker Money Trough")]
        [DefaultValue(true)]
        public bool stalkerMoneyTrough;

        [Label("[i:267] Catch Town NPCs")]
        [DefaultValue(true)]
        public bool catchNPCs;

        [Label("[i:267] Extra Town NPC sales")]
        [DefaultValue(true)]
        public bool npcSales;

        [Label("[i:1809] Powerful Rotten Eggs")]
        [DefaultValue(true)]
        public bool rottenEggs;

        [Label("[i:1683] Banner Recipes")]
        [DefaultValue(true)]
        public bool bannerRecipes;

        [Label("[i:2] Increased Max Stacks")]
        [DefaultValue(true)]
        public bool increaseMaxStack;

        [Label("[i:997] Increased Extractinator Speed")]
        [DefaultValue(true)]
        public bool extractSpeed;

        [Label("[i:909] Fountains Cause Biomes")]
        [DefaultValue(true)]
        public bool fountains;

        [Label("[i:3117] Boss Zen")]
        [DefaultValue(true)]
        public bool bossZen;
    }
}