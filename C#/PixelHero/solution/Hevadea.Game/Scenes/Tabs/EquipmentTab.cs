using Hevadea.Entities.Monsters;
using Hevadea.Framework;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Hevadea.Worlds;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Hevadea.Scenes.Tabs
{
    public class EquipmentTab : Tab
    {
        public EquipmentTab(GameState GameState)
        {
            int CurrentLevel = GameState.LocalPlayer.Entity.Level.LevelId;
            int Total = 0, Current = 0;
            List<Monster> MonstersOnLevel = new List<Monster>();
            foreach (Level l in GameState.World.Levels)
            {
                List<Monster> Monsters = GameState.World.GetLevel(l.LevelId).GetAllMonsters();
                if (l.LevelId == CurrentLevel)
                {
                    Current = Monsters.Count;
                    MonstersOnLevel = Monsters;
                }
                Total += Monsters.Count;
            }
            Icon = new Sprite(Resources.TileIcons, new Point(4, 4));
            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                    new WidgetLabel
                    {
                        Text = "Goal",
                        Font = Resources.FontAlagard,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Total of monsters in world: " + Total,
                        Dock = Dock.Top
                    },
                     new WidgetLabel
                    {
                        Text = "On this level",
                        Font = Resources.FontAlagard,
                        Dock = Dock.Top
                    },
                     new WidgetLabel
                    {
                        Text = "Zombies: " + MonstersOnLevel.Where(x=>x is Zombie).Count(),
                        Dock = Dock.Top

                    },
                     new WidgetLabel
                    {
                        Text = "Evil Flowers: " + MonstersOnLevel.Where(x=>x is DarkFlower).Count(),
                        Dock = Dock.Top
                    },
                     new WidgetLabel
                    {
                       Text = "Evil Mushroom: " + MonstersOnLevel.Where(x=>x is DarkMushroom).Count(),
                        Dock = Dock.Top
                    },
                     new WidgetLabel
                    {
                        Text = "Evil Trunk: " + MonstersOnLevel.Where(x=>x is DarkTree).Count(),
                        Dock = Dock.Top
                    },

                }
            };
        }
    }
}