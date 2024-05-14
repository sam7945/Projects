using Hevadea.Entities;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Models;
using Hevadea.Registry;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using System.Linq;
using static Hevadea.Entities.ClassesPlayer.Class;

namespace Hevadea.Scenes.Tabs
{
    public class TabNewPerso : Tab
    {
        public WidgetTextBox persoNameTextBox = new WidgetTextBox();
        public WidgetButton confirmButton = new WidgetButton();
        Classes _classe = Classes.Guerrier;
        public WidgetImage imgArcher = new WidgetImage() { Anchor = Anchor.Center, Origine = Anchor.Center, UnitOffset = new Point(0, 0), Scale = 1.13f, Picture = Rise.Resources.GetImage("icon_archer") };
        public WidgetImage imgMage = new WidgetImage() { Anchor = Anchor.Center, Origine = Anchor.Center, UnitOffset = new Point(0, 0), Scale = 1.13f, Picture = Rise.Resources.GetImage("icon_mage") };
        public WidgetImage imgGuerrier = new WidgetImage() { Anchor = Anchor.Center, Origine = Anchor.Center, UnitOffset = new Point(0, 0), Scale = 1.2f, Picture = Rise.Resources.GetImage("icon_guerrier_selected") };
        private WidgetLabel label = new WidgetLabel { Text = "New character", Font = Resources.FontAlagard, Dock = Dock.Top };
        public TabNewPerso(Account account)
        {
            imgGuerrier.RegisterMouseClickEvent(OnClickPersoGuerrier);
            imgMage.RegisterMouseClickEvent(OnClickPersoMage);
            imgArcher.RegisterMouseClickEvent(OnClickPersoArcher);

            Icon = new Sprite(Resources.TileIcons, new Point(1, 3));
            WidgetBackButton backBtn = new WidgetBackButton((sender) =>
            {
                Game.GoToMenuLogin(account);
            });

            persoNameTextBox.Padding = new Spacing(8);
            persoNameTextBox.Text = "";
            persoNameTextBox.UnitBound = new Rectangle(0, 0, 256, 36);


            confirmButton.Text = "Create";
            confirmButton.Dock = Dock.Bottom;
            confirmButton.RegisterMouseClickEvent(OnClickConfirmation);

            void OnClickConfirmation()
            {
                if (!REGISTRY.Context.Players.Any(x => x.Name == persoNameTextBox.Text))
                {

                    Player player = new Player
                    {
                        Name = persoNameTextBox.Text,
                        Classe = _classe,
                        //TODO: Get Good Health Value
                    };
                    WorldPlayer worldPlayer = new WorldPlayer
                    {
                        Account = account,
                        Player = player

                    };
                    account.WorldPlayers.Add(worldPlayer);
                    REGISTRY.Context.SaveChanges();
                    Game.GoToMenuLogin(account);
                }
                else
                {
                    //TODO:Do a pop-up
                    label.Text = "Name is already taken";
                }

            }

            void OnClickPersoArcher()
            {
                OnClickPersoChange(Classes.Archer);
            }
            void OnClickPersoGuerrier()
            {
                OnClickPersoChange(Classes.Guerrier);
            }
            void OnClickPersoMage()
            {
                OnClickPersoChange(Classes.Mage);
            }

            void OnClickPersoChange(Classes classePerso)
            {
                _classe = classePerso;
                if (classePerso == Classes.Guerrier)
                {
                    imgGuerrier.Picture = Rise.Resources.GetImage("icon_guerrier_selected");
                    imgArcher.Picture = Rise.Resources.GetImage("icon_archer");
                    imgMage.Picture = Rise.Resources.GetImage("icon_mage");

                    imgArcher.Scale = 1.13f;
                    imgMage.Scale = 1.13f;
                    imgGuerrier.Scale = 1.2f;

                }
                else if (classePerso == Classes.Mage)
                {
                    imgMage.Picture = Rise.Resources.GetImage("icon_mage_selected");
                    imgArcher.Picture = Rise.Resources.GetImage("icon_archer");
                    imgGuerrier.Picture = Rise.Resources.GetImage("icon_guerrier");

                    imgArcher.Scale = 1.13f;
                    imgMage.Scale = 1.2f;
                    imgGuerrier.Scale = 1.13f;
                }
                else if (classePerso == Classes.Archer)
                {
                    imgArcher.Picture = Rise.Resources.GetImage("icon_archer_selected");
                    imgMage.Picture = Rise.Resources.GetImage("icon_mage");
                    imgGuerrier.Picture = Rise.Resources.GetImage("icon_guerrier");

                    imgArcher.Scale = 1.2f;
                    imgMage.Scale = 1.13f;
                    imgGuerrier.Scale = 1.13f;
                }
            }

            var archerLayout = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    new WidgetLabel
                        {Text = "Archer", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    imgArcher
                }
            };
            var mageLayout = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "", Padding = new Spacing(8), TextAlignement = TextAlignement.Center },
                    new WidgetLabel
                        {Text = "", Padding = new Spacing(8), TextAlignement = TextAlignement.Center },
                    new WidgetLabel
                        {Text = "Mage", Padding = new Spacing(8), TextAlignement = TextAlignement.Center },
                    imgMage
                }
            };
            var guerrierLayout = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "Warrior", Padding = new Spacing(8), TextAlignement = TextAlignement.Center},
                    imgGuerrier
                }
            };

            var persoOptions = new LayoutFlow//Ajouter les composantes au layout ainsi que les différentes labels
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "Character name:", Padding = new Spacing(8), TextAlignement = TextAlignement.Left},
                    persoNameTextBox,
                    guerrierLayout,
                    archerLayout,
                    mageLayout
                }
            };
            Content = new LayoutDock() //Ajouter le bouton sous le layout précédent
            {
                Padding = new Spacing(16),
                Children =
                {
                    backBtn,
                    label,
                    confirmButton,
                    persoOptions
                }
            };
        }
    }
}