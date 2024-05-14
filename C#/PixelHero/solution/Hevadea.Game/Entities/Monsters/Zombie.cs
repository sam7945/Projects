using Hevadea.Entities.Components;
using Hevadea.Entities.Components.AI;
using Hevadea.Entities.Components.AI.Behaviors;
using Hevadea.Registry;
using Microsoft.Xna.Framework;
using System;

namespace Hevadea.Entities.Monsters
{
    public class Zombie : Monster
    {
        public Zombie()
        {
            AddComponent(new ComponentFlammable());
            AddComponent(new ComponentCastShadow());

            AddComponent(new Agent(new BehaviorEnemy
            {
                MoveSpeedAgro = 0.75f,
                MoveSpeedWandering = 0.5f,
                NaturalEnvironment =
                {
                    TILES.DIRT,
                    TILES.GRASS,
                    TILES.SAND,
                    TILES.WOOD_FLOOR
                }
            }));

            AddComponent(new RendererCreature(Resources.Sprites["entity/zombie"]));

            AddComponent(new ComponentAttack());
            AddComponent(new ComponentCollider(new Rectangle(-2, -2, 4, 4)));
            AddComponent(new ComponentHealth(50));
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentDropExperience(6));
            AddComponent(new ComponentLightSource
            { IsOn = false, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });

            Damage = 12;
            DamageCritical = 18;
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