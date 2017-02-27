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
    class TestGreenMushroomCollision
    {
        private static TestGreenMushroomCollision instance = new TestGreenMushroomCollision();
        private int failure = 0;
        public static TestGreenMushroomCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The MarioGreenmushroomCollision testing has begun. Errors will be output to the console.");
            TestSmallMarioGreenMushroomCollision();
            TestBigMarioGreenMushroomCollision();
            TestFireMarioGreenMushroomCollision();
            Debug.WriteLine("All MarioGreenmushroomCollision test complete, " + failure + " failures occurGreen");

        }

        public void TestSmallMarioGreenMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new GreenMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible)
            {
                Debug.WriteLine("Small Mario collides with Greenmushroom failed.");
                failure++;
            }
        }

        public void TestBigMarioGreenMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new GreenMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible)
            {
                Debug.WriteLine("Big Mario collides with Greenmushroom failed.");
                failure++;
            }
        }

        public void TestFireMarioGreenMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_FIRE, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new GreenMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible)
            {
                Debug.WriteLine("Fire Mario colldes with Greenmushroom failed.");
                failure++;
            }
        }
    }
}
