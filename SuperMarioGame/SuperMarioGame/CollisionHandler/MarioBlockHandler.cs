using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.LevelLoading;
using SuperMarioGame.Sprites;
using System.Diagnostics;
using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioBlockHandler
    {
        public static void BlockHandler(Game1 game, Mario mario, IBlock block, int CollisionSide)
        {
            int SIXTEEN = 16;
            int SIX = 6;
            int THREE = 3;
            int THIRTYONE = 31;
            int EIGHT = 8;
            int TWELVE = 12;
            Vector2 newPosition;
            Game1 myGame = game;

            if (block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1: //top collision
                       
                        newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - mario.state.marioSprite.desRectangle.Height-SIX;
                        mario.position = newPosition;
                        break;
                    case 2: //right side collision
                        
                         newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                        mario.position = newPosition;
                        
                       
                        break;
                    case 3: //bottom collision
                        mario.jump = false;
                        newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height+THREE;
                        mario.position = newPosition;
                        if (block is BrickBlock && block.blockSprite is BrickBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.BUMP);
                            if (mario.marioState != Mario.MARIO_SMALL)
                            {
                                MarioSoundManager.instance.playSound(MarioSoundManager.BREAKBLOCK);
                                block.Bump();
                                block.isVisible = false;
                                BlockPiece block1 = new BlockPiece(new Vector2(block.position.X, block.position.Y), GameConstants.BlockPieceOne);
                                BlockPiece block2 = new BlockPiece(new Vector2(block.position.X, block.position.Y +SIXTEEN), GameConstants.BlockPieceTwo);
                                BlockPiece block3 = new BlockPiece(new Vector2(block.position.X +SIXTEEN, block.position.Y), GameConstants.BlockPieceThree);
                                BlockPiece block4 = new BlockPiece(new Vector2(block.position.X +SIXTEEN, block.position.Y+SIXTEEN), GameConstants.BlockPieceFour);
                                block1.gravity = 0;
                                block2.gravity = 0;
                                block3.gravity = 0;
                                block4.gravity = 0;
                                myGame.level.itemElements.Add(block1);
                                myGame.level.itemElements.Add(block2);
                                myGame.level.itemElements.Add(block3);
                                myGame.level.itemElements.Add(block4);
                            }
                            else
                            {
                                if (!block.isBumped)
                                {
                                    block.Bump();
                                }
                            }
                           
                        }
                        else if(block is BrickBlockC && block.blockSprite is BrickBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.COIN);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                            //score part
                            mario.isScored = true;
                            mario.score = GameConstants.Score2;
                            mario.coin += 1;
                            mario.totalScore += mario.score;
                            Vector2 newP;
                            newP.X = block.position.X+TWELVE;
                            newP.Y = block.position.Y -THREE;
                            mario.textPosition = newP;
                        }
                        else if (block is BrickBlockCC && block.blockSprite is BrickBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.COIN);
                            BrickBlockCC b = block as BrickBlockCC;
                            if (b.coinCount > 0)
                            {
                                b.Bump();
                                Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                                b.coinCount--;
                                //score part
                                mario.isScored = true;
                                mario.score = GameConstants.Score2;
                                mario.coin += 1;
                                mario.totalScore += mario.score;
                                Vector2 newP;
                                newP.X = b.blockSprite.desRectangle.X+TWELVE;
                                newP.Y = b.blockSprite.desRectangle.Y -THREE;
                                mario.textPosition = newP;
                            }
                            else
                            {
                                block.Bump();
                                block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                                Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                            }

                        }
                        else if (block is BrickBlockS && block.blockSprite is BrickBlockSprite)
                        {
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            myGame.level.itemElements.Add(new Star(new Vector2(block.position.X,block.position.Y-GameConstants.SquareWidth)));
                        }
                        else if (block is QuestionBlockM && block.blockSprite is QuestionBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.POWERUPAPPEARS);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            
                            if(mario.marioState == Mario.MARIO_SMALL)
                            {
                                myGame.level.itemElements.Add(new RedMushroom(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                            }
                            else if(mario.marioState == Mario.MARIO_BIG || mario.marioState == Mario.MARIO_FIRE)
                            {
                                myGame.level.itemElements.Add(new Flower(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                            }
                        }
                        else if (block is QuestionBlockC && block.blockSprite is QuestionBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.COIN);
                            block.Bump();
                            //score part
                            mario.isScored = true;
                            mario.score = GameConstants.Score2;
                            mario.coin += 1;
                            mario.totalScore += mario.score;
                            Vector2 newP;
                            newP.X = block.blockSprite.desRectangle.X + TWELVE;
                            newP.Y = block.blockSprite.desRectangle.Y -THREE;
                            mario.textPosition = newP;
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                            
                        }
                        else if (block is HiddenBlock && block.blockSprite is HiddenBlockSprite)
                        {
                            MarioSoundManager.instance.playSound(MarioSoundManager.POWERUPAPPEARS);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            myGame.level.itemElements.Add(new GreenMushroom(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                        }
                        break;
                    case 4: //left side collision
                        newPosition.X = block.blockSprite.desRectangle.X - mario.state.marioSprite.desRectangle.Width;
                        newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                        mario.position = newPosition;
                       
                         break;
                }
            }
        }
    }
}
