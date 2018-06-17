using Microsoft.Xna.Framework;

namespace FlappyBird.GameObject
{
    class Pipe : GameObject
    {
        PipeColors _color;
        public PipeColors Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Pipe()
        {
            _color = PipeColors.Green;

            _spritesCollection = new System.Collections.Generic.List<Rectangle>(2)
           {
               Constants.GreenPipe,
               Constants.BrownPipe
           };
        }

        protected override void ChooseSprite()
        {
            int factor = (int)_color;
            _sprite = _spritesCollection[factor];

            _sprite.Y = Constants.Height - (_sprite.Y + _sprite.Height);
        }
    }
}
