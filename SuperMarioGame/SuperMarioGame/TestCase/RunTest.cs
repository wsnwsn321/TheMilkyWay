﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.TestCase
{
    class RunTest
    {
        private static RunTest instance = new RunTest();
        public static RunTest Instance
        {
            get
            {
                return instance;
            }
        }

        public void runAllTests()
        {
            TestCase.TestGroundBlockCollision.Instance.RunTests();
            TestCase.TestHiddenBlockCollision.Instance.RunTests();
            TestCase.TestQuestionBlockCollision.Instance.RunTests();
            TestCase.TestUsedBlockCollision.Instance.RunTests();
            TestCase.TestSmallMarioBrickBlockCollision.Instance.RunTests();
            TestCase.TestBigMarioBrickBlockCollision.Instance.RunTests();
            TestCase.TestEnemyCollision.Instance.RunTests();
            TestCase.TestFlowerCollision.Instance.RunTests();
            TestCase.TestStarCollision.Instance.RunTests();
            TestCase.TestRedMushroomCollision.Instance.RunTests();
            TestCase.TestGreenMushroomCollision.Instance.RunTests();
        }


    }
}
