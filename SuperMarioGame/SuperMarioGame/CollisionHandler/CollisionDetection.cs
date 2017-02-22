using System.Collections.Generic;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;


namespace SuperMarioGame.CollisionHandler
{
    class CollisionDetection
    {
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
                    collideRectangle = Rectangle.Intersect(firstRectangle,secondRectangle);
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
                            SIDE = 2;
                        }
                        else
                        {
                            SIDE = 4;
                        }
                    }
                    MarioBlockHandler.BlockHandler(mario, block, SIDE);
                }
            }
        }

        public void MarioItemCollision(Mario mario, List<IItem> itemElements)
        {
            foreach (IItem item in itemElements)
            {     
                if (mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {
                    firstRectangle = mario.state.marioSprite.desRectangle;
                    secondRectangle = item.itemSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
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
                    MarioItemHandler.ItemHandler(mario, item, SIDE);
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
                    MarioEnemyHandler.EnemyHandler(mario, enemy, SIDE);
                }
            }
        }

        //maybe need an enemy enemy collison too because we would need it later.
        //  public void MarioEnemyCollision(List<IEnemy> enemyElement1, List<IEnemy> enemyElement2)

        //and a enemy block collision as well
        //  public void MarioEnemyCollision(List<IEnemy> enemyElements, List<IBlock>envElements)

    }
}
