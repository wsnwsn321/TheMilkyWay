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
            bool top = false;
            if (!enemy.flip&&block.isBroken==false)
            {
                switch (CollisionSide)
                {
                    case 1:
                        newPosition.X = enemy.enemySprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - enemy.enemySprite.desRectangle.Height - 2;
                        enemy.position = newPosition;
                        top = true;
                        if (block.isVisible == false&&block.isBroken==false)
                        {
                            enemy.BeFlipped();
                            block.isBroken = true;
                        }
                        break;
                    case 2:
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = enemy.enemySprite.desRectangle.Y;
                        enemy.position = newPosition;
                        enemy.ChangeDirection();
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
                        break;
                }
                if (top)
                {
                    enemy.onTop = true;
                }
                else
                {
                    enemy.onTop = false;
                }
            }            
        }
    }
}
