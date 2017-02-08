﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioIdleOrCrouchingCommand : ICommand
    {

        private Game1 myGame;
        private SuperMarioGame.StateClass.Mario mario;

        public MarioIdleOrCrouchingCommand(Game1 game)
        {
            myGame = game;
            mario = game.mario;
        }

        public void Execute()
        {
           
            mario.MarioCrouch();
        }
    }
}
