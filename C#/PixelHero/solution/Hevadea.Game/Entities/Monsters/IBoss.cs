using Hevadea.Entities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.Monsters
{
    public interface IBoss
    {
        EntityBlueprint Minion { get; }
    }
}
