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
                if (mario.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                       
                }
            }
        }

        public void MarioItemCollision(Mario mario, List<IItem> itemElements)
        {

            foreach (IItem item in itemElements)
            {
               if(mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {

                }
                
            }
        }

        public void MarioEnemyCollision(Mario mario, List<IEnemy> enemyElements)
        {

            foreach (IEnemy enemy in enemyElements)
            {
                if (mario.state.marioSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle))
                {

                }
            }
        }

        //maybe need an enemy enemy collison too because we would need it later.
        //  public void MarioEnemyCollision(List<IEnemy> enemyElement1, List<IEnemy> enemyElement2)

        //and a enemy block collision as well
        //  public void MarioEnemyCollision(List<IEnemy> enemyElements, List<IBlock>envElements)

    }
}
