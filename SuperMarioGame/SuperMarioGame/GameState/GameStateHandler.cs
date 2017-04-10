using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.LevelLoading;
using System.Collections.Generic;

namespace SuperMarioGame.GameState
{
    public class GameStateHandler
    {

        Level myLevel;

        private List<IBlock> undergroundEnvElements;
        private List<IItem> undergroundItemElements;
        private List<IEnemy> undergroundEnemyElements;
        private List<IBackground> undergroundBackgroundElements;

        private List<IBlock> overworldEnvElements;
        private List<IItem> overworldItemElements;
        private List<IEnemy> overworldEnemyElements;
        private List<IBackground> overworldBackgroundElements;

        public GameStateHandler(Level level)
        {
            myLevel = level;
            undergroundEnvElements = new List<IBlock>();
            undergroundItemElements = new List<IItem>();
            undergroundEnemyElements = new List<IEnemy>();
            undergroundBackgroundElements = new List<IBackground>();

            overworldEnvElements = new List<IBlock>();
            overworldItemElements = new List<IItem>();
            overworldEnemyElements = new List<IEnemy>();
            overworldBackgroundElements = new List<IBackground>();
        }


        public void GamePause()
        {
            myLevel.Pause();
        }

        public void DisplayDeathScreen()
        {
            
        }        

    }
}
