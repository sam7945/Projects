using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.Platform;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using static Hevadea.Framework.UI.Widget;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Hevadea.Registry;
using Hevadea.Models;
using Hevadea.Entities;
using System.Collections.Generic;
using Hevadea.Scenes.Menus;

namespace Hevadea.Scenes.Tabs
{
    /// <summary>
    ///     7 Octobre 2019
    ///     
    /// *   Tab permettant de choisir un des joueurs de l'utilisateur.
    ///      Lorsque l'utilisateur sélectionne son joueur et clique sur rejoindre Monde,
    ///      la tab rejoindre monde apparait.
    ///      
    /// </summary>
    public class TabChoisirJoueur : Tab
    {
        Account _account;
        IQueryable<WorldPlayer> _worldPlayers;

        public TabChoisirJoueur(Account account)
        {
            _account = account;
            var classTypeList = new WidgetList() { UnitBound = new Rectangle(0, 0, 256, 300) };
            Icon = new Sprite(Resources.TileIcons, new Point(0, 2));


            //WIDGETLABEL : CHOISIR JOUEUR (HAUT, CENTRE)
            var mainLabel = new WidgetLabel()
            {
                Text = "Choose your player",
                Font = Resources.FontAlagard,
                Dock = Dock.Top
            };

            //WIDGETLIST  AFFICHE JOUEURS 
            AfficherJoueursUtilisateur();

            var choisirJoueurOptions = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "Character:", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    classTypeList
                }
            };

            //WIDGETBUTTON "REJOINDRE MONDE" --> VÉRIFICATION SI JOUEUR EST SELECTIONNE
            //                                                                           AFFICHER TABCHOISIRMONDEJOUEUR

            var btnChoisirMonde = new WidgetButton { Text = "Confirm", Dock = Dock.Bottom }.RegisterMouseClickEvent(GoToMenuChoisirMonde);






            //INITIALIATION DU CONTENU

            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                    mainLabel,
                    choisirJoueurOptions,
                    btnChoisirMonde
                }
            };
            /// <summary>
            /// Auteur : Felix Noiseux
            /// Description : Fonction permettant d'afficher les joueurs emregistré d'un utilisateur
            /// </summary>
            void AfficherJoueursUtilisateur()
            {
                var WorldPlayers = REGISTRY.Context.WorldPlayers.Include("Player").Include("World").Where(x => x.Account.ID == _account.ID);
                _worldPlayers = WorldPlayers;
                foreach (Player wp in WorldPlayers.Select(x => x.Player).Distinct())
                {
                    classTypeList.AddItem(new ListItemText(wp.Name));
                }
                if (classTypeList.Items.Count > 0)
                    classTypeList.SelectFirst();
            }
            void GoToMenuChoisirMonde()
            {
                if (classTypeList.SelectedItem != null)
                {
                    string playerName = ((ListItemText)classTypeList.SelectedItem).Text;
                    Rise.Scene.Switch(new MenuChoisirMonde(_worldPlayers.Where(x => x.Player != null && x.Player.Name == playerName), account));
                }
            }



        }

    }
}
