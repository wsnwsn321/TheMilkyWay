using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.UFOSound;
using TheMilkyWay.SpriteFactories;

namespace TheMilkyWay.Commands
{
    class MainCharJumpCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;

        public MainCharJumpCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            mainCharacter.MainCharJump();
        }
    }
}
