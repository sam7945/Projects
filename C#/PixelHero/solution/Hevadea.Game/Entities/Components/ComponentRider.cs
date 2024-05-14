using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hevadea.Registry;
using Hevadea.Storage;
using Hevadea.Systems.InventorySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hevadea.Entities.Components
{
    public class ComponentRider : EntityComponent, IEntityComponentSaveLoad, IEntityComponentInitialize
    {
        public Entity Ride { get; set; }
        /// <summary>
        /// Le temps depuis lequel le joueur est dur l'objet
        /// </summary>
        public int RidingFor { get; set; } = 0;
        public int Help { get; set; }

       
        /// <summary>
        /// Si le personnage était dahns un objet il recommence avec
        /// </summary>
        public void OnGameInitialize()
        {
            if (Ride != null)
            {
                if (Owner.GetComponent<ComponentInventory>().Content.Count(Owner.HoldedItem()) == 0)
                    Owner.HoldItem(null);
                Owner.GetComponent<ComponentInteract>().Do(Owner.HoldedItem());
            }
        }
        /// <summary>
        /// Load le fait que le personnage était sur un objet
        /// </summary>
        /// <param name="store"></param>
        public void OnGameLoad(EntityStorage store)
        {           
            var entityType = store.ValueOf("ride_entity_type", "null");

            if (entityType != "null")
            {
                var entityData = store.ValueOf("ride_entity_data", new Dictionary<string, object>());
                var entity = ENTITIES.Construct(entityType);
                entity.Load(new EntityStorage(entityType, entityData));
                Ride = entity;
            }
        }
        /// <summary>
        /// Sauvegarde que le personnage est sur un objet
        /// </summary>
        /// <param name="store"></param>
        public void OnGameSave(EntityStorage store)
        {
            if (Ride != null)
            {
                store.Value("ride_entity_type", Ride.Blueprint.Name);
                store.Value("ride_entity_data", Ride.Save().Data);
            }
        }

    }
}
