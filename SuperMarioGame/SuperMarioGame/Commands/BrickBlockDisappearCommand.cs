using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class BrickBlockDisappearCommand : ICommand
    {
        private Game1 myGame;


        public BrickBlockDisappearCommand(Game1 game)
        {
            myGame = game;
            
            
        }

        public void Execute()
        {
            // NULL REF ERROR since game.BrickBlock doesn't define brick.draw
            // At first I tried making brick a BrickBlockSprite object instead
            //brick.draw = !(brick.draw);
            myGame.BrickBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateHiddenBlockSprite();
        }
    }
}
