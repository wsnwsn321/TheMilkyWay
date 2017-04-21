using Microsoft.Xna.Framework;

namespace Sprint6.Commands
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
            myGame.level.currentLevel = GameConstants.Menu;
            myGame.level.Load(GameConstants.Menu, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
        }
    }
}
