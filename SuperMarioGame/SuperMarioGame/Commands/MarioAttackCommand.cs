using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.ElementClasses.ItemClass;

namespace SuperMarioGame.Commands
{
    class MarioAttackCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;
        KeyboardState OldState;

        public MarioAttackCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState == ElementClasses.Mario.MARIO_FIRE)
            {
                KeyboardState NewState = Keyboard.GetState();
                if (NewState.IsKeyDown(Keys.X) && OldState.IsKeyUp(Keys.X))
                {
                    mario.Attack();
                    myGame.level.itemElements.Add(new Fireball(new Vector2(mario.position.X, mario.position.Y+10)));
                }
                OldState = NewState;
            }
        }
    }
}
