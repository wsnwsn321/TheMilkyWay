using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.CollisionHandler;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.HUDElements;
using Sprint6.SpriteFactories;
using System.Collections.Generic;
using Sprint6.Sound.BackgroundMusic;
using System;

namespace Sprint6.LevelLoading
{
    public class Level
    {
        internal List<IBlock> envElements = new List<IBlock>();
        internal List<IItem> itemElements = new List<IItem>();
        internal List<IEnemy> enemyElements = new List<IEnemy>();
        internal List<IBackground> backgroundElements = new List<IBackground>();

        private PauseText pauseText;
        internal HUDManager scoreSystem;

        public string currentLevel { get; set; }
        public IBackground background { get; set; }
        private int gameWidth, gameHeight;
        private bool IsPaused { get; set;}
        int camX = 0;

        internal MainCharacter mainCharacter;
        Game1 myGame;
        public int accel { get; set; }

        public Level(Game1 game)
        {
           
            myGame = game;
            currentLevel = GameConstants.OverworldLevel;
            IsPaused = false;
            mainCharacter = new MainCharacter(myGame, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
            
        }

        public void Update()
        {            
            if (!IsPaused)
            {
                mainCharacter.canMove = true;
                foreach (IEnemy enemy in enemyElements)
                {
                    if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - 100 && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + GameConstants.ScreenWidth))
                    {
                        CollisionDetection.Instance.EnemyBlockCollision(mainCharacter, enemy, envElements);

                        enemy.Update();
                    }
                }

                foreach (IItem item in itemElements)
                {
                    CollisionDetection.Instance.ItemBlockCollision(item, envElements);
                    CollisionDetection.Instance.BeamCowCollision(myGame,mainCharacter,itemElements);
                    item.position = new Vector2(item.position.X, item.position.Y + item.gravity);
                    item.Update();
                }

                foreach (IBlock block in envElements)
                {
                    block.Update();
                }


                foreach (IBackground back in backgroundElements)
                {
                    back.Update();
                }
                if (!mainCharacter.animated)
                {
                    CollisionDetection.Instance.MainCharBlockCollision(myGame, mainCharacter, envElements);
                    CollisionDetection.Instance.MarioEnemyCollision(mainCharacter, enemyElements);
                    CollisionDetection.Instance.MainCharItemCollision(mainCharacter, itemElements);
                    if (accel != 5)
                    {
                        accel += 1;
                    }
                    mainCharacter.state.Update();
                    if (mainCharacter.canMove)
                    {
                        mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + mainCharacter.gravity + accel);
                        mainCharacter.MainCharUpdate();

                    }

                    if ((mainCharacter.position.X > (-myGame.GraphicsDevice.Viewport.X) + 400) && -myGame.GraphicsDevice.Viewport.X < gameWidth - GameConstants.ScreenWidth)
                    {
                        camX -= (int)(mainCharacter.position.X + myGame.GraphicsDevice.Viewport.X - 400);
                    }
                }
                //else do animation updates
            }
            else
            {
                mainCharacter.canMove = false;
            }
        }

        public void Draw()
        {
            myGame.GraphicsDevice.Viewport = new Viewport(camX, 0, gameWidth, gameHeight);

            background.Draw();

            foreach (IBackground back in backgroundElements)
            {
                back.Draw();
            }
            foreach (IItem item in itemElements)
            {
                item.Draw();
            }
            if(IsPaused)
            {
                pauseText.Draw();
            }
            if (mainCharacter.isVisible)
            {
                mainCharacter.MainCharDraw();
            }
            foreach (IBlock block in envElements)
            {
                block.Draw();
            }
            foreach (IEnemy enemy in enemyElements)
            {
                if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - 100 && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + GameConstants.ScreenWidth))
                {
                    enemy.Draw();
                }
            }
            scoreSystem.DisplayHUDElements();
        }
        
        public void Load(string levelToLoad, Vector2 marioPos)
        {
            currentLevel = levelToLoad;
            camX = 0;
            envElements = new List<IBlock>();
            itemElements = new List<IItem>();
            enemyElements = new List<IEnemy>();
            backgroundElements = new List<IBackground>();
            pauseText = new PauseText(myGame);
            LevelLoader loader = new LevelLoader(this);
            loader.LoadLevel(currentLevel);
            gameWidth = loader.width;
            gameHeight = loader.height;
            mainCharacter.MarioIdle();
            mainCharacter.position = marioPos;
            scoreSystem = new HUDManager(myGame);
                    BackgroundMusic.instanse.playSound(BackgroundMusic.BACKGROUNGMUSIC1);
                  
            
        }

        public void Pause()
        {
            IsPaused = !IsPaused;
            if (IsPaused) { 
                Microsoft.Xna.Framework.Media.MediaPlayer.Pause();
             }else{
                Microsoft.Xna.Framework.Media.MediaPlayer.Resume();
            }
        }
    }
}
