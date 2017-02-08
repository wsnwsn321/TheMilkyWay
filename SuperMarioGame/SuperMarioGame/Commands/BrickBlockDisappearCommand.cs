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
        private Sprites.ISprite brick;


        public BrickBlockDisappearCommand(Game1 game)
        {
            myGame = game;
           // brick = game.BrickBlock;
            
        }

        public void Execute()
        {
            // NULL REF ERROR since game.BrickBlock doesn't define brick.draw
            // At first I tried making brick a BrickBlockSprite object instead
            //brick.draw = !(brick.draw);
        }
    }
}
