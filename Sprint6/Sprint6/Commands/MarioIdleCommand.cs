﻿namespace Sprint6.Commands
{
    class MarioIdleCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mario;
        public MarioIdleCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mainCharacter;
        }

        public void Execute()
        {
                mario.MarioIdle();
        }
    }
}
