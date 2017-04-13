using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.ItemClass;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.Commands
{
    class MarioAttackCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        int  TwentyFive = 25;

        public MarioAttackCommand(Game1 game)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
        }

        public void Execute()
        {

        }
    }
}
