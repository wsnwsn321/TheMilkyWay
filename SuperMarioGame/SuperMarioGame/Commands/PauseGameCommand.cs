namespace SuperMarioGame.Commands
{
    class PauseGameCommand : ICommand
    {
        private Game1 myGame;

        public PauseGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.gameStateHandler.GamePause();
        }
    }
}
