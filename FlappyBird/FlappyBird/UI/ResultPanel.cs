using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.UI
{
    class ResultPanel : UI
    {
        private Label _highScoreLabel;
        private Label _highScore;
        private Label _scoreLabel;
        private Label _score;

        public Texture2D Texture;
        public Vector2 InitialPosition;

        public ResultPanel(SpriteFont font, Texture2D texture)
        {
            _highScoreLabel = new Label("High Score:", Color.Black);
            _highScore = new Label("0", Color.Black);
            _scoreLabel = new Label("Your Score:", Color.Black);
            _score = new Label("0", Color.Black);

            _highScoreLabel.Font = _highScore.Font = _scoreLabel.Font = _score.Font = font;
            Texture = texture;
        }

        public override void Update(GameTime gameTime)
        {
            
            if (ScoreManager.Scores / 3 > ScoreManager.HighScores)
            {
                _highScore.Text = "" + ScoreManager.Scores / 3;
                _score.Text = "" + ScoreManager.Scores / 3;
            }
            else
            {
                _highScore.Text = "" + ScoreManager.HighScores;
                _score.Text = "" + ScoreManager.Scores / 3;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle source)
        {
            float x = InitialPosition.X - source.Width * 0.5f;
            float y = InitialPosition.Y - source.Height * 0.5f;
            _position = new Vector2(x, y);

            _highScoreLabel.Position = new Vector2(_position.X + 200, _position.Y + 50);
            _highScore.Position = new Vector2(_position.X + 425, _position.Y + 50);
            _scoreLabel.Position = new Vector2(_position.X + 200, _position.Y + 150);
            _score.Position = new Vector2(_position.X + 425, _position.Y + 150);

            spriteBatch.Draw(Texture, _position, source, Color.White);
            _highScoreLabel.Draw(gameTime, spriteBatch);
            _highScore.Draw(gameTime, spriteBatch);
            _scoreLabel.Draw(gameTime, spriteBatch);
            _score.Draw(gameTime, spriteBatch);
        }
    }
}
