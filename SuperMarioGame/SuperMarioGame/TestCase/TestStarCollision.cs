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
    class TestStarCollision
    {
        private static TestStarCollision instance = new TestStarCollision();
        private int failure = 0;
        public static TestStarCollision Instance
        {
            get
            {
                return instance;
            }
        }
        public void RunTests()
        {
            Debug.WriteLine("The MarioStarCollision testing has begun. Errors will be output to the console.");
            TestSmallMarioStarCollision();
            TestBigMarioStarCollision();
            TestFireMarioStarCollision();
            Debug.WriteLine("All MarioStarCollision test complete, " + failure + " failures occurred");

        }

        public void TestSmallMarioStarCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_SMALL, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem Star = new Star(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, Star, 3);
            mario.MarioJump();
            if (Star.isVisible || !mario.IsInvincible||!mario.HasStarPower)
            {
                Debug.WriteLine("Small Mario collides with Star failed.");
                failure++;
            }
        }

        public void TestBigMarioStarCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_BIG, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem Star = new Star(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, Star, 3);
            mario.MarioJump();
            if (Star.isVisible || !mario.IsInvincible || !mario.HasStarPower)
            {
                Debug.WriteLine("Big Mario collides with Star failed.");
                failure++;
            }
        }

        public void TestFireMarioStarCollision()
        {
            int marioXpos = 400;
            int marioYpos = 400;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos), Mario.MARIO_FIRE, false);
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

            IItem Star = new Star(new Vector2(marioXpos, marioYpos));
            MarioItemHandler.ItemHandler(mario, Star, 3);
            mario.MarioJump();
            if (Star.isVisible || !mario.IsInvincible || !mario.HasStarPower)
            {
                Debug.WriteLine("Fire Mario colldes with Star failed.");
                failure++;
            }
        }
    }
}
