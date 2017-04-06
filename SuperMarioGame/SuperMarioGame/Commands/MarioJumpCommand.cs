using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.Commands
{
    class MarioJumpCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private int jumpTime = 50;
        private double jumpForce = 12;
        private double decay = 0;
        private bool jumpCount = true;
        public bool wDown;

        public MarioJumpCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.canMove)
            {
                
                if (!mario.jump)
                {
                    jumpTime  = 0;
       
                }
                if (mario.marioState != ElementClasses.Mario.MARIO_DEAD)
                {
                    
                    if (jumpTime > 0)
                    {
                        mario.MarioJump();
                        if (jumpCount)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.JUMPSMALL);
                            jumpCount = false;
                        }
                        mario.position = new Vector2(mario.position.X, mario.position.Y - (float)(jumpForce - decay));
                        decay += jumpForce / 50;

                        jumpTime--;
                   
                        if (mario.gravity == 0 && !wDown)
                        {
                            decay = 0;
                            jumpTime = 50;
                            mario.jump = true;
                            jumpCount = true;
                        }
                        else if (!wDown)
                        {
                            mario.jump = false;
                        }
                    }
                    else
                    {

                        mario.jump = false;
                        if (mario.gravity == 0 && !wDown)
                        {
                            decay = 0;
                            jumpTime = 50;
                            mario.jump = true;
                            jumpCount = true;

                        }
                    }
                }
            }
        }
    }
}
