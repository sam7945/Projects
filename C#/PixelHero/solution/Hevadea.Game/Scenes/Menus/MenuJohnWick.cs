using Hevadea.Framework;
using Hevadea.Framework.Platform;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Entities.Monsters;
using Hevadea.Registry;

namespace Hevadea.Scenes.Menus
{
    public class MenuJohnWick : Menu
    {
        public MenuJohnWick(GameState gameState, Entities.Entity dog) : base(gameState)
        {
            Content = new LayoutDock
            {
                Children =
                {
                    new WidgetFancyPanel
                    {
                        UnitBound = new Rectangle(0, 0, 840, 420),
                        Padding = new Spacing(16),
                        Anchor = Anchor.Center,
                        Origine = Anchor.Center,
                        Dock = Rise.Platform.Family == PlatformFamily.Mobile ? Dock.Fill : Dock.None,

                        Content = new LayoutDock
                        {
                            Children =
                            {
                                new WidgetImage(){
                                     Anchor = Anchor.Center,
                                     Origine = Anchor.Center,
                                     UnitOffset = new Point(0, 0),
                                     Scale =  3f,
                                     Picture = Resources.Sprites["icon/wick"].GetTexture()
                                },
                                 new WidgetLabel()
                                    {
                                       Text=""
                                    },
                                new WidgetLabel()
                                    {
                                        Text = "Don't you dare kill that dog!", Font = Resources.FontAlagard, TextSize = 1f,
                                        Anchor = Anchor.Center, Origine = Anchor.Center
                                    },

                                new WidgetButton("Sorry")
                                    {
                                        UnitOffset = new Point(-16, 0), Anchor = Anchor.Bottom,
                                        Origine = Anchor.BottomRight
                                    }
                                    .RegisterMouseClickEvent((sender) =>
                                    {
                                        gameState.CurrentMenu = new MenuInGame(gameState);
                                    }),
                                new WidgetButton("Who cares?")
                                    {
                                        UnitOffset = new Point(-16, 0), Anchor = Anchor.Bottom,
                                        Origine = Anchor.BottomLeft
                                    }
                                    .RegisterMouseClickEvent((sender) =>
                                    {
                                        dog.Remove();
                                        foreach (Entities.Dog gb in GameState.World.GetLevel(GameState.LocalPlayer.Entity.Level.LevelId).GetAllDogs())
                                        {
                                            Entities.AngryDog angry = (Entities.AngryDog)ENTITIES.ANGRYDOG.Construct();
                                            angry.SpawnDog(gb);
                                            gb.Remove();
                                            angry.Level.AddEntity(angry);
                                            gameState.CurrentMenu = new MenuInGame(gameState);
                                    }})
                            }
                        }
                    }
                }
            };
        }
    }
}
