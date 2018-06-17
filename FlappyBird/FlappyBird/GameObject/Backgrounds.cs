using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.GameObject
{
    class Backgrounds : GameObject
    {
        Texture2D _dayBackground;
        Texture2D _nightBackgound;
        private static readonly string DayBackgroundPath = "Backgrounds/BgDay";
        private static readonly string NightBackgroundPath = "Backgrounds/BgNight";

        BackgroundTypes _type;
        public BackgroundTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public Backgrounds()
        {
            _type = BackgroundTypes.Day;
            _sprite = new Rectangle(0, 0, 480, 800);
            _position = new Vector2(240, 400);
        }

        public Backgrounds(BackgroundTypes type)
        {
            _type = type;
            _sprite = new Rectangle(0, 0, 480, 800);
            _position = new Vector2(240, 400);
        }

        public override void LoadContent(ContentManager content)
        {
            _dayBackground = content.Load<Texture2D>(DayBackgroundPath);
            _nightBackgound = content.Load<Texture2D>(NightBackgroundPath);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color color)
        {
            if (_type == BackgroundTypes.Day)
                spriteBatch.Draw(_dayBackground, _position, _sprite, Color.White, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, SpriteEffects.None, 1.0f);
            else
                spriteBatch.Draw(_nightBackgound, _position, _sprite, Color.White, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, SpriteEffects.None, 1.0f);
        }

    }
}
