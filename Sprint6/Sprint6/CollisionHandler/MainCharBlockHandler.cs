using Microsoft.Xna.Framework;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses.EnvironmentClass;
using Sprint6.ElementClasses.ItemClass;
using Sprint6.Sound.MarioSound;
using Sprint6.SpriteFactories;
using Sprint6.Sprites;

namespace Sprint6.CollisionHandler
{
    public static class MainCharBlockHandler
    {
        public static void BlockHandler(Game1 game, MainCharacter mainCharacter, IBlock block, int CollisionSide)
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
                       
                        newPosition.X = mainCharacter.state.Sprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - mainCharacter.state.Sprite.desRectangle.Height-SIX;
                        mainCharacter.position = newPosition;
                        break;
                    case 2: //right side collision
                        
                         newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = mainCharacter.state.Sprite.desRectangle.Y;
                        mainCharacter.position = newPosition;
                        
                       
                        break;
                    case 3: //bottom collision
                        mainCharacter.jump = false;
                        newPosition.X = mainCharacter.state.Sprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height+THREE;
                        mainCharacter.position = newPosition;
                        if (block is BrickBlock && block.blockSprite is BrickBlockSprite)
                        {
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.BUMP);
                            if (mainCharacter.marioState != MainCharacter.MARIO_SMALL)
                            {
                                MainCharSoundManager.instance.playSound(MainCharSoundManager.BREAKBLOCK);
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
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.COIN);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                            //score part
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score2;
                            mainCharacter.coin += 1;
                            mainCharacter.totalScore += mainCharacter.score;
                            Vector2 newP;
                            newP.X = block.position.X+TWELVE;
                            newP.Y = block.position.Y -THREE;
                            mainCharacter.textPosition = newP;
                        }
                        else if (block is BrickBlockCC && block.blockSprite is BrickBlockSprite)
                        {
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.COIN);
                            BrickBlockCC b = block as BrickBlockCC;
                            if (b.coinCount > 0)
                            {
                                b.Bump();
                                Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                                b.coinCount--;
                                //score part
                                mainCharacter.isScored = true;
                                mainCharacter.score = GameConstants.Score2;
                                mainCharacter.coin += 1;
                                mainCharacter.totalScore += mainCharacter.score;
                                Vector2 newP;
                                newP.X = b.blockSprite.desRectangle.X+TWELVE;
                                newP.Y = b.blockSprite.desRectangle.Y -THREE;
                                mainCharacter.textPosition = newP;
                            }
                            else
                            {
                                block.Bump();
                                block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                                Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                                //score part
                                mainCharacter.isScored = true;
                                mainCharacter.score = GameConstants.Score2;
                                mainCharacter.coin += 1;
                                mainCharacter.totalScore += mainCharacter.score;
                                Vector2 newP;
                                newP.X = b.blockSprite.desRectangle.X + TWELVE;
                                newP.Y = b.blockSprite.desRectangle.Y - THREE;
                                mainCharacter.textPosition = newP;
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
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.POWERUPAPPEARS);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            
                            if(mainCharacter.marioState == MainCharacter.MARIO_SMALL)
                            {
                                myGame.level.itemElements.Add(new RedMushroom(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                            }
                            else if(mainCharacter.marioState == MainCharacter.MARIO_BIG || mainCharacter.marioState == MainCharacter.MARIO_FIRE)
                            {
                                myGame.level.itemElements.Add(new Flower(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                            }
                        }
                        else if (block is QuestionBlockC && block.blockSprite is QuestionBlockSprite)
                        {
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.COIN);
                            block.Bump();
                            //score part
                            mainCharacter.isScored = true;
                            mainCharacter.score = GameConstants.Score2;
                            mainCharacter.coin += 1;
                            mainCharacter.totalScore += mainCharacter.score;
                            Vector2 newP;
                            newP.X = block.blockSprite.desRectangle.X + TWELVE;
                            newP.Y = block.blockSprite.desRectangle.Y -THREE;
                            mainCharacter.textPosition = newP;
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + EIGHT, block.position.Y - THIRTYONE));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                            
                        }
                        else if (block is HiddenBlock && block.blockSprite is HiddenBlockSprite)
                        {
                            MainCharSoundManager.instance.playSound(MainCharSoundManager.POWERUPAPPEARS);
                            block.Bump();
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            myGame.level.itemElements.Add(new GreenMushroom(new Vector2(block.position.X, block.position.Y -GameConstants.SquareWidth)));
                        }
                        break;
                    case 4: //left side collision
                        if (block is Pipe)
                        {
                            Pipe tempPipe = block as Pipe;
                            if (tempPipe.size == GameConstants.UnderPipe && mainCharacter.position.Y > block.position.Y-GameConstants.Three+GameConstants.Two)
                            {
                                mainCharacter.animated = true;
                                mainCharacter.animation = GameConstants.UnderPipeAnimation;
                            }
                        }
                        newPosition.X = block.blockSprite.desRectangle.X - mainCharacter.state.Sprite.desRectangle.Width;
                        newPosition.Y = mainCharacter.state.Sprite.desRectangle.Y;
                        mainCharacter.position = newPosition;
                        break;
                }
            }
        }
    }
}
