using Microsoft.Xna.Framework;
using System.Diagnostics;
using TheMilkyWay.Sound.BackgroundMusic;

namespace TheMilkyWay.Commands
{
    public class CollectiblesSelectCommand : ICommand
    {
        private Game1 myGame;
        public CollectiblesSelectCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            int ufoPos = myGame.level.scoreSystem.collectibles.ufoPos;
            switch (ufoPos)
            {
                case 1:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.MainMenu);
                    break;
                case 2:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.LevelOne);
                    break;
                case 3:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.LevelTwo);

                    break;
                case 4:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.LevelThree);

                    break;
                case 5:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.BGM1);

                    break;
                case 6:
                    BackgroundMusic.instanse.playSound(BackgroundMusic.BGM2);

                    break;
                case 7:
                    myGame.Exit();
                    break;
            }
        }
    }
}
