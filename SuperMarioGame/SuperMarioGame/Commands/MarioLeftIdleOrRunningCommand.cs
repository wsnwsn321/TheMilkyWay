﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioLeftIdleOrRunningCommand : ICommand
    {

        private Game1 myGame;

        public MarioLeftIdleOrRunningCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //left/a and right/d should change mario between left running, left idle, right idle, and right running.
            // may want to delay the state change to avoid a seemingly instant change from left running to right running when right is held down and vice-versa.
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}