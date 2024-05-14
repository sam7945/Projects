using Hevadea.Entities;
using Hevadea.Entities.ClassesPlayer;
using Hevadea.Entities.Components;
using Hevadea.Entities.Monsters;
using Hevadea.Framework;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Hevadea.Worlds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hevadea.Scenes.Tabs
{
    public class StatsTab : Tab
    {
        public StatsTab(GameState GameState)
        {
            Player player = GameState.LocalPlayer.Entity;
            Icon = new Sprite(Resources.TileIcons, new Point(4, 4));
            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                {
                    new WidgetLabel
                    {
                        Text = "Class: " + Enum.GetName(typeof(Class.Classes), player.Classe),
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Level: " + player.Class.Level + " (" + player.Class.Experience + "/" + player.Class.ExperienceRequired + ")",
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Health point: " + player.GetComponent<ComponentHealth>().Value + "/" + player.GetComponent<ComponentHealth>().MaxValue,
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Damage: " + player.Class.Damage,
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Critical chance: " + Percentage(player.Class.CriticalHit),
                        TextSize = 0.8f,
                        Dock = Dock.Top

                    },
                    new WidgetLabel
                    {
                        Text = "Critical chance with prefered weapon: " + Percentage(player.Class.CriticalHitWithItem),
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Critical damage: " + player.Class.DamageCritical,
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Miss chance: " + Percentage(player.Class.MissHit),
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Miss chance with prefered weapon: " + Percentage(player.Class.MissHitWithItem),
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                    new WidgetLabel
                    {
                        Text = "Escape chance: " + Percentage(player.Class.GTFO),
                        TextSize = 0.8f,
                        Dock = Dock.Top
                    },
                }
            };
        }
        
        private string Percentage(float f)
        {
            return (f * 100) + "%";
        }
    }
}