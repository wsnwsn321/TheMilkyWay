using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Commands
{
    class MarioChangeFormCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        public MarioChangeFormCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
        }

        public void Execute()
        {
            switch(mario.marioState)
            {
                case ElementClasses.Mario.MARIO_SMALL:
                    mario.MarioChangeForm(ElementClasses.Mario.MARIO_BIG);
                    break;
                case ElementClasses.Mario.MARIO_BIG:
                    mario.MarioChangeForm(ElementClasses.Mario.MARIO_FIRE);
                    break;
                case ElementClasses.Mario.MARIO_FIRE:
                    mario.MarioChangeForm(ElementClasses.Mario.MARIO_SMALL);
                    break;
                default:
                    break;
            }
        }
    }
}
