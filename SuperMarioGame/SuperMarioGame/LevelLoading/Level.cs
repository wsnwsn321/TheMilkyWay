using Microsoft.Xna.Framework;
using SuperMarioGame.CollisionHandler;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ElementInterfaces;
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

        internal Mario mario = new Mario(new Vector2(400, 400), Mario.MARIO_SMALL, false);
        //mario.MarioIdle();

        public void Update()
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
            foreach (IBackground back in backgroundElements)
            {
                back.Update();
            }

            mario.MarioUpdate();

            CollisionDetection.Instance.MarioBlockCollision(mario, envElements);
            CollisionDetection.Instance.MarioEnemyCollision(mario, enemyElements);
            CollisionDetection.Instance.MarioItemCollision(mario, itemElements);
        }

        public void Draw()
        {
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
            foreach (IBackground back in backgroundElements)
            {
                back.Draw();
            }

            mario.MarioDraw();
        }

        public void resetLevel()
        {
            mario = new Mario(new Vector2(400, 400), Mario.MARIO_SMALL, false);
            mario.MarioIdle();
            envElements = new List<IBlock>();
            itemElements = new List<IItem>();
            enemyElements = new List<IEnemy>();
            backgroundElements = new List<IBackground>();
        }
        
        public void Load()
        {
            LevelLoader loader = new LevelLoader(this);
            loader.LoadLevel();
            Debug.WriteLine(envElements.Capacity);
        }
        

    }
}
