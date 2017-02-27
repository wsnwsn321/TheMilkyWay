using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;
using System.Diagnostics;

namespace SuperMarioGame.TestCase
{
    class TestBigMarioBrickBlockCollision
    {

        private static TestBigMarioBrickBlockCollision instance = new TestBigMarioBrickBlockCollision();
        private int BrickBlockWidthAndHeight = 32;
        private int failure = 0;
        public static TestBigMarioBrickBlockCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The BigMarioBrickBlockCollision testing has begun. Errors will be output to the console.");
            TestBrickBlockBottomCollision();
            TestBrickBlockTopCollision();
            TestBrickBlockLeftCollision();
            TestBrickBlockRightCollision();
            Debug.WriteLine("All BigMarioBrickBlockCollision test complete, " + failure + " failures occurred");

        }



        public void TestBrickBlockBottomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos - BrickBlockWidthAndHeight + 1;

            IBlock block = new BrickBlock(new Vector2(marioXpos, blockposition));
            MarioBlockHandler.BlockHandler(mario, block,3);
            mario.MarioJump();
            if (block.isVisible || marioYpos < ((blockposition + block.blockSprite.desRectangle.Height)-1))
            {
                Debug.WriteLine("BigMarioBrickBlockBottomCollision failed.");
                failure++;
            }    
         }

        public void TestBrickBlockTopCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioYpos + mario.state.marioSprite.desRectangle.Height-1;

            IBlock block = new BrickBlock(new Vector2(marioXpos, blockposition));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 1);
            mario.MarioCrouch();
            if (marioYpos > (blockposition - mario.state.marioSprite.desRectangle.Height)+1)
            {
                Debug.WriteLine("BigMarioBrickBlockTopCollision failed.");
                failure++;
            }
        }

        public void TestBrickBlockLeftCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int blockposition = marioXpos + mario.state.marioSprite.desRectangle.Width-1;

            IBlock block = new BrickBlock(new Vector2(blockposition, marioYpos));
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if (marioXpos > (blockposition - mario.state.marioSprite.desRectangle.Width)+1)
            {
                Debug.WriteLine("BigMarioBrickBlockLeftCollision failed.");
                failure++;
            }
        }

        public void TestBrickBlockRightCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            int blockposition = marioXpos - BrickBlockWidthAndHeight + 1;

            IBlock block = new BrickBlock(new Vector2(blockposition, marioYpos));

            // Make mario collide with the block
            MarioBlockHandler.BlockHandler(mario, block, 4);
            mario.MarioRun();
            if ( marioXpos < (blockposition - mario.state.marioSprite.desRectangle.Width)-1)
            {
                Debug.WriteLine("BigMarioBrickBlockRightCollision failed.");
                failure++;
            }
        }


    }
}
