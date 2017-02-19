using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    class CollisionDetection
    {
        private Mario mario;
        private List<IBlock> envElements = new List<IBlock>();
        private List<IItem> itemElements = new List<IItem>();
        private List<IEnemy> enemyElements = new List<IEnemy>();

        private static CollisionDetection instance = new CollisionDetection();


        public static CollisionDetection Instance
        {
            get
            {
                return instance;
            }
        }

        private CollisionDetection()
        {
        }

        public void MarioBlockCollision(Mario mario, List<IBlock> envElements)
        {

            foreach (IBlock block in envElements)
            {
                mario.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle);
            }
        }

        public void MarioItemCollision(Mario mario, List<IItem> itemElements)
        {

            foreach (IItem item in itemElements)
            {
                mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle);
            }
        }

        public void MarioEnemyCollision(Mario mario, List<IEnemy> enemyElements)
        {

            foreach (IEnemy enemy in enemyElements)
            {
                mario.state.marioSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle);
            }
        }

    }
}
