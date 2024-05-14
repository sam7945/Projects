using System.Collections.Generic;
using Hevadea.Craftings;
using Hevadea.Entities.Components;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.Platform;
using Hevadea.Framework.UI;
using Hevadea.Registry;
using Hevadea.Scenes.Tabs;
using Hevadea.Scenes.Widgets;
using Hevadea.Systems.InventorySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hevadea.Scenes.Menus
{
    public class MenuMap : Menu
    {
        Menu _lastMenu;
        public MenuMap(GameState gameState, Menu lastMenu) : base(gameState)
        {
            InitializeComponents();
            _lastMenu = lastMenu;
        }

        public void InitializeComponents()
        {
            PauseGame = true;

            var closeBtn = new WidgetSprite()
            {
                Sprite = new Sprite(Resources.TileGui, new Point(7, 7)),
                UnitBound = new Rectangle(0, 0, 48, 48),
                Anchor = Anchor.TopRight,
                Origine = Anchor.TopRight,
                UnitOffset = new Point(-24, 24)
            };

            closeBtn.MouseClick += CloseBtnOnMouseClick;

            var _sideMenu = new WidgetTabContainer
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitBound = new Rectangle(0, 0, 600, 720),
                Dock = Rise.Platform.Family == PlatformFamily.Mobile ? Dock.Fill : Dock.None,

                Tabs =
                {
                    new MinimapTab(GameState),
                }
            };

            Content = new LayoutDock()
            {
                Children = { _sideMenu },
            };
        }

        private void CloseBtnOnMouseClick(Widget sender)
        {
            GameState.CurrentMenu = _lastMenu;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Rise.Input.KeyTyped(Keys.M))
            {
                CloseBtnOnMouseClick(this);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.FillRectangle(Rise.Graphic.GetBound(), Color.Black * 0.5f);
            base.Draw(spriteBatch, gameTime);
        }
    }
}
