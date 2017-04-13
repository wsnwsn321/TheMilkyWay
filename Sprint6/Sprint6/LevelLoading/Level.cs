using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.CollisionHandler;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.ItemClass;
using Sprint6.HUDElements;
using Sprint6.SpriteFactories;
using System.Collections.Generic;
using Sprint6.Sound.BackgroundMusic;

namespace Sprint6.LevelLoading
{
    public class Level
    {
        internal List<IBlock> envElements = new List<IBlock>();
        internal List<IItem> itemElements = new List<IItem>();
        internal List<IEnemy> enemyElements = new List<IEnemy>();
        internal List<IBackground> backgroundElements = new List<IBackground>();
        internal List<IItem> fireBallList = new List<IItem>();
        internal Stack<int> deleteList = new Stack<int>();

        private PauseText pauseText;
        internal ScoreSystem scoreSystem;

        public string currentLevel { get; set; }
        public Color backgroundColor { get; set; }
        private int gameWidth, gameHeight;
        private bool IsPaused { get; set;}
        int camX = 0;

        internal MainCharacter mainCharacter;
        Game1 myGame;


        public Level(Game1 game)
        {
           
            myGame = game;
            currentLevel = GameConstants.OverworldLevel;
            IsPaused = false;
            backgroundColor = Color.CornflowerBlue;
            mainCharacter = new MainCharacter(myGame, new Vector2(GameConstants.MarioStartingX, GameConstants.MarioStartingY), MainCharacter.MARIO_SMALL, false);
            
        }

        public void Update()
        {            
            if (!IsPaused)
            {
                mainCharacter.canMove = true;
                foreach (IEnemy enemy in enemyElements)
                {
                    if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - GameConstants.SquareWidth && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + GameConstants.ScreenWidth))
                    {
                        CollisionDetection.Instance.EnemyBlockCollision(mainCharacter, enemy, envElements);
                        CollisionDetection.Instance.EnemyEnemyCollision(enemy, enemyElements);
                        enemy.position = new Vector2(enemy.position.X, enemy.position.Y + enemy.gravity);
                        enemy.Update();
                    }
                }

                foreach (IItem item in itemElements)
                {
                    CollisionDetection.Instance.ItemBlockCollision(item, envElements);

                    if (!(item is Flower) && !(item is Coin))
                    {
                        item.position = new Vector2(item.position.X, item.position.Y + item.gravity);
                    }
                    item.Update();
                }



                foreach (IItem item in fireBallList)
                {

                    CollisionDetection.Instance.ItemBlockCollision(item, envElements);
                    CollisionDetection.Instance.ItemEnemyCollision(item, enemyElements,mainCharacter);


                    if (!item.isVisible)
                    {
                        deleteList.Push(fireBallList.IndexOf(item));
                    }
                    item.Update();
                }

                while (deleteList.Count > 0)
                {
                    fireBallList.RemoveAt(deleteList.Pop());
                }



                foreach (IBlock block in envElements)
                {
                    block.Update();
                }


                foreach (IBackground back in backgroundElements)
                {
                    CollisionDetection.Instance.MarioFlagCollision(mainCharacter, backgroundElements);
                    back.Update();
                }
                if (!mainCharacter.animated)
                {
                    CollisionDetection.Instance.MarioBlockCollision(myGame, mainCharacter, envElements);
                    CollisionDetection.Instance.MarioEnemyCollision(mainCharacter, enemyElements);
                    CollisionDetection.Instance.MarioItemCollision(mainCharacter, itemElements);
                    mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + mainCharacter.gravity);
                    mainCharacter.MarioUpdate();

                    if ((mainCharacter.position.X > (-myGame.GraphicsDevice.Viewport.X) + 400) && -myGame.GraphicsDevice.Viewport.X < gameWidth - GameConstants.ScreenWidth)
                    {
                        camX -= (int)(mainCharacter.position.X + myGame.GraphicsDevice.Viewport.X - 400);
                    }
                }
                else
                {
                    if (mainCharacter.animation == GameConstants.FlagAnimation)
                    {
                        mainCharacter.FlagAnimationUpdate();
                    }
                    else if(mainCharacter.animation == GameConstants.PipeAnimation)
                    {
                        mainCharacter.PipeAnimationUpdate();
                    }
                    else if(mainCharacter.animation == GameConstants.UnderPipeAnimation)
                    {
                        mainCharacter.UnderPipeAnimationUpdate();
                    }
                    else if(mainCharacter.animation == GameConstants.GrowAnimation)
                    {
                        mainCharacter.GrowAnimationUpdate();
                    }
                    else
                    {
                        mainCharacter.LifeScreenUpdate();
                    }
                }
            }
            else
            {
                mainCharacter.canMove = false;
            }
        }

        public void Draw()
        {
            myGame.GraphicsDevice.Viewport = new Viewport(camX, 0, gameWidth, gameHeight);

            foreach (IBackground back in backgroundElements)
            {
                back.Draw();
            }
            foreach (IItem item in itemElements)
            {
                item.Draw();
            }
            foreach(IItem fireBall in fireBallList)
            {
                fireBall.Draw();
            }
            if(IsPaused)
            {
                pauseText.Draw();
            }
            if (mainCharacter.isVisible)
            {
                mainCharacter.MarioDraw();
            }
            foreach (IBlock block in envElements)
            {
                block.Draw();
            }
            foreach (IEnemy enemy in enemyElements)
            {
                if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - GameConstants.SquareWidth && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + GameConstants.ScreenWidth))
                {
                    enemy.Draw();
                }
            }
            scoreSystem.DisplayScore(mainCharacter.totalScore);
            scoreSystem.CoinSystem(mainCharacter.coin);
            scoreSystem.WorldSystem();
            scoreSystem.Time();
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
            scoreSystem = new ScoreSystem(myGame);
            switch (levelToLoad)
            {
                case GameConstants.OverworldLevel:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.LEVEL1);
                    break;
                case GameConstants.UnderworldLevel:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.LEVEL2);
                    break;
            }
          
            
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
