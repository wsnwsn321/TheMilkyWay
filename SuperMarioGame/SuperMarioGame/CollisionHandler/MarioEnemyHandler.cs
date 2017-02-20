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
                    if(mario.marioState  == Mario.MARIO_FIRE)
                    {
                        mario.MarioChangeForm(Mario.MARIO_BIG);
                    }else if(mario.marioState == Mario.MARIO_BIG)
                    {
                        mario.MarioChangeForm(Mario.MARIO_SMALL);
                    }else
                    {
                        mario.MarioDie();
                    }
                    mario.InvincibilityTime += 3;
                    break;
                case 2:
                    if (mario.marioState == Mario.MARIO_FIRE)
                    {
                        mario.MarioChangeForm(Mario.MARIO_BIG);
                    }
                    else if (mario.marioState == Mario.MARIO_BIG)
                    {
                        mario.MarioChangeForm(Mario.MARIO_SMALL);
                    }
                    else
                    {
                        mario.MarioDie();
                    }
                    mario.InvincibilityTime += 3;
                    break;
                case 3:
                    if (mario.marioState == Mario.MARIO_FIRE)
                    {
                        mario.MarioChangeForm(Mario.MARIO_BIG);
                    }
                    else if (mario.marioState == Mario.MARIO_BIG)
                    {
                        mario.MarioChangeForm(Mario.MARIO_SMALL);
                    }
                    else
                    {
                        mario.MarioDie();
                    }
                    mario.InvincibilityTime += 3;
                    break;
                case 4:
                    if (mario.marioState == Mario.MARIO_FIRE)
                    {
                        mario.MarioChangeForm(Mario.MARIO_BIG);
                    }
                    else if (mario.marioState == Mario.MARIO_BIG)
                    {
                        mario.MarioChangeForm(Mario.MARIO_SMALL);
                    }
                    else
                    {
                        mario.MarioDie();
                    }
                    mario.InvincibilityTime += 3;
                    break;
            }
        }
    }
}
