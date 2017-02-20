namespace SuperMarioGame.Commands
{
    class MarioChangeFormCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        private int counter;
        public MarioChangeFormCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.mario;
            counter = 0;
        }

        public void Execute()
        {
            counter++;
            if (counter >= 10)
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
