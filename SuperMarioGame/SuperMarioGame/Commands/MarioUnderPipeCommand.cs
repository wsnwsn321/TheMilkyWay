using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.BackgroundClass;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.Sound.MarioSound;
using SuperMarioGame.SpriteFactories;

namespace SuperMarioGame.Commands
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
