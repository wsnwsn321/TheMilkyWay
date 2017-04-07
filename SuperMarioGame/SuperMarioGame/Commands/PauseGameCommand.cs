using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.Commands
{
    class PauseGameCommand : ICommand
    {
        private Game1 myGame;
        private int counter;

        public PauseGameCommand(Game1 game)
        {
            myGame = game;
            counter = 0;
        }

        public void Execute()
        {
            counter++;
            if (counter % 10 == 0)
            {
                counter = 0;
                MarioSoundManager.instance.playSound(MarioSoundManager.PAUSE);
                myGame.gameStateHandler.GamePause();
            }
        }
    }
}
