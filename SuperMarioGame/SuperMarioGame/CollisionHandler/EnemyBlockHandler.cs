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

            switch (CollisionSide)
            {
                case 1:
                    newPosition.X = enemy.enemySprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y - enemy.enemySprite.desRectangle.Height;
                    enemy.position = newPosition;
                    break;
                case 2:
                    enemy.ChangeDirection();
                    break;
                case 3:
                    newPosition.X = enemy.enemySprite.desRectangle.X;
                    newPosition.Y = block.blockSprite.desRectangle.Y + enemy.enemySprite.desRectangle.Height;
                    enemy.position = newPosition;
                    break;
                case 4:
                    enemy.ChangeDirection();
                    break;
            }            
        }
    }
}
