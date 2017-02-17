using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioLeftCommand : ICommand
    {

        private Game1 myGame;
        private ElementClasses.Mario mario;
        public MarioLeftCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            if (!mario.marioDirection)
            {
                mario.MarioIdle();
                mario.MarioChangeDireciton();
            }
            mario.MarioRun();
            mario.position = new Vector2(mario.position.X - 3, mario.position.Y);


        }
    }
}
