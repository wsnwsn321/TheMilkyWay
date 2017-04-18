using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
{
    class MarioJumpCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        private int jumpTime = 50;
        private double jumpForce = 12;
        private double decay = 0;
        private bool jumpCount = true;
        public bool wDown;
        private int Fifty = 50;

        public MarioJumpCommand(Game1 game)
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
