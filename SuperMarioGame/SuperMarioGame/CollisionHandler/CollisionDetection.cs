using System.Collections.Generic;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.Sprites;
using SuperMarioGame.SpriteFactories;

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
            mario.gravity = 4;
            foreach (IBlock block in envElements)
            {
                myGame = game;
                if (block.isVisible)
                {
                    if (mario.state.marioSprite.desRectangle.Bottom > block.position.Y - 5 && mario.state.marioSprite.desRectangle.Bottom <= block.position.Y)
                    {
                        if (mario.state.marioSprite.desRectangle.Right > block.position.X + 3 && mario.state.marioSprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            mario.gravity = 0;
                            mario.jump = true;
                        }
                    }
                }
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
                        MarioBlockHandler.BlockHandler(myGame, mario, block, SIDE);
                    }
                }

            }
        }

        public void EnemyBlockCollision(Mario mario, IEnemy enemy, List<IBlock> envElements)
        {
            enemy.gravity = 3;
            foreach (IBlock block in envElements)
            {
                if (block.isVisible)
                {
                    if (enemy.enemySprite.desRectangle.Bottom > block.position.Y - 5 && enemy.enemySprite.desRectangle.Bottom <= block.position.Y)
                    {
                        if (enemy.enemySprite.desRectangle.Right > block.position.X + 3 && enemy.enemySprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            if (!enemy.flip)
                            {
                                if (mario.state.marioSprite.desRectangle.Intersects(block.blockSprite.desRectangle)&&mario.marioState!=Mario.MARIO_SMALL)
                                    enemy.BeFlipped();
                                enemy.gravity = 0;
                            }
                        }
                    }
                }
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
            if(!(item.itemSprite is FireballSprite))
            {
                item.gravity = 4;
            }
        
            foreach (IBlock block in envElements)
            {
                if (block.isVisible)
                {
                    if (item.itemSprite.desRectangle.Bottom > block.position.Y - 5 && item.itemSprite.desRectangle.Bottom <= block.position.Y)
                    {
                        
                        if (item.itemSprite.desRectangle.Right > block.position.X + 3 && item.itemSprite.desRectangle.Left < block.blockSprite.desRectangle.Right - 3)
                        {
                            if(item.itemSprite is FireballSprite)
                            {
                                item.ItemChangeDirection();
                            }
                            item.gravity = 0;
                        }
                    }
                }
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

        public void ItemEnemyCollision(IItem item, List<IEnemy> enemyElements)
        {
            SIDE = TOP;
            
                foreach (IEnemy enemy in enemyElements)
                {
                    if (item.itemSprite.desRectangle.Intersects(enemy.enemySprite.desRectangle))
                    {
                        ItemEnemyHandler.EnemyHandler(item, enemy, TOP);
                          
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

        public void MarioFlagCollision(Mario mario, List<IBackground> backgroundElements)
        {
            foreach (IBackground bg in backgroundElements)
            {
                if(bg.backgroundSprite is FlagpoleSprite)
                {
                    if(mario.state.marioSprite.desRectangle.Intersects(bg.backgroundSprite.desRectangle))
                    {
                        myGame.keyboardController.keysEnabled = false;
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
