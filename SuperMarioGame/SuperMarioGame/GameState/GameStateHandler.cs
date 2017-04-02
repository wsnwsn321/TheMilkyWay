using SuperMarioGame.LevelLoading;

namespace SuperMarioGame.GameState
{
    public class GameStateHandler
    {


        Level myLevel;

        public GameStateHandler(Level level)
        {
            myLevel = level;
        }


        public void GamePause()
        {
            myLevel.Pause();
        }

        public void GoToUnderworld()
        {
            // StoreElements();

        }

        public void GoToOverworld()
        {

        }

        public void GoToDeathScreen()
        {

        }

        

    }
}
