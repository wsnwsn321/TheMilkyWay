using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.LevelLoading;
using SuperMarioGame.ElementClasses.BackgroundClass;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.GameState;

namespace SuperMarioGame

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphicsDeviceManager graphics;        
        internal SpriteBatch spriteBatch;
        internal GamepadController gamepadController;
        internal KeyboardController keyboardController;
        internal Level level;
        internal GameStateHandler gameStateHandler;
        internal SpriteFont font;
        private bool freeze = false;
        private int freezeCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            level = new Level(this);
            gameStateHandler = new GameStateHandler(level);

            InitializeCommands();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateElements();
            level.Load();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (!freeze)
            {
                level.Update();
                if (level.mario.marioState == Mario.MARIO_DEAD)
                {
                    freeze = true;
                }
                keyboardController.Update();
                base.Update(gameTime);
            }
            else
            {
                freezeCount++;
                if (freezeCount == 75)
                {
                    freeze = false;
                    freezeCount = 0;
                    ResetGame();
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            level.Draw();
            base.Draw(gameTime);
        }

        private void InitializeCommands()
        {
            keyboardController.RegisterCommand(Keys.W, new MarioJumpCommand(this));
            keyboardController.RegisterCommand(Keys.A, new MarioLeftCommand(this));
            keyboardController.RegisterCommand(Keys.D, new MarioRightCommand(this));
            keyboardController.RegisterCommand(Keys.S, new MarioCrouchCommand(this));

            keyboardController.RegisterCommand(Keys.Space, new PauseGameCommand(this));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.C, new MarioChangeFormCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Keys.BrowserBack, new MarioIdleCommand(this));
            keyboardController.RegisterCommand(Keys.X, new MarioAttackCommand(this));

            gamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MarioJumpCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLeftCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioCrouchCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioRightCommand(this));
            gamepadController.RegisterCommand(Buttons.Start, new ResetCommand(this));

        }

        private void CreateElements()
        {
            ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            font = Content.Load<SpriteFont>(@"SpriteFonts\Courier New");
        }

        public void ResetGame()
        {
            Initialize();
            LoadContent();
            
        }
    }
}
