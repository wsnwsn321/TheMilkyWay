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
        Sprites.ISprite Flower, RedMush, GreenMush, Pipe, Goomba, Koopa, Coin, Star, UsedBlock, QuestionBlock, GroundBlock, BrickBlock, HiddenBlock;
        Sprites.ISprite LeftIdleSmallMario, RightIdleSmallMario, LeftRunningSmallMario,RightRunningSmallMario, LeftJumpingSmallMario, RightJumpingSmallMario;
        Sprites.ISprite LeftIdleBigMario, RightIdleBigMario, LeftRunningBigMario, RightRunningBigMario, LeftJumpingBigMario, RightJumpingBigMario;



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
            LeftIdleBigMario.Update();
            RightIdleBigMario.Update();
            LeftRunningBigMario.Update();
            RightRunningBigMario.Update();
            LeftJumpingBigMario.Update();
            RightJumpingBigMario.Update();


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
            Flower.Draw(spriteBatch,new Vector2(100, 100));
            RedMush.Draw(spriteBatch, new Vector2(200, 100));
            GreenMush.Draw(spriteBatch, new Vector2(300, 100));
            Pipe.Draw(spriteBatch, new Vector2(400, 100));
            Koopa.Draw(spriteBatch, new Vector2(500, 100));
            Goomba.Draw(spriteBatch, new Vector2(600, 100));
            Coin.Draw(spriteBatch, new Vector2(100, 200));
            Star.Draw(spriteBatch, new Vector2(200, 200));
            HiddenBlock.Draw(spriteBatch, new Vector2(300, 200));
            GroundBlock.Draw(spriteBatch, new Vector2(400, 200));
            BrickBlock.Draw(spriteBatch, new Vector2(500, 200));
            QuestionBlock.Draw(spriteBatch, new Vector2(600, 200)); 
            UsedBlock.Draw(spriteBatch, new Vector2(700, 200));
            LeftIdleSmallMario.Draw(spriteBatch, new Vector2(700, 300));
            RightIdleSmallMario.Draw(spriteBatch, new Vector2(750, 300));
            LeftRunningSmallMario.Draw(spriteBatch, new Vector2(650, 300));
            RightRunningSmallMario.Draw(spriteBatch, new Vector2(600, 300));
            RightJumpingSmallMario.Draw(spriteBatch, new Vector2(550, 300));
            LeftJumpingSmallMario.Draw(spriteBatch, new Vector2(500, 300));
            LeftIdleBigMario.Draw(spriteBatch, new Vector2(450, 300));
            RightIdleBigMario.Draw(spriteBatch, new Vector2(400, 300));
            LeftRunningBigMario.Draw(spriteBatch, new Vector2(350, 300));
            RightRunningBigMario.Draw(spriteBatch, new Vector2(300, 300));
            RightJumpingBigMario.Draw(spriteBatch, new Vector2(250, 300));
            LeftJumpingBigMario.Draw(spriteBatch, new Vector2(200, 300));




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
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactories.EnvironmentSpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactories.EnemySpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFactories.MarioSpriteFactory.Instance.LoadAllTextures(Content);
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
            LeftIdleBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();
            RightIdleBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigMarioSprite();
            LeftRunningBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
            RightRunningBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
            LeftJumpingBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
            RightJumpingBigMario = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();

        }
    }
}
