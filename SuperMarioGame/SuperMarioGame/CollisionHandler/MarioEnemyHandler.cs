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
                    if(mario.marioState  == 3)
                    {
                        mario.MarioChangeForm(2);
                    }else if(mario.marioState == 2)
                    {
                        mario.MarioChangeForm(1);
                    }else
                    {
                        mario.Die();
                    }
                    break;
                case 2:
                    if (mario.marioState == 3)
                    {
                        mario.MarioChangeForm(2);
                    }
                    else if (mario.marioState == 2)
                    {
                        mario.MarioChangeForm(1);
                    }
                    else
                    {
                        mario.Die();
                    }
                    break;
                case 3:
                    if (mario.marioState == 3)
                    {
                        mario.MarioChangeForm(2);
                    }
                    else if (mario.marioState == 2)
                    {
                        mario.MarioChangeForm(1);
                    }
                    else
                    {
                        mario.Die();
                    }
                    break;
                case 4:
                    if (mario.marioState == 3)
                    {
                        mario.MarioChangeForm(2);
                    }
                    else if (mario.marioState == 2)
                    {
                        mario.MarioChangeForm(1);
                    }
                    else
                    {
                        mario.Die();
                    }
                    break;
            }
        }
    }
}
