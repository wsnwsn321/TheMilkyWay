namespace Sprint6.Commands
{
    class MarioChangeFormCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private int counter;
        private int TEN =10;
        public MarioChangeFormCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
            counter = 0;
        }

        public void Execute()
        {
            if (mario.canMove)
            {
                counter++;
                if (counter >= TEN)
                {
                    switch (mario.marioState)
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
                    counter = 0;
                }
            }
        }
    }
}
