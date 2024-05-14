using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.Graphic;
using Hevadea.Framework.UI;
using Hevadea.Scenes.Widgets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Scenes.Tabs
{
    class LoadingTab : Tab
    {
        public LoadingTab()
        {
            Icon = new Sprite(Resources.TileIcons, new Point(0, 4));
            Content = new LayoutDock()
            {
                Padding = new Spacing(16),
                Children =
                        {
                        new WidgetLabel
                            {
                              Anchor = Anchor.Center,
                              Font = Resources.FontRomulus,
                              Origine = Anchor.Center,
                              Text = "Loading...",
                              UnitOffset = new Point(0, -24)
                            }
                        }
            };
        }
    }
}
