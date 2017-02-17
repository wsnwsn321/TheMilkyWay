using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioLeftCommand : ICommand
    {

        private Game1 myGame;
        private ElementClasses.Mario mario;
        public MarioLeftCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            if (!mario.marioDirection)
            {
                mario.MarioChangeDireciton();
            }
            mario.position = new Vector2(mario.position.X - 3, mario.position.Y);


        }
    }
}
