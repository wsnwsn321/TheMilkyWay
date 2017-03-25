using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy enemy, int CollisionSide)
        {
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaStompedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                        }
                        else
                        {
                            if(mario.state.marioSprite.desRectangle.Bottom < enemy.enemySprite.desRectangle.Bottom)
                            {
                                enemy.BeStomped();
                            }
                        }
                        break;
                    case 2:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                        }
                        else
                        {
                            mario.MarioGetHit();
                        }
                        mario.MarioGetHit();
                        break;
                    case 3:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                        }
                        else
                        {
                            mario.MarioGetHit();
                        }
                        mario.MarioGetHit();
                        break;
                    case 4:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                        }
                        else
                        {
                            mario.MarioGetHit();
                        }
                        break;
                }
            }
        }
    }
}
