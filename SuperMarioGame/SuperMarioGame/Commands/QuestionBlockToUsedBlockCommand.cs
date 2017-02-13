using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class QuestionBlockToUsedBlockCommand : ICommand
    {

        private Game1 myGame;

        public QuestionBlockToUsedBlockCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.QuestionBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
        }
    }
}
