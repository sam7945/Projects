using Hevadea.Entities.Components;
using Hevadea.Items;
using Hevadea.Registry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Entities
{
    public class Boat : Entity
    {
        public Boat()
        {
            AddComponent(new RendererCreature(Resources.Sprites["entity/boat"]));
            AddComponent(new ComponentBreakable());
            AddComponent(new ComponentCollider(new Rectangle(-8, -8, 16, 16)));
            AddComponent(new ComponentMove());
            AddComponent(new ComponentPushable());
            AddComponent(new ComponentRideable());
            AddComponent(new ComponentSwim());
            AddComponent(new ComponentDropable { Items = { new Drop(ITEMS.BOAT, 1f, 1, 1) } });
            AddComponent(new ComponentPickupable());
            AddComponent(new ComponentLightSource
            { IsOn = false, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });
        }
    }
}
