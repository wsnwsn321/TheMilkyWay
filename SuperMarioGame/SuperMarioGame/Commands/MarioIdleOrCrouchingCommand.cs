using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioIdleOrCrouchingCommand : ICommand
    {

        private Game1 myGame;
        private SuperMarioGame.StateClass.Mario mario;

        public MarioIdleOrCrouchingCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //Change mario to an idle state if he was in a jumping state and a crouching state if he was not.
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);

        }
    }
}
