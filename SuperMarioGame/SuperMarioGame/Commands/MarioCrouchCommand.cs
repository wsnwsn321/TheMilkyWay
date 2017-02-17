using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioCrouchCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioCrouchCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            mario.MarioCrouch();
            mario.position = new Vector2(mario.position.X, mario.position.Y + 1);
        }
    }
}
