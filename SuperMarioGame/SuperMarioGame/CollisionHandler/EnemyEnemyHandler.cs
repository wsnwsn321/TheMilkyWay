using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    public static class EnemyEnemyHandler
    {
        public static void EnemyHandler(IEnemy enemy1, IEnemy enemy2, int CollisionSide)
        {
            Vector2 newPosition;
            switch (CollisionSide)
            {
                case 1:
                    
                    break;
                case 2:
                    newPosition.X = enemy2.enemySprite.desRectangle.X + enemy2.enemySprite.desRectangle.Width;
                    newPosition.Y = enemy1.enemySprite.desRectangle.Y;
                    enemy1.position = newPosition;
                    enemy1.ChangeDirection();
                    break;
                case 3:

                    break;
                case 4:
                    newPosition.X = enemy2.enemySprite.desRectangle.X - enemy1.enemySprite.desRectangle.Width;
                    newPosition.Y = enemy1.enemySprite.desRectangle.Y;
                    enemy1.position = newPosition;
                    enemy1.ChangeDirection();
                    break;
            }
            
        }
    }
}
