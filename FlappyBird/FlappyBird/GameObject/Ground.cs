using Microsoft.Xna.Framework;

namespace FlappyBird.GameObject
{
    class Ground : GameObject
    {
        public Ground()
        {
            _position = new Vector2(200, 876);
            _scale = new Vector2(1,1);
            _sprite = Constants.Ground;
            _sprite.Y = Constants.Height - (_sprite.Y + _sprite.Height);
        }
    }
}
