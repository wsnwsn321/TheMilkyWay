using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.ItemClass;
using Sprint6.Sprites.MarioSprite.FireMarioSprite;

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
            if (myGame.level.fireBallList.Count <= 1 && mainCharacter.canMove)
            {
                if (mainCharacter.marioState == ElementClasses.MainCharacter.MARIO_FIRE)
                {
                    mainCharacter.Attack();
                    Fireball fball = new Fireball(new Vector2(mainCharacter.position.X, mainCharacter.position.Y + TwentyFive));
                    if (mainCharacter.state.marioSprite is RightAttackingMarioSprite)
                    {


                        myGame.level.fireBallList.Add(fball);


                    }
                    else if (mainCharacter.state.marioSprite is LeftAttackingMarioSprite)
                    {

                        
                            fball.hDirection = !fball.hDirection;
                            myGame.level.fireBallList.Add(fball);
                       


                    }
                }
            }
        }
    }
}
