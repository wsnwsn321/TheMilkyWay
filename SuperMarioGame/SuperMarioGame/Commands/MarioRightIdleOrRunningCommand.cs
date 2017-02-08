﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioRightIdleOrRunningCommand : ICommand
    {

        private Game1 myGame;
        public StateClass.Mario mario { get; set; }
        public MarioRightIdleOrRunningCommand(Game1 game)
        {
            myGame = game;
            mario  = game.mario;
        }

        public void Execute()
        {
            //left / a and right/ d should change mario between left running, left idle, right idle, and right running.
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
            if (!mario.marioDirection)
            {
                mario.MarioRun();
            }else
            {
                mario.MarioChangeDireciton();
                mario.MarioIdle();
            }
            
        }
    }
}
