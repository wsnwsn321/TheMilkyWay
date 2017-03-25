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
        public float gravity = 3;
        public int height;
        private int gameWidth, gameHeight;
        private Camera.Camera camera;
        int camX = 0;

        internal Mario mario = new Mario(new Vector2(2400, 358), Mario.MARIO_BIG, false);
        Game1 myGame;


        public Level(Game1 game)
        {
            myGame = game;
            camera = new Camera.Camera(game.Window.ClientBounds);

        }

        public void Update()
        {

            foreach (IEnemy enemy in enemyElements)
            {
                if (enemy.position.X > (-myGame.GraphicsDevice.Viewport.X) - 32 && enemy.position.X < ((-myGame.GraphicsDevice.Viewport.X) + 800))
                {
                    CollisionDetection.Instance.EnemyBlockCollision(enemy, envElements);
                    CollisionDetection.Instance.EnemyEnemyCollision(enemy, enemyElements);
                    if (enemy.onTop)
                    {
                        enemy.gravity = 0;
                    }
                    else
                    {
                        enemy.gravity = 4;
                    }
                    enemy.position = new Vector2(enemy.position.X, enemy.position.Y + enemy.gravity);
                    enemy.Update();
                }
            }
            foreach (IItem item in itemElements)
            {
                CollisionDetection.Instance.ItemBlockCollision(item, envElements);
                CollisionDetection.Instance.ItemEnemyCollision(item, enemyElements);
                if (item.onTop)
                {
                    item.gravity = 0;
                }
                else
                {
                    item.gravity = 4;
                }
                if (!(item is Flower) && !(item is Coin))
                {
                    item.position = new Vector2(item.position.X, item.position.Y + item.gravity);
                }
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
            CollisionDetection.Instance.MarioBlockCollision(myGame, mario, envElements);
            CollisionDetection.Instance.MarioEnemyCollision(mario, enemyElements);
            CollisionDetection.Instance.MarioItemCollision(mario, itemElements);
            //if (!mario.onTop)
            //{
            //    mario.gravity = 3;
            //}
            //else
            //{
            //    mario.gravity = 0;
            //}

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
            camera.InitialShift(loader.GetHeight());
            mario.MarioIdle();
        }
    }
}
