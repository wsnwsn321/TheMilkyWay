﻿using System;
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
            myGame.BrickBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateHiddenBlockSprite();
        }
    }
}
