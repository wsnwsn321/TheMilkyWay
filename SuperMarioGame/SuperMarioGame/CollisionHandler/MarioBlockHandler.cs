using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.SpriteFactories;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioBlockHandler
    {
        public static void BlockHandler(Mario mario, IBlock block, int CollisionSide)
        {
            Vector2 newPosition;
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
                        else if (block is QuestionBlock)
                        {
                            block.blockSprite = EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
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
