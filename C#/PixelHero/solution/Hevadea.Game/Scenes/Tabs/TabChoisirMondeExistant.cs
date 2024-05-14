using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Models;
using Hevadea.Scenes.Widgets;
using Hevadea.Worlds;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Hevadea.Scenes.Tabs
{
    /// <summary>
    ///     7 Octobre 2019
    ///     
    /// *   Tab permettant de choisir un monde dont
    ///     le personnage choisi fait déjà parti.
    ///     
    /// </summary>
    public class TabChoisirMondeExistant : Tab
    {
        private IQueryable<WorldPlayer> _worldPlayers;

        public TabChoisirMondeExistant(IQueryable<WorldPlayer> worldPlayers,Account account)
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
            WidgetBackButton backBtn = new WidgetBackButton((sender) =>
            {
                Game.GoToMenuLogin(account);
            });

            var choisirMonde = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "World you've already joined", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    mondes,
                }
            };


            var btnRejoindreMonde = new WidgetButton
            {
                Text = "Join",
                Dock = Dock.Bottom
            }.RegisterMouseClickEvent((sender) =>
            {

                ListItem item = mondes.SelectedItem;
                ListItemText texte = (ListItemText)item;
                string monde = texte?.Text;


                Game.WorldPlayer = _worldPlayers.FirstOrDefault(x=>x.World!=null &&x.World.Name == monde);
                Game.Play(Game.SavesFolder +monde+ "/");
            });

            //INITIALATION DU CONTENU
            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                    mainLabel,
                    choisirMonde,
                    btnRejoindreMonde,
                    backBtn
                }
            };
            void AfficherMondes()
            {
                foreach (World wp in _worldPlayers.Select(x => x.World).Distinct())
                {
                    if (wp != null)
                        mondes.AddItem(new ListItemText(wp.Name));
                }
                if (mondes.Items.Count > 0)
                    mondes.SelectFirst();
            }
        }
    }
}
