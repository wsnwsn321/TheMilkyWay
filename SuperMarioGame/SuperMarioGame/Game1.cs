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
        internal List<ElementClasses.ElementInterfaces.IBlock> envElements = new List<ElementClasses.ElementInterfaces.IBlock>();
        internal List<ElementClasses.ElementInterfaces.IItem> itemElements = new List<ElementClasses.ElementInterfaces.IItem>();
        internal List<ElementClasses.ElementInterfaces.IEnemy> enemyElements = new List<ElementClasses.ElementInterfaces.IEnemy>();

        internal ElementClasses.Mario mario = new ElementClasses.Mario(new Vector2(400, 300), 1, false);        

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
            foreach (ElementClasses.ElementInterfaces.IEnemy enemy in enemyElements)
            {
                enemy.Update();
            }
            foreach (ElementClasses.ElementInterfaces.IItem item in itemElements)
            {
                item.Update();
            }
            foreach (ElementClasses.ElementInterfaces.IBlock block in envElements)
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

            foreach (ElementClasses.ElementInterfaces.IEnemy enemy in enemyElements)
            {
                enemy.Draw();
            }
            foreach (ElementClasses.ElementInterfaces.IItem item in itemElements)
            {
                item.Draw();
            }
            foreach (ElementClasses.ElementInterfaces.IBlock block in envElements)
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

            enemyElements.Add(new ElementClasses.CharacterClass.Enemies.Koopa(new Vector2(500, 100)));
            //enemyElements[0] - Koopa
            enemyElements.Add(new ElementClasses.CharacterClass.Enemies.Goomba(new Vector2(600, 100)));
            //enemyElements[1] - Goomba

            itemElements.Add(new ElementClasses.ItemClass.Coin(new Vector2(100, 200)));
            //itemElements[0] - Coin
            itemElements.Add(new ElementClasses.ItemClass.Flower(new Vector2(100, 100)));
            //itemElements[1] - Flower
            itemElements.Add(new ElementClasses.ItemClass.GreenMushroom(new Vector2(300, 100)));
            //itemElements[2] - GreenMushroom
            itemElements.Add(new ElementClasses.ItemClass.RedMushroom(new Vector2(200, 100)));
            //itemElements[3] - RedMushroom
            itemElements.Add(new ElementClasses.ItemClass.Star(new Vector2(200, 200)));
            //itemElements[4] - Star

            envElements.Add(new ElementClasses.EnvironmentClass.UsedBlock(new Vector2(700, 200)));
            //envElements[0] - UsedBlock
            envElements.Add(new ElementClasses.EnvironmentClass.QuestionBlock(new Vector2(400, 200)));
            //envElements[1] - QuestionBlock
            envElements.Add(new ElementClasses.EnvironmentClass.BrickBlock(new Vector2(500, 200)));
            //envElements[2] - BrickBlock
            envElements.Add(new ElementClasses.EnvironmentClass.HiddenBlock(new Vector2(300, 200)));
            //envElements[3] - HiddenBlock
            envElements.Add(new ElementClasses.EnvironmentClass.GroundBlock(new Vector2(600, 200)));
            //envElements[4] - GroundBlock
            envElements.Add(new ElementClasses.EnvironmentClass.StageBlock(new Vector2(700, 100)));
            //envElements[5] - StageBlock
            envElements.Add(new ElementClasses.EnvironmentClass.Pipe(new Vector2(400, 100)));
            //envElements[6] - Pipe
        }

        public void ResetGame()
        {
            mario = new ElementClasses.Mario(new Vector2(400, 300), 1, false);
            mario.MarioIdle();
            Initialize();
            envElements = new List<ElementClasses.ElementInterfaces.IBlock>();
            itemElements = new List<ElementClasses.ElementInterfaces.IItem>();
            enemyElements = new List<ElementClasses.ElementInterfaces.IEnemy>();
            LoadContent();
        }
    }
}
