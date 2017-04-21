using System.Diagnostics;

namespace Sprint6.Commands
{
    public class MenuCommand : ICommand
    {
        private Game1 myGame;

        public MenuCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.menuKeyboardController.up)
            {
                myGame.level.scoreSystem.menu.moveCharacterUp();
            }
            else
            {
                myGame.level.scoreSystem.menu.moveCharacterDown();
            }
        }
    }
}
