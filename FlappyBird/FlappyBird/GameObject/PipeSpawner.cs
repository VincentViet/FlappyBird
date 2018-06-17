using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.GameObject
{
    class PipeSpawner : GameObject
    {

        #region Fields
//        private Vector2 _randomPosition;
        private Random _random;
//        private readonly TimeSpan _timeOut = TimeSpan.FromSeconds(4);
//        private TimeSpan _spawningTime = TimeSpan.FromSeconds(0);
        #endregion

        public List<PipeHolder> PipeHolderList;

        public PipeSpawner()
        {
            PipeHolderList = new List<PipeHolder>();
            _random = new Random();
            _position = new Vector2(600, 400);
            _initialPosition = _position;

            spawn();
        }

        #region Method
        /// <summary>
        /// TODO: spawn PipeHolder.
        /// </summary>
        private void spawn()
        {
            //            if (gameTime.TotalGameTime >= _spawningTime)
            //            {
//            int randomHeight = _random.Next(PipeHolder.MAX_HEIGHT, PipeHolder.MIN_HEIGHT);

            //
            //                PipeHolderQueue.Enqueue(newPipeHolder);
            //
            //                _spawningTime = gameTime.TotalGameTime + _timeOut;
            //            }

            int distance = 0;

            for (int i = 0; i < 3; i++)
            {
                int randomHeight = _random.Next(PipeHolder.MAX_HEIGHT, PipeHolder.MIN_HEIGHT);

                PipeHolder newPipeHolder = new PipeHolder
                { 
                    InitialPosition = new Vector2(_position.X + distance, randomHeight),
                    Acceleration = new Vector2(-0.75f, 0)
                };

                PipeHolderList.Add(newPipeHolder);
                distance += 500;
            }

        }
        public override void Update(GameTime gameTime)
        {

            if (PipeHolderList.Count > 0)
            {
                foreach (PipeHolder pipeHolder in PipeHolderList)
                {
                    pipeHolder.Update(gameTime);
                }
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite)
        {
            if (PipeHolderList.Count > 0)
            {
                foreach (PipeHolder pipeHolder in PipeHolderList)
                {
                    pipeHolder.Draw(gameTime, spriteBatch, sprite);
                }
            }
        }
        /// <summary>
        /// Todo: Destroy PipeHolder when it out of game window;
        /// </summary>

        public void reset()
        { 
            PipeHolderList.Clear();
            spawn();
        }
        #endregion
    }
}
