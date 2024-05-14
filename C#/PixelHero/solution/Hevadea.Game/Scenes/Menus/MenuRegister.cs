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
    public class MenuRegister : Scene
    {
        string _username;
        string _password;
        static bool loading;
        static WidgetLabel informations = new WidgetLabel
        {
            Text = "Register",
            UnitBound = new Rectangle(0, 0, 256, 64),
            Dock = Dock.Top,
            Font = Resources.FontAlagard,
        };
        public MenuRegister(string username, string password)
        {
            _password = password;
            _username = username;
        }

        WidgetTextBox textBoxUserName = new WidgetTextBox
        {
            Padding = new Spacing(8),
            UnitBound = new Rectangle(0, 0, 256, 36)
        };
        WidgetPassword textBoxPassword = new WidgetPassword
        {
            Padding = new Spacing(8),
            UnitBound = new Rectangle(0, 0, 256, 36)
        };
        WidgetPassword textBoxConfirmPassword = new WidgetPassword
        {
            Padding = new Spacing(8),
            Text = "",
            UnitBound = new Rectangle(0, 0, 256, 36)
        };
        WidgetButton buttonRegister = new WidgetButton
        {
            Padding = new Spacing(16),
            Text = "Register",
            Dock = Dock.Bottom
        };

        private static void ClickButtonRegister(string username, string password)
        {
            Account account = null;
            new Thread(new ThreadStart(() =>
            {
                loading = true;
                account = Register(username, password);
                if (account != null)
                {
                    Game.GoToMenuLogin(account);
                }
                else
                {
                    //TODO: Pop-up erreur
                    informations.Text = "Username taken";
                }
            })).Start();
        }
        private static Account Register(string userName, string password)
        {
            if (REGISTRY.Context.Accounts.Any(x => x.UserName == userName))
                return null;
            Account account = new Account(userName, password);
            REGISTRY.Context.Accounts.Add(account);
            REGISTRY.Context.SaveChanges();
            return account;
        }

        public override void Load()
        {

            #region Widgets

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
            var labelConfirmPassword = new WidgetLabel
            {
                Text = "Password confirmation",
                Padding = new Spacing(8),
                TextAlignement = TextAlignement.Left
            };
            var logo = new WidgetImage
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 95),
                Scale = 0.41f,
                Picture = Rise.Resources.GetImage("logo")
            };
            buttonRegister.RegisterMouseClickEvent(ClickRegister);
            textBoxPassword.Text = _password;
            textBoxUserName.Text = _username;
            #endregion

            void ClickRegister()
            {
                if (textBoxConfirmPassword.Text == textBoxPassword.Text)
                    ClickButtonRegister(textBoxUserName.Text, textBoxPassword.Text);
                else
                {
                    informations.Text = "Confirmation is not like password!";
                }
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
                    labelConfirmPassword,
                    textBoxConfirmPassword,
                    logo
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
                        buttonRegister
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
            if (textBoxUserName.Text.Trim(' ') != "" && textBoxPassword.Text.Trim(' ') != "" && textBoxConfirmPassword.Text.Trim(' ') != "")
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                buttonRegister.Enabled = false;
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
    }
}
