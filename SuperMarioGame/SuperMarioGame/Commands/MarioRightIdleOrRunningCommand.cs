using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioRightIdleOrRunningCommand : ICommand
    {

        private Game1 myGame;

        public MarioRightIdleOrRunningCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //left / a and right/ d should change mario between left running, left idle, right idle, and right running.
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}
