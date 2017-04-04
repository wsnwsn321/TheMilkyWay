using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.BackgroundClass;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.SpriteFactories;

namespace SuperMarioGame.Commands
{
    class MarioPipeCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private int wait1 = 0;

        public MarioPipeCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            myGame.keyboardController.keysEnabled = false;
            if (wait1 < 200)
            {
                wait1++;
                mario.position = new Vector2(mario.position.X, mario.position.Y + 1);
            }
            else
            {
                myGame.level.Load(GameConstants.UnderworldLevel, new Vector2(GameConstants.NewMarioStartingX, GameConstants.NewMarioStartingY));
                wait1 = 0;
                myGame.keyboardController.keysEnabled = true;
                mario.animated = false;
            }
        }
    }
}
