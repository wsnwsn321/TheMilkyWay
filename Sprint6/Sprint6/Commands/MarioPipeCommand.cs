using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
{
    class MarioPipeCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        private int wait1 = 0;
        private bool pipeCount = true;
        public MarioPipeCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            myGame.keyboardController.keysEnabled = false;
            if (wait1 < 200)
            {
                if (pipeCount)
                {
                    pipeCount = false;
                    MarioSoundManager.instance.playSound(MarioSoundManager.PIPE);
                }
                wait1++;
                mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + 1);
            }
            else
            {
                pipeCount = true;
                myGame.level.Load(GameConstants.UnderworldLevel, new Vector2(GameConstants.NewMarioStartingX, GameConstants.NewMarioStartingY));
                wait1 = 0;
                myGame.keyboardController.keysEnabled = true;
                mainCharacter.animated = false;
            }
        }
    }
}
