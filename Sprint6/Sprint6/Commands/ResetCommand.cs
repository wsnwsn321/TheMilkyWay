namespace Sprint6.Commands
{
    class ResetCommand : ICommand
    {

        private Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.ResetGame();
        }
    }
}
