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
            if (myGame.level.fireBall.Count <= 1)
            {
                if (mario.marioState == ElementClasses.Mario.MARIO_FIRE)
                {
                    mario.Attack();
                    Fireball fball = new Fireball(new Vector2(mario.position.X, mario.position.Y + 25));
                    if (mario.state.marioSprite is RightAttackingMarioSprite)
                    {


                        myGame.level.fireBall.Add(fball);


                    }
                    else if (mario.state.marioSprite is LeftAttackingMarioSprite)
                    {

                        
                            fball.hDirection = !fball.hDirection;
                            myGame.level.fireBall.Add(fball);
                       


                    }
                }
            }
        }
    }
}
