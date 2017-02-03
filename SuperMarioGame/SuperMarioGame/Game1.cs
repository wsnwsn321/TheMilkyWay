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
        SpriteFactories.ISprite Flower;

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
           // this.InitializeCommands();
            
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
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Flower =  SpriteFactories.ItemSpriteFactory.Instance.CreateFlowerSprite();
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
            Flower.Draw(spriteBatch,new Vector2( 100, 100));

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
    }
}
