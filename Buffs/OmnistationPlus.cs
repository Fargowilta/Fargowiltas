//using CalamityMod.CalPlayer;
using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

//using ThoriumMod;

namespace Fargowiltas.Buffs
{
    public class OmnistationPlus : ModBuff
    {
        public override string Texture => "Fargowiltas/Buffs/Omnistation";

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Omnistation+");
            DisplayName.AddTranslation(GameCulture.Chinese,"强化增益站");
            Description.SetDefault("Effects of all stations, vanilla and modded");
            Description.AddTranslation(GameCulture.Chinese,"拥有原版和Mod所有增益站的效果");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[ModContent.BuffType<Omnistation>()] = true;
            player.buffImmune[BuffID.Sunflower] = true;
            player.buffImmune[BuffID.Campfire] = true;
            player.buffImmune[BuffID.HeartLamp] = true;
            player.buffImmune[BuffID.StarInBottle] = true;
            player.buffImmune[BuffID.DryadsWard] = true;

            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(146, 2, quiet: false);
                player.AddBuff(BuffID.Campfire, 2, quiet: false);
                player.AddBuff(BuffID.HeartLamp, 2, quiet: false);
                player.AddBuff(BuffID.StarInBottle, 2, quiet: false);

                //dryad's blessing
                player.lifeRegen += 6;
                player.statDefense += 8;
                if (player.thorns < 1f)
                {
                    player.thorns += 0.2f;
                }

                if (Fargowiltas.ModLoaded("ThoriumMod"))
                {
                    Thorium(player);
                }

                if (Fargowiltas.ModLoaded("CalamityMod"))
                {
                    Calamity(player);
                }
            }

            int type = Framing.GetTileSafely(player.Center).type;

            if (type == ModContent.TileType<OmnistationPlusSheet>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }

        private void Thorium(Player player)
        {
            player.buffImmune[Fargowiltas.LoadedMods["ThoriumMod"].BuffType("SeasonsGreeting")] = true;

            //mistletoe effect
            player.lifeRegenTime++;
            player.lifeRegen++;
            player.manaRegenBonus++;
            player.manaRegenDelayBonus++;

            // TODO: ThoriumPlayer
            // player.GetModPlayer<ThoriumPlayer>().inspirationRegenBonus += 0.02f;
        }

        private void Calamity(Player player)
        {
            Mod calamity = Fargowiltas.LoadedMods["CalamityMod"];

            player.buffImmune[calamity.BuffType("PurpleDefenseCandle")] = true;
            player.buffImmune[calamity.BuffType("YellowDamageCandle")] = true;
            player.buffImmune[calamity.BuffType("PinkHealthCandle")] = true;
            player.buffImmune[calamity.BuffType("BlueSpeedCandle")] = true;

            // TODO: CalamityPlayer
            /*player.GetModPlayer<CalamityPlayer>().purpleCandle = true;
            player.GetModPlayer<CalamityPlayer>().yellowCandle = true;
            player.GetModPlayer<CalamityPlayer>().pinkCandle = true;
            player.GetModPlayer<CalamityPlayer>().blueCandle = true;*/
        }
    }
}
