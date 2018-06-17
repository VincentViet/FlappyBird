using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird.UI
{
    class Button : UI
    {
        #region Fields

        private MouseState _preMouseState;
        private MouseState _currMouseState;

        private KeyboardState _preKeyboardState;
        private KeyboardState _currKeyboardState;

        private Keys _allowKey;

        #endregion

        #region Properties

        public Vector2 InitialPosition;
        public Texture2D Texture;
        public event EventHandler Click;

        #endregion

        public Button(Keys allowKey)
        {
            _position = new Vector2();
            Texture = null;
            _allowKey = allowKey;
        }

        public Button(Texture2D texture, Keys allowKey)
        {
            _position = new Vector2();
            Texture = texture;
            _allowKey = allowKey;
        }

        public override void Update(GameTime gameTime)
        {
            _preMouseState = _currMouseState;
            _currMouseState = Mouse.GetState();

            _preKeyboardState = _currKeyboardState;
            _currKeyboardState = Keyboard.GetState();

            
            if(_currKeyboardState.IsKeyUp(_allowKey) && _preKeyboardState.IsKeyDown(_allowKey))
            {
                Click?.Invoke(this, new EventArgs());
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, Color.White);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle source)
        {
            float x = InitialPosition.X - source.Width * 0.5f;
            float y = InitialPosition.Y - source.Height * 0.5f;
            _position = new Vector2(x, y);

            spriteBatch.Draw(Texture, _position, source, Color.White);
        }
    }
}
