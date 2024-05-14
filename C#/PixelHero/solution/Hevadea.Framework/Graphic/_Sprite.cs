using Hevadea.Framework.Extension;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Hevadea.Framework.Graphic
{
    public class _Sprite
    {
        [IgnoreDataMember] public _SpriteAtlas Atlas { get; }

        [IgnoreDataMember] public string Name { get; }

        [IgnoreDataMember] public Point Grid { get; }
        [IgnoreDataMember] public Bitmap Bitmap { get; }

        [IgnoreDataMember] public Rectangle Bound => new Rectangle(X, Y, Width, Height);

        [IgnoreDataMember] public Vector2 Size => new Vector2(Width, Height);


        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public _Sprite(_SpriteAtlas atlas, string name, int x, int y, int width, int height, Bitmap bitmap) : this(atlas, name, x, y, width, height, new Point(1), bitmap)
        { }

        public _Sprite(_SpriteAtlas atlas, string name, int x, int y, int width, int height, Point grid, Bitmap bitmap)
        {
            Atlas = atlas;
            Name = name;
            Bitmap = bitmap;

            X = x;
            Y = y;

            Width = width;
            Height = height;

            Grid = grid;
        }

        public _Sprite WithGrid(int width, int height)
        {
            return new _Sprite(Atlas, Name, X, Y, Width, Height, new Point(width, height), Bitmap);
        }

        public _Sprite SubSprite(int x, int y)
        {            
            return new _Sprite(
                Atlas,
                Name,
                X + (Width / Grid.X) * Math.Min(Grid.X - 1, x),
                Y + (Height / Grid.Y) * Math.Min(Grid.Y - 1, y),
                (Width / Grid.X),
                (Height / Grid.Y), Bitmap);
        }

        public Texture2D getSubTextureHero()
        {
            // pas le choix de mettre des constantes a linterieur car sinon on a une erreur qui est out of memory
            Bitmap b = Bitmap.Clone(new System.Drawing.Rectangle(Width, Height, Width, Height), Bitmap.PixelFormat);

            // on le resize par la suite en crean un autre bitmap
            Bitmap b2 = new Bitmap(b, new Size(Width*2, Height*2));            


            return MonoGameExtension.GetTexture2DFromBitmap(Rise.MonoGame.GraphicsDevice, b2);
        }
        public Texture2D getSubTextureEnnemi()
        {
            // pas le choix de mettre des constantes a linterieur car sinon on a une erreur qui est out of memory
            Bitmap b = Bitmap.Clone(new System.Drawing.Rectangle(Width, Height*3, Width, Height), Bitmap.PixelFormat);

            // on le resize par la suite en crean un autre bitmap
            Bitmap b2 = new Bitmap(b, new Size(Width * 2, Height * 2));


            return MonoGameExtension.GetTexture2DFromBitmap(Rise.MonoGame.GraphicsDevice, b2);
        }

        public _Sprite UpperHalf(float split = 0.5f)
        {
            return new _Sprite(Atlas, Name, X, Y, Width, (int)(Height * split), Bitmap);
        }

        public _Sprite BottomHalf(float split = 0.5f)
        {
            return new _Sprite(Atlas, Name, X, Y + (int)(Height * split), Width, (int)(Height * (1f - split)), Bitmap);
        }
        public Texture2D GetTexture()
        {
            return MonoGameExtension.GetTexture2DFromBitmap(Rise.MonoGame.GraphicsDevice, Bitmap);
        }
    }
}