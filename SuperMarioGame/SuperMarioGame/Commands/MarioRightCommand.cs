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
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState != ElementClasses.Mario.MARIO_DEAD)
            {
                if (mario.marioDirection)
                {
                    mario.MarioIdle();
                    mario.MarioChangeDireciton();
                }
                mario.MarioRun();
                if (mario.position.X < myGame.Window.ClientBounds.Width - mario.state.marioSprite.desRectangle.Width)
                {
                    mario.position = new Vector2(mario.position.X + 3, mario.position.Y);
                }                
                if (mario.position.Y > 0)
                {
                    mario.position = new Vector2(mario.position.X, mario.position.Y - 3);
                }
                if (mario.position.Y < myGame.Window.ClientBounds.Height - mario.state.marioSprite.desRectangle.Height)
                {
                    mario.position = new Vector2(mario.position.X, mario.position.Y + 3);
                }
            }
             
        }
    }
}
