using Hevadea.Entities.Components;
using Hevadea.Entities.Components.AI;
using Hevadea.Entities.Components.AI.Behaviors;
using Hevadea.Registry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.Monsters
{
    public abstract class Monster : Entity
    {
        public float CriticalHit { get; protected set; }
        public float MissHit { get; protected set; }
        public int Damage { get; protected set; }
        public int DamageCritical { get; protected set; }
        public bool IsInCombat { get; set; }
        public abstract int Attaquer(Entity ennemi);
    }
}
