using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FlappyBird.GameObject
{
    class Bird : GameObject
    {
        #region Fields
        private TimeSpan _animateTimeOut = TimeSpan.FromMilliseconds(100);
        private TimeSpan _animateTime = TimeSpan.FromSeconds(0);
        private Vector2 MIN_POSITION = new Vector2(240, 40);
        private Vector2 MAX_POSITION = new Vector2(240, 800);
        int _currentFrame = 0;
        const int _totalFrame = 3;
        BirdColors _color;
        #endregion

        #region Properties
        public static int WIDTH;
        public BirdColors Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public bool isDead;
        #endregion


        public Bird()
        {
            isDead = false;
            _color = BirdColors.Blue;
            _velocity = new Vector2(0, 0);
            _acceleration = Constants.FreeFallAcceleration;
            _mass = 1.0f;
            CreateBirds();
        }

        public Bird(BirdColors color)
        {
            isDead = false;
            _color = color;
            _velocity = new Vector2(0, 0);
            _acceleration = Constants.FreeFallAcceleration;
            _mass = 1.0f;
            _movingTime = TimeSpan.Zero;
            CreateBirds();
        }

        #region Method

        void CreateBirds()
        {
            _spritesCollection = new List<Rectangle>(3 * 4)
            {
                Constants.BlueBird[0],
                Constants.BlueBird[1],
                Constants.BlueBird[2],
                Constants.BlueBird[3],
                Constants.RedBird[0],
                Constants.RedBird[1],
                Constants.RedBird[2],
                Constants.RedBird[3],
                Constants.GreenBird[0],
                Constants.GreenBird[1],
                Constants.GreenBird[2],
                Constants.GreenBird[3]
            };
        }

        /// <summary>
        /// Call this method in Update method of game to animate this bird
        /// </summary>
        protected override void Animate(GameTime gameTime)
        {
            if (gameTime.TotalGameTime >= _animateTime)
            {
                if (_currentFrame < _totalFrame - 1)
                    _currentFrame++;
                else
                    _currentFrame = 0;

                _animateTime = gameTime.TotalGameTime + _animateTimeOut;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!isDead && MainGame.IsStarted)
            {
                TranslateMotion(gameTime);
                _position = Vector2.Clamp(_position, MIN_POSITION, MAX_POSITION);

                if (_acceleration.Y > 0.0f)
                {
                    _rotation += 1.5f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    _rotation = MathHelper.Clamp(_rotation, _rotation, MathHelper.PiOver2);
                }
                else if (_acceleration.Y < 0.0f)
                {
                    _rotation -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    _rotation = MathHelper.Clamp(_rotation, -MathHelper.PiOver4, _rotation);
                }
            }

            WIDTH = (int)(_sprite.Width * _scale.X);

            Animate(gameTime);
        }

        protected override void ChooseSprite()
        {
            int factor = (int)_color;

            if (!isDead)
                _sprite = _spritesCollection[factor * 4 + _currentFrame];
            else
                _sprite = _spritesCollection[factor * 4 + 3];

            _sprite.Y = Constants.Height - (_sprite.Y + _sprite.Height);
        }

        public void Reset()
        {
            isDead = false;
            _currentFrame = 0;
            _position = new Vector2(240, 400);
            _initialPosition = _position;
            _velocity = new Vector2();
            _initialVelocity = new Vector2();
            _scale = new Vector2(0.4f,0.4f);
            _movingTime = TimeSpan.Zero;
            _rotation = 0.0f;
        }

        #endregion
    }
}
