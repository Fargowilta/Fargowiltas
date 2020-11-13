using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Buffs
{
    public class Omnistation : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Description.SetDefault("Effects of all vanilla stations");

            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
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
            }

            int type = Framing.GetTileSafely(player.Center).type;

            if (type == ModContent.TileType<OmnistationTile>() || type == ModContent.TileType<OmnistationTile2>())
            {
                player.AddBuff(BuffID.Honey, 30 * 60 + 1);
            }
        }
    }
}