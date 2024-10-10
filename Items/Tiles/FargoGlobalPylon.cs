using Fargowiltas.Common.Configs;
using Fargowiltas.Items.Tiles;
using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Fargowiltas.Tiles
{
    public class FargoGlobalPylon : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
        {
            if (FargoServerConfig.Instance.PylonsIgnoreEvents && !FargoGlobalNPC.AnyBossAlive())
                return true;
            
            return base.ValidTeleportCheck_PreAnyDanger(pylonInfo);
        }
    }
}