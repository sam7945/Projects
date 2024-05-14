using Hevadea.Framework.Extension;
using Hevadea.Framework.UI;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hevadea.Scenes.Widgets;
using Hevadea.Framework;
using Hevadea.Framework.Graphic;
using Hevadea.Scenes.Tabs;
using Hevadea.Models;

namespace Hevadea.Scenes.Menus
{
    public class MenuLogIn : Scene
    {
        Account _user;
        TabNewPerso tabNewPerso;
        public MenuLogIn(Account user)
        {
            _user = user;
            tabNewPerso = new TabNewPerso(user);
        }
        WidgetButton buttonRegister = new WidgetButton
        {
            Padding = new Spacing(16),
            Text = "Register",
            Dock = Dock.Bottom
        };
        public override void Load()
        {
            #region Widgets
            //1
            var informations = new WidgetLabel
            {

                Text = "Choose a world",
                UnitBound = new Rectangle(0, 0, 256, 64),
                Dock = Dock.Top,
                Font = Resources.FontAlagard,
            };
            var logo = new WidgetImage
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 95),
                Scale = 0.41f,
                Picture = Rise.Resources.GetImage("logo")
            };
            #endregion

            var layoutflow = new LayoutFlow()
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    informations,
                    logo
                }
            };

            var menu = new WidgetTabContainer
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitBound = new Rectangle(0, 0, 600, 720),
                TabAnchore = Rise.Platform.Family == Framework.Platform.PlatformFamily.Mobile ? TabAnchore.Bottom : TabAnchore.Left,
                Tabs =
                {
                    new TabChoisirJoueur(_user),
                    tabNewPerso,
                    new TabOption(false)
                }
            };
            Container = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                menu
                }
            };
        }

        public override void OnDraw(GameTime gameTime)
        {
        }

        public override void OnUpdate(GameTime gameTime)
        {
            if (tabNewPerso.persoNameTextBox.Text.Trim(' ') == "")
                tabNewPerso.confirmButton.Enabled = false;
            else
                tabNewPerso.confirmButton.Enabled = true;
        }

        public override void Unload()
        {
        }
    }
}
