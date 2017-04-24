using System.Diagnostics;

namespace TheMilkyWay.Commands
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
            if (myGame.level.scoreSystem.displayCollectibles)
            {
                if (myGame.collectibleKeyboardController.up)
                {
                    myGame.level.scoreSystem.collectibles.moveCharacterUp();
                }
                else
                {
                    myGame.level.scoreSystem.collectibles.moveCharacterDown();
                }
            }
            else
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
}
