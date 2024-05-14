using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Items;
using Hevadea.Items.Tags;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Hevadea.Entities.Components
{
    public static class EntityExtension
    {
        /// <summary>
        /// Permet de lever un objet du sol.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="target"></param>
        public static void Pickup(this Entity entity, Entity target)
        {
            entity.GetComponent<ComponentPickup>()?.PickupEntity(target);
        }
        /// <summary>
        /// Permet de monteru sur un bateau
        /// </summary>
        /// <param name="entity">Joueur</param>
        /// <param name="ride">Bateau</param>
        public static void Mount(this Entity entity, Entity ride)
        {
            if (ride.HasComponent<ComponentRideable>() && ride.GetComponent<ComponentRideable>().Rider == null)
            {
                ride.GetComponent<ComponentRideable>().Rider = entity;
                entity.GetComponent<ComponentRider>().Ride = ride;
                entity.Remove();
            }
        }
        /// <summary>
        /// Permet de descendre du bateau
        /// </summary>
        /// <param name="entity">player</param>
        public static void UnMount(this Entity entity)
        {
            if (entity.IsRiding())
            {
                var ComponentRider = entity.GetComponent<ComponentRider>();
                Entity ride = ComponentRider.Ride;


                var safePlaces = new List<Coordinates>();

                foreach (var coords in ride.Level.QueryCoordinates(ride.Position, Game.Unit * 3))
                {
                    if (!ride.Level.AnyEntityAt(coords) && !ride.Level.GetTile(coords).BlockLineOfSight)
                    {
                        safePlaces.Add(coords);
                    }
                }
                Coordinates closestPlace = null;
                float distance = 0;
                Vector2 ridePostion = ride.Position;
                switch (ride.Facing)
                {
                    case Utils.Direction.North:
                        ridePostion.Y -= 30;
                        //Pour Pickup
                        entity.Facing = Utils.Direction.South;
                        break;
                    case Utils.Direction.East:
                        ridePostion.X += 10;
                        entity.Facing = Utils.Direction.West;
                        break;
                    case Utils.Direction.South:
                        ridePostion.Y += 10;
                        entity.Facing = Utils.Direction.North;
                        break;
                    case Utils.Direction.West:
                        ridePostion.X -= 30;
                        entity.Facing = Utils.Direction.East;
                        break;
                   
                }
                //Trouve une case approprié pour débarquer
                foreach (Coordinates place in safePlaces)
                {
                    float distance1 = Mathf.Distance(place.ToVector2World(), ridePostion);

                    if ((closestPlace == null || distance1 < distance) && place != ride.Coordinates)
                    {
                        closestPlace = place;
                        distance = distance1;
                    }

                }
                //Place le joueur dans le jeu
                if (closestPlace != null)
                {
                    ComponentRider.RidingFor = 0;
                    entity.GetComponent<ComponentRider>().Ride = null;
                    ride.GetComponent<ComponentRideable>().Rider = null;
                    ride.Level.AddEntityAt(entity, closestPlace);
                }
            }
        }

        public static void InteractWith(this Entity entity, Entity target, Item item = null)
        {
            if (!entity.IsHolding())
            {
                if (target.HasComponent<ComponentInteractive>(out var interactable))
                {
                    interactable.Interacte(entity, entity.Facing, item);
                }
                else if (target.HasComponent<ComponentRideable>())
                {
                    entity.Mount(target);
                }
                else if (target.HasComponent<ComponentFlammable>()) {
                    InteractWith(entity, entity.FacingCoordinates, item);
                }
            }
        }

        public static void InteractWith(this Entity entity, Coordinates coords, Item item = null)
        {
            item?.Tag<InteractItemTag>()?.InteracteOn(entity, coords);
        }

        public static bool IsMoving(this Entity entity)
        {
            return entity.GetComponent<ComponentMove>()?.IsMoving ?? false;
        }

        public static bool IsSwimming(this Entity entity)
        {
            return entity.GetComponent<ComponentSwim>()?.IsSwiming ?? false;
        }

        public static bool IsHolding(this Entity entity)
        {
            return entity.GetComponent<ComponentPickup>()?.PickedUpEntity != null ||
                   entity.GetComponent<ComponentRideable>()?.Rider != null ||
                   (entity.GetComponent<ComponentInventory>()?.HasPickup ?? false);
        }

        public static bool IsRiding(this Entity entity)
        {
            ComponentRider Component = entity.GetComponent<ComponentRider>();
            return Component?.Ride != null && Component.RidingFor > 20;
        }

        public static Entity GetHoldedEntity(this Entity entity)
        {
            if (entity.HasComponent<ComponentPickup>())
            {
                return entity.GetComponent<ComponentPickup>().PickedUpEntity;
            }
            else if (entity.HasComponent<ComponentRideable>())
            {
                return entity.GetComponent<ComponentRideable>().Rider;
            }
            else
            {
                return null;
            }
        }
    }
}