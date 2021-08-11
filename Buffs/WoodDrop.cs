using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Fargowiltas.Buffs
{
    public class WoodDrop : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wood Drop");
            DisplayName.AddTranslation(GameCulture.Chinese,"化木");
            Main.buffNoSave[Type] = true;
        }
    }
}
