using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.Commands
{
    class MarioAttackCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.MainCharacter mainCharacter;
        int  TwentyFive = 25;
        private bool bomb;

        public MarioAttackCommand(Game1 game, bool bomb)
        {
            myGame = game;
            mainCharacter = myGame.level.mainCharacter;
            this.bomb = bomb;
        }

        public void Execute()
        {
            myGame.level.mainCharacter.Attack(bomb);
        }
    }
}
