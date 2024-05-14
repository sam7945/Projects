using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.Platform;
using Hevadea.Framework.UI;
using Hevadea.Models;
using Hevadea.Scenes.Tabs;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Hevadea.Scenes.Menus
{
    public class MenuChoisirMonde : Scene
    {
        IQueryable<WorldPlayer> _worldPlayers;
        private Account _account;

        public MenuChoisirMonde(IQueryable<WorldPlayer> worldPlayers, Account account)
        {
            _worldPlayers = worldPlayers;
            _account = account;
        }
        public override void Load()
        {
            Rise.Sound.Play(Resources.Theme0);

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

            var menu = new WidgetTabContainer
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitBound = new Rectangle(0, 0, 600, 720),
                TabAnchore = Rise.Platform.Family == PlatformFamily.Mobile ? TabAnchore.Bottom : TabAnchore.Left,
                Tabs =
                {
                    new TabChoisirMondeExistant(_worldPlayers,_account),
                    new TabChoisirMondeInexistant(_worldPlayers, _account),
                    new TabOption(false)
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