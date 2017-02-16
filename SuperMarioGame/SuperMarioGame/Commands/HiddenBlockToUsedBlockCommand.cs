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

        public HiddenBlockToUsedBlockCommand(Game1 game)
        {
            myGame = game;
            
        }

        public void Execute()
        {
            //c changes a hidden block into a used block
            myGame.envElements[3] = new ElementClasses.EnvironmentClass.UsedBlock(myGame.envElements[3].position);
            
        }
    }
}
