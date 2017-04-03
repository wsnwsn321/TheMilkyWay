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
            Vector2 newPosition;
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaFlippedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                        mario.bounce = true;
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                        }
                        else
                        {
                            if(mario.state.marioSprite.desRectangle.Bottom < enemy.enemySprite.desRectangle.Bottom)
                            {
                                enemy.BeStomped();
                                mario.isScored = true;
                                mario.score = 100;
                                Vector2 newP;
                                newP.X = mario.position.X;
                                newP.Y = mario.position.Y-3;
                                mario.textPosition = newP;
                                
                            }
                            else if(enemy.enemySprite is KoopaStompedSprite)
                            {
                                if (enemy.shellDirection)
                                {
                                    mario.MarioGetHit();
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
                                if (enemy.shellDirection)
                                {
                                    mario.MarioGetHit();
                                }
                                else
                                {
                                    if (mario.position.X < enemy.position.X)
                                    {
                                        newPosition.X = mario.position.X - 6;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mario.position.X + 6;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    
                                    enemy.shellDirection = true;
                                enemy.shellMoving = 2;
                                }    
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
                                if (enemy.shellDirection)
                                {
                                    mario.MarioGetHit();
                                }
                                else
                                {
                                    if (mario.position.X < enemy.position.X)
                                    {
                                        newPosition.X = mario.position.X - 6;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mario.position.X + 6;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    enemy.shellDirection = true;
                                    enemy.shellMoving = 4;
                                    
                                }
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
