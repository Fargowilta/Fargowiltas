using Fargowiltas.Common.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Common.Systems {
    public class ShopExpanderSupport : ModSystem {

        public static Mod shopExpander = null;

        public override void Load() {
            if (ModLoader.TryGetMod("ShopExpander", out Mod se)) { 
                shopExpander = se;
            }
        }

        public static bool IsModLoaded => shopExpander != null;
        public static bool SupportEnabled => IsModLoaded && FargoClientConfig.Instance.EnableShopExpanderSupport;
        public static int ShopPageSize => Chest.maxItems - (SupportEnabled ? 2 : 0);


    }
}
