using Hevadea.Entities;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Hevadea.Entities.Components;
using System.Collections.Generic;

namespace Hevadea.Scenes.Widgets
{
    /// <summary>
    /// Auteur : Felix Noiseux
    /// Description : Widget Servant a afficher le niveau de vie restant d'un Entite
    /// Date : 6 Novembre 2019
    /// </summary>
    public class WidgetEntitiesStats : Widget
    {
        private readonly Sprite _halfHearth;
        private readonly Sprite _hearth;
        private readonly Sprite _emptyHearth;
        private readonly Entity _entity;

        public WidgetEntitiesStats(Entity entity)
        {
            _entity = entity;
            _hearth = new Sprite(Resources.TileIcons, 0);
            _halfHearth = new Sprite(Resources.TileIcons, 23);
            _emptyHearth = new Sprite(Resources.TileIcons, 7);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var health = 0.0f;
            var maxHealth = 0.0f;
            var energy = 0.0f;

            if (!_entity.HasComponent<ComponentHealth>()) return;

            if (_entity.HasComponent<ComponentEnergy>())
                energy = _entity.GetComponent<ComponentEnergy>().ValuePercent;

            health = _entity.GetComponent<ComponentHealth>().Value;
            maxHealth = _entity.GetComponent<ComponentHealth>().MaxValue;

            var size = Scale(40);

    
            for (int i = 0; i <= (maxHealth/10)-1; i++)
            {
                int FullHearts = (int)(health / 10);
                if (FullHearts > i)
                    _hearth.Draw(spriteBatch, new Rectangle(Bound.X + size * i, Bound.Y, size, size), Color.White);
                else if (FullHearts == i && health > 0)
                {
                    _halfHearth.Draw(spriteBatch, new Rectangle(Bound.X + size * i, Bound.Y, size, size), Color.White);
                }
                else
                    _emptyHearth.Draw(spriteBatch, new Rectangle(Bound.X + size * i, Bound.Y, size, size), Color.White);
            }

        }
    }
}