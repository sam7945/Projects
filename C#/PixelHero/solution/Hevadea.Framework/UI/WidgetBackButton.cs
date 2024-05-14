using Hevadea.Framework.Extension;
using Hevadea.Framework.Platform;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Hevadea.Framework.UI
{
    public class WidgetBackButton: Widget
    {
        public string Text { get; set; } = "Back";
        public SpriteFont Font { get; set; } = Rise.Ui.DefaultFont;
        public Style IdleStyle { get; set; } = Style.Idle;
        public Style OverStyle { get; set; } = Style.Over;
        public Style DownStyle { get; set; } = Style.Focus;

        /// <param name="action">Action du button</param>
        public WidgetBackButton(System.Action action)
        {
            RegisterMouseClickEvent(action);
            UnitBound = new Rectangle(0, 0, 85, 40);
        }
        /// <param name="action">Action du button</param>
        public WidgetBackButton(WidgetEventHandler action)
        {
            RegisterMouseClickEvent(action);
            UnitBound = new Rectangle(0, 0, 85, 40);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (MouseState == MouseState.Over)
            {
                OverStyle.Draw(spriteBatch, UnitBound);
            }
            else if (MouseState == MouseState.Down)
            {
                DownStyle.Draw(spriteBatch, UnitBound);
            }
            else
            {
                IdleStyle.Draw(spriteBatch, UnitBound);
            }

            spriteBatch.DrawString(Font, Text, Host, TextAlignement.Center, TextStyle.DropShadow, Color.White, Rise.Ui.ScaleFactor);

        }
    }
}