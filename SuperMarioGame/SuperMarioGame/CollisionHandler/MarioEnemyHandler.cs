using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;


namespace SuperMarioGame.CollisionHandler
{
    public static class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy enemy, int CollisionSide)
        {
            switch (CollisionSide)
            {
                case 1:
                    mario.MarioGetHit();
                    mario.InvincibilityTime += 3;
                    break;
                case 2:
                    mario.MarioGetHit();
                    mario.InvincibilityTime += 3;
                    break;
                case 3:
                    mario.MarioGetHit();
                    mario.InvincibilityTime += 3;
                    break;
                case 4:
                    mario.MarioGetHit();
                    mario.InvincibilityTime += 3;
                    break;
            }
        }
    }
}
