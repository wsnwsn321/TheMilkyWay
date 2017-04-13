using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.BackgroundClass;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;

namespace Sprint6.Commands
{
    class MarioGrowCommand : ICommand
    {
        private Game1 myGame;
        private Mario mario;
        Vector2 oldPos;
        private int wait1 = 0;
        bool changeOnce = true;
        bool firstPos = true;
        private int Ten =10;
        private int Twenty = 20;
        private int Thirty = 30;
        private int Forty = 40;


        public MarioGrowCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (firstPos)
            {
                oldPos = mario.position;
                firstPos = false;
            }
            myGame.keyboardController.keysEnabled = false;
            if (wait1 < Ten)
            {
                if (changeOnce)
                {
                    mario.state.ChangeForm(Mario.MARIO_BIG);
                    mario.MarioChangeForm(Mario.MARIO_BIG);
                    changeOnce = false;
                }
                if (wait1 == Ten-1)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if(wait1 < Twenty)
            {
                if (changeOnce)
                {
                    mario.position = oldPos;
                    mario.state.ChangeForm(Mario.MARIO_SMALL);
                    changeOnce = false;
                }
                if (wait1 == Twenty-1)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if (wait1 < Thirty)
            {
                if (changeOnce)
                {
                    mario.state.ChangeForm(Mario.MARIO_BIG);
                    mario.MarioChangeForm(Mario.MARIO_BIG);
                    changeOnce = false;
                }
                if (wait1 == Thirty-1)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if (wait1 < Forty)
            {
                if (changeOnce)
                {
                    mario.position = oldPos;
                    mario.state.ChangeForm(Mario.MARIO_SMALL);
                    changeOnce = false;
                }
                wait1++;
            }
            else
            {
                wait1 = 0;
                myGame.keyboardController.keysEnabled = true;
                mario.animated = false;
                firstPos = true;
                changeOnce = true;
                mario.state.ChangeForm(Mario.MARIO_BIG);
                mario.MarioChangeForm(Mario.MARIO_BIG);
            }
        }
    }
}
