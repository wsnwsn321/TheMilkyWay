using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;
using System.Collections.Generic;
 
namespace SuperMarioGame

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        GraphicsDeviceManager graphics;        
        SpriteBatch spriteBatch;
        IController controller;
        internal Sprites.ISprite Flower, RedMush, GreenMush, Pipe, Goomba, Koopa, Coin, Star;
        //initial mario
        public List<StateClass.StateInterface.IBlock> envElements = new List<StateClass.StateInterface.IBlock>();
        //public StateClass.StateInterface.IBlock BrickBlock;
        //public StateClass.StateInterface.IBlock HiddenBlock;
        //public StateClass.StateInterface.IBlock UsedBlock;
        //public StateClass.StateInterface.IBlock QuestionBlock;
        //public StateClass.StateInterface.IBlock GroundBlock;
        //public StateClass.StateInterface.IBlock StageBlock;


        internal StateClass.Mario mario = new StateClass.Mario(new Vector2(400, 300), 1, false);        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Assign commands to keys
            controller = new Controller.Controller();

            InitializeCommands();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites();
            mario.MarioIdle();
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            Flower.Update();
            RedMush.Update();
            GreenMush.Update();
            Pipe.Update();
            Goomba.Update();
            Koopa.Update();
            Coin.Update();
            Star.Update();
            foreach (StateClass.StateInterface.IBlock block in envElements)
            {
                block.Update();
            }
            //UsedBlock.Update();
            //GroundBlock.Update();
            //HiddenBlock.Update();
            //BrickBlock.Update();
            //QuestionBlock.Update();
            //StageBlock.Update();

            mario.MarioUpdate();
            controller.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Flower.Draw(new Vector2(100, 100));
            RedMush.Draw(new Vector2(200, 100));
            GreenMush.Draw(new Vector2(300, 100));
            Pipe.Draw(new Vector2(400, 100));
            Koopa.Draw(new Vector2(500, 100));
            Goomba.Draw(new Vector2(600, 100));
            Coin.Draw(new Vector2(100, 200));
            Star.Draw(new Vector2(200, 200));
            foreach (StateClass.StateInterface.IBlock block in envElements)
            {
                block.Draw();
            }
            //HiddenBlock.Draw();
            //GroundBlock.Draw();
            //BrickBlock.Draw();
            //QuestionBlock.Draw();
            //UsedBlock.Draw();
            //StageBlock.Draw();

            mario.MarioDraw();

            base.Draw(gameTime);
        }

        private void InitializeCommands()
        {
            controller.RegisterCommand(Keys.W, new MarioIdleOrJumpCommand(this));
            controller.RegisterCommand(Keys.A, new MarioLeftIdleOrRunningCommand(this));
            controller.RegisterCommand(Keys.S, new MarioIdleOrCrouchingCommand(this));
            controller.RegisterCommand(Keys.D, new MarioRightIdleOrRunningCommand(this));

            controller.RegisterCommand(Keys.Up, new MarioIdleOrJumpCommand(this));
            controller.RegisterCommand(Keys.Left, new MarioLeftIdleOrRunningCommand(this));
            controller.RegisterCommand(Keys.Down, new MarioIdleOrCrouchingCommand(this));
            controller.RegisterCommand(Keys.Right, new MarioRightIdleOrRunningCommand(this));

            controller.RegisterCommand(Keys.Y, new MarioSmallCommand(this));
            controller.RegisterCommand(Keys.U, new MarioBigCommand(this));
            controller.RegisterCommand(Keys.I, new MarioFireCommand(this));
            controller.RegisterCommand(Keys.O, new MarioDeadCommand(this));
            controller.RegisterCommand(Keys.Z, new QuestionBlockToUsedBlockCommand(this));
            controller.RegisterCommand(Keys.X, new BrickBlockDisappearCommand(this));
            controller.RegisterCommand(Keys.C, new HiddenBlockToUsedBlockCommand(this));
            controller.RegisterCommand(Keys.R, new ResetCommand(this));
            controller.RegisterCommand(Keys.Q, new QuitCommand(this));
        }

        private void LoadSprites()
        {
            //Load the textures from factories
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            //Create instances for all sprites from spritefactories
            Flower = SpriteFactories.ItemSpriteFactory.Instance.CreateFlowerSprite();
            RedMush = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
            GreenMush = SpriteFactories.ItemSpriteFactory.Instance.CreateGreenMushroomSprite();
            Pipe = SpriteFactories.EnvironmentSpriteFactory.Instance.CreatePipeSprite();
            Goomba = SpriteFactories.EnemySpriteFactory.Instance.CreateGoombaSprite();
            Koopa = SpriteFactories.EnemySpriteFactory.Instance.CreateKoopaSprite();
            Coin = SpriteFactories.ItemSpriteFactory.Instance.CreateCoinSprite();
            Star = SpriteFactories.ItemSpriteFactory.Instance.CreateStarSprite();
            //UsedBlock = new StateClass.EnvironmentClass.UsedBlock(new Vector2(700, 200));
            //QuestionBlock = new StateClass.EnvironmentClass.QuestionBlock(new Vector2(400, 200));
            //BrickBlock = new StateClass.EnvironmentClass.BrickBlock(new Vector2(500, 200));
            //HiddenBlock = new StateClass.EnvironmentClass.HiddenBlock(new Vector2(300, 200));
            //GroundBlock = new StateClass.EnvironmentClass.GroundBlock(new Vector2(600,200));
            //StageBlock = new StateClass.EnvironmentClass.StageBlock(new Vector2(700, 100));
            envElements.Add(new StateClass.EnvironmentClass.UsedBlock(new Vector2(700, 200)));
            envElements.Add(new StateClass.EnvironmentClass.QuestionBlock(new Vector2(400, 200)));
            envElements.Add(new StateClass.EnvironmentClass.BrickBlock(new Vector2(500, 200)));
            envElements.Add(new StateClass.EnvironmentClass.HiddenBlock(new Vector2(300, 200)));
            envElements.Add(new StateClass.EnvironmentClass.GroundBlock(new Vector2(600, 200)));
            envElements.Add(new StateClass.EnvironmentClass.StageBlock(new Vector2(700, 100)));
        }

        public void ResetGame()
        {
            mario = new StateClass.Mario(new Vector2(400, 300), 1, false);
            mario.MarioIdle();
            Initialize();
            LoadContent();

        }
    }
}
