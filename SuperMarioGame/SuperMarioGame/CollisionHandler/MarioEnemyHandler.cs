using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy enemy, int CollisionSide)
        {
            if (!(enemy.enemySprite is GoombaStompedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                        enemy.BeStomped();
                        break;
                    case 2:
                        mario.MarioGetHit();
                        break;
                    case 3:
                        mario.MarioGetHit();
                        break;
                    case 4:
                        mario.MarioGetHit();
                        break;
                }
            }
        }
    }
}
