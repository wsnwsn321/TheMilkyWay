using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioRightIdleOrRunningCommand : ICommand
    {

        private Game1 myGame;
        private StateClass.Mario mario;
        public MarioRightIdleOrRunningCommand(Game1 game)
        {
            myGame = game;
            mario  = game.mario;
        }

        public void Execute()
        {
            //left / a and right/ d should change mario between left running, left idle, right idle, and right running.
            if (!mario.marioDirection)
            {
                if (mario.marioAction == StateClass.Mario.MARIO_IDLE)
                {
                    mario.MarioRun();
                }
                else
                {
                    mario.MarioIdle();
                }
            }
            else
            {
                mario.MarioChangeDireciton();
                mario.MarioIdle();
            }
            
        }
    }
}
