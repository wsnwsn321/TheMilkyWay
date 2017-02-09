using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
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
            // r resets the scene
            //myGame.mario = new StateClass.Mario(new Vector2(700, 300), 2, true);
            myGame.Exit();
        }
    }
}
