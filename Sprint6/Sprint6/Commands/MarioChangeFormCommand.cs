namespace Sprint6.Commands
{
    class MarioChangeFormCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        private int counter;
        private int TEN =10;
        public MarioChangeFormCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
            counter = 0;
        }

        public void Execute()
        {
           
        }
    }
}
