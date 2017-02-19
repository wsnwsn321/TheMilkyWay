using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioMoveLeftCommand : ICommand
    {
        private Game1 myGame;
        private SuperMarioGame.ElementClasses.Mario mario;

        public MarioMoveLeftCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            if (mario.MarioDirection)
            {
                mario.position = new Vector2(mario.position.X - 1, mario.position.Y);
            }
           else
            {
                mario.marioChangeDirection();
            }
        }
    }
}
