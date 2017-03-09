using System.Collections.Generic;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ItemClass;

namespace SuperMarioGame.CollisionHandler
{
    class CollisionDetection
    {
        private Rectangle collideRectangle;
        private Rectangle firstRectangle;
        private Rectangle secondRectangle;
        public const int TOP = 1, RIGHT = 2, BOTTOM = 3, LEFT = 4;
        public int SIDE;
        Game1 myGame;

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

        public void MarioBlockCollision(Game1 game, Mario mario, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                myGame = game;
                if (mario.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = mario.state.marioSprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = BOTTOM;
                        }
                        else
                        {
                            SIDE = TOP;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = RIGHT;
                        }
                        else
                        {
                            SIDE = LEFT;
                        }
                    }
                   if (collideRectangle.Width * collideRectangle.Height > 13)
                    {
                        MarioBlockHandler.BlockHandler(myGame,mario, block, SIDE);
                    }
                }
            }
        }

        public void EnemyBlockCollision(IEnemy enemy, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                if (enemy.enemySprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = enemy.enemySprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = BOTTOM;
                        }
                        else
                        {
                            SIDE = TOP;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = RIGHT;
                        }
                        else
                        {
                            SIDE = LEFT;
                        }
                    }
                    if (collideRectangle.Width * collideRectangle.Height > 13)
                    {
                        EnemyBlockHandler.BlockHandler(enemy, block, SIDE);
                    }
                }
            }
        }

        public void ItemBlockCollision(IItem item, List<IBlock> envElements)
        {
            foreach (IBlock block in envElements)
            {
                if (!(item is Flower) && item.itemSprite.desRectangle.Intersects(block.blockSprite.desRectangle))
                {
                    firstRectangle = item.itemSprite.desRectangle;
                    secondRectangle = block.blockSprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(firstRectangle, secondRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = BOTTOM;
                        }
                        else
                        {
                            SIDE = TOP;
                        }
                    }
                    else if (collideRectangle.Width <= collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = RIGHT;
                        }
                        else
                        {
                            SIDE = LEFT;
                        }
                    }
                    if (collideRectangle.Width * collideRectangle.Height > 13)
                    {
                        ItemBlockHandler.BlockHandler(item, block, SIDE);
                    }
                }
            }
        }

        public void MarioItemCollision(Mario mario, List<IItem> itemElements)
        {
            SIDE = TOP;
            foreach (IItem item in itemElements)
            {     
                if (mario.state.marioSprite.desRectangle.Intersects(item.itemSprite.desRectangle))
                {
                    MarioItemHandler.ItemHandler(mario, item);
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
                            SIDE = BOTTOM;
                        }
                        else
                        {
                            SIDE = TOP;
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = RIGHT;
                        }
                        else
                        {
                            SIDE = LEFT;
                        }
                    }
                    MarioEnemyHandler.EnemyHandler(mario, enemy, SIDE);
                }
            }
        }

        public void EnemyEnemyCollision(IEnemy enemy1, List<IEnemy> enemyElements)
        {
            foreach (IEnemy enemy2 in enemyElements)
            {
                if (!enemy1.Equals(enemy2) && enemy1.enemySprite.desRectangle.Intersects(enemy2.enemySprite.desRectangle))
                {
                    firstRectangle = enemy1.enemySprite.desRectangle;
                    secondRectangle = enemy2.enemySprite.desRectangle;
                    collideRectangle = Rectangle.Intersect(enemy1.enemySprite.desRectangle, enemy2.enemySprite.desRectangle);
                    if (collideRectangle.Width > collideRectangle.Height)
                    {
                        if (firstRectangle.Top > secondRectangle.Top)
                        {
                            SIDE = BOTTOM;
                        }
                        else
                        {
                            SIDE = TOP;
                        }
                    }
                    else if (collideRectangle.Width < collideRectangle.Height)
                    {
                        if (firstRectangle.Left > secondRectangle.Left)
                        {
                            SIDE = RIGHT;
                        }
                        else
                        {
                            SIDE = LEFT;
                        }
                    }
                    EnemyEnemyHandler.EnemyHandler(enemy1, enemy2, SIDE);
                }
            }
        }
    }
}
