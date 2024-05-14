using System;
using System.Collections.Generic;
using System.Linq;
using Hevadea.Entities.Components;
using Hevadea.Framework.Graphic;
using Hevadea.Items;
using Hevadea.Registry;
using Hevadea.Scenes.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hevadea.Entities
{
    public class Furnace : Entity
    {
        public Furnace()
        {
            AddComponent(new ComponentPickupable());
            AddComponent(new RendererSprite(Resources.Sprites["entity/furnace"]));
            AddComponent(new ComponentBreakable());
            AddComponent(new ComponentCollider(new Rectangle(-6, -2, 12, 8)));
            AddComponent(new ComponentDropable { Items = { new Drop(ITEMS.FURNACE, 1f, 1, 1) } });
            AddComponent(new ComponentInteractive()).Interacted += EntityInteracte;
            AddComponent(new ComponentMove());
            //AddComponent(new ComponentPushable());
            AddComponent(new ComponentCastShadow());
            AddComponent(new ComponentLightSource
            { IsOn = true, Color = Color.LightGoldenrodYellow * 0.75f, Power = 96 });
        }

        private void EntityInteracte(object sender, InteractEventArg args)
        {
            GameState.CurrentMenu = new MenuCraftFurnace(args.Entity, this, GameState, GameState.CurrentMenu);
        }
    }
}