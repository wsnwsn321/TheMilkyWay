using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.Sound.MarioSound;

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
            if (mainCharacter.canMove)
            {
                
                if (!mainCharacter.jump)
                {
                    jumpTime  = 0;
       
                }
                if (mainCharacter.marioState != ElementClasses.MainCharacter.MARIO_DEAD)
                {
                    
                    if (jumpTime > 0)
                    {
                        mainCharacter.MarioJump();
                        if (jumpCount)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.JUMPSMALL);
                            jumpCount = false;
                        }
                        mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y - (float)(jumpForce - decay));
                        decay += jumpForce / Fifty;

                        jumpTime--;
                   
                        if (mainCharacter.gravity == 0 && !wDown)
                        {
                            decay = 0;
                            jumpTime = Fifty;
                            mainCharacter.jump = true;
                            jumpCount = true;
                        }
                        else if (!wDown)
                        {
                            mainCharacter.jump = false;
                        }
                    }
                    else
                    {

                        mainCharacter.jump = false;
                        if (mainCharacter.gravity == 0 && !wDown)
                        {
                            decay = 0;
                            jumpTime = Fifty;
                            mainCharacter.jump = true;
                            jumpCount = true;

                        }
                    }
                }
            }
        }
    }
}
