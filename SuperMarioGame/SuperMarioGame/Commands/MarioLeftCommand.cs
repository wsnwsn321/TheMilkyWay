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
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState != ElementClasses.Mario.MARIO_DEAD)
            {
                if (!mario.marioDirection)
               {
                mario.MarioIdle();
                mario.MarioChangeDireciton();
               }
                if (mario.marioAction != ElementClasses.Mario.MARIO_CROUCH)
                {
                    mario.MarioRun();

                    if (mario.position.X > -myGame.GraphicsDevice.Viewport.X)
                    {
                        mario.position = new Vector2(mario.position.X - 3, mario.position.Y);
                    }
                    //if (mario.position.X < 0)
                    //{
                    //    mario.position = new Vector2(mario.state.marioSprite.desRectangle.Width, mario.position.Y);
                    //}
                }

            }



        }
    }
}
