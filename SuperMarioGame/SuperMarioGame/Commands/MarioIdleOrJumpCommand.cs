﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioIdleOrJumpCommand : ICommand
    {
        private Game1 myGame;
        private SuperMarioGame.StateClass.Mario mario;

        public MarioIdleOrJumpCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }
        
        public void Execute()
        {
                if (mario.marioAction == StateClass.Mario.MARIO_JUMP)
                {
                    mario.MarioCrouch();
                }
                else
                {
                    mario.MarioJump();
                }
            

        }
    }
}
