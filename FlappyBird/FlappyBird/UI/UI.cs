using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.UI
{
    internal abstract class UI
    {
        protected Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        protected Color _colour;
        public Color Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle source) { }
    }
}
