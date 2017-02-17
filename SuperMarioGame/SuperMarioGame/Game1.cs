using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Commands;
using SuperMarioGame.Controller;
using System.Collections.Generic;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;
using SuperMarioGame.ElementClasses;

namespace SuperMarioGame

{ 
    public class Game1 : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        GraphicsDeviceManager graphics;        
        SpriteBatch spriteBatch;
        GamepadController gamepadController;
        KeyboardController keyboardController;
        internal List<IBlock> envElements = new List<IBlock>();
        internal List<IItem> itemElements = new List<IItem>();
        internal List<IEnemy> enemyElements = new List<IEnemy>();

        internal Mario mario = new Mario(new Vector2(400, 300), 1, false);        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();

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
            foreach (IEnemy enemy in enemyElements)
            {
                enemy.Update();
            }
            foreach (IItem item in itemElements)
            {
                item.Update();
            }
            foreach (IBlock block in envElements)
            {
                block.Update();
            }

            mario.MarioUpdate();
            keyboardController.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (IEnemy enemy in enemyElements)
            {
                enemy.Draw();
            }
            foreach (IItem item in itemElements)
            {
                item.Draw();
            }
            foreach (IBlock block in envElements)
            {
                block.Draw();
            }

            mario.MarioDraw();
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


            gamepadController.RegisterCommand(Buttons.LeftThumbstickUp, new MarioJumpCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickLeft, new MarioLeftCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickDown, new MarioCrouchCommand(this));
            gamepadController.RegisterCommand(Buttons.LeftThumbstickRight, new MarioRightCommand(this));
            gamepadController.RegisterCommand(Buttons.Start, new ResetCommand(this));

        }

        private void CreateElements()
        {
            //Load the textures from factories
            SpriteFactories.ItemSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnvironmentSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.EnemySpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);
            SpriteFactories.MarioSpriteFactory.Instance.LoadAllTextures(Content, spriteBatch);

            enemyElements.Add(new Koopa(new Vector2(500, 100)));
            //enemyElements[0] - Koopa
            enemyElements.Add(new Goomba(new Vector2(600, 100)));
            //enemyElements[1] - Goomba

            itemElements.Add(new Coin(new Vector2(100, 200)));
            //itemElements[0] - Coin
            itemElements.Add(new Flower(new Vector2(100, 100)));
            //itemElements[1] - Flower
            itemElements.Add(new GreenMushroom(new Vector2(300, 100)));
            //itemElements[2] - GreenMushroom
            itemElements.Add(new RedMushroom(new Vector2(200, 100)));
            //itemElements[3] - RedMushroom
            itemElements.Add(new Star(new Vector2(200, 200)));
            //itemElements[4] - Star

            envElements.Add(new UsedBlock(new Vector2(700, 200)));
            //envElements[0] - UsedBlock
            envElements.Add(new QuestionBlock(new Vector2(400, 200)));
            //envElements[1] - QuestionBlock
            envElements.Add(new BrickBlock(new Vector2(500, 200)));
            //envElements[2] - BrickBlock
            envElements.Add(new HiddenBlock(new Vector2(300, 200)));
            //envElements[3] - HiddenBlock
            envElements.Add(new GroundBlock(new Vector2(600, 200)));
            //envElements[4] - GroundBlock
            envElements.Add(new StageBlock(new Vector2(700, 100)));
            //envElements[5] - StageBlock
            envElements.Add(new Pipe(new Vector2(400, 100)));
            //envElements[6] - Pipe
        }

        public void ResetGame()
        {
            mario = new Mario(new Vector2(400, 300), 1, false);
            mario.MarioIdle();
            Initialize();
            envElements = new List<IBlock>();
            itemElements = new List<IItem>();
            enemyElements = new List<IEnemy>();
            LoadContent();
        }
    }
}
