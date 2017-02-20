using Microsoft.Xna.Framework;

namespace SuperMarioGame.Commands
{
    class MarioJumpCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioJumpCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }
        
        public void Execute()
        {
            if (mario.marioState != ElementClasses.Mario.MARIO_DEAD)
            {
             mario.MarioJump();
             mario.position = new Vector2(mario.position.X, mario.position.Y - 3);
            }
             
        }
    }
}
