using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.Sprites.MarioSprite.FireMarioSprite;

namespace SuperMarioGame.Commands
{
    class MarioAttackCommand : ICommand
    {
        private Game1 myGame;
        private ElementClasses.Mario mario;

        public MarioAttackCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (mario.marioState == ElementClasses.Mario.MARIO_FIRE)
            {
                mario.Attack();
                Fireball fball = new Fireball(new Vector2(mario.position.X, mario.position.Y + 13));
                if (mario.state.marioSprite is RightAttackingMarioSprite)
                {
                    myGame.level.itemElements.Add(fball);
                }
                else if(mario.state.marioSprite is LeftAttackingMarioSprite)
                {
                    fball.changeDirection = !fball.changeDirection;
                    myGame.level.itemElements.Add(fball);                
                }
            }
        }
    }
}
