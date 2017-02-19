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
        private Rectangle collideRectangle;
        private Rectangle firstRectangle;
        private Rectangle secondRectangle;
        public int SIDE;

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
                if (mario.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle)){
                    firstRectangle = mario.state.marioSprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(mario.state.marioSprite.desRectangle, block.blockSprite.desRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = 3;
                            MarioBlockHandler.BlockHandler(mario,block,3);
                        }
                        else
                        {
                            SIDE = 1;
                            MarioBlockHandler.BlockHandler(mario, block, 1);
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = 4;
                            MarioBlockHandler.BlockHandler(mario, block, 4);
                        }
                        else
                        {
                            SIDE = 2;
                            MarioBlockHandler.BlockHandler(mario, block, 2);
                        }
                    }
                    
                }
            }
        }

        public void MarioItemCollision(Mario mario, List<IItem> itemElements)
        {

            foreach (IItem item in itemElements)
            {
                mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle);
                if (mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {
                    firstRectangle = mario.state.marioSprite.desRectangle;
                    secondRectangle = item.itemSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(mario.state.marioSprite.desRectangle, item.itemSprite.desRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = 3;
                        }
                        else
                        {
                            SIDE = 1;
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = 4;
                        }
                        else
                        {
                            SIDE = 2;
                        }
                    }

                }
            }
        }

        public void MarioEnemyCollision(Mario mario, List<IEnemy> enemyElements)
        {

            foreach (IEnemy enemy in enemyElements)
            {
           
                if (mario.state.marioSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle))
                {
                    firstRectangle = mario.state.marioSprite.desRectangle;
                    secondRectangle = enemy.enemySprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(mario.state.marioSprite.desRectangle, enemy.enemySprite.desRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = 3;
                        }
                        else
                        {
                            SIDE = 1;
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = 4;
                        }
                        else
                        {
                            SIDE = 2;
                        }
                    }

                }
            }
        }

        //maybe need an enemy enemy collison too because we would need it later.
        //  public void MarioEnemyCollision(List<IEnemy> enemyElement1, List<IEnemy> enemyElement2)

        //and a enemy block collision as well
        //  public void MarioEnemyCollision(List<IEnemy> enemyElements, List<IBlock>envElements)

    }
}
