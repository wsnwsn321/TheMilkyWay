using Microsoft.Xna.Framework;

namespace Sprint6.Commands
{
    class MarioCrouchCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;

        public MarioCrouchCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {
            if (mainCharacter.marioState != ElementClasses.MainCharacter.MARIO_DEAD && mainCharacter.canMove)
            {
                 mainCharacter.MarioCrouch();
                mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y);
            }

        }
    }
}
