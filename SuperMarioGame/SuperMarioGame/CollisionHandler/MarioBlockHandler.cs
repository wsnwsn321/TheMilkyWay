
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    class MarioBlockHandler
    {
        private bool CollsionSide;
        private Mario mario;
        private IBlock brickBlock;
        public static void BlockHandler(Mario mario, IBlock brickBlock, bool CollsionSide)
        {
            // From Bottom
            if (CollsionSide) {
                
            }
            //Other Side
            else
            {

            }
        }
    }
}
