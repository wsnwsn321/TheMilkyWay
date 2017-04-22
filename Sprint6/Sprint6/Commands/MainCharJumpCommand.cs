using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sound.MarioSound;
using TheMilkyWay.SpriteFactories;

namespace TheMilkyWay.Commands
{
    class MainCharJumpCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        private int jumpTime = 50;
        private double jumpForce = 12;
        private double decay = 0;
        private bool jumpCount = true;
        public bool wDown;
        private int Fifty = 50;

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
