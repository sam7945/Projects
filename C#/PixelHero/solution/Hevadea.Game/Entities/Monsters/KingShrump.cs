using Hevadea.Entities.Blueprints;
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
    class KingShrump:Monster, IBoss
    {
        public KingShrump()
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

            AddComponent(new RendererCreature(Resources.Sprites["entity/king_shrump"]));

            AddComponent(new ComponentAttack());
            AddComponent(new ComponentCollider(new Rectangle(-4, -8, 8, 8)));
            AddComponent(new ComponentHealth(120));
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentDropExperience(15));
            AddComponent(new ComponentLightSource
            { IsOn = false, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });
            Damage = 20;
            DamageCritical = 40;
            CriticalHit = 0.15f;
            MissHit = 0.3f;
        }

        public EntityBlueprint Minion { get; } = ENTITIES.DARKTREE;

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
