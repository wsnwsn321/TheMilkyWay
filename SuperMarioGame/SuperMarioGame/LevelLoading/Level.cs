using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.CollisionHandler;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.ItemClass;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperMarioGame.LevelLoading
{
    public class Level
    {
        internal List<IBlock> envElements = new List<IBlock>();
        internal List<IItem> itemElements = new List<IItem>();
        internal List<IEnemy> enemyElements = new List<IEnemy>();
        internal List<IBackground> backgroundElements = new List<IBackground>();
        internal List<IItem> fireBall = new List<IItem>();
        internal Stack<int> deleteList = new Stack<int>();
    
        public float gravity = 3;
        public int height;
        private int gameWidth, gameHeight;
        int camX = 0;

        internal Mario mario = new Mario(new Vector2(100, 358), Mario.MARIO_SMALL, false);
        Game1 myGame;


        public Level(Game1 game)
        {
           
            myGame = game;
        }

        public void Update()
        {

            foreach (IEnemy enemy in enemyElements)
            {
                if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - 32 && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + 800))
                {
                    CollisionDetection.Instance.EnemyBlockCollision(enemy, envElements);
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
            

            
            foreach (IItem item in fireBall)
            {
                
                CollisionDetection.Instance.ItemBlockCollision(item,envElements);
                CollisionDetection.Instance.ItemEnemyCollision(item, enemyElements);

            
                if (!item.isVisible)
                {
                    deleteList.Push(fireBall.IndexOf(item));
                }
                item.Update();
            }

            while(deleteList.Count > 0)
            {
                fireBall.RemoveAt(deleteList.Pop());
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
            CollisionDetection.Instance.MarioBlockCollision(myGame, mario, envElements);
            CollisionDetection.Instance.MarioEnemyCollision(mario, enemyElements);
            CollisionDetection.Instance.MarioItemCollision(mario, itemElements);

            mario.position = new Vector2(mario.position.X, mario.position.Y + mario.gravity);
            mario.MarioUpdate();

            if ((mario.position.X > (-myGame.GraphicsDevice.Viewport.X) + 400) && -myGame.GraphicsDevice.Viewport.X < gameWidth - 800)
            {
                camX -= (int)(mario.position.X + myGame.GraphicsDevice.Viewport.X - 400);
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
            foreach (IBlock block in envElements)
            {               
                block.Draw();
            }
            foreach (IEnemy enemy in enemyElements)
            {
                if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X)-32 && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + 800))
                {
                    enemy.Draw();
                }
            }
            foreach(IItem fireBall in fireBall)
            {
                fireBall.Draw();
            }

            mario.MarioDraw();
        }
        
        public void Load()
        {
            envElements = new List<IBlock>();
            itemElements = new List<IItem>();
            enemyElements = new List<IEnemy>();
            backgroundElements = new List<IBackground>();
            LevelLoader loader = new LevelLoader(this);
            loader.LoadLevel();
            gameWidth = loader.GetWidth();
            gameHeight = loader.GetHeight();
            mario.MarioIdle();
        }
    }
}
