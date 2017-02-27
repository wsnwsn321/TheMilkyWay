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
    class TestRedMushroomCollision
    {
        private static TestRedMushroomCollision instance = new TestRedMushroomCollision();
        private int failure = 0;
        public static TestRedMushroomCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The MarioRedmushroomCollision testing has begun. Errors will be output to the console.");
            TestSmallMarioRedMushroomCollision();
            TestBigMarioRedMushroomCollision();
            TestFireMarioRedMushroomCollision();
            Debug.WriteLine("All MarioRedmushroomCollision test complete, " + failure + " failures occurred");

        }

        public void TestSmallMarioRedMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new RedMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible || mario.marioState != Mario.MARIO_BIG)
            {
                Debug.WriteLine("Small Mario moving up colliding with redmushroom failed.");
                failure++;
            }
        }

        public void TestBigMarioRedMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new RedMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible || mario.marioState != Mario.MARIO_BIG)
            {
                Debug.WriteLine("Big Mario collides with redmushroom failed.");
                failure++;
            }
        }

        public void TestFireMarioRedMushroomCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_FIRE, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem mushroom = new RedMushroom(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, mushroom, 3);
            mario.MarioJump();
            if (mushroom.isVisible || mario.marioState != Mario.MARIO_FIRE)
            {
                Debug.WriteLine("Fire Mario colldes with redmushroom failed.");
                failure++;
            }
        }
    }
}
