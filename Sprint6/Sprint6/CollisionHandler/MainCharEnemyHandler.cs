using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Sprint6.Sprites;
using Microsoft.Xna.Framework;
using Sprint6.Sound.MarioSound;

namespace Sprint6.CollisionHandler
{
    public static class MainCharEnemyHandler
    {
        public static void EnemyHandler(MainCharacter mainCharacter, IEnemy enemy, int CollisionSide)
        {
            int THREE = 3;
            int SIX = 6;
            Vector2 newPosition;
            if (!(enemy.enemySprite is GoombaFlippedSprite) && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaFlippedSprite))
            {
                switch (CollisionSide)
                {
                    case 1:
                        if (mainCharacter.HasStarPower)
                        {
                            enemy.BeFlipped();
                            //score
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score1;
                            mainCharacter.totalScore += mainCharacter.score;
                            Vector2 newP;
                            newP.X = mainCharacter.position.X;
                            newP.Y = mainCharacter.position.Y - THREE;
                            mainCharacter.textPosition = newP;
                        }
                        else
                        {
                            if(mainCharacter.state.Sprite.desRectangle.Bottom > enemy.enemySprite.desRectangle.Top)
                            {
                                mainCharacter.bounce = true;
                                MainCharSoundManager.instance.playSound(MainCharSoundManager.STOMP);
                                enemy.BeStomped();
                                if(!(enemy.shellDirection))
                                {
                                mainCharacter.isScored = true;
                                    mainCharacter.score = GameConstants.Score1;
                                    mainCharacter.totalScore += mainCharacter.score;
                                    Vector2 newP;
                                newP.X = mainCharacter.position.X;
                                newP.Y = mainCharacter.position.Y- THREE;
                                mainCharacter.textPosition = newP;
                                }
                                
                                
                            }
                            else if(enemy.enemySprite is KoopaStompedSprite)
                            {
                                if (enemy.shellDirection)
                                {
                                    mainCharacter.MarioGetHit();
                                }
                                else
                                {
                                    if (mainCharacter.marioDirection)
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
                        if (mainCharacter.HasStarPower)
                        {
                            enemy.BeFlipped();
                            //score
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mainCharacter.position.X;
                            newP.Y = mainCharacter.position.Y - THREE;
                            mainCharacter.textPosition = newP;
                        }
                        else
                        {
                            if(enemy.enemySprite is KoopaStompedSprite)
                            {
                               
                                if (enemy.shellDirection)
                                {
                                    mainCharacter.MarioGetHit();
                                }
                                else
                                {
                                    if (mainCharacter.position.X < enemy.position.X)
                                    {
                                        newPosition.X = mainCharacter.position.X -SIX;
                                        newPosition.Y = mainCharacter.position.Y;
                                        mainCharacter.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mainCharacter.position.X +SIX;
                                        newPosition.Y = mainCharacter.position.Y;
                                        mainCharacter.position = newPosition;
                                    }
                                    
                                    enemy.shellDirection = true;
                                enemy.shellMoving = GameConstants.Right;
                                }    
                            }
                            else
                            {
                                mainCharacter.MarioGetHit();
                            }
                         
                        }
                        break;
                    case 3:
                        if (mainCharacter.HasStarPower)
                        {
                            enemy.BeFlipped();
                            //score
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mainCharacter.position.X;
                            newP.Y = mainCharacter.position.Y - THREE;
                            mainCharacter.textPosition = newP;
                        }
                        else
                        {
                            mainCharacter.MarioGetHit();
                        }
                      
                        break;
                    case 4:
                        if (mainCharacter.HasStarPower)
                        {
                            
                            enemy.BeFlipped();
                            //score
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score1;
                            Vector2 newP;
                            newP.X = mainCharacter.position.X;
                            newP.Y = mainCharacter.position.Y - THREE;
                            mainCharacter.textPosition = newP;
                        }
                        else
                        {
                            if (enemy.enemySprite is KoopaStompedSprite)
                            {
                               
                                if (enemy.shellDirection)
                                {
                                    mainCharacter.MarioGetHit();
                                }
                                else
                                {
                                    MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                                    if (mainCharacter.position.X < enemy.position.X)
                                    {
                                        newPosition.X = mainCharacter.position.X -SIX;
                                        newPosition.Y = mainCharacter.position.Y;
                                        mainCharacter.position = newPosition;
                                    }
                                    else
                                    {
                                        newPosition.X = mainCharacter.position.X +SIX;
                                        newPosition.Y = mainCharacter.position.Y;
                                        mainCharacter.position = newPosition;
                                    }
                                    enemy.shellDirection = true;
                                    enemy.shellMoving = GameConstants.Left;
                                    
                                }
                            }
                            else
                            {
                                mainCharacter.MarioGetHit();
                            }

                        }
                        break;
                }
            }
        }
    }
}
