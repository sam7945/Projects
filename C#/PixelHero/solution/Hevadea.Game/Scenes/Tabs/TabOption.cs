using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;

namespace Hevadea.Scenes.Tabs
{
    public class TabOption : Tab
    {
        /// <param name="exitOrBack">false = back to menu | true = exit the app</param>
        public TabOption(bool exitOrBack)
        {

            Icon = new Sprite(Resources.TileIcons, new Point(2, 4));
            var informations = new WidgetLabel
            {
                Text = "Projet de session 2019 \n Membres de l'equipe",
                Dock = Dock.Top,
                Font = Resources.FontRomulus,
                TextSize = 1f
            };

            var felixButton = new WidgetButton
            {
                Text = "Felix",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -210),
                UnitBound = new Rectangle(0, 0, 256, 64)
            };
            var maxButton = new WidgetButton
            {
                Text = "Maxime",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -136),
                UnitBound = new Rectangle(0, 0, 256, 64),
            };
            var loikButton = new WidgetButton
            {
                Text = "Loik",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -62),
                UnitBound = new Rectangle(0, 0, 256, 64),
            };
            var raphButton = new WidgetButton
            {
                Text = "Raphael",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 12),
                UnitBound = new Rectangle(0, 0, 256, 64),
            };
            var alexButton = new WidgetButton
            {
                Text = "Alexandre",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 86),
                UnitBound = new Rectangle(0, 0, 256, 64),
            };
            var samButton = new WidgetButton
            {
                Text = "Samuel",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 160),
                UnitBound = new Rectangle(0, 0, 256, 64),
            };


            if (exitOrBack == false)
            {
                Content = new LayoutDock
                {

                    Padding = new Spacing(16),
                    Children =
                {
                    informations,
                    felixButton,
                    maxButton,
                    loikButton,
                    raphButton,
                    alexButton,
                    samButton,
                    new WidgetButton {Text = "Menu", Dock = Dock.Bottom}
                        .RegisterMouseClickEvent(Game.GoToMainMenu)
            },
                };
            }
            else
            {
                Content = new LayoutDock
                {

                    Padding = new Spacing(16),
                    Children =
                {
                    informations,
                    felixButton,
                    maxButton,
                    loikButton,
                    raphButton,
                    alexButton,
                    samButton,
                    new WidgetButton {Text = "Fermer Pixel Hero", Dock = Dock.Bottom}
                        .RegisterMouseClickEvent((sender) => Rise.Platform.Stop())
                },
                };
            }
        }

    }
}