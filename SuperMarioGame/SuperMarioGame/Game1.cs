using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;

namespace SuperMarioGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IController controller;
        public Sprites.ISprite Flower, RedMush, GreenMush, Pipe, Goomba, Koopa, Coin, Star, UsedBlock, QuestionBlock, GroundBlock, BrickBlock, HiddenBlock;
        Sprites.ISprite LeftIdleSmallMario, RightIdleSmallMario, LeftRunningSmallMario, RightRunningSmallMario, LeftJumpingSmallMario, RightJumpingSmallMario, DeadSmallMario;
        Sprites.ISprite LeftRunningBigMario;

        public StateClass.Mario mario = new StateClass.Mario(new Vector2(700, 300), 2, true);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
       
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Assign commands to keys
            controller = new Controller.Controller();

            InitializeCommands();
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites();
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Flower.Update();
            RedMush.Update();
            GreenMush.Update();
            Pipe.Update();
            Goomba.Update();
            Koopa.Update();
            Coin.Update();
            Star.Update();
            UsedBlock.Update();
            GroundBlock.Update();
            HiddenBlock.Update();
            BrickBlock.Update();
            QuestionBlock.Update();
            LeftIdleSmallMario.Update();
            RightIdleSmallMario.Update();
            LeftRunningSmallMario.Update();
            RightRunningSmallMario.Update();
            LeftJumpingSmallMario.Update();
            RightJumpingSmallMario.Update();
            DeadSmallMario.Update();
            //LeftRunningBigMario.Update();
            test1.MarioUpdate();
            controller.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Flower.Draw(new Vector2(100, 100));
            RedMush.Draw(new Vector2(200, 100));
            GreenMush.Draw(new Vector2(300, 100));
            Pipe.Draw(new Vector2(400, 100));
            Koopa.Draw(new Vector2(500, 100));
            Goomba.Draw(new Vector2(600, 100));
            Coin.Draw(new Vector2(100, 200));
            Star.Draw(new Vector2(200, 200));
            HiddenBlock.Draw(new Vector2(300, 200));
            GroundBlock.Draw(new Vector2(400, 200));
            BrickBlock.Draw(new Vector2(500, 200));
            QuestionBlock.Draw(new Vector2(600, 200));
            UsedBlock.Draw(new Vector2(700, 200));

            test1.MarioDraw();

            
            //LeftIdleSmallMario.Draw(new Vector2(700, 300));
            //RightIdleSmallMario.Draw(new Vector2(750, 300));
            //LeftRunningSmallMario.Draw(new Vector2(650, 300));
            //RightRunningSmallMario.Draw(new Vector2(600, 300));
            //RightJumpingSmallMario.Draw(new Vector2(550, 300));
            //LeftJumpingSmallMario.Draw(new Vector2(500, 300));
            //DeadSmallMario.Draw(new Vector2(450, 300));
            //LeftRunningBigMario.Draw(new Vector2(650, 300));



            base.Draw(gameTime);
        }

        private void InitializeCommands()
        {
            controller.RegisterCommand(Keys.W, new MarioIdleOrJumpCommand(this));
            controller.RegisterCommand(Keys.A, new MarioLeftIdleOrRunningCommand(this));
            controller.RegisterCommand(Keys.S, new MarioIdleOrCrouchingCommand(this));
            controller.RegisterCommand(Keys.D, new MarioRightIdleOrRunningCommand(this));
            controller.RegisterCommand(Keys.Y, new MarioSmallCommand(this));
            controller.RegisterCommand(Keys.U, new MarioBigCommand(this));
            controller.RegisterCommand(Keys.I, new MarioFireCommand(this));
            controller.RegisterCommand(Keys.O, new MarioDeadCommand(this));
            controller.RegisterCommand(Keys.Z, new QuestionBlockToUsedBlockCommand(this));
            controller.RegisterCommand(Keys.X, new BrickBlockDisappearCommand(this));
            controller.RegisterCommand(Keys.C, new HiddenBlockToUsedBlockCommand(this));
            controller.RegisterCommand(Keys.R, new ResetCommand(this));
        }

        private void LoadSprites()
        {
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content,spriteBatch);
            SpriteFactories.EnvironmentSpriteFactory.Instance.LoadAllTextures(Content,spriteBatch);
            SpriteFactories.EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
          

            Flower = SpriteFactories.ItemSpriteFactory.Instance.CreateFlowerSprite();
            RedMush = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
            GreenMush = SpriteFactories.ItemSpriteFactory.Instance.CreateGreenMushroomSprite();
            Pipe = SpriteFactories.EnvironmentSpriteFactory.Instance.CreatePipeSprite();
            Goomba = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
            Koopa = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
            Coin = SpriteFactories.ItemSpriteFactory.Instance.CreateCoinSprite();
            Star = SpriteFactories.ItemSpriteFactory.Instance.CreateStarSprite();
            UsedBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
            QuestionBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateQuestionBlockSprite();
            BrickBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();
            HiddenBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateHiddenBlockSprite();
            GroundBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateGroundBlockSprite();
            LeftIdleSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            RightIdleSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            LeftRunningSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();
            RightRunningSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
            LeftJumpingSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
            RightJumpingSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
            DeadSmallMario = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();

            LeftRunningBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
        }
    }
}
