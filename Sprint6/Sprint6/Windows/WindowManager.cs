using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.ElementClasses;
using Sprint6.SpriteFactories;
using System;
using Sprint6.HUDElements;

namespace Sprint6
{
    public class WindowManager
    {
        private Game1 mygame;
        private MenuWindow menuWindow;

        public WindowManager(Game1 game)
        {
            mygame = game;
            menuWindow = new MenuWindow(mygame);
        }

        public void DisplayAllWindows()
        {
            menuWindow.Display();
        }

    }
}
