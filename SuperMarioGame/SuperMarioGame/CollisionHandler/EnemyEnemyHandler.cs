using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;

namespace SuperMarioGame.CollisionHandler
{
    public static class EnemyEnemyHandler
    {
        public static void EnemyHandler(IEnemy enemy1, IEnemy enemy2, int CollisionSide)
        {
            Vector2 newPosition;
            if (!(enemy2.enemySprite is GoombaStompedSprite) && enemy2.isVisible && !(enemy1.enemySprite is GoombaStompedSprite) && enemy1.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1:

                        break;
                    case 2:
                        newPosition.X = enemy1.enemySprite.desRectangle.X + 2;
                        newPosition.Y = enemy1.enemySprite.desRectangle.Y;
                        enemy1.position = newPosition;
                        if (enemy1 is Koopa)
                        {
                            if (enemy1.shellDirection)
                            {
                                
                                enemy2.BeFlipped();
                            }
                            else
                            {
                                 enemy2.ChangeDirection();
                            }
                           
                        }
                        enemy1.ChangeDirection();
                        break;
                    case 3:

                        break;
                    case 4:
                        newPosition.X = enemy1.enemySprite.desRectangle.X - 2;
                        newPosition.Y = enemy1.enemySprite.desRectangle.Y;
                        enemy1.position = newPosition;
                        if (enemy1 is Koopa)
                        {
                            if (enemy1.shellDirection)
                            {
                                enemy2.BeFlipped();
                            }
                            else
                            {
                                enemy2.ChangeDirection();
                            }
                        }
                        enemy1.ChangeDirection();
                        break;
                }
            }                    
        }
    }
}
