using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioFireCommand : ICommand
    {

        private Game1 myGame;
        private ElementClasses.Mario mario;
        public MarioFireCommand(Game1 game)
        {
            myGame = game;
            this.mario = myGame.mario;
        }

        public void Execute()
        {
           
            mario.MarioChangeForm(ElementClasses.Mario.MARIO_FIRE);
        }
    }
}
