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
        private ElementClasses.Mario mario;
        int  TwentyFive = 25;

        public MarioAttackCommand(Game1 game)
        {
            myGame = game;
            mario = myGame.level.mario;
        }

        public void Execute()
        {
            if (myGame.level.fireBallList.Count <= 1 && mario.canMove)
            {
                if (mario.marioState == ElementClasses.Mario.MARIO_FIRE)
                {
                    mario.Attack();
                    Fireball fball = new Fireball(new Vector2(mario.position.X, mario.position.Y + TwentyFive));
                    if (mario.state.marioSprite is RightAttackingMarioSprite)
                    {


                        myGame.level.fireBallList.Add(fball);


                    }
                    else if (mario.state.marioSprite is LeftAttackingMarioSprite)
                    {

                        
                            fball.hDirection = !fball.hDirection;
                            myGame.level.fireBallList.Add(fball);
                       


                    }
                }
            }
        }
    }
}
