﻿using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioRightCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioRightCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState != ElementClasses.Mario.MARIO_DEAD && mario.canMove)
            {
                if (mario.marioDirection)
                {
                    mario.MarioIdle();
                    mario.MarioChangeDireciton();
                }
                if (mario.marioAction != ElementClasses.Mario.MARIO_CROUCH)
                {
                    mario.MarioRun();
                    mario.position = new Vector2(mario.position.X + 3, mario.position.Y);
                }
            }             
        }
    }
}
