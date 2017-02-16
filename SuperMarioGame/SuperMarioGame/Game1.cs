using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;
using System;
using System.Collections.Generic;

namespace SuperMarioGame

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        GraphicsDeviceManager graphics;        
        SpriteBatch spriteBatch;
        IController controller;
        public List<StateClass.StateInterface.IBlock> envElements = new List<StateClass.StateInterface.IBlock>();
        public List<StateClass.StateInterface.IItem> itemElements = new List<StateClass.StateInterface.IItem>();
        public List<StateClass.StateInterface.IEnemy> enemyElements = new List<StateClass.StateInterface.IEnemy>();

        internal StateClass.Mario mario = new StateClass.Mario(new Vector2(400, 300), 1, false);        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            controller = new Controller.Controller();

            InitializeCommands();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CreateElements();
            mario.MarioIdle();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (StateClass.StateInterface.IEnemy enemy in enemyElements)
            {
                enemy.Update();
            }
            foreach (StateClass.StateInterface.IItem item in itemElements)
            {
                item.Update();
            }
            foreach (StateClass.StateInterface.IBlock block in envElements)
            {
                block.Update();
            }

            mario.MarioUpdate();
            controller.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (StateClass.StateInterface.IEnemy enemy in enemyElements)
            {
                enemy.Draw();
            }
            foreach (StateClass.StateInterface.IItem item in itemElements)
            {
                item.Draw();
            }
            foreach (StateClass.StateInterface.IBlock block in envElements)
            {
                block.Draw();
            }

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

        private void CreateElements()
        {
            //Load the textures from factories
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);

            enemyElements.Add(new StateClass.CharacterClass.Enemies.Koopa(new Vector2(500, 100)));
            //enemyElements[0] - Koopa
            enemyElements.Add(new StateClass.CharacterClass.Enemies.Goomba(new Vector2(600, 100)));
            //enemyElements[1] - Goomba

            itemElements.Add(new StateClass.ItemClass.Coin(new Vector2(100, 200)));
            //itemElements[0] - Coin
            itemElements.Add(new StateClass.ItemClass.Flower(new Vector2(100, 100)));
            //itemElements[1] - Flower
            itemElements.Add(new StateClass.ItemClass.GreenMushroom(new Vector2(300, 100)));
            //itemElements[2] - GreenMushroom
            itemElements.Add(new StateClass.ItemClass.RedMushroom(new Vector2(200, 100)));
            //itemElements[3] - RedMushroom
            itemElements.Add(new StateClass.ItemClass.Star(new Vector2(200, 200)));
            //itemElements[4] - Star

            envElements.Add(new StateClass.EnvironmentClass.UsedBlock(new Vector2(700, 200)));
            //envElements[0] - UsedBlock
            envElements.Add(new StateClass.EnvironmentClass.QuestionBlock(new Vector2(400, 200)));
            //envElements[1] - QuestionBlock
            envElements.Add(new StateClass.EnvironmentClass.BrickBlock(new Vector2(500, 200)));
            //envElements[2] - BrickBlock
            envElements.Add(new StateClass.EnvironmentClass.HiddenBlock(new Vector2(300, 200)));
            //envElements[3] - HiddenBlock
            envElements.Add(new StateClass.EnvironmentClass.GroundBlock(new Vector2(600, 200)));
            //envElements[4] - GroundBlock
            envElements.Add(new StateClass.EnvironmentClass.StageBlock(new Vector2(700, 100)));
            //envElements[5] - StageBlock
            envElements.Add(new StateClass.EnvironmentClass.Pipe(new Vector2(400, 100)));
            //envElements[6] - Pipe
        }

        public void ResetGame()
        {
            mario = new StateClass.Mario(new Vector2(400, 300), 1, false);
            mario.MarioIdle();
            Initialize();
            envElements = new List<StateClass.StateInterface.IBlock>();
            itemElements = new List<StateClass.StateInterface.IItem>();
            enemyElements = new List<StateClass.StateInterface.IEnemy>();
            LoadContent();
        }
    }
}
