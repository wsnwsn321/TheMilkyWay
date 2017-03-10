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
            mario = myGame.level.mario;
        }
        
        public void Execute()
        {
            if (mario.marioState != ElementClasses.Mario.MARIO_DEAD)
            {
             mario.MarioJump();
             mario.position = new Vector2(mario.position.X, mario.position.Y - 3);
                //if (mario.position.Y > 0)
                //{
                //    mario.position = new Vector2(mario.position.X, mario.position.Y - 3);
                //}
                //if(mario.position.X > myGame.Window.ClientBounds.Width - mario.state.marioSprite.desRectangle.Width)
                //{
                //    mario.position = new Vector2(myGame.Window.ClientBounds.Width - mario.state.marioSprite.desRectangle.Width, mario.position.Y);
                //}
                //if (mario.position.X < 0)
                //{
                //    mario.position = new Vector2(mario.state.marioSprite.desRectangle.Width, mario.position.Y);
                //}
            }

        }
    }
}
