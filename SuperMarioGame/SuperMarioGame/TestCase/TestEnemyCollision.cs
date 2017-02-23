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

        // Need Right, left, top, bottom collision for all block types
        // Also, need test cases for special cases, like small mario
        // trying to break a brick block. Only big mario forms can 
        // break a brick block.

        public void RunTests()
        {
            Debug.WriteLine("The testing has begun. Errors will be output to the console.");
            TestGoombaTopCollision();
            TestGoombaBottomCollision();
            TestGoombaLeftCollision();
            TestGoombaRightCollision();
            TestKoopaTopCollision();
            TestKoopaLeftCollision();
            TestKoopaRightCollision();
            TestKoopaBottomCollision();
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
                Debug.WriteLine("MarioGoombaTopCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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
            MarioEnemyHandler.EnemyHandler(mario, goomba, left);
            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioGoombaLeftCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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
            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioGoombaRightCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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

            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioGoombaBottomCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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
                Debug.WriteLine("MarioKoopaTopCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
            }
        }

        public void TestKoopaLeftCollision()
        {
            int koopbaXpos = 500;
            int koopbaYpos = 100;
            Koopa koopba = new Koopa(new Vector2(koopbaXpos, koopbaYpos));
            int marioXpos = 500 - SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite().desRectangle.Width;
            int marioYpos = 100;
            Mario mario = new Mario(new Vector2(marioXpos, marioYpos));
            mario.state.marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
            int left = CollisionDetection.LEFT;
            MarioEnemyHandler.EnemyHandler(mario, koopba, left);

            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioKoopaLeftCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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

            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioKoopaRightCollision failed.");
            }
            else
            {
                Debug.WriteLine("Success");
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

            if (mario.marioAction != Mario.MARIO_DEAD)
            {
                Debug.WriteLine("MarioKoopaBottomCollision failed.");
            }else
            {
                Debug.WriteLine("Success");
            }
        }

    }
}
