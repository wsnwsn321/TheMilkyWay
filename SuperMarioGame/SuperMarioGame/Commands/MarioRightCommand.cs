using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioRightCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioRightCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            mario.MarioChangeDireciton();
            mario.position = new Vector2(mario.position.X + 1, mario.position.Y);
        }
    }
}
