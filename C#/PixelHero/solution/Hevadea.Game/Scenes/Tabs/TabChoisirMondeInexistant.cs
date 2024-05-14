using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Models;
using Hevadea.Registry;
using Hevadea.Scenes.Menus;
using Hevadea.Scenes.Widgets;
using Hevadea.Worlds;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Hevadea.Scenes.Tabs
{
    /// <summary>
    ///     7 Octobre 2019
    ///     
    /// *   Tab permettant de choisir un monde dont le
    ///     personnage choisi ne fait pas encore parti.
    ///     
    /// </summary>
    public class TabChoisirMondeInexistant : Tab
    {
        private IQueryable<WorldPlayer> _worldPlayers;
        private IQueryable<World> _worlds;


        public TabChoisirMondeInexistant(IQueryable<WorldPlayer> worldPlayers, Account account)
        {
            _worldPlayers = worldPlayers;
            Icon = new Sprite(Resources.TileIcons, new Point(0, 2));
            var mondes = new WidgetList() { UnitBound = new Rectangle(0, 0, 256, 300) };


            var mainLabel = new WidgetLabel()
            {
                Text = "Worlds",
                Font = Resources.FontAlagard,
                Dock = Dock.Top
            };
            AfficherMondes();

            var choisirMonde = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "Online Worlds", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    mondes,
                }
            };



            WidgetBackButton backBtn = new WidgetBackButton((sender) =>
            {
                Game.GoToMenuLogin(account);
            });
            var btnRejoindreMonde = new WidgetButton
            {
                Text = "Join",
                Dock = Dock.Bottom
            }.RegisterMouseClickEvent((sender) =>
            {
                ListItem item = mondes.SelectedItem;
                ListItemText texte = (ListItemText)item;
                string monde = texte?.Text;
                if (item != null && monde != null)
                {
                    WorldPlayer worldPlayer = new WorldPlayer
                    {
                        Account = account,
                        Player = _worldPlayers.FirstOrDefault().Player,
                        World = _worlds.FirstOrDefault(x => x.Name == monde),

                    };
                    account.WorldPlayers.Add(worldPlayer);
                    REGISTRY.Context.SaveChanges();
                    Game.WorldPlayer = worldPlayer;
                    Game.Play(Game.SavesFolder + monde + "/");
                }


                //TODO : REJOINDRE MONDE AVEC LE MONDE RECUPEERER


            });
            var btnCreerMonde = new WidgetButton
            {
                Text = "Create World",
                Dock = Dock.Bottom
            }.RegisterMouseClickEvent((sender) =>
            {
                Rise.Scene.Switch(new MenuCreationMonde(account,_worldPlayers));          



                //TODO : REJOINDRE MONDE AVEC LE MONDE RECUPEERER


            });


            //INITIALISATION DU CONTENU
            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                    mainLabel,
                    choisirMonde,
                    btnRejoindreMonde,
                    btnCreerMonde,
                    backBtn
                }
            };
            void AfficherMondes()
            {
                var worlds = REGISTRY.Context.Worlds.Where(x => !_worldPlayers.Any(a => a.World == x));
                _worlds = worlds;
                foreach (World world in worlds)
                {
                    mondes.AddItem(new ListItemText(world.Name));
                }
                if (mondes.Items.Count > 0)
                    mondes.SelectFirst();
            }
        }
    }
}
