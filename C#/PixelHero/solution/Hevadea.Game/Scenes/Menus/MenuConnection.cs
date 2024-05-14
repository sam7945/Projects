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
using Hevadea.Registry;
using System.Threading;

namespace Hevadea.Scenes.Menus
{
    public class MenuConnection : Scene
    {


        WidgetTextBox textBoxUserName = new WidgetTextBox
        {
            Padding = new Spacing(8),
            Text = "",
            UnitBound = new Rectangle(0, 0, 256, 36)
        };
        WidgetPassword textBoxPassword = new WidgetPassword
        {
            Padding = new Spacing(8),
            Text = "",
            UnitBound = new Rectangle(0, 0, 256, 36)
        };
        WidgetButton buttonConnect = new WidgetButton
        {
            Padding = new Spacing(16),
            Text = "Connexion | S'enregistrer",
            Dock = Dock.Bottom
        };
        private static bool loading = false;

        private static void ClickButtonLoginOrRegister(string username, string password)
        {


            Account account = null;
            new Thread(new ThreadStart(() =>
            {
                loading = true;
                account = Login(username, password);
                //TODO:Loading bar
                if (account != null)
                {
                    //login le joueur sur son compte

                    //si compte existe // passer le username en paramètre
                    Game.GoToMenuLogin(account);
                }
                else
                {
                    //Le redirigé vers le menu Register
                    Game.GoToMenuRegister(username, password);
                }
            })).Start();
        }

        public override void Load()
        {

            #region Widgets
            //1
            var informations = new WidgetLabel
            {

                Text = "Login -|- Register",
                UnitBound = new Rectangle(0, 0, 256, 64),
                Dock = Dock.Top,
                Font = Resources.FontAlagard,
            };
            //2
            var labelUserName = new WidgetLabel
            {
                Text = "Enter your username",
                Padding = new Spacing(8),
                TextAlignement = TextAlignement.Left
            };
            //3
            var labelPassword = new WidgetLabel
            {
                Text = "Enter your password",
                Padding = new Spacing(8),
                TextAlignement = TextAlignement.Left
            };

            var logo = new WidgetImage
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                //UnitOffset = new Point(0, Int32.Parse((this.textBoxPassword.UnitHost.Height).ToString())),
                Scale = 0.52f,
                Picture = Rise.Resources.GetImage("logo")
            };

            var logoLayout = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    new WidgetLabel
                        {Text = "", Padding = new Spacing(0), TextAlignement = TextAlignement.Center },
                    new WidgetLabel
                        {Text = "", Padding = new Spacing(0), TextAlignement = TextAlignement.Center },

                    logo
                }
            };

            buttonConnect.RegisterMouseClickEvent(ClickConnect);
            #endregion

            void ClickConnect()
            {
                ClickButtonLoginOrRegister(textBoxUserName.Text.TrimEnd(' ').TrimStart(' '), textBoxPassword.Text.TrimEnd(' ').TrimStart(' '));
            }

            var layoutflow = new LayoutFlow()
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,

                Children =
                {
                    informations,
                    labelUserName,
                    textBoxUserName,
                    labelPassword,
                    textBoxPassword,
                    logoLayout
                }

            };
            var homeTab = new Tab
            {
                Icon = new Sprite(Resources.TileIcons, new Point(0, 4)),
                Content = new LayoutDock()
                {
                    Padding = new Spacing(16),
                    Children =
                    {
                        layoutflow,
                        buttonConnect
                    }
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
                    homeTab,
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
            if (textBoxUserName.Text.Trim(' ') != "" && textBoxPassword.Text.Trim(' ') != "")
            {
                buttonConnect.Enabled = true;
            }
            else
            {
                buttonConnect.Enabled = false;
            }
            if (loading)
            {
                LoadingTab l = new LoadingTab();
                ((WidgetTabContainer)((LayoutDock)Container).Children.FirstOrDefault()).Tabs.Add(l);
                ((WidgetTabContainer)((LayoutDock)Container).Children.FirstOrDefault()).SelectedTab = l;
                ((WidgetTabContainer)((LayoutDock)Container).Children.FirstOrDefault()).Tabs.RemoveAll(x => x != l);

                loading = false;
            }
        }

        public override void Unload()
        {
        }
        #region À mettre dans la page register
        //Mettre les méthodes private
        private static Account Login(string UserName, string Password)
        {
            Account account = new Account(UserName, Password);
            //TODO: Ajouter ThenInclude World et ThenInclude Player

            return REGISTRY.Context.Accounts.Include("WorldPlayers").FirstOrDefault(x => x.UserName == account.UserName && x.Password == account.Password);
        }

        #endregion
    }
}
