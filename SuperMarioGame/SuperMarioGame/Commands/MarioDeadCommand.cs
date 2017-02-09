using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioDeadCommand : ICommand
    {

        private Game1 myGame;
        private StateClass.Mario mario;

        public MarioDeadCommand(Game1 game)
        {
            myGame = game;
            mario = game.mario;
        }

        public void Execute()
        {
            mario.MarioEatShit();
        }
    }
}
