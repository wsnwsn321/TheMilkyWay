using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.SpriteFactories;
using System;
using TheMilkyWay.HUDElements;

namespace TheMilkyWay
{
    public class WindowManager
    {
        private Game1 mygame;
        public MenuWindow menuWindow { get; set; }
        public LevelWindow levelWindow { get; set; }
        public EndLevelWindow endLevelWindow { get; set; }
        public bool dispMenu { get; set; }
        public bool dispLevel { get; set; }
        public bool dispEndLevel { get; set; }

        public WindowManager(Game1 game)
        {
            mygame = game;
            dispMenu = false;
            dispLevel = false;
            dispEndLevel = false;
            menuWindow = new MenuWindow(mygame);
            levelWindow = new LevelWindow(mygame);
            endLevelWindow = new EndLevelWindow(mygame);
        }

        public void DisplayAllWindows()
        {
            if (dispMenu)
            {
                menuWindow.Display();

            }
            if (dispLevel)
            {
                levelWindow.Display();
            }
            if (dispEndLevel)
            {
                endLevelWindow.Display();
            }
        }
    }
}
