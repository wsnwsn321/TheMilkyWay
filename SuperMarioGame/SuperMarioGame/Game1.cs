using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.LevelLoading;

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

        public int WINDOW_HEIGHT;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            level = new Level();

            InitializeCommands();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateElements();
            level.Load();
            //TestCase.TestQuestionBlockCollision.Instance.RunTests();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {   
            level.Update();
            keyboardController.Update();
            base.Update(gameTime);
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

            keyboardController.RegisterCommand(Keys.Up, new MarioJumpCommand(this));
            keyboardController.RegisterCommand(Keys.Left, new MarioLeftCommand(this));
            keyboardController.RegisterCommand(Keys.Right, new MarioRightCommand(this));
            keyboardController.RegisterCommand(Keys.Down, new MarioCrouchCommand(this));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.C, new MarioChangeFormCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Keys.BrowserBack, new MarioIdleCommand(this));


            gamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MarioJumpCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLeftCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioCrouchCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioRightCommand(this));
            gamepadController.RegisterCommand(Buttons.Start, new ResetCommand(this));

        }

        private void CreateElements()
        {
            //Load the textures from factories
            ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);

            //enemyElements.Add(new Koopa(new Vector2(500, 100)));
            ////enemyElements[0] - Koopa
            //enemyElements.Add(new Goomba(new Vector2(600, 100)));
            ////enemyElements[1] - Goomba
            //itemElements.Add(new Coin(new Vector2(100, 300)));
            ////itemElements[0] - Coin
            //itemElements.Add(new Flower(new Vector2(100, 100)));
            ////itemElements[1] - Flower
            //itemElements.Add(new GreenMushroom(new Vector2(300, 100)));
            ////itemElements[2] - GreenMushroom
            //itemElements.Add(new RedMushroom(new Vector2(200, 100)));
            ////itemElements[3] - RedMushroom
            //itemElements.Add(new Star(new Vector2(200, 300)));
            ////itemElements[4] - Star

            //envElements.Add(new UsedBlock(new Vector2(700, 300)));
            ////envElements[0] - UsedBlock
            //envElements.Add(new QuestionBlock(new Vector2(400, 300)));
            ////envElements[1] - QuestionBlock
            //envElements.Add(new BrickBlock(new Vector2(500, 300)));
            ////envElements[2] - BrickBlock
            //envElements.Add(new HiddenBlock(new Vector2(300, 300)));
            ////envElements[3] - HiddenBlock
            //envElements.Add(new GroundBlock(new Vector2(600, 300)));
            ////envElements[4] - GroundBlock
            //envElements.Add(new StageBlock(new Vector2(700, 100)));
            ////envElements[5] - StageBlock
            //envElements.Add(new Pipe(new Vector2(400, 100)));
            ////envElements[6] - Pipe

            //backgroundElements.Add(new BigCloud(new Vector2(200, 40)));
            //backgroundElements.Add(new SmallCloud(new Vector2(400, 40)));
            //backgroundElements.Add(new BigMountain(new Vector2(150, 410)));
            //backgroundElements.Add(new SmallMountain(new Vector2(375, 440)));
            //backgroundElements.Add(new BigBrush(new Vector2(500, 450)));
            //backgroundElements.Add(new SmallBrush(new Vector2(700, 450)));
        }

        public void ResetGame()
        {
            Initialize();
            LoadContent();
            
        }
    }
}
