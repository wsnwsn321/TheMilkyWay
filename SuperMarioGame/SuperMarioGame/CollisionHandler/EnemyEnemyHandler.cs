using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.CollisionHandler
{
    public static class EnemyEnemyHandler
    {
        public static void EnemyHandler(IEnemy enemy1, IEnemy enemy2, int CollisionSide)
        {

            switch (CollisionSide)
            {
                case 1:
                    
                    break;
                case 2:
                    enemy1.ChangeDirection();
                    enemy2.ChangeDirection();
                    break;
                case 3:

                    break;
                case 4:
                    enemy1.ChangeDirection();
                    enemy2.ChangeDirection();
                    break;
            }
            
        }
    }
}
