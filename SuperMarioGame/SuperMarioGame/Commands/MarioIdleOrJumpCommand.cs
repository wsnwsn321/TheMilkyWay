using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioIdleOrJumpCommand : ICommand
    {
        private Game1 myGame;

        public MarioIdleOrJumpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //Change mario to an idle state if he was in a crouching state and a jumping state if he was not.
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}
