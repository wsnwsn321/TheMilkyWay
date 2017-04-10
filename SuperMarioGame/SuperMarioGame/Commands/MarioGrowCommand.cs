using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.BackgroundClass;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.Sound.MarioSound;
using SuperMarioGame.SpriteFactories;

namespace SuperMarioGame.Commands
{
    class MarioGrowCommand : ICommand
    {
        private Game1 myGame;
        private Mario mario;
        Vector2 oldPos;
        private int wait1 = 0;
        bool changeOnce = true;
        bool firstPos = true;
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
            if (wait1 < 10)
            {
                if (changeOnce)
                {
                    mario.state.ChangeForm(Mario.MARIO_BIG);
                    mario.MarioChangeForm(Mario.MARIO_BIG);
                    changeOnce = false;
                }
                if (wait1 == 9)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if(wait1 < 20)
            {
                if (changeOnce)
                {
                    mario.position = oldPos;
                    mario.state.ChangeForm(Mario.MARIO_SMALL);
                    changeOnce = false;
                }
                if (wait1 == 19)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if (wait1 < 30)
            {
                if (changeOnce)
                {
                    mario.state.ChangeForm(Mario.MARIO_BIG);
                    mario.MarioChangeForm(Mario.MARIO_BIG);
                    changeOnce = false;
                }
                if (wait1 == 29)
                {
                    changeOnce = true;
                }
                wait1++;
            }
            else if (wait1 < 40)
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
