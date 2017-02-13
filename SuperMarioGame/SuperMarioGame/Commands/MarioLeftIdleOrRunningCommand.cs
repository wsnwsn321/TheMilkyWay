using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioLeftIdleOrRunningCommand : ICommand
    {

        private Game1 myGame;
        private StateClass.Mario mario;
        public MarioLeftIdleOrRunningCommand(Game1 game)
        {
            myGame = game;
            mario = game.mario;
        }

        public void Execute()
        {
            if (mario.marioDirection)
            {
                if (mario.marioAction == StateClass.Mario.MARIO_IDLE)
                {
                    mario.MarioRun();
                } else
                {
                    mario.MarioIdle();
                }
            }else
            {
                mario.MarioChangeDireciton();
                mario.MarioIdle();
            }
        
        }
    }
}
