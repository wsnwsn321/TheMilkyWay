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
        private SuperMarioGame.Sprites.BrickBlockSprite brick;


        public BrickBlockDisappearCommand(Game1 game)
        {
            myGame = game;
            brick = (SuperMarioGame.Sprites.BrickBlockSprite)game.BrickBlock;
        }

        public void Execute()
        {
            brick.draw = !(brick.draw);
        }
    }
}
