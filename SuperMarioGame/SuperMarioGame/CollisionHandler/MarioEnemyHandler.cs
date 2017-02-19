using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;


namespace SuperMarioGame.CollisionHandler
{
    class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy item, int CollisionSide)
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
                        mario.MarioEatShit();
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
                        mario.MarioEatShit();
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
                        mario.MarioEatShit();
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
                        mario.MarioEatShit();
                    }
                    break;
            }
        }
    }
}
