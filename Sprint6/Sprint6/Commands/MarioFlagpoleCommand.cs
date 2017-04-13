using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
{
    class MarioFlagpoleCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private bool b1,b2,b3 = false;
        private int wait1,wait2 = 0;

        public MarioFlagpoleCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState == Mario.MARIO_SMALL)
            {
                smallAnimation();
            }
            else if (mario.marioState == Mario.MARIO_BIG)
            {
                bigAnimation();
            }
            else if (mario.marioState == Mario.MARIO_FIRE)
            {
                fireAnimation();
            }
        }

        private void smallAnimation()
        {
            if (!b1)
            {
                mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagSmallMarioSprite();
                b1 = true;
            }
            if (mario.position.Y >= GameConstants.ScreenHeight - 132)
            {
                if (!b2)
                {
                    mario.gravity = 0;
                    mario.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagSmallMarioSprite();
                    mario.position = new Vector2(mario.position.X + GameConstants.SquareWidth, mario.position.Y);
                    b2 = true;
                }
                else
                {
                    if (wait1 < 85)
                    {
                        wait1++;
                    }
                    if (wait1 == 85)
                    {
                        if (!b3)
                        {
                            mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                            b3 = true;
                        }
                        if(mario.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mario.position = new Vector2(mario.position.X + 3, mario.position.Y+4);
                        }
                        else
                        {
                            if(wait2 < 60)
                            {
                                mario.position = new Vector2(mario.position.X + 3, mario.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mario.isVisible = false;
                                myGame.keyboardController.keysEnabled = true;
                                b1 = b2 = b3 = false;
                                wait1 = wait2 = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                mario.position = new Vector2(mario.position.X, mario.position.Y + 4);
            }
        }
        private void bigAnimation()
        {
            if (!b1)
            {
                mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagBigMarioSprite();
                b1 = true;
            }
            if (mario.position.Y >= GameConstants.ScreenHeight - 164)
            {
                if (!b2)
                {
                    mario.gravity = 0;
                    mario.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagBigMarioSprite();
                    mario.position = new Vector2(mario.position.X + GameConstants.SquareWidth, mario.position.Y);
                    b2 = true;
                }
                else
                {
                    if (wait1 < 85)
                    {
                        wait1++;
                    }
                    if (wait1 == 85)
                    {
                        if (!b3)
                        {
                            mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                            b3 = true;
                        }
                        if (mario.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mario.position = new Vector2(mario.position.X + 3, mario.position.Y + 4);
                        }
                        else
                        {
                            if (wait2 < 60)
                            {
                                mario.position = new Vector2(mario.position.X + 3, mario.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mario.isVisible = false;
                                myGame.keyboardController.keysEnabled = true;
                                b1 = b2 = b3 = false;
                                wait1 = wait2 = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                mario.position = new Vector2(mario.position.X, mario.position.Y + 4);
            }
        }

        private void fireAnimation()
        {
            if (!b1)
            {
                mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagFireMarioSprite();
                b1 = true;
            }
            if (mario.position.Y >= GameConstants.ScreenHeight - 164)
            {
                if (!b2)
                {
                    mario.gravity = 0;
                    mario.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagFireMarioSprite();
                    mario.position = new Vector2(mario.position.X + GameConstants.SquareWidth, mario.position.Y);
                    b2 = true;
                }
                else
                {
                    if (wait1 < 85)
                    {
                        wait1++;
                    }
                    if (wait1 == 85)
                    {
                        if (!b3)
                        {
                            mario.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
                            b3 = true;
                        }
                        if (mario.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mario.position = new Vector2(mario.position.X + 3, mario.position.Y + 4);
                        }
                        else
                        {
                            if (wait2 < 60)
                            {
                                mario.position = new Vector2(mario.position.X + 3, mario.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mario.isVisible = false;
                                myGame.keyboardController.keysEnabled = true;
                                b1 = b2 = b3 = false;
                                wait1 = wait2 = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                mario.position = new Vector2(mario.position.X, mario.position.Y + 4);
            }
        }        
    }
}
