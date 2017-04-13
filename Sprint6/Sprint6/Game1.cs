using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint6.Commands;
using Sprint6.Controller;
using Sprint6.SpriteFactories;
using Sprint6.LevelLoading;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses;
using Sprint6.Sound.MarioSound;
using Sprint6.Sound.BackgroundMusic;
using Sprint6.HUDElements;

namespace Sprint6

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphicsDeviceManager graphics;        
        internal SpriteBatch spriteBatch;
        internal GamepadController gamepadController;
        internal KeyboardController keyboardController;
        internal Level level;
        internal SpriteFont font;
        private bool freeze = false;
        public bool resetTime { get; set; }
        public int lifeCount { get; set; }
        public bool displayLifeText { get; set; }
        private LifeText lifeText;


        private int freezeCount = 0;
        private int lifeScreenCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            lifeCount = 3;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            level = new Level(this);
            lifeText = new LifeText(this);
            resetTime = false;
            InitializeCommands();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateElements();
            level.Load(GameConstants.OverworldLevel, new Vector2(GameConstants.MarioStartingX, GameConstants.MarioStartingY)); ;
           
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {         
            if (!freeze)
            {
                level.Update();
                if (level.mainCharacter.marioState == MainCharacter.MARIO_DEAD)
                {
                    freeze = true;
                    lifeCount--;
                }
                keyboardController.Update();
                base.Update(gameTime);
            }
            else
            {
                if (freezeCount == GameConstants.FreezeTime)
                {

                    int marioWidth = level.mainCharacter.state.Sprite.desRectangle.Width;
                    level.mainCharacter.marioAction = MainCharacter.MARIO_IDLE;
                    level.mainCharacter.marioState = MainCharacter.MARIO_SMALL;
                    level.mainCharacter.marioDirection = !MainCharacter.MARIO_LEFT;
                    level.mainCharacter.MarioChangeForm(MainCharacter.MARIO_SMALL);
                    level.mainCharacter.animated = true;
                    level.mainCharacter.animation = GameConstants.LifeScreenAnimation;
                    level.Load(GameConstants.LifeScreen,new Vector2((GameConstants.ScreenWidth/2)-marioWidth-GameConstants.Eight,GameConstants.ScreenHeight/2));
                    displayLifeText = true;
                    if (lifeScreenCount == GameConstants.LifeScreenTime)
                    {
                        level.mainCharacter.animated = false;
                        keyboardController.keysEnabled = true;
                        freeze = false;
                        freezeCount = 0;
                        lifeScreenCount = 0;
                        displayLifeText = false;
                        if (lifeCount > 0)
                        {
                            ResetGame();
                        } else
                        {
                            Exit();
                        }
                    }
                    else
                    {
                        lifeScreenCount++;
                    }
                }
                else
                {
                    freezeCount++;
                }
            }           
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
            keyboardController.RegisterCommand(Keys.W, new MarioJumpCommand(this));

            keyboardController.RegisterCommand(Keys.Space, new PauseGameCommand(this));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.C, new MarioChangeFormCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Keys.BrowserBack, new MarioIdleCommand(this));
            keyboardController.RegisterCommand(Keys.X, new MarioAttackCommand(this));
            //arbitrarily choose o,p for animation commands
            //o,p,Attn is disabled in KeyboardController.cs
            keyboardController.RegisterCommand(Keys.BrowserHome, new MarioGrowCommand(this));

            gamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MarioJumpCommand(this));
            gamepadController.RegisterCommand(Buttons.Start, new ResetCommand(this));

        }

        private void CreateElements()
        {
            ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            UFOSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            MainCharSoundManager.instance.LoadSound(Content);
            BackgroundMusic.instanse.LoadSound(Content);
       
            font = Content.Load<SpriteFont>(@"SpriteFonts\Courier New");
        }

        public void ResetGame()
        {
            Initialize();
            LoadContent();
            resetTime = true;
        }
    }
}
