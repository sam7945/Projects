using Hevadea.Entities;
using Hevadea.Entities.Components;
using Hevadea.Entities.Monsters;
using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Hevadea.Systems.InventorySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace Hevadea.Scenes.Menus
{
    public class MenuAttaque : Menu
    {
        private Entity _player;
        private Entity _ennemi;
        int imageX = 15;
        int imageY = -50;
        int imageEnnemiX = 15;
        int imageEnnemiY = -50;
        WidgetLabel lblAnimations;
        WidgetLabel lblAnimationsEnnemi;
        WidgetImage imgHero;
        WidgetImage imgEnnemi;
        WidgetButton btnAttaquer;
        WidgetButton btnQuitter;
        bool Combat = false;
        bool CombatEnnemi = false;
        bool Depart = false;
        bool DepartEnnemi = false;

        public MenuAttaque(Entity ennemi, GameState gameState) : base(gameState)
        {
            //DefaultBehavior
            PauseGame = true;
            EscapeToClose = false;


            //GetCurrentPlayerAndEnnemi
            _player = GameState.LocalPlayer.Entity;
            _ennemi = ennemi;

            //GetHeroName
            string nomHero = _player.Identifier;
            string nomEnnemi = _ennemi.Identifier;




            //Widgets AND Events
            #region WidgetsAndEvents

            //Load Stats Player (Vie)
            var playerStats = new WidgetEntitiesStats(_player);
            //Load Stats Ennemi (Vie)
            var ennemiStats = new WidgetEntitiesStats(_ennemi);
            Texture2D t;
            if (_player.HoldedItem()?.Sprite?.GetTexture() != null)
            {
                t = _player.HoldedItem().Sprite.GetTexture();
            }
            else
            {
                t = new Texture2D(Rise.MonoGame.GraphicsDevice, 16, 16);
            }
            //Load ItemJoueur           
            var itemJoueur = new WidgetImage()
            {
                Anchor = Anchor.Right,
                Origine = Anchor.Right,
                UnitOffset = new Point(imageX, imageY),
                Scale = 3.0f,
                Picture = t
            };

            lblAnimations = new WidgetLabel()
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                Text = "",
            };
            lblAnimationsEnnemi = new WidgetLabel()
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                Text = "",
            };

            //Load ImageHero
            imgHero = new WidgetImage()
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(imageX, imageY),
                Scale = 3.0f,
                Picture = _player.GetComponent<RendererCreature>()._defaultSprite.SubSprite(1, 1).getSubTextureHero()
            };
            //Load ImageEnnemi
            imgEnnemi = new WidgetImage()
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(imageEnnemiX, imageEnnemiY),
                Scale = 3.0f,
                Picture =  _ennemi.GetComponent<RendererCreature>()._defaultSprite.SubSprite(0, 1).getSubTextureEnnemi()
            };
            //Load le bouton Attaquer 
            btnAttaquer = new WidgetButton
            {
                Text = "Attaquer",
                UnitBound = new Rectangle(0, 0, 0, 50),
            };
            //Load le bouton fuir
            btnQuitter = new WidgetButton
            {
                Text = "Fuir",
                UnitBound = new Rectangle(0, 0, 0, 50),
            };
            //LabelVide, servant de saut de ligne
            var lblVide = new WidgetLabel
            {
                Text = "",
                Padding = new Spacing(8),
                TextAlignement = TextAlignement.Center
            };

            //Events
            btnQuitter.MouseClick += CloseBtnOnMouseClick;
            btnAttaquer.MouseClick += BtnAttaquer_MouseClick;

            #endregion

            //FLOW AMI
            #region InformationsFlow

            var informationsLayout = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Top,
                Children =
                {
                  //HealtBar
                  playerStats,


                  itemJoueur
                }
            };

            #endregion
            #region ImageJoueurFllow
            var imageJoueurFlow = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    lblVide,
                    lblAnimations,
                    lblVide,
                    lblVide,
                    imgHero
                }
            };
            #endregion
            #region fonctionsFlow
            var fonctionsFlow = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Bottom,
                Children =
                {
                    btnAttaquer,
                }
            };
            #endregion

            //FlOW ENNEMI
            #region InformationsFlowEnnemi
            var informationsLayoutEnnemi = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                  {
                     //HealtBar
                     ennemiStats,
                  }
            };

            #endregion
            #region ImageJoueurFlowEnnemi
            var imageJoueurFlowEnnemi = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Fill,
                Children =
                {
                    lblVide,
                    lblAnimationsEnnemi,
                    lblVide,
                    lblVide,
                    lblVide,
                    imgEnnemi
                }
            };
            #endregion
            #region fonctionsFlowEnnemi
            var fonctionsFlowEnnemi = new LayoutFlow
            {
                Flow = LayoutFlowDirection.TopToBottom,
                Dock = Dock.Bottom,
                Children =
                {
                    btnQuitter,
                }
            };
            #endregion

            //AffichagePrincipal
            #region LayoutDock

            //Load partie Gauche
            var widgetAmi = new LayoutDock()
            {
                Dock = Dock.Fill,
                Padding = new Spacing(4, 4),
                Children =
                  {
                      informationsLayout,
                      imageJoueurFlow,
                      fonctionsFlow
                  }
            };

            //Load partie Droite
            var widgetEnnemi = new LayoutDock()
            {
                Dock = Dock.Fill,
                Padding = new Spacing(4, 4),
                Children =
                  {
                      informationsLayoutEnnemi,
                      imageJoueurFlowEnnemi,
                      fonctionsFlowEnnemi
                  }
            };

            //Affiche Contenu
            Content = new WidgetFancyPanel()
            {
                Content = new LayoutDock()
                {
                    Children =
                    {
                        new LayoutDock()
                        {
                            Dock = Dock.Fill,
                        },
                        GuiFactory.CreateSplitContainer(new Rectangle(0, 0, 64, 1000), _player.Identifier, widgetAmi, _ennemi.Identifier, widgetEnnemi)
                    }
                }
            };
            #endregion

        }



        //Events
        private void CloseBtnOnMouseClick(Widget sender)
        {
            Random rnd = new Random();
            float escape = rnd.NextFloat(1);
            if (escape <= ((Player)_player).Class.GTFO)
            {
                EndBattleRespawn();
                GameState.CurrentMenu = new MenuInGame(GameState);
            }
            else
            {
                CombatEnnemi = true;
                lblAnimations.Text = "Escape failed";
            }
        }
        private void BtnAttaquer_MouseClick(Widget sender)
        {
            btnAttaquer.Disable();
            btnQuitter.Disable();
            Combat = true;
        }
        private void EndBattleRespawn()
        {
            if (_ennemi.GetComponent<ComponentHealth>().Value<=0)

            {
                ((Player)_player).LastCombat = 0;
                _player.Level.AddEntity(_player);
                //Pour activer l'ajout de boss
                _ennemi.Remove();
            }
            else if (_player.GetComponent<ComponentHealth>().Value <= 0)
            {
                _player.Level.AddEntity(_ennemi);
            }
            else {
                ((Player)_player).LastCombat = 0;
                _player.Level.AddEntity(_player);
                _ennemi.Level.AddEntity(_ennemi);
            }
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            #region Animations
            if (Combat == true)
            {
                lblAnimations.Text = "";
                lblAnimationsEnnemi.Text = "";
                imageX += 50;
                imgHero.UnitOffset = new Point(imageX, imageY);
                if (imageX >= 450)
                {
                    Combat = false;
                    Depart = true;
                    int dmg = ((Player)_player).Attaquer(_ennemi);
                    if (dmg >= ((Player)_player).Class.DamageCritical)
                    {
                        lblAnimations.Text = "Critical hit";
                    }
                    else if (dmg == 0)
                    {
                        lblAnimations.Text = "Miss hit";
                    }
                    else
                    {
                        lblAnimations.Text = "Normal hit";
                    }
                }
            }

            if (Depart == true)
            {
                imageX -= 15;
                imgHero.UnitOffset = new Point(imageX, imageY);
                if (imageX <= 15)
                {
                    Depart = false;
                    CombatEnnemi = true;
                }
            }
            if (CombatEnnemi == true)
            {
                if (_ennemi.GetComponent<ComponentHealth>().Value <= 0.0f)
                {
                    EndBattleRespawn();
                    GameState.CurrentMenu = new MenuInGame(GameState);
                }
                imageEnnemiX -= 50;
                imgEnnemi.UnitOffset = new Point(imageEnnemiX, imageEnnemiY);
                if (imageEnnemiX <= -435)
                {
                    CombatEnnemi = false;
                    DepartEnnemi = true;
                    int dmg = ((Monster)_ennemi).Attaquer(_player);
                    if (dmg == ((Monster)_ennemi).DamageCritical)
                    {
                        lblAnimationsEnnemi.Text = "Critical hit";
                    }
                    else if (dmg == 0)
                    {
                        lblAnimationsEnnemi.Text = "Miss hit";
                    }
                    else
                    {
                        lblAnimationsEnnemi.Text = "Normal hit";
                    }
                }
            }
            if (DepartEnnemi == true)
            {
                imageEnnemiX += 15;
                imgEnnemi.UnitOffset = new Point(imageEnnemiX, imageEnnemiY);
                if (imageEnnemiX >= 15)
                {
                    DepartEnnemi = false;
                    btnAttaquer.Enable();
                    btnQuitter.Enable();
                }
            }

            #endregion
            //if (Rise.Input.KeyTyped(Keys.Escape))
            //{
            //    GameState.CurrentMenu = new MenuGamePaused(GameState,this);
            //}

            base.Update(gameTime);
        }
    }
}