using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioMoveRightCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioMoveRightCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            if (!mario.marioDirection)
            {
                mario.position = new Vector2(mario.position.X + 1, mario.position.Y);
            }else
            {
                mario.MarioChangeDirection();
            }
           
        }
    }
}
