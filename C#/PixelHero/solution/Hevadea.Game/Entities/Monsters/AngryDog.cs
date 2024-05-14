using Hevadea.Entities.Blueprints;
using Hevadea.Entities.Components;
using Hevadea.Entities.Components.AI;
using Hevadea.Entities.Components.AI.Behaviors;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Registry;
using Microsoft.Xna.Framework;

namespace Hevadea.Entities
{
    public class AngryDog : Entity
    {
        public AngryDog()
        {

            //Stats zombie + speed - vie 
            AddComponent(new ComponentFlammable());
            AddComponent(new ComponentCastShadow());

            AddComponent(new Agent(new BehaviorEnemy
            {
                MoveSpeedAgro = 1.2f,
                MoveSpeedWandering = 0.8f,
                NaturalEnvironment =
                {
                    TILES.DIRT,
                    TILES.GRASS,
                    TILES.SAND,
                    TILES.WOOD_FLOOR
                }
            }));

            AddComponent(new RendererCreature(Resources.Sprites["entity/dog3"]));

            AddComponent(new ComponentAttack());
            AddComponent(new ComponentCollider(new Rectangle(-2, -2, 4, 4)));
            AddComponent(new ComponentEnergy());
            AddComponent(new ComponentHealth(3));
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentDropExperience(4));
            AddComponent(new ComponentLightSource
            { IsOn = false, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });

        }

        public void SpawnDog(Dog dog)
        {
            this.X = dog.X;
            this.Y = dog.Y;
            this.Level = dog.Level;
            this.GameState = dog.GameState;
            this.Position = dog.Position;
            this.ParticleSystem = dog.ParticleSystem;
            this.World = dog.World;
        }

    }
}