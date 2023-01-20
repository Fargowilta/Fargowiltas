using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace Fargowiltas
{
    public enum SeasonSelections
    {
        [Label("$Mods.Fargowiltas.Config.SeasonSelectionNormal")]
        Normal,
        [Label("$Mods.Fargowiltas.Config.SeasonSelectionAlwaysOn")]
        AlwaysOn,
        [Label("$Mods.Fargowiltas.Config.SeasonSelectionAlwaysOff")]
        AlwaysOff
    }
}
