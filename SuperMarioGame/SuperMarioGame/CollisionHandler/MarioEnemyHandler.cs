using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioEnemyHandler
    {
        public static void EnemyHandler(Mario mario, IEnemy enemy, int CollisionSide)
        {
            int THREE = 3;
            int SIX = 6;
            Vector2 newPosition;
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaFlippedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                            //score
                            mario.isScored = true;
                            mario.score = GameConstants.Score1;
                            mario.totalScore += mario.score;
                            Vector2 newP;
                            newP.X = mario.position.X;
                            newP.Y = mario.position.Y - THREE;
                            mario.textPosition = newP;
                        }
                        else
                        {
                            if(mario.state.marioSprite.desRectangle.Bottom > enemy.enemySprite.desRectangle.Top)
                            {
                                mario.bounce = true;
                                MarioSoundManager.instance.playSound(MarioSoundManager.STOMP);
                                enemy.BeStomped();
                                if(!(enemy.shellDirection))
                                {
                                mario.isScored = true;
                                    mario.score = GameConstants.Score1;
                                    mario.totalScore += mario.score;
                                    Vector2 newP;
                                newP.X = mario.position.X;
                                newP.Y = mario.position.Y- THREE;
                                mario.textPosition = newP;
                                }
                                
                                
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
                                        enemy.shellMoving = GameConstants.Left;
                                    
                                    }
                                    else
                                       {
                                        enemy.shellDirection = true;
                                        enemy.shellMoving = GameConstants.Right;
                                        }
                                }                              
                            }
                        }
                        break;
                    case 2:
                        if (mario.HasStarPower)
                        {
                            enemy.BeFlipped();
                            //score
                            mario.isScored = true;
                            mario.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mario.position.X;
                            newP.Y = mario.position.Y - THREE;
                            mario.textPosition = newP;
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
                                        newPosition.X = mario.position.X -SIX;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mario.position.X +SIX;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    
                                    enemy.shellDirection = true;
                                enemy.shellMoving = GameConstants.Right;
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
                            //score
                            mario.isScored = true;
                            mario.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mario.position.X;
                            newP.Y = mario.position.Y - THREE;
                            mario.textPosition = newP;
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
                            //score
                            mario.isScored = true;
                            mario.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mario.position.X;
                            newP.Y = mario.position.Y - THREE;
                            mario.textPosition = newP;
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
                                    MarioSoundManager.instance.playSound(MarioSoundManager.KICK);
                                    if (mario.position.X < enemy.position.X)
                                    {
                                        newPosition.X = mario.position.X -SIX;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mario.position.X +SIX;
                                        newPosition.Y = mario.position.Y;
                                        mario.position = newPosition;
                                    }
                                    enemy.shellDirection = true;
                                    enemy.shellMoving = GameConstants.Left;
                                    
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
