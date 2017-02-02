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

        public MarioSmallCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //y should change mario to a small state
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}
