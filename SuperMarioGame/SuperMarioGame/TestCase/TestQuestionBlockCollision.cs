﻿using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;
using System.Diagnostics;

namespace SuperMarioGame.TestCase
{
    class TestQuestionBlockCollision
    {

        private static TestQuestionBlockCollision instance = new TestQuestionBlockCollision();
        private int QuestionBlockWidthAndHeight = 32;
        private int failure = 0;

        public static TestQuestionBlockCollision Instance
        {
            get
            {
                return instance;
            }
        }

        // Need Right, left, top, bottom collision for all block types
        // Also, need test cases for special cases, like small mario
        // trying to break a brick block. Only big mario forms can 
        // break a brick block.

        public void RunTests()
        {
            Debug.WriteLine("The QuestionBlockCollision testing has begun. Errors will be output to the console.");
            TestQuestionBlockBottomCollision();
            TestQuestionBlockTopCollision();
            TestQuestionBlockLeftCollision();
            TestQuestionBlockRightCollision();
            Debug.WriteLine("All UsedBlockCollision test complete, " + failure + " failures occurred");
        }



        public void TestQuestionBlockBottomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos - QuestionBlockWidthAndHeight ;

            IBlock block = new QuestionBlock(new Vector2(marioXpos, blockposition));

            // Make mario collide with the block  
            mario.MarioJump();
            MarioBlockHandler.BlockHandler(mario, block,3);
            if (!(block is UsedBlock) || marioYpos < (blockposition + block.blockSprite.desRectangle.Height))
            {
                Debug.WriteLine("MarioQuestionBlockBottomCollision failed.");
                failure++;
            }    
         }

        public void TestQuestionBlockTopCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos + mario.state.marioSprite.desRectangle.Height-1;

            IBlock block = new QuestionBlock(new Vector2(marioXpos, blockposition));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 1);
            mario.MarioCrouch();
            if (marioYpos > (blockposition - mario.state.marioSprite.desRectangle.Height)+1)
            {
                Debug.WriteLine("MarioQuestionBlockTopCollision failed.");
                failure++;
            }
        }

        public void TestQuestionBlockLeftCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioXpos + mario.state.marioSprite.desRectangle.Width-1;

            IBlock block = new QuestionBlock(new Vector2(blockposition, marioYpos));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if (marioXpos > (blockposition - mario.state.marioSprite.desRectangle.Width)+1)
            {
                Debug.WriteLine("MarioQuestionBlockLeftCollision failed.");
                failure++;
            }
        }

        public void TestQuestionBlockRightCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            int blockposition = marioXpos - QuestionBlockWidthAndHeight + 1;

            IBlock block = new QuestionBlock(new Vector2(blockposition, marioYpos));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if ( marioXpos < (blockposition + mario.state.marioSprite.desRectangle.Width)-1)
            {
                Debug.WriteLine("MarioQuestionBlockRightCollision failed.");
                failure++;
            }
        }


    }
}
