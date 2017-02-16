using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioBigCommand : ICommand
    {

        private Game1 myGame;
        private SuperMarioGame.ElementClasses.Mario mario;

        public MarioBigCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            mario.MarioChangeForm(ElementClasses.Mario.MARIO_BIG);
        }
    }
}
