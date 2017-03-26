using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.LevelLoading;
using SuperMarioGame.Sprites;
using System.Diagnostics;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioBlockHandler
    {
        public static void BlockHandler(Game1 game, Mario mario, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
            Game1 myGame = game;

            if (block.isVisible)
            {
                switch (CollisionSide)
                {
                    case 1: //top collision
                        if (!(block is HiddenBlock))
                        {
                         newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - mario.state.marioSprite.desRectangle.Height-2;
                        mario.position = newPosition;
                        }
                        //mario.gravity = 0;
                        break;
                    case 2: //right side collision
                        if (!(block is HiddenBlock))
                        {
                         newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                        mario.position = newPosition;
                        }
                       
                        break;
                    case 3: //bottom collision
                        
                        mario.jump = false;
                        newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height+3;
                        mario.position = newPosition;
                        if (block is BrickBlock && block.blockSprite is BrickBlockSprite && mario.marioState != Mario.MARIO_SMALL)
                        {
                            block.isVisible = false;
                            //block.isBroken = true;
                            //block.blockSprite = EnvironmentSpriteFactory.Instance.CreateBlockPiece2Sprite();
                            BlockPiece block1 = new BlockPiece(new Vector2(block.position.X, block.position.Y),1);
                          
                            BlockPiece block2 = new BlockPiece(new Vector2(block.position.X, block.position.Y+16), 2);
                            BlockPiece block3 = new BlockPiece(new Vector2(block.position.X+16, block.position.Y), 3);
                            BlockPiece block4 = new BlockPiece(new Vector2(block.position.X+16, block.position.Y+16), 4);
                              block1.gravity = 0;
                            block2.gravity = 0;
                            block3.gravity = 0;
                            block4.gravity = 0;
                            myGame.level.itemElements.Add(block1);
                            myGame.level.itemElements.Add(block2);
                            myGame.level.itemElements.Add(block3);
                            myGame.level.itemElements.Add(block4);
                        }
                        else if(block is BrickBlockC && block.blockSprite is BrickBlockSprite)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + 8, block.position.Y - 31));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                        }
                        else if (block is BrickBlockCC && block.blockSprite is BrickBlockSprite)
                        {
                            BrickBlockCC b = block as BrickBlockCC;
                            if (b.coinCount > 0)
                            {
                                Coin c = new Coin(new Vector2(block.position.X + 8, block.position.Y - 31));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                                b.coinCount--;
                            }
                            else
                            {
                                block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                                Coin c = new Coin(new Vector2(block.position.X + 8, block.position.Y - 31));
                                c.jump = true;
                                myGame.level.itemElements.Add(c);
                            }

                        }
                        else if (block is BrickBlockS && block.blockSprite is BrickBlockSprite)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            myGame.level.itemElements.Add(new Star(new Vector2(block.position.X,block.position.Y-32)));
                        }
                        else if (block is QuestionBlockM && block.blockSprite is QuestionBlockSprite)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            
                            if(mario.marioState == 2)
                            {
                                myGame.level.itemElements.Add(new RedMushroom(new Vector2(block.position.X, block.position.Y - 32)));
                                //IItem redMushroom = myGame.level.itemElements[myGame.level.itemElements.Count - 1];
                            }
                            else if(mario.marioState == 3 || mario.marioState == 4)
                            {
                                myGame.level.itemElements.Add(new Flower(new Vector2(block.position.X, block.position.Y - 32)));
                                //IItem flower = myGame.level.itemElements[myGame.level.itemElements.Count - 1];
                            }
                        }
                        else if (block is QuestionBlockC && block.blockSprite is QuestionBlockSprite)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            Coin c = new Coin(new Vector2(block.position.X + 8, block.position.Y - 31));
                            c.jump = true;
                            myGame.level.itemElements.Add(c);
                        }
                        else if (block is HiddenBlock && block.blockSprite is HiddenBlockSprite)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
                            myGame.level.itemElements.Add(new GreenMushroom(new Vector2(block.position.X, block.position.Y - 32)));
                        }
                        break;
                    case 4: //left side collision
                        if (!(block is HiddenBlock))
                        {
                        newPosition.X = block.blockSprite.desRectangle.X - mario.state.marioSprite.desRectangle.Width;
                        newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                        mario.position = newPosition;
                       
                        }
                         break;
                }
            }
        }
    }
}
