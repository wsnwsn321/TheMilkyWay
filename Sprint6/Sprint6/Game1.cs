using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheMilkyWay.Commands;
using TheMilkyWay.Controller;
using TheMilkyWay.SpriteFactories;
using TheMilkyWay.LevelLoading;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.MarioSound;
using TheMilkyWay.Sound.BackgroundMusic;
using TheMilkyWay.HUDElements;

namespace TheMilkyWay

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphicsDeviceManager graphics;        
        internal SpriteBatch spriteBatch;
        internal GamepadController gamepadController;
        internal KeyboardController keyboardController;
        internal MenuKeyboardController menuKeyboardController;
        internal Level level;
        internal SpriteFont font;
        internal string playerName;
        public bool freeze = false;
        public bool resetTime { get; set; }
        public int lifeCount { get; set; }
        public bool displayLifeText { get; set; }
        private LifeText lifeText;
        public string currentLevel { get; set; }


        private int freezeCount = 0;
        private int lifeScreenCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            currentLevel = GameConstants.Menu;
            lifeCount = 3;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            level = new Level(this);
            keyboardController = new KeyboardController(this);
            gamepadController = new GamepadController();
            menuKeyboardController = new MenuKeyboardController(this);
            playerName = "3Pros1LenUFO";
            lifeText = new LifeText(this);
            resetTime = false;
            InitializeCommands();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateElements();
            level.Load(currentLevel, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            level.Update();
            currentLevel = level.currentLevel;
            menuKeyboardController.Update();
            keyboardController.Update();
            base.Update(gameTime);         
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(level.backgroundColor);
            level.Draw();
            if(displayLifeText)
            {
                lifeText.Draw();
            }
            base.Draw(gameTime);
        }

        private void InitializeCommands()
        {
            keyboardController.RegisterCommand(Keys.Space, new MainCharJumpCommand(this));
            keyboardController.RegisterCommand(Keys.P, new PauseGameCommand(this));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Keys.B, new MainCharAttackCommand(this, false));
            keyboardController.RegisterCommand(Keys.N, new MainCharAttackCommand(this, true));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MainCharJumpCommand(this));
            gamepadController.RegisterCommand(Buttons.Start, new ResetCommand(this));

            menuKeyboardController.RegisterCommand(Keys.Down, new MenuCommand(this));
            menuKeyboardController.RegisterCommand(Keys.Up, new MenuCommand(this));
            menuKeyboardController.RegisterCommand(Keys.Enter, new MenuSelectCommand(this));
        }

        private void CreateElements()
        {
            ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            CharacterSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            UFOSoundManager.instance.LoadSound(Content);
            BackgroundMusic.instanse.LoadSound(Content);
       
            font = Content.Load<SpriteFont>(@"SpriteFonts\Courier New");
        }

        public void ResetGame()
        {
            LoadContent();
            Initialize();
            resetTime = true;
        }
    }
}
