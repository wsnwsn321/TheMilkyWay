﻿namespace SuperMarioGame.Commands
{
    class QuitCommand : ICommand
    {
        private Game1 myGame;

        public QuitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            
            myGame.Exit();
        }
    }
}
