namespace Sprint6.Commands
{
    class MarioIdleCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        public MarioIdleCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            if(mainCharacter.marioState != ElementClasses.MainCharacter.MARIO_DEAD && mainCharacter.canMove)
            {
                     mainCharacter.MarioIdle();
            }
           
        }
    }
}
