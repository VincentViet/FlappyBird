using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.UI
{
    class Label : UI
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Vector2 InitialPosition;

        private SpriteFont _font;
        public SpriteFont Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public Label()
        {
            _text = "";
            _colour = Color.White;
            _font = null;
            _position = new Vector2();
        }

        public Label(string text)
        {
            _text = text;
            _colour = Color.White;
            _font = null;
            _position = new Vector2();
        }

        public Label(string text, Color color)
        {
            _text = text;
            _colour = color;
            _font = null;
            _position = new Vector2();
        }

        public override void Update(GameTime gameTime)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                _position = InitialPosition - _font.MeasureString(_text) * 0.5f;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_font != null)
            {
                spriteBatch.DrawString(_font, _text, _position, _colour);
            }
        }
    }
}
