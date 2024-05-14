using Hevadea.Framework;
using Hevadea.Framework.Extension;
using Hevadea.Framework.UI;
using Microsoft.Xna.Framework;

namespace Hevadea.Scenes
{
    public class SceneTitleScreen : Scene
    {
        public override void Load()
        {
            var background = Rise.Rnd.Pick(Resources.ParalaxeForest, Resources.ParalaxeMontain);
            Rise.Scene.SetBackground(background);
            Rise.Sound.Play(Resources.Theme0);

            var logo = new WidgetImage
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, -25),
                Scale = 1f,
                Picture = Rise.Resources.GetImage("logo")
            };

            var title = new WidgetLabel
            {
                Text = Game.Title,
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0),
                Font = Resources.FontAlagard,
                TextSize = 6f,
                Disabled = true,
            };

            var subTitle = new WidgetLabel
            {
                Text = Game.SubTitle,
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 72),
                Font = Resources.FontRomulus,
                TextColor = ColorPalette.Accent,
                TextSize = 1f,
                Disabled = true,
            };

            var prompt = new WidgetButton("> Press any key <")
            {
                Anchor = Anchor.Center,
                Origine = Anchor.Center,
                UnitOffset = new Point(0, 320),
                Font = Resources.FontRomulus,
            }.RegisterMouseClickEvent(Game.GoToMainMenu);

            var version = new WidgetLabel
            {
                Text = $"{Game.Title} {Game.Version}",
                Anchor = Anchor.BottomRight,
                Origine = Anchor.BottomRight,
                UnitOffset = new Point(-16, 0),
                Font = Resources.FontHack,
                TextAlignement = TextAlignement.Right,
                TextColor = Color.White * 0.5f,
                TextSize = 1f,
            };

            Container = new LayoutDock()
            {
                Children =
                {
                    logo, title, subTitle, prompt, version
                }
            };
        }

        public override void OnDraw(GameTime gameTime)
        {
        }

        public override void OnUpdate(GameTime gameTime)
        {
            if (Rise.Input.AnyKeyDown()) Game.GoToMainMenu();
        }

        public override void Unload()
        {
        }
    }
}