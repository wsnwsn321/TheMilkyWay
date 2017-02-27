using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;
using System.Diagnostics;

namespace SuperMarioGame.TestCase
{
    class TestUsedBlockCollision
    {

        private static TestUsedBlockCollision instance = new TestUsedBlockCollision();
        private int UsedBlockWidthAndHeight = 32;
        private int failure = 0;
        public static TestUsedBlockCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The UsedBlockCollision testing has begun. Errors will be output to the console.");
            TestUsedBlockBottomCollision();
            TestUsedBlockTopCollision();
            TestUsedBlockLeftCollision();
            TestUsedBlockRightCollision();
            Debug.WriteLine("All UsedBlockCollision test complete, "+ failure+ " failures occurred");
        }



        public void TestUsedBlockBottomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos - UsedBlockWidthAndHeight + 1;

            IBlock block = new UsedBlock(new Vector2(marioXpos, blockposition));
            MarioBlockHandler.BlockHandler(mario, block, 3);
            mario.MarioJump();
            if (marioYpos < ((blockposition + block.blockSprite.desRectangle.Height) - 1))
            {
                Debug.WriteLine("MarioUsedBlockBottomCollision failed.");
                failure++;
            }
        }

        public void TestUsedBlockTopCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos + mario.state.marioSprite.desRectangle.Height - 1;

            IBlock block = new UsedBlock(new Vector2(marioXpos, blockposition));
            MarioBlockHandler.BlockHandler(mario, block, 1);
            mario.MarioCrouch();
            if (marioYpos > (blockposition - mario.state.marioSprite.desRectangle.Height) + 1)
            {
                Debug.WriteLine("MarioUsedBlockTopCollision failed.");
                failure++;
            }
        }

        public void TestUsedBlockLeftCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioXpos + mario.state.marioSprite.desRectangle.Width - 1;

            IBlock block = new UsedBlock(new Vector2(blockposition, marioYpos));
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if (marioXpos > (blockposition - mario.state.marioSprite.desRectangle.Width) + 1)
            {
                Debug.WriteLine("MarioUsedBlockLeftCollision failed.");
                failure++;
            }
        }

        public void TestUsedBlockRightCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            int blockposition = marioXpos - UsedBlockWidthAndHeight + 1;

            IBlock block = new UsedBlock(new Vector2(blockposition, marioYpos));
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if (marioXpos < (blockposition - mario.state.marioSprite.desRectangle.Width)-1)
            {
                Debug.WriteLine("MarioUsedBlockarioBlockRightCollision failed.");
                failure++;
            }
        }




    }
}
