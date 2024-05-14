using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hevadea.Framework.UI
{
    public class WidgetImage : Widget
    {
        public Texture2D Picture { get; set; } = null;
        public new float? Scale { get; set; }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Scale == null)
            {
                Vector2 pos = (Host.Center - Picture.Bounds.Center).ToVector2();
                spriteBatch.Draw(texture: Picture, 
                                 position: pos, 
                                 color: Color.White
                                 );
            }
            else
            {
                float scaling = (float)Scale * Rise.Ui.ScaleFactor;
                Point center = new Point((int)(Picture.Bounds.Center.X * scaling), (int)(Picture.Bounds.Center.Y * scaling));
                Point scale = new Point((int)(Picture.Width * scaling), (int)(Picture.Height * scaling));
                spriteBatch.Draw(texture: Picture,
                                 destinationRectangle: new Rectangle((Host.Center - center + UnitOffset), scale),
                                 color: Color.White
                );
            }
        }
    }
}