using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;

namespace SuperMarioGame.TestCase
{
    class TestBlockCollision
    {
        // Need Right, left, top, bottom collision for all block types
        // Also, need test cases for special cases, like small mario
        // trying to break a brick block. Only big mario forms can 
        // break a brick block.
        public void TestQuestionBlockBottomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            int blockposition = marioYpos - mario.state.marioSprite.desRectangle.Height;

            IBlock block = new QuestionBlock(new Vector2(marioXpos, blockposition));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block,3);

            if (block.isVisible || !(block is UsedBlock) || marioYpos > (blockposition + block.position.Y))
            {
                Console.WriteLine("MarioBlockBottomCollision failed.");
            }

            
         }

        
    }
}
