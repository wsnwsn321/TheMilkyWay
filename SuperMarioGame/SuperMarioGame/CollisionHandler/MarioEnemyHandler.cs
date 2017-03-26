using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy enemy, int CollisionSide)
        {
            //Vector2 newPosition;
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) /*&& !(enemy.enemySprite is KoopaStompedSprite)*/)
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
                            else if(enemy.enemySprite is KoopaStompedSprite)
                            {
                                if (enemy.shellDirection)
                                {
                                    enemy.shellDirection = false;
                                }
                                else
                                {
                                     if (mario.marioDirection)
                                    {
                                        enemy.shellDirection =true;
                                        enemy.shellMoving = 4;
                                    
                                    }
                                    else
                                       {
                                        enemy.shellDirection = true;
                                        enemy.shellMoving = 2;
                                        }
                                }
                              
                                //enemy.enemySprite.desRectangle;
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
                            if(enemy.enemySprite is KoopaStompedSprite)
                            {
                                //if (enemy.shellDirection)
                                //{
                                //    mario.MarioGetHit();
                                //}
                                //else
                                //{
                                enemy.shellDirection = true;
                                enemy.shellMoving = 2;
                                //}    
                            }
                            else
                            {
                                mario.MarioGetHit();
                            }
                         
                        }
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
                            if (enemy.enemySprite is KoopaStompedSprite)
                            {
                                //if (enemy.shellDirection)
                                //{
                                 //   mario.MarioGetHit();
                                //}
                                //else
                                //{
                                    enemy.shellDirection = true;
                                    enemy.shellMoving = 4;
                                //}
                            }
                            else
                            {
                                mario.MarioGetHit();
                            }

                        }
                        break;
                }
            }
        }
    }
}
