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
                        newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y - mario.state.marioSprite.desRectangle.Height;
                        mario.position = newPosition;
                        break;
                    case 2: //right side collision
                        newPosition.X = block.blockSprite.desRectangle.X + block.blockSprite.desRectangle.Width;
                        newPosition.Y = mario.state.marioSprite.desRectangle.Y;
                        mario.position = newPosition;
                        break;
                    case 3: //bottom collision
                        newPosition.X = mario.state.marioSprite.desRectangle.X;
                        newPosition.Y = block.blockSprite.desRectangle.Y + block.blockSprite.desRectangle.Height;
                        mario.position = newPosition;
                        if (block is BrickBlock && mario.marioState != Mario.MARIO_SMALL)
                        {
                            block.isVisible = false;
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
                            myGame.level.itemElements.Add(new Coin(new Vector2(block.position.X+8, block.position.Y - 31)));                            
                        }
                        else if (block is HiddenBlock)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
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
