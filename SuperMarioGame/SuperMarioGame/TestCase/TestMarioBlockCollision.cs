using System.Collections.Generic;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;
using SuperMarioGame.ElementClasses.EnvironmentClass;
using SuperMarioGame.CollisionHandler;

namespace SuperMarioGame.TestCase
{
    class TestMarioBlockCollision
    {
        public void MarioBlockTopCollision()
        {
            bool isV = false;
            Mario mario = new Mario(new Vector2(400, 400), Mario.MARIO_SMALL, false);
            int blockposotion = 400-mario.state.marioSprite.desRectangle.Height;
            IBlock block = new QuestionBlock(new Vector2(400, blockposotion));
            MarioBlockHandler.BlockHandler(mario, block,3);
            if (isV != block.isVisible)
            {
                //test case not pass
            }
            if(!(block is UsedBlock))
            {
                //test case not pass
            }
            
         }

        
    }
}
