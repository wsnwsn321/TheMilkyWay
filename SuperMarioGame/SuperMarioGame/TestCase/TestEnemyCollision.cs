using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;
using System;
using System.Diagnostics;
using SuperMarioGame.ElementClasses.CharacterClass.Enemies;

namespace SuperMarioGame.TestCase
{
    class TestEnemyCollision
    {

        private static TestEnemyCollision instance = new TestEnemyCollision();

        public static TestEnemyCollision Instance
        {
            get
            {
                return instance;
            }
        }
        private int failure = 0;
        public void RunTests()
        {
            Debug.WriteLine("The EnemyCollision testing has begun. Errors will be output to the console.");
            TestGoombaTopCollision();
            TestGoombaBottomCollision();
            TestGoombaLeftCollision();
            TestGoombaRightCollision();
            TestKoopaTopCollision();
            TestKoopaLeftCollision();
            TestKoopaRightCollision();
            TestKoopaBottomCollision();
            Debug.WriteLine("All EnemyCollision test complete, " + failure + " failures occurred");
        }


        public void TestGoombaTopCollision()
        {
            int goombaXpos = 500;
            int goombaYpos = 100;
            Goomba goomba  = new Goomba(new Vector2(goombaXpos, goombaYpos));
            int marioXpos = 500;
            int marioYpos = 100 - SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite().desRectangle.Height;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int top = CollisionDetection.TOP;
            MarioEnemyHandler.EnemyHandler(mario, goomba, top);

            if (goomba.goombaAction != Goomba.GOOMBA_DEAD)
            {
                Debug.WriteLine("The MarioGoombaTopCollision test case failed.");
                failure++;
            }
          

        }
        public void TestGoombaLeftCollision()
        {
            int goombaXpos = 500;
            int goombaYpos = 100;
            Goomba goomba  = new Goomba(new Vector2(goombaXpos, goombaYpos));
            int marioXpos = 500 - SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite().desRectangle.Width;
            int marioYpos = 100;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            int left = CollisionDetection.LEFT;
            mario.MarioRun();
            MarioEnemyHandler.EnemyHandler(mario, goomba, left);

            if (mario.marioState != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("The MarioGoombaLeftCollision test case failed.");
                failure++;
            }
           
        }
        public void TestGoombaRightCollision()
        {
            int goombaXpos = 500;
            int goombaYpos = 100;
            Goomba goomba = new Goomba(new Vector2(goombaXpos, goombaYpos));
            int marioXpos = 500 + goomba.enemySprite.desRectangle.Width;
            int marioYpos = 100;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            int right = CollisionDetection.RIGHT;
            MarioEnemyHandler.EnemyHandler(mario, goomba, right);
            
            if (mario.marioState != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("The MarioGoombaRightCollision test case failed.");
                failure++;
            }
          
        }

        public void TestGoombaBottomCollision()
        {
            int goombaXpos = 500;
            int goombaYpos = 100;
            Goomba goomba = new Goomba(new Vector2(goombaXpos, goombaYpos));
            int marioXpos = 500;
            int marioYpos = 100 + goomba.enemySprite.desRectangle.Height;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int bottom = CollisionDetection.BOTTOM;
            MarioEnemyHandler.EnemyHandler(mario, goomba, bottom);

            if (mario.marioState != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("The MarioGoombaBottomCollision test case failed.");
                failure++;
            }
            

        }

        public void TestKoopaTopCollision()
        {
            int koopbaXpos = 500;
            int koopbaYpos = 100;
            Koopa koopba = new Koopa(new Vector2(koopbaXpos, koopbaYpos));
            int marioXpos = 500;
            int marioYpos = 100 - SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite().desRectangle.Height;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int top = CollisionDetection.TOP;
            MarioEnemyHandler.EnemyHandler(mario, koopba, top);

            if (koopba.koopaAction != Koopa.KOOPA_SHELL)
            {
                Debug.WriteLine("The MarioKoopaTopCollision test case failed.");
                failure++;
            }
           
        }

        public void TestKoopaLeftCollision()
        {
            int koopbaXpos = 500;
            int koopbaYpos = 100;
            Koopa koopba = new Koopa(new Vector2(koopbaXpos, koopbaYpos));
            int marioXpos = 550 - SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite().desRectangle.Width;
            int marioYpos = 100;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));

            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int left = CollisionDetection.LEFT;
            MarioEnemyHandler.EnemyHandler(mario, koopba, left);

            if (mario.marioState != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("The MarioKoopaLeftCollision test case failed.");
                failure++;
            }
            
        }

        public void TestKoopaRightCollision()
        {
            int koopbaXpos = 500;
            int koopbaYpos = 100;
            Koopa koopba = new Koopa(new Vector2(koopbaXpos, koopbaYpos));
            int marioXpos = 500 + koopba.enemySprite.desRectangle.Width;
            int marioYpos = 100;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int right = CollisionDetection.RIGHT;
            MarioEnemyHandler.EnemyHandler(mario, koopba, right);

            if (mario.marioState != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("The MarioKoopaRightCollision test case failed.");
                failure++;
            }
        }

        public void TestKoopaBottomCollision()
        {
            int koopbaXpos = 500;
            int koopbaYpos = 100;
            Koopa koopba = new Koopa(new Vector2(koopbaXpos, koopbaYpos));
            int marioXpos = 500;
            int marioYpos = 100 + koopba.enemySprite.desRectangle.Height;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int bottom = CollisionDetection.BOTTOM;
            MarioEnemyHandler.EnemyHandler(mario, koopba, bottom);

            if (mario.marioState != Mario.MARIO_DEAD)
            {
               
                Debug.WriteLine("The MarioKoopaBottomCollision test case failed.");
                failure++;
            } 
        }

    }
}
