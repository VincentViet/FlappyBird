using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.GameObject
{
    class PipeHolder : GameObject
    {

        public Pipe _upperPipe;
        public Pipe _lowerPipe;

        private Random _random;

        #region Properties

        public Rectangle UpperBorder
        {
            get { return _upperPipe.Border; }
        }
        public Rectangle LowerBorder
        {
            get { return _lowerPipe.Border; }
        }

        public static readonly int MAX_HEIGHT = 150;
        public static readonly int MIN_HEIGHT = 650;

        #endregion


        public PipeHolder()
        {
            _upperPipe = new Pipe();
            _lowerPipe = new Pipe();
            _upperPipe.Scale = new Vector2(0.5f, 1);
            _lowerPipe.Scale = new Vector2(0.5f, 1);

            _initialPosition = new Vector2(-100, 0);
            _position = _initialPosition;

            _random = new Random();
        }

        public override void Update(GameTime gameTime)
        {


            _position += new Vector2(-2f, 0f);

            if (_position.X < -45)
            {
                int randomHeight = _random.Next(MAX_HEIGHT, MIN_HEIGHT);
                _position = new Vector2(900, randomHeight);
                _velocity = Vector2.Zero;
            }



            _upperPipe.Position = new Vector2(_position.X, _position.Y - 40 - 310);
            _lowerPipe.Position = new Vector2(_position.X, _position.Y + 40 + 310);


            // ToDo: Scoring
            if ((int)_position.X ==  210)
            {
                ScoreManager.Scores++;
                SoundManager.Play("Ping");
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {
            _upperPipe.Draw(gameTime, spriteBatch, sprite, SpriteEffects.FlipVertically);
            _lowerPipe.Draw(gameTime, spriteBatch, sprite);
        }
    }
}
