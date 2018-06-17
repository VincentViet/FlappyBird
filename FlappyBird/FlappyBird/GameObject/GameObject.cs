using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.GameObject
{
    internal abstract class GameObject
    {
        #region Fields
        protected List<Rectangle> _spritesCollection;
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected Vector2 _acceleration;
        protected float _mass;
        protected Vector2 _initialPosition;
        protected Vector2 _initialVelocity;
        protected TimeSpan _movingTime;
        protected float _rotation;
        protected Vector2 _scale;
        protected Rectangle _sprite;
        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
        public Vector2 Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }
        public float Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }
        public Vector2 InitialPosition
        {
            get { return _initialPosition; }
            set { _initialPosition = value; }
        }
        public Vector2 InitialVelocity
        {
            get { return _initialVelocity; }
            set { _initialVelocity = value; }
        }
        public TimeSpan MovingTime
        {
            get { return _movingTime; }
            set { _movingTime = value; }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        public Vector2 Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        public Rectangle Border
        {
            get
            {
                //                int width = (int)(_sprite.Width * _scale.X) ;
                //                int height = (int) (_sprite.Height * _scale.Y);
                int width = (int)(_sprite.Width * _scale.X );
                int height = (int)(_sprite.Height * _scale.Y); ;
                int x = (int) (_position.X - width * 0.5f);
                int y = (int) (_position.Y - height * 0.5f);

                return new Rectangle(x, y, width , height);

            }
        }

        #endregion

        protected GameObject()
        {
            _position = new Vector2();
            _scale = new Vector2(1, 1);
            _sprite = new Rectangle();
            _rotation = 0.0f;
        }

        #region Method

        protected virtual void Animate(GameTime gameTime) { }
        public virtual void LoadContent(ContentManager content) { }
        protected virtual void ChooseSprite() { }
        
        public virtual void AddForce(Vector2 force)
        {
            _acceleration = force / _mass + Constants.FreeFallAcceleration;
            _initialVelocity = _velocity;
            _initialPosition = _position;
        }

        protected virtual void TranslateMotion(GameTime gameTime)
        {
            float time = (float)_movingTime.TotalSeconds;
            _velocity = _initialVelocity + _acceleration * time;
            _position = _initialPosition + (_initialVelocity * time + 0.5f * _acceleration * time * time)
                        * Constants.Meters2Pixel;
            _movingTime += gameTime.ElapsedGameTime;
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Color color) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D spriteSheet)
        {
            ChooseSprite();
           

            //spriteBatch.Draw(spriteSheet, _area, _sprite, Color.White);
            spriteBatch.Draw(spriteSheet, _position, _sprite, Color.White, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, SpriteEffects.None, 1.0f);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D spriteSheet, float rotation)
        {
            ChooseSprite();
          

            //spriteBatch.Draw(spriteSheet, _area, _sprite, Color.White, rotation, new Vector2(_area.Width / 2, _area.Height), SpriteEffects.None, 1.0f);
            spriteBatch.Draw(spriteSheet, _position, _sprite, Color.White, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, SpriteEffects.None, 1.0f);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D spriteSheet, Color color)
        {
            ChooseSprite();
           

            //spriteBatch.Draw(spriteSheet, _area, _sprite, color);
            spriteBatch.Draw(spriteSheet, _position, _sprite, color, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, SpriteEffects.None, 1.0f);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D spriteSheet, SpriteEffects effects)
        {
            ChooseSprite();
           

           // spriteBatch.Draw(spriteSheet, _area, _sprite, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipVertically, 1.0f);
            spriteBatch.Draw(spriteSheet, _position, _sprite, Color.White, _rotation, new Vector2(_sprite.Width / 2.0f, _sprite.Height / 2.0f), _scale, effects, 1.0f);
        }

        #endregion
    }
}
