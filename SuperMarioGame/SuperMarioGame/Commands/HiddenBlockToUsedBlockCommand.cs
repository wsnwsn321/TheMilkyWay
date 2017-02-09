using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class HiddenBlockToUsedBlockCommand : ICommand
    {

        private Game1 myGame;
        private Sprites.ISprite block;

        public HiddenBlockToUsedBlockCommand(Game1 game)
        {
            myGame = game;
            
        }

        public void Execute()
        {
            //c changes a hidden block into a used block
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
            
        }
    }
}
