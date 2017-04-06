using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.CollisionHandler;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.HUDElements;
using SuperMarioGame.SpriteFactories;
using System.Collections.Generic;

namespace SuperMarioGame.LevelLoading
{
    public class Level
    {
        internal List<IBlock> envElements = new List<IBlock>();
        internal List<IItem> itemElements = new List<IItem>();
        internal List<IEnemy> enemyElements = new List<IEnemy>();
        internal List<IBackground> backgroundElements = new List<IBackground>();
        internal List<IItem> fireBallList = new List<IItem>();
        internal Stack<int> deleteList = new Stack<int>();

        private List<IBlock> tempEnvElements = new List<IBlock>();
        private List<IItem> tempItemElements = new List<IItem>();
        private List<IEnemy> tempEnemyElements = new List<IEnemy>();
        private List<IBackground> tempBackgroundElements = new List<IBackground>();
        private PauseText pauseText;
        internal ScoreSystem scoreSystem;

        public string currentLevel { get; set; }
        public Color backgroundColor;
        private int gameWidth, gameHeight;
        private bool IsPaused { get; set;}
        int camX = 0;

        internal Mario mario;
        Game1 myGame;


        public Level(Game1 game)
        {
           
            myGame = game;
            currentLevel = GameConstants.OverworldLevel;
            IsPaused = false;
            backgroundColor = Color.CornflowerBlue;
            mario = new Mario(myGame, new Vector2(GameConstants.MarioStartingX, GameConstants.MarioStartingY), Mario.MARIO_SMALL, false);
            
        }

        public void Update()
        {            
            if (!IsPaused)
            {
                mario.canMove = true;
                foreach (IEnemy enemy in enemyElements)
                {
                    if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - GameConstants.SquareWidth && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + GameConstants.ScreenWidth))
                    {
                        CollisionDetection.Instance.EnemyBlockCollision(mario, enemy, envElements);
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
                    CollisionDetection.Instance.ItemEnemyCollision(item, enemyElements);


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
                    CollisionDetection.Instance.MarioFlagCollision(mario, backgroundElements);
                    back.Update();
                }
                if (!mario.animated)
                {
                    CollisionDetection.Instance.MarioBlockCollision(myGame, mario, envElements);
                    CollisionDetection.Instance.MarioEnemyCollision(mario, enemyElements);
                    CollisionDetection.Instance.MarioItemCollision(mario, itemElements);
                    mario.position = new Vector2(mario.position.X, mario.position.Y + mario.gravity);
                    mario.MarioUpdate();

                    if ((mario.position.X > (-myGame.GraphicsDevice.Viewport.X) + 400) && -myGame.GraphicsDevice.Viewport.X < gameWidth - GameConstants.ScreenWidth)
                    {
                        camX -= (int)(mario.position.X + myGame.GraphicsDevice.Viewport.X - 400);
                    }
                }
                else
                {
                    if (mario.animation == GameConstants.FlagAnimation)
                        mario.FlagAnimationUpdate();
                    else
                        mario.PipeAnimationUpdate();
                }
            }
            else
            {
                mario.canMove = false;
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
            if (mario.isVisible)
            {
                mario.MarioDraw();
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
            scoreSystem.DisplayScore(mario.totalScore);
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
            mario.MarioIdle();
            mario.position = marioPos;
            scoreSystem = new ScoreSystem(myGame);
        }

        private void StoreElements()
        {
            tempBackgroundElements = backgroundElements;
            tempEnemyElements = enemyElements;
            tempEnvElements = envElements;
            tempItemElements = itemElements;
        }

        public void Pause()
        {
            IsPaused = !IsPaused;
        }
    }
}
