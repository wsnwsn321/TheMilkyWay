using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;
using System.Diagnostics;
using SuperMarioGame.SpriteFactories;

namespace SuperMarioGame.TestCase
{
    class TestHiddenBlockCollision
    {

        private static TestHiddenBlockCollision instance = new TestHiddenBlockCollision();
        private int HiddenBlockWidthAndHeight = 32;

        public static TestHiddenBlockCollision Instance
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
            Debug.WriteLine("The testing has begun. Errors will be output to the console.");
            TestHiddenBlockBottomCollision();
            TestHiddenBlockTopCollision();
            TestHiddenBlockLeftCollision();
            TestHiddenBlockRightCollision();

        }



        public void TestHiddenBlockBottomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos - HiddenBlockWidthAndHeight + 1;

            IBlock block = new HiddenBlock(new Vector2(marioXpos, blockposition));
            IBlock newBlock = new UsedBlock(new Vector2(marioXpos, blockposition));
            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block,3);
            mario.MarioJump();
            if (block.blockSprite != newBlock.blockSprite)
            {
                Debug.WriteLine("no trans.");
            }
            if (block.blockSprite != EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite() || marioYpos < ((blockposition + block.blockSprite.desRectangle.Height)-1))
            {
                Debug.WriteLine("MarioHiddenBlockBottomCollision failed.");
            }    
         }

        public void TestHiddenBlockTopCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos + mario.state.marioSprite.desRectangle.Height-1;

            IBlock block = new HiddenBlock(new Vector2(marioXpos, blockposition));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 1);
            mario.MarioCrouch();
            if (marioYpos > (blockposition - mario.state.marioSprite.desRectangle.Height)+1)
            {
                Debug.WriteLine("MarioHiddenBlockTopCollision failed.");
            }
        }

        public void TestHiddenBlockLeftCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioXpos + mario.state.marioSprite.desRectangle.Width-1;

            IBlock block = new HiddenBlock(new Vector2(blockposition, marioYpos));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if (marioXpos > (blockposition - mario.state.marioSprite.desRectangle.Width)+1)
            {
                Debug.WriteLine("MarioHiddenBlockLeftCollision failed.");
            }
        }

        public void TestHiddenBlockRightCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            int blockposition = marioXpos - HiddenBlockWidthAndHeight + 1;

            IBlock block = new HiddenBlock(new Vector2(blockposition, marioYpos));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if ( marioXpos < (blockposition - mario.state.marioSprite.desRectangle.Width)-1)
            {
                Debug.WriteLine("MarioHiddenBlockRightCollision failed.");
            }
        }


    }
}
