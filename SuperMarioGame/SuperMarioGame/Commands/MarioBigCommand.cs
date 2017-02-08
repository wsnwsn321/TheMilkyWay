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
        private SuperMarioGame.StateClass.Mario mario;
        
 
        public MarioBigCommand(Game1 game)
        {
            myGame = game;
            mario = game.mario;
        }

        public void Execute()
        {
            if(mario.marioState == 1)
            {
                mario.marioState = 2;
                mario.MarioIdle();
            }   
        }
    }
}
