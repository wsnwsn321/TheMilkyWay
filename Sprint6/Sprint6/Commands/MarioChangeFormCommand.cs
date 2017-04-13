namespace Sprint6.Commands
{
    class MarioChangeFormCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        private int counter;
        private int TEN =10;
        public MarioChangeFormCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
            counter = 0;
        }

        public void Execute()
        {
            if (mainCharacter.canMove)
            {
                counter++;
                if (counter >= TEN)
                {
                    switch (mainCharacter.marioState)
                    {
                        case ElementClasses.MainCharacter.MARIO_SMALL:
                            mainCharacter.MarioChangeForm(ElementClasses.MainCharacter.MARIO_BIG);
                            break;
                        case ElementClasses.MainCharacter.MARIO_BIG:
                            mainCharacter.MarioChangeForm(ElementClasses.MainCharacter.MARIO_FIRE);
                            break;
                        case ElementClasses.MainCharacter.MARIO_FIRE:
                            mainCharacter.MarioChangeForm(ElementClasses.MainCharacter.MARIO_SMALL);
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
