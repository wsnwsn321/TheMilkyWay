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
        public MenuWindow menuWindow;
        public LevelWindow levelWindow;
        public bool dispMenu;
        public bool dispLevel;

        public WindowManager(Game1 game)
        {
            mygame = game;
            dispMenu = false;
            dispLevel = false;
            menuWindow = new MenuWindow(mygame);
            levelWindow = new LevelWindow(mygame);
        }

        public void DisplayAllWindows()
        {
            if (dispMenu)
            {
                menuWindow.Display();

            }
            if (dispLevel)
            {
                mygame.freeze = true;
                levelWindow.Display();
            }
        }
    }
}
