using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioSmallCommand : ICommand
    {
        private Game1 myGame;
        private StateClass.Mario mario;
        public MarioSmallCommand(Game1 game)
        {
            myGame = game;
            mario = game.mario;
        }

        public void Execute()
        {
            mario.MarioChangeForm(StateClass.Mario.MARIO_SMALL);
        }
    }
}
