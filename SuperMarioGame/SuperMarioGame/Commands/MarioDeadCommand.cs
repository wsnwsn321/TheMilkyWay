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

        public MarioDeadCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //u should make mario big ( ͡° ͜ʖ ͡°)
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}
