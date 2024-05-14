using Hevadea.Framework.Graphic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Hevadea.Framework.Input
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Outside = 4
    }
    public class LegacyInputManager
    {
        private KeyboardState _oldKeyboardState;
        private KeyboardState _newKeyboardState;
        private MouseState _oldMouseState;
        private MouseState _newMouseState;
        private GraphicManager _graphic;

        public LegacyInputManager(GraphicManager graphic)
        {
            _graphic = graphic;
        }

        public void Initialize()
        {
            _oldKeyboardState = _newKeyboardState = Keyboard.GetState();
            _oldMouseState = _newMouseState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            _oldKeyboardState = _newKeyboardState;
            _newKeyboardState = Keyboard.GetState();
            _oldMouseState = _newMouseState;
            _newMouseState = Mouse.GetState();
        }

        public bool AnyKeyDown()
        {
            return _newKeyboardState.GetPressedKeys().Any();
        }

        public bool KeyUp(Keys key)
        {
            return _newKeyboardState.IsKeyUp(key);
        }

        public bool KeyDown(Keys key)
        {
            return _newKeyboardState.IsKeyDown(key);
        }

        public bool KeyTyped(Keys key)
        {
            return _newKeyboardState.IsKeyUp(key) && _oldKeyboardState.IsKeyDown(key);
        }

        public bool MouseLeftButtonClick()
        {
            if ((_oldMouseState != _newMouseState) && _newMouseState.LeftButton == ButtonState.Pressed)
                return true;
            return false ;
        }
        public bool MouseRightButtonClick()
        {
            if ((_oldMouseState != _newMouseState) && _newMouseState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }
        /// <summary>
        /// Détermine si le scroll de la souris a été utilisé
        /// </summary>
        /// <returns>null si la scroll n'a pas été touché, vrai si pour le haut et false pour le bas</returns>
        public bool? ScrollWheelDelta()
        {
            if (_oldMouseState.ScrollWheelValue == _newMouseState.ScrollWheelValue)
                return null;
            return _oldMouseState.ScrollWheelValue < _newMouseState.ScrollWheelValue;
        }
        public Direction MousePostionDelta()
        {
            float Width = _graphic.GetWidth();
            float Height = _graphic.GetHeight();
            float X = _newMouseState.Position.X;
            float Y = _newMouseState.Position.Y;
            float a = (Height / Width);
            float expectedY = (-a * Mathf.Abs(X - (Width / 2))) + (Height / 2);

            if (X > Width || Y > Height || X < 0 || Y < 0)
                return Direction.Outside;

            if (Y < (-a * Mathf.Abs(X - (Width / 2))) + (Height / 2))
                return Direction.North;

            if (Y > (a * Mathf.Abs(X - (Width / 2))) + (Height / 2))
                return Direction.South;

            if (X < Width / 2)
                return Direction.West;

            else
                return Direction.East;

        }

    }
}