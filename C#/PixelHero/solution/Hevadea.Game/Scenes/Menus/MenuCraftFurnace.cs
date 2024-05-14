using Hevadea.Entities;
using Hevadea.Entities.Components;
using Hevadea.Framework;
using Hevadea.Scenes.Widgets;
using Hevadea.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Hevadea.Items;
using Hevadea.Registry;
using Hevadea.Craftings;
using Microsoft.Xna.Framework.Graphics;
using Hevadea.Scenes.Tabs;

namespace Hevadea.Scenes.Menus
{
    public class MenuCraftFurnace : Menu
    {
        private readonly WidgetItemContainer _inventory;
        private WidgetButton _buttonCraft;
        public WidgetList CraftingList { get; }


        public MenuCraftFurnace(Entity player, Entity furnace, GameState gameState, Menu lastmenu) : base(gameState)
        {
            ScreenHeight = Rise.Graphic.GetHeight();
            ScreenWidth = Rise.Graphic.GetWidth();
            _lastmenu = lastmenu;
            PauseGame = true;
            EscapeToClose = true;
            _buttonCraft = new WidgetButton("Craft");
            _buttonCraft.MouseClick += CraftIt;
            _buttonCraft.Dock = Dock.Bottom;
            _buttonCraft.Anchor = Anchor.BottomRight;


            _inventory = new WidgetItemContainer(player.GetComponent<ComponentInventory>().Content)
            { Padding = new Spacing(4, 4), Dock = Dock.Fill };

            CraftingList = new WidgetList
            {
                Dock = Dock.Fill,
                ItemHeight = 64,
            };



            foreach (var recipe in RECIPIES.FurnaceCrafted)
                CraftingList.AddItem(new CraftingListItem(recipe,
                    GameState.LocalPlayer.Entity.GetComponent<ComponentInventory>().Content));


            var closeBtn = new WidgetSprite()
            {
                Sprite = new Sprite(Resources.TileGui, new Point(7, 7)),
                UnitBound = new Rectangle(0, 0, 48, 48),
                Anchor = Anchor.TopLeft,
                Origine = Anchor.Center

            };
            
            closeBtn.MouseClick += CloseBtnOnMouseClick;
            Content = new WidgetFancyPanel()
            {
                Content = new LayoutDock()
                {
                    Children =
                    {
                        new LayoutDock()
                        {
                            Dock = Dock.Fill,
                            Children = {closeBtn}
                        },


                        new LayoutTile()
                        {
                            UnitBound =new Rectangle(0,0,64,64),
                            Dock = Dock.Fill,
                            Children =
                            {
                                new WidgetPanel()
                                {
                                    UnitBound = new Rectangle(0, 0, 400, 480),
                                    Anchor = Anchor.Center,
                                    Origine = Anchor.Left,
                                    Dock = Dock.Left,
                                    Content = new LayoutDock()
                                    {
                                        Children =
                                        {
                                            new WidgetLabel {Text = "Inventaire", Font = Resources.FontAlagard, Dock = Dock.Top},
                                            _inventory
                                        }
                                    }
                                },
                                new WidgetPanel()
                                {
                                    UnitBound = new Rectangle(0, 0, 400, 480),
                                    Anchor = Anchor.Center,
                                    Origine = Anchor.TopRight,
                                    Dock = Dock.Top,
                                    Content = new LayoutDock()
                                    {
                                        Children =
                                        {
                                            new WidgetLabel {Text = "Craft", Font = Resources.FontAlagard, Dock = Dock.Top},
                                            CraftingList,
                                            _buttonCraft
                                        }
                                    }
                                }
                            }
                        },

                    }
                }
            };

        }

        private void CraftIt(Widget sender)
        {
            if (CraftingList.SelectedItem is CraftingListItem craft)
                craft.GetRecipe().Craft(GameState.LocalPlayer.Entity.GetComponent<ComponentInventory>().Content);
        }
        private void CloseBtnOnMouseClick(Widget sender)
        {
            GameState.CurrentMenu = new MenuInGame(GameState);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Rise.Input.KeyTyped(Microsoft.Xna.Framework.Input.Keys.Escape) && EscapeToClose)
            {
                CloseBtnOnMouseClick(this);
            }

        }

    }
}
