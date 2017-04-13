using Microsoft.Xna.Framework;

namespace Sprint6.Commands
{
    class MarioRightCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;

        public MarioRightCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            if (mainCharacter.marioState != ElementClasses.MainCharacter.MARIO_DEAD && mainCharacter.canMove)
            {
                if (mainCharacter.marioDirection)
                {
                    mainCharacter.MarioIdle();
                    mainCharacter.MarioChangeDireciton();
                }
                if (mainCharacter.marioAction != ElementClasses.MainCharacter.MARIO_CROUCH)
                {
                    mainCharacter.MarioRun();
                    mainCharacter.position = new Vector2(mainCharacter.position.X + 3, mainCharacter.position.Y);
                }
            }             
        }
    }
}
