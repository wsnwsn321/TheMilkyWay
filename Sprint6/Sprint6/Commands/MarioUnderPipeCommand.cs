using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
{
    class MarioUnderPipeCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private int wait1 = 0;
        private bool pipeCount = true;
        public MarioUnderPipeCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
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
                mario.position = new Vector2(mario.position.X + 1, mario.position.Y);
            }
            else
            {
                pipeCount = true;
                myGame.level.Load(GameConstants.OverworldLevel, new Vector2(GameConstants.OutPipeStartingX, GameConstants.OutPipeStartingY));
                wait1 = 0;
                myGame.keyboardController.keysEnabled = true;
                mario.animated = false;
            }
        }
    }
}
