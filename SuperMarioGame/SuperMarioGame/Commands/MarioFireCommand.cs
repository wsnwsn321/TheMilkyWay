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
        private StateClass.Mario mario;
        public MarioFireCommand(Game1 game)
        {
            myGame = game;
            this.mario = game.mario;
        }

        public void Execute()
        {
           
            mario.MarioChangeForm(StateClass.Mario.MARIO_FIRE);
        }
    }
}
