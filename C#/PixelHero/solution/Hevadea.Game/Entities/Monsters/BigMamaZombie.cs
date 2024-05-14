using Hevadea.Entities.Blueprints;
using Hevadea.Entities.Components;
using Hevadea.Entities.Components.AI;
using Hevadea.Entities.Components.AI.Behaviors;
using Hevadea.Framework;
using Hevadea.Framework.Graphic;
using Hevadea.Registry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities.Monsters
{
    class BigMamaZombie : Monster, IBoss
    {
        public EntityBlueprint Minion { get; } = ENTITIES.ZOMBIE;
        public BigMamaZombie()
        {
            AddComponent(new ComponentFlammable());

            AddComponent(new Agent(new BehaviorBoss
            {
                MoveSpeedAgro = 1f,
                MoveSpeedWandering = 0.5f,
                NaturalEnvironment =
                {
                    TILES.DIRT,
                    TILES.GRASS,
                    TILES.SAND,
                    TILES.WOOD_FLOOR
                }
            }));     
            
            AddComponent(new RendererCreature(Resources.Sprites["entity/0_mama_zombie"]));

            AddComponent(new ComponentAttack());
            AddComponent(new ComponentCollider(new Rectangle(-2, -4, 4, 4)));
            //AddComponent(new ComponentCollider(new Rectangle(-8, -16, 16, 16)));
            AddComponent(new ComponentHealth(100));
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentDropExperience(20));
            AddComponent(new ComponentLightSource
            { IsOn = false, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });

            Damage = 18;
            DamageCritical = 24;
            CriticalHit = 0.1f;
            MissHit = 0.2f;
        }
        public override int Attaquer(Entity ennemi)
        {
            Random rnd = new Random();
            var random = rnd.NextDouble();

            if (random < CriticalHit)
            {
                ((ComponentHealth)ennemi.Componenents.Find(x => x is ComponentHealth)).Hurt(this, DamageCritical, false);
                return DamageCritical;
            }
            else if (random < CriticalHit + MissHit)
            {
                ((ComponentHealth)ennemi.Componenents.Find(x => x is ComponentHealth)).Hurt(this, 0, false);
                return 0;
            }
            else
            {
                ((ComponentHealth)ennemi.Componenents.Find(x => x is ComponentHealth)).Hurt(this, Damage, false);
                return Damage;
            }
        }
    }
}
