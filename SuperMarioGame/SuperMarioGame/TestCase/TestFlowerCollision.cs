using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.Sprites;
using SuperMarioGame.CollisionHandler;
using System.Diagnostics;
using SuperMarioGame.ElementClasses.ItemClass;

namespace SuperMarioGame.TestCase
{
    class TestFlowerCollision
    {
        private static TestFlowerCollision instance = new TestFlowerCollision();
        private int failure = 0;
        public static TestFlowerCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The MarioFlowerCollision testing has begun. Errors will be output to the console.");
            TestSmallMarioFlowerCollision();
            TestBigMarioFlowerCollision();
            TestFireMarioFlowerCollision();
            Debug.WriteLine("All MarioFlowerCollision test complete, " + failure + " failures occurred");

        }

        public void TestSmallMarioFlowerCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem flower = new Flower(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, flower, 3);
            mario.MarioJump();
            if (flower.isVisible || mario.marioState != Mario.MARIO_BIG)
            {
                Debug.WriteLine("Small Mario collides with Flower failed.");
                failure++;
            }
        }

        public void TestBigMarioFlowerCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem flower = new Flower(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, flower, 3);
            mario.MarioJump();
            if (flower.isVisible || mario.marioState != Mario.MARIO_FIRE)
            {
                Debug.WriteLine("Big Mario collides with Flower failed.");
                failure++;
            }
        }

        public void TestFireMarioFlowerCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_FIRE, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem flower = new Flower(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, flower, 3);
            mario.MarioJump();
            if (flower.isVisible || mario.marioState != Mario.MARIO_FIRE)
            {
                Debug.WriteLine("Fire Mario colldes with Flower failed.");
                failure++;
            }
        }
    }
}
