﻿using Microsoft.Xna.Framework;
using System.Diagnostics;
using TheMilkyWay.Sound.MenuMusic;

namespace TheMilkyWay.Commands
{
    public class MenuSelectCommand : ICommand
    {
        private Game1 myGame;

        public MenuSelectCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            int ufoPos = myGame.level.scoreSystem.menu.ufoPos;
            switch (ufoPos)
            {
                case 1:
                    myGame.level.Load(GameConstants.Level1, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
                   
                    break;
                case 2:
                    myGame.level.Load(GameConstants.Level2, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
               
                    break;
                case 3:
                    myGame.level.Load(GameConstants.Level3, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
          
                    break;
                case 4:
                    myGame.level.Load(GameConstants.Collectibles, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));

                    break;
                case 5:
                    myGame.level.Load(GameConstants.Credits, new Vector2(GameConstants.MainCharStartingX, GameConstants.MainCharStartingY));
                    break;
                case 6:
                    myGame.Exit();
                    break;
            }
        }
    }
}
