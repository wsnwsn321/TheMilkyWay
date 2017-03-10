using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.CollisionHandler;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.ItemClass;
using System.Collections.Generic;

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
        private Camera.Camera camera;
        int camX = 0;



        internal Mario mario = new Mario(new Vector2(50, 358), Mario.MARIO_SMALL, false);
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
                enemy.position = new Vector2(enemy.position.X, enemy.position.Y + gravity);
                enemy.Update();
                CollisionDetection.Instance.EnemyBlockCollision(enemy, envElements);
                CollisionDetection.Instance.EnemyEnemyCollision(enemy, enemyElements);
            }
            foreach (IItem item in itemElements)
            {
                if(!(item is Flower) && !(item is Coin))
                {
                    item.position = new Vector2(item.position.X, item.position.Y + gravity);
                }
                item.Update();
                CollisionDetection.Instance.ItemBlockCollision(item, envElements);
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

            mario.MarioUpdate();
            mario.position = new Vector2(mario.position.X, mario.position.Y + gravity);
            if(mario.position.X > (-myGame.GraphicsDevice.Viewport.X) + 400)
            {
                camX -= 1;
            }
            
        }

        public void Draw()
        {
            myGame.GraphicsDevice.Viewport = new Viewport(camX, 0, 800, 480);

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
                enemy.Draw();
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
            camera.InitialShift(loader.GetHeight());
            mario.MarioIdle();
        }


    }
}
