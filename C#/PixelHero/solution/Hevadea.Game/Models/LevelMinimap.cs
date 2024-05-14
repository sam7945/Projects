using Hevadea.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Models
{

    public class LevelMinimap
    {
        public int LevelMinimapId { get; set; }
        public Level Level { get; set; }
        public Minimap Minimap { get; set; }
        public WorldPlayer WorldPlayer { get; set; }
    }
}
