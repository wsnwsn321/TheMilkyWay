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
        private ElementClasses.MainCharacter mainCharacter;
        private bool b1,b2,b3 = false;
        private int wait1,wait2 = 0;

        public MarioFlagpoleCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            if (mainCharacter.marioState == MainCharacter.MARIO_SMALL)
            {
                smallAnimation();
            }
            else if (mainCharacter.marioState == MainCharacter.MARIO_BIG)
            {
                bigAnimation();
            }
            else if (mainCharacter.marioState == MainCharacter.MARIO_FIRE)
            {
                fireAnimation();
            }
        }

        private void smallAnimation()
        {
            if (!b1)
            {
                mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagSmallMarioSprite();
                b1 = true;
            }
            if (mainCharacter.position.Y >= GameConstants.ScreenHeight - 132)
            {
                if (!b2)
                {
                    mainCharacter.gravity = 0;
                    mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagSmallMarioSprite();
                    mainCharacter.position = new Vector2(mainCharacter.position.X + GameConstants.SquareWidth, mainCharacter.position.Y);
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
                            mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                            b3 = true;
                        }
                        if(mainCharacter.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y+4);
                        }
                        else
                        {
                            if(wait2 < 60)
                            {
                                mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mainCharacter.isVisible = false;
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
                mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + 4);
            }
        }
        private void bigAnimation()
        {
            if (!b1)
            {
                mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagBigMarioSprite();
                b1 = true;
            }
            if (mainCharacter.position.Y >= GameConstants.ScreenHeight - 164)
            {
                if (!b2)
                {
                    mainCharacter.gravity = 0;
                    mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagBigMarioSprite();
                    mainCharacter.position = new Vector2(mainCharacter.position.X + GameConstants.SquareWidth, mainCharacter.position.Y);
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
                            mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                            b3 = true;
                        }
                        if (mainCharacter.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y + 4);
                        }
                        else
                        {
                            if (wait2 < 60)
                            {
                                mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mainCharacter.isVisible = false;
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
                mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + 4);
            }
        }

        private void fireAnimation()
        {
            if (!b1)
            {
                mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightFlagFireMarioSprite();
                b1 = true;
            }
            if (mainCharacter.position.Y >= GameConstants.ScreenHeight - 164)
            {
                if (!b2)
                {
                    mainCharacter.gravity = 0;
                    mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateLeftFlagFireMarioSprite();
                    mainCharacter.position = new Vector2(mainCharacter.position.X + GameConstants.SquareWidth, mainCharacter.position.Y);
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
                            mainCharacter.state.marioSprite = MarioSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
                            b3 = true;
                        }
                        if (mainCharacter.state.marioSprite.desRectangle.Bottom < GameConstants.ScreenHeight - 67)
                        {
                            mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y + 4);
                        }
                        else
                        {
                            if (wait2 < 60)
                            {
                                mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y);
                                wait2++;
                            }
                            else
                            {
                                mainCharacter.isVisible = false;
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
                mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y + 4);
            }
        }        
    }
}
