namespace SuperMarioGame.Commands
{
    class MarioIdleCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        public MarioIdleCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            if(mario.marioState != ElementClasses.Mario.MARIO_DEAD)
            {
                     mario.MarioIdle();
            }
           
        }
    }
}
