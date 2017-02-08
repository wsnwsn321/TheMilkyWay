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
        private SuperMarioGame.Sprites.ISprite brick;



        public BrickBlockDisappearCommand(Game1 game)
        {
            myGame = game;
            brick = game.BrickBlock;
        }

        public void Execute()
        {

            // x makes the brick block disappear
            //myGame.MarioSprite = new IdleTidusSprite(myGame.Texture);
        }
    }
}
