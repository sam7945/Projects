using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.Platform;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Tabs;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;

namespace Hevadea.Scenes.Menus
{
    public class MenuMain : Scene
    {
        public override void Load()
        {
            Rise.Sound.Play(Resources.Theme0);

            var logo = new WidgetImage
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -50),
                Scale = 0.6f,
                Picture = Rise.Resources.GetImage("logo")
            };

            var title = new WidgetLabel
            {
                Text = Game.Title,
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -72),
                Font = Resources.FontAlagard,
                TextSize = 3f,
                Disabled = true,
            };

            var subTitle = new WidgetLabel
            {
                Text = Game.SubTitle,
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -16),
                Font = Resources.FontRomulus,
                TextColor = ColorPalette.Accent,
                TextSize = 1f,
                Disabled = true,
            };

            var copyright = new WidgetLabel
            {
                Text = "© 2019-2019 Pixel Hero",
                Anchor = Anchor.Bottom,
                Origine = Anchor.Bottom,
                Font = Resources.FontRomulus,
                TextSize = 1f
            };



            var offlineButton = new WidgetButton
            {
                Text = "Offline",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 190),
                UnitBound = new Rectangle(0, 0, 256, 64),
            }.RegisterMouseClickEvent(Game.GoToMenuOffline);

            var onlineButton = new WidgetButton
            {
                Text = "Online",
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 260),
                UnitBound = new Rectangle(0, 0, 256, 64),
            }.RegisterMouseClickEvent(Game.GoToMenuOnline);

            var version = new WidgetLabel
            {
                Text = $"{Game.Title} {Game.Version}",
                Anchor = Anchor.BottomRight,
                Origine = Anchor.BottomRight,
                UnitOffset = new Point(-16, 0),
                Font = Resources.FontHack,
                TextAlignement = TextAlignement.Right,
                TextColor = Color.White * 0.5f,
                TextSize = 1f,
            };
            var homeTab = new Tab
            {
                Icon = new Sprite(Resources.TileIcons, new Point(0, 4)),
                Content = new LayoutDock()
                {
                    Children =
                    {
                        logo, title, subTitle, copyright, offlineButton, onlineButton
                    }
                }
            };

            var menu = new WidgetTabContainer
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitBound = new Rectangle(0, 0, 600, 720),
                TabAnchore = Rise.Platform.Family == PlatformFamily.Mobile ? TabAnchore.Bottom : TabAnchore.Left,
                Tabs =
            {
                    homeTab,
                    new TabOption(true)
            }
            };
            Container = new LayoutDock().AddChildren(menu, version);
        }

        public override void Unload()
        {
        }

        public override void OnUpdate(GameTime gameTime)
        {
        }

        public override void OnDraw(GameTime gameTime)
        {
        }
    }
}