using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlappyBird.GameObject;
using FlappyBird.UI;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {

        #region Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _spriteSheet;
        private Dictionary<string, GameObject.GameObject> _gameComponents;
        private Dictionary<string, UI.UI> _uiComponents;
        private readonly Vector2 _force = new Vector2(0, -9000f);
        private readonly string SPRITE_SHEET_PATH = "Sprite/FlappyBirdSprites";
        private readonly string FONT_PATH = "Font/FlappyBirdFont";

        private int _alpha = 255;
        private int _temp;
        #endregion

        public static bool IsPaused;
        public static bool IsStarted;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _gameComponents = new Dictionary<string, GameObject.GameObject>();
            _uiComponents = new Dictionary<string, UI.UI>();
            IsPaused = false;
            IsStarted = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            // TODO: Add your initialization logic here

            // initialize resolution of game
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            Point startPosition = new Point();
            startPosition.X = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - Window.ClientBounds.Height) * 2;
            startPosition.Y = (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - Window.ClientBounds.Width) / 8;

            Window.Title = "Flappy Bird";
            Window.Position = startPosition;
            //Window.AllowUserResizing = true;

            // Create Game Components
            _gameComponents.Add("Background", new Backgrounds(BackgroundTypes.Night));
            _gameComponents.Add("Ground", new Ground());
            _gameComponents.Add("Spawner", new PipeSpawner());
            _gameComponents.Add("Bird", new Bird(BirdColors.Blue));

            // Create UI Components
            _uiComponents.Add("Score", new Label());
            _uiComponents.Add("GameTitle", new Label("Flappy Bird", Color.Black));
            _uiComponents.Add("PlayString", new Label("Press \"Enter\" to play.", Color.Black));
            _uiComponents.Add("TouchButton", new Button(new Texture2D(GraphicsDevice, 480, 800), Keys.Space));
            _uiComponents.Add("PlayButton", new Button(Content.Load<Texture2D>(SPRITE_SHEET_PATH), Keys.Enter));
            _uiComponents.Add("Result", new ResultPanel(Content.Load<SpriteFont>("Font/FlappyBirdFont20"), 
                                                            Content.Load<Texture2D>(SPRITE_SHEET_PATH)));

            //_gameComponents["Spawner"].Position = new Vector2(600, 400);

            _gameComponents["Bird"].Position = new Vector2(240, 400);
            _gameComponents["Bird"].InitialPosition = _gameComponents["Bird"].Position;
            _gameComponents["Bird"].Scale = new Vector2(0.4f, 0.4f);

            ((Label)_uiComponents["Score"]).Position = new Vector2(240, 50);
            _uiComponents["Score"].Colour = Color.White;

            ((Label) _uiComponents["PlayString"]).InitialPosition = new Vector2(240, 600);
            ((Label)_uiComponents["GameTitle"]).InitialPosition = new Vector2(240, 80);
            ((Button)_uiComponents["TouchButton"]).Click += TouchButton_Clicked;
            ((Button)_uiComponents["PlayButton"]).Click += PlayButton_Clicked;
            ((Button)_uiComponents["PlayButton"]).InitialPosition = new Vector2(240, 600);
            ((ResultPanel)_uiComponents["Result"]).InitialPosition = new Vector2(240, 400);

            ScoreManager.Scores = 0;
            ScoreManager.GetHighScore();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _spriteSheet = Content.Load<Texture2D>(SPRITE_SHEET_PATH);

            SoundManager.Add("Dead", Content.Load<SoundEffect>("Sounds/Dead"));
            SoundManager.Add("Fly", Content.Load<SoundEffect>("Sounds/Fly"));
            SoundManager.Add("Ping", Content.Load<SoundEffect>("Sounds/Ping"));

            _gameComponents["Background"].LoadContent(Content);
            ((Label)_uiComponents["Score"]).Font = Content.Load<SpriteFont>(FONT_PATH);
            ((Label)_uiComponents["GameTitle"]).Font = Content.Load<SpriteFont>(FONT_PATH);
            ((Label) _uiComponents["PlayString"]).Font = Content.Load<SpriteFont>("Font/FlappyBirdFont20");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (_alpha == 255)
                _temp = -5; 
            else if (_alpha == 50)
                _temp = 5;

            _alpha += _temp;


            if (!IsStarted)
            {
                _uiComponents["GameTitle"].Update(gameTime);
                _uiComponents["PlayButton"].Update(gameTime);
                _uiComponents["PlayString"].Update(gameTime);
                _gameComponents["Bird"].Update(gameTime);

                ((Label)_uiComponents["PlayString"]).Colour = new Color(Color.Black, _alpha);

                return;
            }

            if (!IsPaused)
            {
                IsPaused = Collide();

                ((Button)_uiComponents["TouchButton"]).Update(gameTime);

                if (_gameComponents["Bird"].Velocity.Y < 0.0f)
                {
                    _gameComponents["Bird"].Acceleration = Constants.FreeFallAcceleration;
                    _gameComponents["Bird"].InitialVelocity = new Vector2(0, 0);
                    _gameComponents["Bird"].InitialPosition = _gameComponents["Bird"].Position;
                    _gameComponents["Bird"].MovingTime = TimeSpan.Zero;
                }

                ((Label)_uiComponents["Score"]).Text = "" + ScoreManager.Scores / 3;

                

                foreach (KeyValuePair<string, GameObject.GameObject> component in _gameComponents)
                {
                    component.Value.Update(gameTime);
                }
            }
            else
            {
                _uiComponents["Result"].Update(gameTime);
                _uiComponents["PlayButton"].Update(gameTime);
                _uiComponents["PlayString"].Update(gameTime);

                ((Label)_uiComponents["PlayString"]).Colour = new Color(Color.Black, _alpha);
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            // TODO: Add your drawing code here
            
            _spriteBatch.Begin();

            if (IsStarted)
            {

                _gameComponents["Background"].Draw(gameTime, _spriteBatch, Color.White);
                _gameComponents["Spawner"].Draw(gameTime, _spriteBatch, _spriteSheet);
                _gameComponents["Bird"].Draw(gameTime, _spriteBatch, _spriteSheet, _gameComponents["Bird"].Rotation);
                _gameComponents["Ground"].Draw(gameTime, _spriteBatch, _spriteSheet);
                _uiComponents["Score"].Draw(gameTime, _spriteBatch);

                if (IsPaused)
                {
                    _uiComponents["Result"].Draw(gameTime, _spriteBatch, Constants.Panel);
                    
                    _uiComponents["PlayString"].Draw(gameTime, _spriteBatch);
                }
            }
            else
            {
                _gameComponents["Background"].Draw(gameTime, _spriteBatch, Color.White);
                _gameComponents["Bird"].Draw(gameTime, _spriteBatch, _spriteSheet, _gameComponents["Bird"].Rotation);
                _uiComponents["GameTitle"].Draw(gameTime, _spriteBatch);
               
                _uiComponents["PlayString"].Draw(gameTime, _spriteBatch);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private bool Collide()
        {
            var spawner = (PipeSpawner)_gameComponents["Spawner"];
            Ground ground = (Ground)_gameComponents["Ground"];
            Bird bird = (Bird)_gameComponents["Bird"];
            Rectangle border = bird.Border;
            bool check;

            if (spawner.PipeHolderList.Count > 0)
            {
                foreach (var pipeHolder in spawner.PipeHolderList)
                {

                    check = border.Intersects(pipeHolder.UpperBorder) ||
                            border.Intersects(pipeHolder.LowerBorder);

                    if (check)
                    {
                        bird.isDead = true;
                        SoundManager.Play("Dead");
                        return true;
                    }
                }
            }

            check = border.Intersects(ground.Border);
            if (check)
            {
                bird.isDead = true;
                SoundManager.Play("Dead");
                return true;
            }
            return false;
        }

        private void TouchButton_Clicked(object sender, EventArgs e)
        {
            _gameComponents["Bird"].AddForce(_force);
            _gameComponents["Bird"].MovingTime = TimeSpan.Zero;
            SoundManager.Play("Fly");
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            IsStarted = true;
            IsPaused = false;

            if (ScoreManager.Scores / 3 > ScoreManager.HighScores)
                ScoreManager.HighScores = ScoreManager.Scores / 3;

            ((Bird)_gameComponents["Bird"]).Reset();

            GameTime gameTime = new GameTime();

            _spriteBatch.Begin();
            _gameComponents["Bird"].Draw(gameTime, _spriteBatch, _spriteSheet, _gameComponents["Bird"].Rotation);
            _spriteBatch.End();
            ((PipeSpawner)_gameComponents["Spawner"]).reset();
            ScoreManager.ResetScores();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);


            if (ScoreManager.Scores / 3 > ScoreManager.HighScores)
                ScoreManager.HighScores = ScoreManager.Scores / 3;

            ScoreManager.UpdateHighScore();
        }
    }
}
