using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    public static class EnemyBlockHandler
    {
        public static void BlockHandler(IEnemy enemy, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            if (!enemy.flip&&block.isBroken==false&&block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1:
                        newPosition.X = enemy.enemySprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - enemy.enemySprite.desRectangle.Height - 6;
                        enemy.position = newPosition;
                        break;
                    case 2:
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = enemy.enemySprite.desRectangle.Y;
                        enemy.position = newPosition;
                        enemy.ChangeDirection();
                        if (enemy.shellMoving == 2)
                        {
                            enemy.shellMoving = 4;
                        }
                       else if (enemy.shellMoving == 4)
                        {
                            enemy.shellMoving = 2;
                        }
                        break;
                    case 3:
                        newPosition.X = enemy.enemySprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + enemy.enemySprite.desRectangle.Height;
                        enemy.position = newPosition;
                        break;
                    case 4:
                        newPosition.X = block.blockSprite.desRectangle.X - enemy.enemySprite.desRectangle.Width;
                        newPosition.Y = enemy.enemySprite.desRectangle.Y;
                        enemy.position = newPosition;
                        enemy.ChangeDirection();
                        if (enemy.shellMoving == 2)
                        {
                            enemy.shellMoving = 4;
                        }
                        else if (enemy.shellMoving == 4)
                        {
                            enemy.shellMoving = 2;
                        }
                        break;
                }
            }            
        }
    }
}
