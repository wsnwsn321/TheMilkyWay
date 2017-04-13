using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Sprint6.Sprites;
using Microsoft.Xna.Framework;
using Sprint6.Sound.MarioSound;

namespace Sprint6.CollisionHandler
{
    public static class MainCharEnemyHandler
    {
        public static void EnemyHandler(MainCharacter mainCharacter, IEnemy enemy, int CollisionSide)
        {
            int THREE = 3;
            int SIX = 6;
            Vector2 newPosition;
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaFlippedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                      
                        break;
                    case 2:
                        
                        break;
                    case 3:
                       
                        break;
                    case 4:
                       
                        break;
                }
            }
        }
    }
}
